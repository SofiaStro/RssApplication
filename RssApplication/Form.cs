using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer.Services;
using Models.Classes;
using Models.Exceptions;
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

            Task.Run(async () => DisplaySubscribeList(await feedService.GetListOfFeedsAsync())).Wait();
            Task.Run(() => this.InputCategoryListAsync()).Wait();

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

        //private void ClearFields()
        //{
        //    tbUrl.ReadOnly = false;
        //    lblType.Visible = true;
        //    cbType.Visible = true;

        //    tbUrl.Text = "";
        //    tbSubscribeName.Text = "";
        //    cbTime.Text = "";
        //    cbSubscribeCategory.Text = "";
        //    cbType.Text = "";
        //    listView1.SelectedItems.Clear();
        //}

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
            lblDescriptionType.Text = episodeService.DisplayEpisodeType(feedObject);
        }

        private string GetSelectedFeed()
        {
            string fileName = "";
            var selectedRow = lvSubscribe.SelectedItems;

            foreach (ListViewItem item in selectedRow)
            {
                //Hämtar filnamnet från kolumn som är hidden
                fileName = item.SubItems[0].Text;
            }
            
            return fileName;
        }



        private async void btnSubcribeAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validator.TextBoxIsPresent(tbUrl, "Vänligen angen en Url.") &&
                    Validator.IsValidUrl(tbUrl.Text) &&
                    Validator.TextBoxIsPresent(tbSubscribeName, "Vänligen ange ett namn.") &&
                    Validator.ComboBoxIsPresent(cbTime, "Vänligen ange ett tidsintervall.") &&
                    Validator.ComboBoxIsPresent(cbSubscribeCategory, "Vänligen ange en kategori.") &&
                    Validator.ComboBoxIsPresent(cbType, "Vänligen ange en typ."))
                {
                    string url = tbUrl.Text;
                    string name = tbSubscribeName.Text;
                    int timeInterval = Convert.ToInt32(cbTime.SelectedItem);
                    string category = Convert.ToString(cbSubscribeCategory.SelectedItem);
                    string type = Convert.ToString(cbType.SelectedItem);

                    await feedService.CreateFeedAsync(url, name, timeInterval, category, type);

                    DisplaySubscribeList(await feedService.GetListOfFeedsAsync());
                }
            }
            catch (ValidatorException ex)
            {
                lblSubcribeMsg.Text = ex.Message;
            }
        }

        private async void btnSubscribeChange_Click(object sender, EventArgs e)
        {
            try {
                if (Validator.IsSelected(lvSubscribe, "Välj en prenumeration att ändra.") &&
                    Validator.TextBoxIsPresent(tbSubscribeName, "Vänligen ange ett namn.") &&
                    Validator.ComboBoxIsPresent(cbTime, "Vänligen ange ett tidsintervall.") &&
                    Validator.ComboBoxIsPresent(cbSubscribeCategory, "Vänligen ange en kategori."))
                {
                    string name = tbSubscribeName.Text;
                    int timeInterval = Convert.ToInt32(cbTime.SelectedItem);
                    string category = Convert.ToString(cbSubscribeCategory.SelectedItem);

                    string fileName = GetSelectedFeed();
                    await feedService.ChangeFeedAsync(name, timeInterval, category, fileName);

                    DisplaySubscribeList( await feedService.GetListOfFeedsAsync());

                }
            }
            catch (ValidatorException ex)
            {
                lblSubcribeMsg.Text = ex.Message;
            }

        }


        private async void lvSubscribe_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                tbEpisodeDescription.Text = "";

                if (lvSubscribe.SelectedItems.Count > 0)
                {
                    string fileName = GetSelectedFeed();

                    if (Validator.FileNameExist(fileName))
                    {
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Oväntat fel");
            }
        }

        private async void btnCategoryAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validator.TextBoxIsPresent(tbCategoryName, "Vänligen ange ett kategori namn."))
                {
                    string inputName = tbCategoryName.Text;
                    string nameFirst = inputName.Substring(0, 1).ToUpperInvariant();
                    string nameLast = inputName.Substring(1).ToLowerInvariant();
                    string name = nameFirst + nameLast;

                    List<string> categoryNames = new List<string>();
                    categoryNames = await categoryService.InputCategoryAsync();

                    if (Validator.CategoryNotExist(categoryNames, name))
                    {
                        await categoryService.CreateAsync(name);

                        await InputCategoryListAsync();
                        tbCategoryName.Text = "";
                    }

                }
            }
            catch (Exception ex)
            {
                lblCategoryMsg.Text = ex.Message;
            }
        }

        private async Task InputCategoryListAsync()
        {
            cbSubscribeCategory.Items.Clear();
            lbCategory.Items.Clear();

            List<string> categoryNames = new List<string>();
            categoryNames = await categoryService.InputCategoryAsync();
            if (categoryNames.Count != 0)
            {
                foreach (string categoryName in categoryNames)
                {
                    cbSubscribeCategory.Items.Add(categoryName);
                    lbCategory.Items.Add(categoryName);
                }
            }
        }

        private async void btnCategoryChange_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validator.IsSelected(lbCategory, "Välj en kategori att ändra.") &&
                    Validator.TextBoxIsPresent(tbCategoryName, "Ange ett nytt kategori namn."))
                {
                    string inputNewCategoryName = tbCategoryName.Text;
                    string newCategoryNameFirst = inputNewCategoryName.Substring(0, 1).ToUpperInvariant();
                    string newCategoryNameLast = inputNewCategoryName.Substring(1).ToLowerInvariant();
                    string newCategoryName = newCategoryNameFirst + newCategoryNameLast;

                    List<string> categoryNames = new List<string>();
                    categoryNames = await categoryService.InputCategoryAsync();

                    if (Validator.CategoryNotExist(categoryNames, newCategoryName))
                    {
                        string oldCategoryName = lbCategory.GetItemText(lbCategory.SelectedItem);
                        await categoryService.ChangeCategoryNameAsync(oldCategoryName, newCategoryName);

                        await InputCategoryListAsync();
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

                        DisplaySubscribeList(await feedService.GetListOfFeedsAsync());
                    }
                }
            }
            catch (Exception ex)
            {
                lblCategoryMsg.Text = ex.Message;
            }
        }

        private async void btnCategoryDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validator.IsSelected(lbCategory, "Välj en kategori att ta bort."))
                {
                    string chosenCategory = lbCategory.GetItemText(lbCategory.SelectedItem);
                    DialogResult popUp = MessageBox.Show("Vill du ta bort kategori: " + chosenCategory, "Är du säker?", 
                        MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);

                    if (popUp == DialogResult.Yes)
                    {
                        await categoryService.DeleteAsync(chosenCategory);
                        await InputCategoryListAsync ();

                        List<Feed> listOfFeedInCategory = await feedService.GetFeedInCategoryAsync(chosenCategory);

                        foreach (Feed item in listOfFeedInCategory)
                        {
                            feedService.DeleteFeed(item.FileName);
                        }

                        DisplaySubscribeList(await feedService.GetListOfFeedsAsync());
                    }
                }

            }
            catch (Exception ex)
            {
                lblCategoryMsg.Text = ex.Message;
            }
        }

        private async void lbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            string filterCategory = lbCategory.GetItemText(lbCategory.SelectedItem);
            List<Feed> listOfFeedInCategory = await feedService.GetFeedInCategoryAsync(filterCategory);
            DisplaySubscribeList(listOfFeedInCategory);
        }

        private async void lbEpisode_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                if (lvSubscribe.SelectedItems.Count > 0)
                {
                    string episode = "";
                    bool match = false;

                    episode = lbEpisode.GetItemText(lbEpisode.SelectedItem);
                    
                    string fileName = GetSelectedFeed();

                    if (Validator.FileNameExist(fileName))
                    {
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

                            if (match == true)
                            {
                                tbEpisodeDescription.Text = description;
                                break;
                            }
                            else
                            {
                                tbEpisodeDescription.Text = "Det finns ingen beskrivning för ditt valda avsnitt";
                            }
                        }
                    
                    }
                
                }
            } 
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
         }


        private async void btnSubcribeDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if(Validator.IsSelected(lvSubscribe, "Välj en prenumeration att ta bort."))
                {
                    string fileName = GetSelectedFeed();
                    DialogResult popUp = MessageBox.Show("Vill du ta bort markerad prenumeration?", "Är du säker?",
                       MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);

                    if (popUp == DialogResult.Yes)
                    {
                        feedService.DeleteFeed(fileName);
                        DisplaySubscribeList(await feedService.GetListOfFeedsAsync());
                    }
                }
            }
            catch(Exception ex)
            {
                lblSubcribeMsg.Text = ex.Message;
            }
            
        }

        private Timer timer = new Timer();

        public async void Timer_Tick(object sender, EventArgs e)
        {
            List<Feed> listOfFeed = await feedService .GetListOfFeedsAsync();

            foreach (Feed feedObject in listOfFeed)
            {
                if (feedObject.NeedsUpdate)
                {
                    await feedService .ChangeFeedAsync(feedObject.Name, feedObject.TimeInterval, feedObject.Category, feedObject.FileName);
                    feedObject.Update();
                   
                    string fileName = GetSelectedFeed();

                    if (fileName != "")
                    {
                        Feed selectedFeedObject = await feedService .GetFeedAsync(fileName);

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

}
