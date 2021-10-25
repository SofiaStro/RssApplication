using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

            String[] row = {
                Convert.ToString(feedService.DisplayFeed().NumberOfEpisodes),
                feedService.DisplayFeed().Name,
                Convert.ToString(feedService.DisplayFeed().TimeInterval),
                feedService.DisplayFeed().Category};

            ListViewItem List = new ListViewItem(row);
            lvSubscribe.Items.Add(List);
        }

        private void btnSubcribeAdd_Click(object sender, EventArgs e)
        {
            string url = tbUrl.Text;
            string name = tbSubscribeName.Text;
            int timeInterval = Convert.ToInt32(cbTime.SelectedItem);
            string category = Convert.ToString(cbSubscribeCategory.SelectedItem);
            string type = Convert.ToString(cbType.SelectedItem);

            feedService.CreateFeed(url, name, timeInterval, category, type);
        }

        private void btnSubscribeChange_Click(object sender, EventArgs e)
        {
            tbEpisodeDescription.Text = "Testar tidsintervall";
        }

        // lägger till kategori i listbox och combobox,
        // samt skapar ett kategori-objekt som sparas i en xml-fil
        // för att kunna hämta vid stängning och öppning av applikationen
        private void btnCategoryAdd_Click(object sender, EventArgs e)
        {
            string name = tbCategoryName.Text;

            categoryService.Create(name);

            lbCategory.Items.Add(name);
            cbSubscribeCategory.Items.Add(name);
        }
        
        // hämtar de sparade kategorier i xml-filen vid öppnining av applikationen
        // if:en används då xml-filen inte kommer att existera förrens man lägger in en applikationen
        // och listan "catagoryNames" kommer ju då vara tom i början
        private void InputCategoryList()
        {
            List<string> categoryNames = new List<string>();
            categoryNames = categoryService.InputCategory();
            if (categoryNames.Count != 0)
            { 
                foreach (String catagoryName in categoryNames)
                {
                    cbSubscribeCategory.Items.Add(catagoryName);
                    lbCategory.Items.Add(catagoryName);
                }
            }
        }
    }
}
