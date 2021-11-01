
namespace RssApplication
{
    partial class Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblCategoryMsg = new System.Windows.Forms.Label();
            this.lblSubcribeMsg = new System.Windows.Forms.Label();
            this.lblEpisodeDescription = new System.Windows.Forms.Label();
            this.lblEpisode = new System.Windows.Forms.Label();
            this.lblSubscribe = new System.Windows.Forms.Label();
            this.btnCategoryChange = new System.Windows.Forms.Button();
            this.btnCategoryDelete = new System.Windows.Forms.Button();
            this.btnCategoryAdd = new System.Windows.Forms.Button();
            this.tbCategoryName = new System.Windows.Forms.TextBox();
            this.lblCategoryName = new System.Windows.Forms.Label();
            this.lblCategory = new System.Windows.Forms.Label();
            this.lbCategory = new System.Windows.Forms.ListBox();
            this.tbEpisodeDescription = new System.Windows.Forms.TextBox();
            this.lbEpisode = new System.Windows.Forms.ListBox();
            this.btnSubscribeChange = new System.Windows.Forms.Button();
            this.btnSubcribeDelete = new System.Windows.Forms.Button();
            this.btnSubcribeAdd = new System.Windows.Forms.Button();
            this.tbUrl = new System.Windows.Forms.TextBox();
            this.lblSubscribeName = new System.Windows.Forms.Label();
            this.cbSubscribeCategory = new System.Windows.Forms.ComboBox();
            this.lblSubscribeCategory = new System.Windows.Forms.Label();
            this.cbTime = new System.Windows.Forms.ComboBox();
            this.lblTime = new System.Windows.Forms.Label();
            this.tbSubscribeName = new System.Windows.Forms.TextBox();
            this.lblUrl = new System.Windows.Forms.Label();
            this.lvSubscribe = new System.Windows.Forms.ListView();
            this.chFileName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chEpisode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chCategory = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.bgCategory = new System.Windows.Forms.Label();
            this.bgFeed = new System.Windows.Forms.Label();
            this.bgEpisode = new System.Windows.Forms.Label();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.lblType = new System.Windows.Forms.Label();
            this.lblDescriptionType = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblCategoryMsg
            // 
            this.lblCategoryMsg.AutoSize = true;
            this.lblCategoryMsg.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.lblCategoryMsg.Location = new System.Drawing.Point(396, 681);
            this.lblCategoryMsg.Name = "lblCategoryMsg";
            this.lblCategoryMsg.Size = new System.Drawing.Size(0, 20);
            this.lblCategoryMsg.TabIndex = 76;
            // 
            // lblSubcribeMsg
            // 
            this.lblSubcribeMsg.AutoSize = true;
            this.lblSubcribeMsg.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.lblSubcribeMsg.Location = new System.Drawing.Point(29, 421);
            this.lblSubcribeMsg.Name = "lblSubcribeMsg";
            this.lblSubcribeMsg.Size = new System.Drawing.Size(0, 20);
            this.lblSubcribeMsg.TabIndex = 75;
            // 
            // lblEpisodeDescription
            // 
            this.lblEpisodeDescription.AutoSize = true;
            this.lblEpisodeDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEpisodeDescription.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.lblEpisodeDescription.Location = new System.Drawing.Point(885, 406);
            this.lblEpisodeDescription.Name = "lblEpisodeDescription";
            this.lblEpisodeDescription.Size = new System.Drawing.Size(163, 32);
            this.lblEpisodeDescription.TabIndex = 74;
            this.lblEpisodeDescription.Text = "Beskrivning";
            // 
            // lblEpisode
            // 
            this.lblEpisode.AutoSize = true;
            this.lblEpisode.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEpisode.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.lblEpisode.Location = new System.Drawing.Point(884, 26);
            this.lblEpisode.Name = "lblEpisode";
            this.lblEpisode.Size = new System.Drawing.Size(167, 32);
            this.lblEpisode.TabIndex = 73;
            this.lblEpisode.Text = "Avsnittslista";
            // 
            // lblSubscribe
            // 
            this.lblSubscribe.AutoSize = true;
            this.lblSubscribe.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubscribe.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.lblSubscribe.Location = new System.Drawing.Point(25, 26);
            this.lblSubscribe.Name = "lblSubscribe";
            this.lblSubscribe.Size = new System.Drawing.Size(227, 32);
            this.lblSubscribe.TabIndex = 71;
            this.lblSubscribe.Text = "Prenumerationer";
            // 
            // btnCategoryChange
            // 
            this.btnCategoryChange.Location = new System.Drawing.Point(498, 628);
            this.btnCategoryChange.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCategoryChange.Name = "btnCategoryChange";
            this.btnCategoryChange.Size = new System.Drawing.Size(81, 40);
            this.btnCategoryChange.TabIndex = 68;
            this.btnCategoryChange.Text = "Ändra";
            this.btnCategoryChange.UseVisualStyleBackColor = true;
            this.btnCategoryChange.Click += new System.EventHandler(this.btnCategoryChange_Click);
            // 
            // btnCategoryDelete
            // 
            this.btnCategoryDelete.Location = new System.Drawing.Point(600, 628);
            this.btnCategoryDelete.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCategoryDelete.Name = "btnCategoryDelete";
            this.btnCategoryDelete.Size = new System.Drawing.Size(81, 40);
            this.btnCategoryDelete.TabIndex = 69;
            this.btnCategoryDelete.Text = "Ta bort";
            this.btnCategoryDelete.UseVisualStyleBackColor = true;
            this.btnCategoryDelete.Click += new System.EventHandler(this.btnCategoryDelete_Click);
            // 
            // btnCategoryAdd
            // 
            this.btnCategoryAdd.Location = new System.Drawing.Point(397, 628);
            this.btnCategoryAdd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCategoryAdd.Name = "btnCategoryAdd";
            this.btnCategoryAdd.Size = new System.Drawing.Size(81, 40);
            this.btnCategoryAdd.TabIndex = 67;
            this.btnCategoryAdd.Text = "Lägg till";
            this.btnCategoryAdd.UseVisualStyleBackColor = true;
            this.btnCategoryAdd.Click += new System.EventHandler(this.btnCategoryAdd_Click);
            // 
            // tbCategoryName
            // 
            this.tbCategoryName.Location = new System.Drawing.Point(396, 584);
            this.tbCategoryName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbCategoryName.Name = "tbCategoryName";
            this.tbCategoryName.Size = new System.Drawing.Size(227, 26);
            this.tbCategoryName.TabIndex = 66;
            // 
            // lblCategoryName
            // 
            this.lblCategoryName.AutoSize = true;
            this.lblCategoryName.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.lblCategoryName.Location = new System.Drawing.Point(396, 550);
            this.lblCategoryName.Name = "lblCategoryName";
            this.lblCategoryName.Size = new System.Drawing.Size(116, 20);
            this.lblCategoryName.TabIndex = 65;
            this.lblCategoryName.Text = "Kategori namn:";
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategory.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.lblCategory.Location = new System.Drawing.Point(39, 496);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(147, 32);
            this.lblCategory.TabIndex = 64;
            this.lblCategory.Text = "Kategorier";
            // 
            // lbCategory
            // 
            this.lbCategory.FormattingEnabled = true;
            this.lbCategory.ItemHeight = 20;
            this.lbCategory.Location = new System.Drawing.Point(33, 550);
            this.lbCategory.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lbCategory.Name = "lbCategory";
            this.lbCategory.Size = new System.Drawing.Size(331, 204);
            this.lbCategory.TabIndex = 63;
            this.lbCategory.SelectedIndexChanged += new System.EventHandler(this.lbCategory_SelectedIndexChanged);
            // 
            // tbEpisodeDescription
            // 
            this.tbEpisodeDescription.BackColor = System.Drawing.SystemColors.Window;
            this.tbEpisodeDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbEpisodeDescription.Enabled = false;
            this.tbEpisodeDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbEpisodeDescription.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tbEpisodeDescription.Location = new System.Drawing.Point(875, 484);
            this.tbEpisodeDescription.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbEpisodeDescription.Multiline = true;
            this.tbEpisodeDescription.Name = "tbEpisodeDescription";
            this.tbEpisodeDescription.Size = new System.Drawing.Size(542, 291);
            this.tbEpisodeDescription.TabIndex = 62;
            // 
            // lbEpisode
            // 
            this.lbEpisode.FormattingEnabled = true;
            this.lbEpisode.ItemHeight = 20;
            this.lbEpisode.Location = new System.Drawing.Point(875, 66);
            this.lbEpisode.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lbEpisode.Name = "lbEpisode";
            this.lbEpisode.Size = new System.Drawing.Size(542, 284);
            this.lbEpisode.TabIndex = 61;
            this.lbEpisode.SelectedIndexChanged += new System.EventHandler(this.lbEpisode_SelectedIndexChanged);
            // 
            // btnSubscribeChange
            // 
            this.btnSubscribeChange.Location = new System.Drawing.Point(135, 369);
            this.btnSubscribeChange.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSubscribeChange.Name = "btnSubscribeChange";
            this.btnSubscribeChange.Size = new System.Drawing.Size(81, 40);
            this.btnSubscribeChange.TabIndex = 60;
            this.btnSubscribeChange.Text = "Ändra";
            this.btnSubscribeChange.UseVisualStyleBackColor = true;
            this.btnSubscribeChange.Click += new System.EventHandler(this.btnSubscribeChange_Click);
            // 
            // btnSubcribeDelete
            // 
            this.btnSubcribeDelete.Location = new System.Drawing.Point(237, 369);
            this.btnSubcribeDelete.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSubcribeDelete.Name = "btnSubcribeDelete";
            this.btnSubcribeDelete.Size = new System.Drawing.Size(81, 40);
            this.btnSubcribeDelete.TabIndex = 58;
            this.btnSubcribeDelete.Text = "Ta bort";
            this.btnSubcribeDelete.UseVisualStyleBackColor = true;
            this.btnSubcribeDelete.Click += new System.EventHandler(this.btnSubcribeDelete_Click);
            // 
            // btnSubcribeAdd
            // 
            this.btnSubcribeAdd.Location = new System.Drawing.Point(33, 369);
            this.btnSubcribeAdd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSubcribeAdd.Name = "btnSubcribeAdd";
            this.btnSubcribeAdd.Size = new System.Drawing.Size(81, 40);
            this.btnSubcribeAdd.TabIndex = 57;
            this.btnSubcribeAdd.Text = "Lägg till";
            this.btnSubcribeAdd.UseVisualStyleBackColor = true;
            this.btnSubcribeAdd.Click += new System.EventHandler(this.btnSubcribeAdd_Click);
            // 
            // tbUrl
            // 
            this.tbUrl.Location = new System.Drawing.Point(30, 320);
            this.tbUrl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbUrl.Name = "tbUrl";
            this.tbUrl.Size = new System.Drawing.Size(211, 26);
            this.tbUrl.TabIndex = 56;
            // 
            // lblSubscribeName
            // 
            this.lblSubscribeName.AutoSize = true;
            this.lblSubscribeName.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.lblSubscribeName.Location = new System.Drawing.Point(245, 298);
            this.lblSubscribeName.Name = "lblSubscribeName";
            this.lblSubscribeName.Size = new System.Drawing.Size(59, 20);
            this.lblSubscribeName.TabIndex = 55;
            this.lblSubscribeName.Text = " Namn:";
            // 
            // cbSubscribeCategory
            // 
            this.cbSubscribeCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSubscribeCategory.FormattingEnabled = true;
            this.cbSubscribeCategory.Location = new System.Drawing.Point(595, 320);
            this.cbSubscribeCategory.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbSubscribeCategory.Name = "cbSubscribeCategory";
            this.cbSubscribeCategory.Size = new System.Drawing.Size(121, 28);
            this.cbSubscribeCategory.TabIndex = 54;
            // 
            // lblSubscribeCategory
            // 
            this.lblSubscribeCategory.AutoSize = true;
            this.lblSubscribeCategory.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.lblSubscribeCategory.Location = new System.Drawing.Point(592, 298);
            this.lblSubscribeCategory.Name = "lblSubscribeCategory";
            this.lblSubscribeCategory.Size = new System.Drawing.Size(76, 20);
            this.lblSubscribeCategory.TabIndex = 53;
            this.lblSubscribeCategory.Text = " Kategori:";
            // 
            // cbTime
            // 
            this.cbTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTime.FormattingEnabled = true;
            this.cbTime.Location = new System.Drawing.Point(420, 320);
            this.cbTime.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbTime.Name = "cbTime";
            this.cbTime.Size = new System.Drawing.Size(159, 28);
            this.cbTime.TabIndex = 52;
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.lblTime.Location = new System.Drawing.Point(413, 298);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(156, 20);
            this.lblTime.TabIndex = 51;
            this.lblTime.Text = " Tidsintervall minuter:";
            // 
            // tbSubscribeName
            // 
            this.tbSubscribeName.Location = new System.Drawing.Point(252, 320);
            this.tbSubscribeName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbSubscribeName.Name = "tbSubscribeName";
            this.tbSubscribeName.Size = new System.Drawing.Size(154, 26);
            this.tbSubscribeName.TabIndex = 50;
            // 
            // lblUrl
            // 
            this.lblUrl.AutoSize = true;
            this.lblUrl.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.lblUrl.Location = new System.Drawing.Point(24, 298);
            this.lblUrl.Name = "lblUrl";
            this.lblUrl.Size = new System.Drawing.Size(50, 20);
            this.lblUrl.TabIndex = 49;
            this.lblUrl.Text = " URL:";
            // 
            // lvSubscribe
            // 
            this.lvSubscribe.BackColor = System.Drawing.SystemColors.Window;
            this.lvSubscribe.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chFileName,
            this.chEpisode,
            this.chName,
            this.chTime,
            this.chCategory});
            this.lvSubscribe.FullRowSelect = true;
            this.lvSubscribe.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvSubscribe.HideSelection = false;
            this.lvSubscribe.Location = new System.Drawing.Point(29, 66);
            this.lvSubscribe.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lvSubscribe.MultiSelect = false;
            this.lvSubscribe.Name = "lvSubscribe";
            this.lvSubscribe.Size = new System.Drawing.Size(795, 206);
            this.lvSubscribe.TabIndex = 48;
            this.lvSubscribe.UseCompatibleStateImageBehavior = false;
            this.lvSubscribe.View = System.Windows.Forms.View.Details;
            this.lvSubscribe.SelectedIndexChanged += new System.EventHandler(this.lvSubscribe_SelectedIndexChanged);
            // 
            // chFileName
            // 
            this.chFileName.DisplayIndex = 4;
            this.chFileName.Text = "Typ";
            this.chFileName.Width = 0;
            // 
            // chEpisode
            // 
            this.chEpisode.DisplayIndex = 0;
            this.chEpisode.Text = "Avsnitt";
            // 
            // chName
            // 
            this.chName.DisplayIndex = 1;
            this.chName.Text = "Namn";
            this.chName.Width = 170;
            // 
            // chTime
            // 
            this.chTime.DisplayIndex = 2;
            this.chTime.Text = "Tidsintervall";
            this.chTime.Width = 120;
            // 
            // chCategory
            // 
            this.chCategory.DisplayIndex = 3;
            this.chCategory.Text = "Kategori";
            this.chCategory.Width = 100;
            // 
            // bgCategory
            // 
            this.bgCategory.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.bgCategory.Location = new System.Drawing.Point(15, 484);
            this.bgCategory.Name = "bgCategory";
            this.bgCategory.Size = new System.Drawing.Size(840, 308);
            this.bgCategory.TabIndex = 70;
            this.bgCategory.Click += new System.EventHandler(this.bgCategory_Click);
            // 
            // bgFeed
            // 
            this.bgFeed.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.bgFeed.Location = new System.Drawing.Point(15, 11);
            this.bgFeed.Name = "bgFeed";
            this.bgFeed.Size = new System.Drawing.Size(840, 462);
            this.bgFeed.TabIndex = 59;
            this.bgFeed.Click += new System.EventHandler(this.bgFeed_Click);
            // 
            // bgEpisode
            // 
            this.bgEpisode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.bgEpisode.Location = new System.Drawing.Point(866, 11);
            this.bgEpisode.Name = "bgEpisode";
            this.bgEpisode.Size = new System.Drawing.Size(568, 781);
            this.bgEpisode.TabIndex = 72;
            this.bgEpisode.Click += new System.EventHandler(this.bgEpisode_Click);
            // 
            // cbType
            // 
            this.cbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbType.FormattingEnabled = true;
            this.cbType.Location = new System.Drawing.Point(730, 320);
            this.cbType.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(94, 28);
            this.cbType.TabIndex = 78;
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.lblType.Location = new System.Drawing.Point(727, 298);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(38, 20);
            this.lblType.TabIndex = 77;
            this.lblType.Text = "Typ:";
            // 
            // lblDescriptionType
            // 
            this.lblDescriptionType.AutoSize = true;
            this.lblDescriptionType.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.lblDescriptionType.Location = new System.Drawing.Point(886, 454);
            this.lblDescriptionType.Name = "lblDescriptionType";
            this.lblDescriptionType.Size = new System.Drawing.Size(0, 20);
            this.lblDescriptionType.TabIndex = 79;
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1446, 804);
            this.Controls.Add(this.lblDescriptionType);
            this.Controls.Add(this.cbType);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.lblCategoryMsg);
            this.Controls.Add(this.lblSubcribeMsg);
            this.Controls.Add(this.lblEpisodeDescription);
            this.Controls.Add(this.lblEpisode);
            this.Controls.Add(this.lblSubscribe);
            this.Controls.Add(this.btnCategoryChange);
            this.Controls.Add(this.btnCategoryDelete);
            this.Controls.Add(this.btnCategoryAdd);
            this.Controls.Add(this.tbCategoryName);
            this.Controls.Add(this.lblCategoryName);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.lbCategory);
            this.Controls.Add(this.tbEpisodeDescription);
            this.Controls.Add(this.lbEpisode);
            this.Controls.Add(this.btnSubscribeChange);
            this.Controls.Add(this.btnSubcribeDelete);
            this.Controls.Add(this.btnSubcribeAdd);
            this.Controls.Add(this.tbUrl);
            this.Controls.Add(this.lblSubscribeName);
            this.Controls.Add(this.cbSubscribeCategory);
            this.Controls.Add(this.lblSubscribeCategory);
            this.Controls.Add(this.cbTime);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.tbSubscribeName);
            this.Controls.Add(this.lblUrl);
            this.Controls.Add(this.lvSubscribe);
            this.Controls.Add(this.bgCategory);
            this.Controls.Add(this.bgFeed);
            this.Controls.Add(this.bgEpisode);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "RSS Applikation";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCategoryMsg;
        private System.Windows.Forms.Label lblSubcribeMsg;
        private System.Windows.Forms.Label lblEpisodeDescription;
        private System.Windows.Forms.Label lblEpisode;
        private System.Windows.Forms.Label lblSubscribe;
        private System.Windows.Forms.Button btnCategoryChange;
        private System.Windows.Forms.Button btnCategoryDelete;
        private System.Windows.Forms.Button btnCategoryAdd;
        private System.Windows.Forms.TextBox tbCategoryName;
        private System.Windows.Forms.Label lblCategoryName;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ListBox lbCategory;
        private System.Windows.Forms.TextBox tbEpisodeDescription;
        private System.Windows.Forms.ListBox lbEpisode;
        private System.Windows.Forms.Button btnSubscribeChange;
        private System.Windows.Forms.Button btnSubcribeDelete;
        private System.Windows.Forms.Button btnSubcribeAdd;
        private System.Windows.Forms.TextBox tbUrl;
        private System.Windows.Forms.Label lblSubscribeName;
        private System.Windows.Forms.ComboBox cbSubscribeCategory;
        private System.Windows.Forms.Label lblSubscribeCategory;
        private System.Windows.Forms.ComboBox cbTime;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.TextBox tbSubscribeName;
        private System.Windows.Forms.Label lblUrl;
        private System.Windows.Forms.ListView lvSubscribe;
        private System.Windows.Forms.Label bgCategory;
        private System.Windows.Forms.Label bgFeed;
        private System.Windows.Forms.Label bgEpisode;
        private System.Windows.Forms.ComboBox cbType;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.ColumnHeader chEpisode;
        private System.Windows.Forms.ColumnHeader chName;
        private System.Windows.Forms.ColumnHeader chTime;
        private System.Windows.Forms.ColumnHeader chCategory;
        private System.Windows.Forms.ColumnHeader chFileName;
        private System.Windows.Forms.Label lblDescriptionType;
    }
}

