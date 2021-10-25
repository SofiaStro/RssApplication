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
       
        }

        private void btnSubcribeAdd_Click(object sender, EventArgs e)
        {
            feedService.CreateFeed("NAMN", 30, 60);
        }

        private void btnSubscribeChange_Click(object sender, EventArgs e)
        {
            tbEpisodeDescription.Text = "Testar tidsintervall";
        }

    }
}
