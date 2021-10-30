using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using BusinessLayer.Services;
using Models.Classes;
using Timer = System.Windows.Forms.Timer;

namespace RssApplication
{
    public partial class Form : System.Windows.Forms.Form
    {
        FeedService feedService;
        CategoryService categoryService;
        EpisodeService episodeService;

        public Form()
        {
            InitializeComponent();
            feedService = new FeedService();
            categoryService = new CategoryService();
            episodeService = new EpisodeService();

            FillComboboxes();
            cbSubscribeCategory.Items.Add("Historia");
            cbSubscribeCategory.Items.Add("Humor");
            tbUrl.ReadOnly = false;
            lblType.Visible = true;
            cbType.Visible = true;

            DisplaySubscribeListAsync();
            InputCategoryListAsync();
            timer.Interval = 30000;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void FillComboboxes()
        {
            cbTime.Items.Add("1");
            cbTime.Items.Add("15");
            cbTime.Items.Add("30");
            cbType.Items.Add("Nyhet");
            cbType.Items.Add("Podcast");
        }
        private async void DisplaySubscribeListAsync()
        {

            lvSubscribe.Items.Clear();
            List<Feed> listOfFeeds = await feedService.GetListOfFeedsAsync();

            foreach (Feed item in listOfFeeds)
            {
                String[] row = {
                item.FileName,
                Convert.ToString(item.NumberOfEpisodes),
                item.Name,
                Convert.ToString(item.TimeInterval),
                item.Category};

                ListViewItem List = new ListViewItem(row);
                lvSubscribe.Items.Add(List);
            }

            //DisplaySubscribeList(listOfFeeds);
        }

        public void DisplaySubscribeList(List<Feed> listOfFeeds)
        {
            lvSubscribe.Items.Clear();

            foreach (Feed item in listOfFeeds)
            {
                String[] row = {
                    item.FileName,
                    Convert.ToString(item.NumberOfEpisodes),
                    item.Name,
                    Convert.ToString(item.TimeInterval),
                    item.Category};

                ListViewItem List = new ListViewItem(row);
                lvSubscribe.Items.Add(List);
            }

        }

        private void DisplayEpisodeList(Feed feedObject)
        {

            lbEpisode.Items.Clear();

            List<Episode> episodeList = null;
            episodeList = new List<Episode>();

            episodeList = feedObject.ListOfEpisodes;

            foreach (Episode episode in episodeList)
            {
                lbEpisode.Items.Add(episode.Title);

            }


        }



        private async void btnSubcribeAdd_Click(object sender, EventArgs e)
        {
            if (Validator.TextBoxIsPresent(tbUrl) && 
                Validator.TextBoxIsPresent(tbSubscribeName) &&
                Validator.ComboBoxIsPresent(cbTime) &&
                Validator.ComboBoxIsPresent(cbSubscribeCategory) &&
                Validator.ComboBoxIsPresent(cbType))
            { 
                string url = tbUrl.Text;
                string name = tbSubscribeName.Text;
                int timeInterval = Convert.ToInt32(cbTime.SelectedItem);
                string category = Convert.ToString(cbSubscribeCategory.SelectedItem);
                string type = Convert.ToString(cbType.SelectedItem);

                await feedService.CreateFeedAsync(url, name, timeInterval, category, type);

                DisplaySubscribeListAsync();
            }
            else
            {
                lblSubcribeMsg.Text = "fyll";
            }
        }

        private async void btnSubscribeChange_Click(object sender, EventArgs e)
        {
            if (Validator.TextBoxIsPresent(tbSubscribeName) &&
                Validator.ComboBoxIsPresent(cbTime) &&
                Validator.ComboBoxIsPresent(cbSubscribeCategory))
            {
                
                string fileName = "";
                var selectedRow = lvSubscribe.SelectedItems;

                foreach (ListViewItem item in selectedRow)
                {
                    //Hämtar filnamnet från kolumnen som är hidden
                    fileName = item.SubItems[0].Text;
                }

                string name = tbSubscribeName.Text;
                int timeInterval = Convert.ToInt32(cbTime.SelectedItem);
                string category = Convert.ToString(cbSubscribeCategory.SelectedItem);

                await feedService.ChangeFeedAsync(name, timeInterval, category, fileName);

                DisplaySubscribeListAsync();
                
            }
            else
            {
                lblSubcribeMsg.Text = "Obligatoriska fält saknas";
            }

        }


        private async void lvSubscribe_SelectedIndexChanged(object sender, EventArgs e)
        {

            if(lvSubscribe.SelectedItems.Count > 0)
            {
                string fileName = "";
                var selectedRow = this.lvSubscribe.SelectedItems;

                foreach (ListViewItem item in selectedRow)
                {
                    //Hämtar filnamnet från kolumnen som är hidden
                    fileName = item.SubItems[0].Text;
                }

                Feed feedObject = await feedService.GetFeedAsync(fileName);
                tbUrl.Text = feedObject.Url;
                    
                tbSubscribeName.Text = feedObject.Name;
                cbTime.Text = Convert.ToString(feedObject.TimeInterval);
                cbSubscribeCategory.Text = feedObject.Category;

                tbUrl.ReadOnly = true;
                lblType.Visible = false;
                cbType.Visible = false;

                DisplayEpisodeList(feedObject);
            }
        }

        private async void btnCategoryAdd_Click(object sender, EventArgs e)
        {
            bool exist = false;
            string name = tbCategoryName.Text;
            string nameFirst = name.Substring(0, 1).ToUpperInvariant();
            string nameLast = name.Substring(1).ToLowerInvariant();

            List<string> categoryNames = new List<string>();
            categoryNames = await categoryService.InputCategoryAsync();

            foreach (string categoryName in categoryNames)
            {
                if (categoryName.Equals(nameFirst + nameLast))
                {
                    exist = true;
                }
            }
            if (exist == false)
            {
                await categoryService.CreateAsync(nameFirst + nameLast);

                InputCategoryListAsync();
                tbCategoryName.Text = "";
            }
            else
            {
                lblCategoryMsg.Text = "Denna kategori finns redan!";
            }
        }

        private async void InputCategoryListAsync()
        {
            cbSubscribeCategory.Items.Clear();
            lbCategory.Items.Clear();

            List<string> categoryNames = new List<string>();
            categoryNames = await categoryService.InputCategoryAsync();
            if (categoryNames.Count != 0)
            {
                foreach (string catagoryName in categoryNames)
                {
                    cbSubscribeCategory.Items.Add(catagoryName);
                    lbCategory.Items.Add(catagoryName);
                }
            }
        }

        private async void btnCategoryChange_Click(object sender, EventArgs e)
        {
            try
            {
                bool newCategoryExist = false;
                string newCategoryName = tbCategoryName.Text;
                string newCategoryNameFirst = newCategoryName.Substring(0, 1).ToUpperInvariant();
                string newCategoryNameLast = newCategoryName.Substring(1).ToLowerInvariant();

                List<string> categoryNames = new List<string>();
                categoryNames = await categoryService.InputCategoryAsync();
                foreach (string categoryName in categoryNames)
                {
                    newCategoryExist = false;
                    if (categoryName.Equals(newCategoryNameFirst + newCategoryNameLast))
                    {
                        newCategoryExist = true;
                    }
                }
                if (newCategoryExist == true)
                {
                    lblCategoryMsg.Text = "Denna kategori finns redan!";
                }
                if (lbCategory.SelectedIndex == -1)
                {
                    lblCategoryMsg.Text = "Välj en kategori att ändra!";
                }
                if (newCategoryExist == false && lbCategory.SelectedIndex != -1)
                {
                    string oldCategoryName = lbCategory.GetItemText(lbCategory.SelectedItem);
                    await categoryService.ChangeCategoryNameAsync(oldCategoryName, newCategoryNameFirst + newCategoryNameLast);

                    InputCategoryListAsync();
                    tbCategoryName.Text = "";

                    List<Feed> listOfFeedInCategory = await feedService.GetFeedInCategoryAsync(oldCategoryName);
                    foreach (Feed item in listOfFeedInCategory)
                    {
                        await feedService.ChangeFeedAsync(
                            item.Name,
                            item.TimeInterval,
                            newCategoryNameFirst + newCategoryNameLast,
                            item.FileName);
                    }

                    DisplaySubscribeListAsync();
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                lblCategoryMsg.Text = "Ange ett nytt namn på en kategori!"; // Eller en validering ist? 
            }
        }

        private async void btnCategoryDelete_Click(object sender, EventArgs e)
        {
            if (lbCategory.SelectedIndex == -1)
            {
                lblCategoryMsg.Text = "Välj en kategori att ta bort!";
            }
            if (lbCategory.SelectedIndex != -1)
            {

                string chosenCategory = lbCategory.GetItemText(lbCategory.SelectedItem);
                DialogResult popUp = MessageBox.Show("Vill du ta bort kategori: " + chosenCategory, "Är du säker?", MessageBoxButtons.YesNoCancel, 

                MessageBoxIcon.Information);

                if (popUp == DialogResult.Yes)
                {
                    await categoryService.DeleteAsync(chosenCategory);
                    InputCategoryListAsync();

                    List<Feed> listOfFeedInCategory = await feedService.GetFeedInCategoryAsync(chosenCategory);
                    foreach(Feed item in listOfFeedInCategory)
                    {
                        feedService.DeleteFeed(item.FileName);
                    }

                    DisplaySubscribeListAsync();
                }
            }
        }


        private async void lbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            string filterCategory = lbCategory.GetItemText(lbCategory.SelectedItem);
            List<Feed> listOfFeedInCategory = await feedService.GetFeedInCategoryAsync(filterCategory);
            DisplaySubscribeList(listOfFeedInCategory);

        }

        private async void btnShowEpisodes_Click(object sender, EventArgs e)
        {
            string fileName = "";
            var selectedRow = this.lvSubscribe.SelectedItems;
            //tbEpisodeDescription.Text = Convert.ToString(selectedRow);
            //var selectedIndex = this.lvSubscribe.SelectedItems;

            foreach (ListViewItem item in selectedRow)
            {
                //Hämtar filnamnet från kolumnen som är hidden
                fileName = item.SubItems[0].Text;
                //tbEpisodeDescription.Text = fileName;
            }

            Feed feedObject = await feedService.GetFeedAsync(fileName);
            DisplayEpisodeList(feedObject);
        }

        private async void lbEpisode_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Välja ett asvnitt för att ta fram beskrivningen
            //tbEpisodeDescription.Text = "";
            try
            {
                if (lvSubscribe.SelectedItems.Count > 0)
                {
                    string fileName = "";
                    string episode = "";

                    episode = lbEpisode.GetItemText(lbEpisode.SelectedItem);
                    var selectedRow = this.lvSubscribe.SelectedItems;


                    foreach (ListViewItem item in selectedRow)
                    {
                        //Hämtar filnamnet från kolumnen som är hidden
                        fileName = item.SubItems[0].Text;
                        //tbEpisodeDescription.Text = fileName;
                    }
                    bool match = false;
                    Feed feedObject = await feedService.GetFeedAsync(fileName);
                    string url = feedObject.Url;
                    List<Episode> listEpisodes = await episodeService.GetListOfEpisodesAsync(url);

                    foreach(Episode episodeObject in listEpisodes)
                    {
                        string title = episodeObject.Title;
                        string description = episodeObject.Description;

                        if (episode.Equals(title))
                        {
                            match = true;
                        }
                        if(match == true)
                        {
                            tbEpisodeDescription.Text = description;
                            break;
                        }
                        else
                        {
                            tbEpisodeDescription.Text = "Det finns ingen beskrivning för ditt valda avsnitt";
                        }
                    }


                    //DisplayEpisodeList(feedObject);
                }
            } catch (Exception ) { }
         }


