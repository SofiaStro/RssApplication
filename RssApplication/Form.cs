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


namespace RssApplication
{
    public partial class Form : System.Windows.Forms.Form
    {
        FeedService feedService;
        CategoryService categoryService;
        public Form()
        {
            InitializeComponent();
            feedService = new FeedService();
            categoryService = new CategoryService();

            cbTime.Items.Add("5");
            cbTime.Items.Add("15");
            cbTime.Items.Add("30");
            cbType.Items.Add("Nyhet");
            cbType.Items.Add("Podcast");
            cbSubscribeCategory.Items.Add("Historia");
            cbSubscribeCategory.Items.Add("Humor");
            DisplaySubscribeList();
            InputCategoryList();
        }

        private void DisplaySubscribeList()
        {

            lvSubscribe.Items.Clear();
            List<Feed> listOfFeeds = feedService.DisplayFeed();

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
            DisplaySubscribeList();

        }

        private void btnSubcribeAdd_Click(object sender, EventArgs e)
        {
            string url = tbUrl.Text;
            string name = tbSubscribeName.Text;
            int timeInterval = Convert.ToInt32(cbTime.SelectedItem);
            string category = Convert.ToString(cbSubscribeCategory.SelectedItem);
            string type = Convert.ToString(cbType.SelectedItem);

            feedService.CreateFeed(url, name, timeInterval, category, type);

            DisplaySubscribeList();


        }

        private void btnSubscribeChange_Click(object sender, EventArgs e)
        {
            tbEpisodeDescription.Text = "Testar tidsintervall";
        }


        private void lvSubscribe_SelectedIndexChanged(object sender, EventArgs e)
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

            Feed feedObject = feedService.CompareFeedObjects(fileName);
            DisplayEpisodeList(feedObject);

        }


        // lägger till kategori i listbox och combobox,
        // samt skapar ett kategori-objekt som sparas i en xml-fil
        // för att kunna hämta vid stängning och öppning av applikationen
        private void btnCategoryAdd_Click(object sender, EventArgs e)
        {
            bool exist = false;
            string name = tbCategoryName.Text;
            string nameFirst = name.Substring(0, 1).ToUpperInvariant();
            string nameLast = name.Substring(1).ToLowerInvariant();

            List<string> categoryNames = new List<string>();
            categoryNames = categoryService.InputCategory();

            foreach (string categoryName in categoryNames)
            {
                if(categoryName.Equals(nameFirst + nameLast))
                {
                    exist = true;
                }
            }
            if (exist == false)
            { 
                categoryService.Create(nameFirst + nameLast);

                InputCategoryList();
                tbCategoryName.Text = "";
            }
            else
            {
                lblCategoryMsg.Text = "Denna kategori finns redan!";
            }   
        }
        
        // hämtar de sparade kategorier i xml-filen vid öppnining av applikationen
        // if:en används då xml-filen inte kommer att existera förrens man lägger in en applikationen
        // och listan "catagoryNames" kommer ju då vara tom i början
        private void InputCategoryList()
        {
            cbSubscribeCategory.Items.Clear();
            lbCategory.Items.Clear();

            List<string> categoryNames = new List<string>();
            categoryNames = categoryService.InputCategory();
            if (categoryNames.Count != 0)
            { 
                foreach (string catagoryName in categoryNames)
                {
                    cbSubscribeCategory.Items.Add(catagoryName);
                    lbCategory.Items.Add(catagoryName);
                }
            }
        }

        private void btnCategoryChange_Click(object sender, EventArgs e)
        {
            try
            {
                bool newExist = false;
                string newCategoryName = tbCategoryName.Text;
                string newCategoryNameFirst = newCategoryName.Substring(0, 1).ToUpperInvariant();
                string newCategoryNameLast = newCategoryName.Substring(1).ToLowerInvariant();

                List<string> categoryNames = new List<string>();
                categoryNames = categoryService.InputCategory();
                foreach (string categoryName in categoryNames)
                {
                    newExist = false;
                    if (categoryName.Equals(newCategoryNameFirst + newCategoryNameLast))
                    {
                        newExist = true;
                    }
                }
                if (newExist == true)
                {
                    lblCategoryMsg.Text = "Denna kategori finns redan!";
                }
                if(lbCategory.SelectedIndex == -1)
                {
                    lblCategoryMsg.Text = "Välj en kategori att ändra!";
                }
                if (newExist == false && lbCategory.SelectedIndex != -1)
                {
                    string oldName = lbCategory.GetItemText(lbCategory.SelectedItem);
                    categoryService.ChangeCategoryName(oldName, newCategoryNameFirst + newCategoryNameLast);

                    InputCategoryList();
                    tbCategoryName.Text = "";
                    // Lägg till så att värder på propertien i rätt feeden ändras! + displayfeed-metoden
                }
            }
            catch(ArgumentOutOfRangeException)
            {
                lblCategoryMsg.Text = "Ange ett nytt namn på en kategori!"; // Eller en validering ist? 
            }
        }

        private void btnCategoryDelete_Click(object sender, EventArgs e)
        {
            if (lbCategory.SelectedIndex == -1)
            {
                lblCategoryMsg.Text = "Välj en kategori att ta bort!";
            }
            if (lbCategory.SelectedIndex != -1)
            {
                string valdKategori = lbCategory.GetItemText(lbCategory.SelectedItem);
                DialogResult popUp = MessageBox.Show("Vill du ta bort kategori: " + valdKategori, "Är du säker?", MessageBoxButtons.YesNoCancel, 
                MessageBoxIcon.Information);

                if (popUp == DialogResult.Yes)
                {
                    categoryService.Delete(valdKategori);
                    InputCategoryList();

                    // Lägg till så att feeden inom denna kategori också tas bort! + displayfeed - metoden
                }
            }
        }

        private void lbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
