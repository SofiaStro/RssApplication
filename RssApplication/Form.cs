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
            cbTime.Items.Add("");
            cbTime.Items.Add("1");
            cbTime.Items.Add("15");
            cbTime.Items.Add("30");
            cbType.Items.Add("");
            cbType.Items.Add("Nyhet");
            cbType.Items.Add("Podcast");
        }

        private void ClearFieldsFeed()
        {
            tbUrl.ReadOnly = false;
            lblType.Visible = true;
            cbType.Visible = true;

            tbUrl.Text = "";
            tbSubscribeName.Text = "";
            cbTime.Text = "";
            cbSubscribeCategory.Text = "";
            cbType.Text = "";
            lvSubscribe.SelectedItems.Clear();
        }
        private async Task ClearFieldsCategory()
        {
            tbCategoryName.Text = "";
            lbCategory.ClearSelected();
            DisplaySubscribeList(await feedService.GetListOfFeedsAsync());
        }
        private void ClearFieldsEpisode()
        {
            lbEpisode.Items.Clear();
            lblDescriptionType.Text = "";
            tbEpisodeDescription.Text = "";
        }

        public void DisplaySubscribeList(List<Feed> listOfFeeds)
        {
            lvSubscribe.Items.Clear();

            foreach (Feed feedObject in listOfFeeds)
            {
                String[] row = {
                    feedObject.FileName,
                    Convert.ToString(feedObject.NumberOfEpisodes),
                    feedObject.Name,
                    Convert.ToString(feedObject.TimeInterval),
                    feedObject.Category};

                ListViewItem List = new ListViewItem(row);
                lvSubscribe.Items.Add(List);
            }
        }

        private void DisplayEpisodeList(Feed feedObject)
        {
            lbEpisode.Items.Clear();

            List<Episode> listOfEpisodes = null;
            listOfEpisodes = new List<Episode>();

            listOfEpisodes = feedObject.ListOfEpisodes;

            foreach (Episode episodeObject in listOfEpisodes)
            {
                lbEpisode.Items.Add(episodeObject.Title);
            }
            lblDescriptionType.Text = episodeService.DisplayFeedType(feedObject);
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
                    ClearFieldsFeed();
                    ClearFieldsEpisode();
                }
            }
            catch (ValidatorException ex)
            {
                lblSubcribeMsg.Text = ex.Message;
            }
        }

        private async void btnSubscribeChange_Click(object sender, EventArgs e)
        {
            try
            {
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
                    ClearFieldsFeed();
                    ClearFieldsEpisode();
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

                    List<string> listOfCategoryNames = new List<string>();
                    listOfCategoryNames = await categoryService.InputCategoryAsync();

                    if (Validator.CategoryNotExist(listOfCategoryNames, name))
                    {
                        await categoryService.CreateCategoryAsync(name);

                        await InputCategoryListAsync();
                        tbCategoryName.Text = "";
                        await ClearFieldsCategory();
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
            cbSubscribeCategory.Items.Add("");

            List<string> listOfCategoryNames = new List<string>();
            listOfCategoryNames = await categoryService.InputCategoryAsync();
            if (listOfCategoryNames.Count != 0)
            {
                foreach (string name in listOfCategoryNames)
                {
                    cbSubscribeCategory.Items.Add(name);
                    lbCategory.Items.Add(name);
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

                    List<string> listOfCategoryNames = new List<string>();
                    listOfCategoryNames = await categoryService.InputCategoryAsync();

                    if (Validator.CategoryNotExist(listOfCategoryNames, newCategoryName))
                    {
                        string oldCategoryName = lbCategory.GetItemText(lbCategory.SelectedItem);
                        await categoryService.ChangeCategoryNameAsync(oldCategoryName, newCategoryName);

                        await InputCategoryListAsync();
                        tbCategoryName.Text = "";

                        List<Feed> listOfFeedInCategory = await feedService.GetFeedInCategoryAsync(oldCategoryName);

                        foreach (Feed feedObject in listOfFeedInCategory)
                        {
                            await feedService.ChangeFeedAsync(
                                feedObject.Name,
                                feedObject.TimeInterval,
                                newCategoryNameFirst + newCategoryNameLast,
                                feedObject.FileName);
                        }

                        DisplaySubscribeList(await feedService.GetListOfFeedsAsync());
                        await ClearFieldsCategory();
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
                    string selectedCategory = lbCategory.GetItemText(lbCategory.SelectedItem);

                    DialogResult popUp = MessageBox.Show("Vill du ta bort kategorin " + selectedCategory + " och alla prenumerationer med denna kategori?", "Är du säker?", 

                        MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);

                    if (popUp == DialogResult.Yes)
                    {
                        await categoryService.DeleteCategoryAsync(selectedCategory);
                        await InputCategoryListAsync();

                        List<Feed> listOfFeedInCategory = await feedService.GetFeedInCategoryAsync(selectedCategory);

                        foreach (Feed feedObject in listOfFeedInCategory)
                        {
                            feedService.DeleteFeed(feedObject.FileName);
                        }

                        DisplaySubscribeList(await feedService.GetListOfFeedsAsync());
                        await ClearFieldsCategory();
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
            ClearFieldsFeed();
            ClearFieldsEpisode();
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
                        List<Episode> listOfEpisodes = await episodeService.GetListOfEpisodesAsync(url);

                        foreach (Episode episodeObject in listOfEpisodes)
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
                if (Validator.IsSelected(lvSubscribe, "Välj en prenumeration att ta bort."))
                {
                    string fileName = GetSelectedFeed();
                    DialogResult popUp = MessageBox.Show("Vill du ta bort markerad prenumeration?", "Är du säker?",
                       MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);

                    if (popUp == DialogResult.Yes)
                    {
                        feedService.DeleteFeed(fileName);
                        DisplaySubscribeList(await feedService.GetListOfFeedsAsync());
                        ClearFieldsFeed();
                        ClearFieldsEpisode();
                    }
                }
            }
            catch (Exception ex)
            {
                lblSubcribeMsg.Text = ex.Message;
            }        
        }

        private Timer timer = new Timer();

        public async void Timer_Tick(object sender, EventArgs e)
        {
            List<Feed> listOfFeed = await feedService.GetListOfFeedsAsync();

            foreach (Feed feedObject in listOfFeed)
            {
                if (feedObject.FeedNeedsUpdate)
                {
                    await feedService.ChangeFeedAsync(feedObject.Name, feedObject.TimeInterval, feedObject.Category, feedObject.FileName);
                    feedObject.UpdateFeedContent();

                    string fileName = GetSelectedFeed();

                    if (fileName != "")
                    {
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

        private async void bgFeed_Click(object sender, EventArgs e)
        {
            ClearFieldsFeed();
            ClearFieldsEpisode();
            await ClearFieldsCategory();
        }

        private async void bgCategory_Click(object sender, EventArgs e)
        {
            ClearFieldsFeed();
            ClearFieldsEpisode();
            await ClearFieldsCategory();
        }

        private async void bgEpisode_Click(object sender, EventArgs e)
        {
            ClearFieldsFeed();
            ClearFieldsEpisode();
            await ClearFieldsCategory();
        }
    }
}