        private void btnSubcribeDelete_Click(object sender, EventArgs e)
        {
            string fileName = "";
            var selectedRow = lvSubscribe.SelectedItems;

            foreach (ListViewItem item in selectedRow)
            {
                fileName = item.SubItems[0].Text;
            }

            feedService.DeleteFeed(fileName);
            DisplaySubscribeListAsync();
        }

        private Timer timer = new Timer();

        public async void Timer_Tick(object sender, EventArgs e)
        {
            List<Feed> listOfFeed = await feedService.GetListOfFeedsAsync();
            string fileName = "";
            foreach (Feed feedObject in listOfFeed)
            {
                if (feedObject.NeedsUpdate)
                {
                    await feedService.ChangeFeedAsync(feedObject.Name, feedObject.TimeInterval, feedObject.Category, feedObject.FileName);
                    feedObject.Update();
                    var selectedRow = this.lvSubscribe.SelectedItems;
                    foreach (ListViewItem item in selectedRow)
                    {
                        fileName = item.SubItems[0].Text;
                    }
                 
                    Feed selectedFeedObject = await feedService.GetFeedAsync(fileName);
                   
                    if (feedObject.FileName.Equals(selectedFeedObject.FileName))
                    {
                        DisplayEpisodeList(selectedFeedObject);
                        tbEpisodeDescription.Text = "";
                    }
                }
            }
        }

    }

}
