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



namespace RssApplication
{
    public partial class Form : System.Windows.Forms.Form
    {
        FeedService feedService;
        public Form()
        {
            InitializeComponent();
            feedService = new FeedService();

            cbTime.Items.Add("5");
            cbTime.Items.Add("15");
            cbTime.Items.Add("30");
            cbType.Items.Add("Nyhet");
            cbType.Items.Add("Podcast");
            cbSubscribeCategory.Items.Add("Historia");
            cbSubscribeCategory.Items.Add("Humor");
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
    }
}
