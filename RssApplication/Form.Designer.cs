﻿
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
            this.chEpisode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chCategory = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.lblType = new System.Windows.Forms.Label();
            this.tbWork = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblCategoryMsg
            // 
            this.lblCategoryMsg.AutoSize = true;
            this.lblCategoryMsg.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.lblCategoryMsg.Location = new System.Drawing.Point(400, 694);
            this.lblCategoryMsg.Name = "lblCategoryMsg";
            this.lblCategoryMsg.Size = new System.Drawing.Size(123, 20);
            this.lblCategoryMsg.TabIndex = 76;
            this.lblCategoryMsg.Text = "Felmeddelande:";
            // 
            // lblSubcribeMsg
            // 
            this.lblSubcribeMsg.AutoSize = true;
            this.lblSubcribeMsg.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.lblSubcribeMsg.Location = new System.Drawing.Point(36, 395);
            this.lblSubcribeMsg.Name = "lblSubcribeMsg";
            this.lblSubcribeMsg.Size = new System.Drawing.Size(123, 20);
            this.lblSubcribeMsg.TabIndex = 75;
            this.lblSubcribeMsg.Text = "Felmeddelande:";
            // 
            // lblEpisodeDescription
            // 
            this.lblEpisodeDescription.AutoSize = true;
            this.lblEpisodeDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEpisodeDescription.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.lblEpisodeDescription.Location = new System.Drawing.Point(910, 341);
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
            this.lblEpisode.Location = new System.Drawing.Point(910, 44);
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
            this.lblSubscribe.Location = new System.Drawing.Point(40, 44);
            this.lblSubscribe.Name = "lblSubscribe";
            this.lblSubscribe.Size = new System.Drawing.Size(227, 32);
            this.lblSubscribe.TabIndex = 71;
            this.lblSubscribe.Text = "Prenumerationer";
            // 
            // btnCategoryChange
            // 
            this.btnCategoryChange.Location = new System.Drawing.Point(497, 634);
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
            this.btnCategoryDelete.Location = new System.Drawing.Point(600, 634);
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
            this.btnCategoryAdd.Location = new System.Drawing.Point(395, 634);
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
            this.tbCategoryName.Location = new System.Drawing.Point(453, 578);
            this.tbCategoryName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbCategoryName.Name = "tbCategoryName";
            this.tbCategoryName.Size = new System.Drawing.Size(227, 26);
            this.tbCategoryName.TabIndex = 66;
            // 
            // lblCategoryName
            // 
            this.lblCategoryName.AutoSize = true;
            this.lblCategoryName.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.lblCategoryName.Location = new System.Drawing.Point(392, 581);
            this.lblCategoryName.Name = "lblCategoryName";
            this.lblCategoryName.Size = new System.Drawing.Size(55, 20);
            this.lblCategoryName.TabIndex = 65;
            this.lblCategoryName.Text = "Namn:";
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategory.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.lblCategory.Location = new System.Drawing.Point(40, 514);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(147, 32);
            this.lblCategory.TabIndex = 64;
            this.lblCategory.Text = "Kategorier";
            // 
            // lbCategory
            // 
            this.lbCategory.FormattingEnabled = true;
            this.lbCategory.ItemHeight = 20;
            this.lbCategory.Location = new System.Drawing.Point(33, 580);
            this.lbCategory.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lbCategory.Name = "lbCategory";
            this.lbCategory.Size = new System.Drawing.Size(332, 204);
            this.lbCategory.TabIndex = 63;
            // 
            // tbEpisodeDescription
            // 
            this.tbEpisodeDescription.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbEpisodeDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbEpisodeDescription.Enabled = false;
            this.tbEpisodeDescription.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.tbEpisodeDescription.Location = new System.Drawing.Point(890, 408);
            this.tbEpisodeDescription.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbEpisodeDescription.Multiline = true;
            this.tbEpisodeDescription.Name = "tbEpisodeDescription";
            this.tbEpisodeDescription.Size = new System.Drawing.Size(333, 293);
            this.tbEpisodeDescription.TabIndex = 62;
            // 
            // lbEpisode
            // 
            this.lbEpisode.FormattingEnabled = true;
            this.lbEpisode.ItemHeight = 20;
            this.lbEpisode.Location = new System.Drawing.Point(890, 101);
            this.lbEpisode.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lbEpisode.Name = "lbEpisode";
            this.lbEpisode.Size = new System.Drawing.Size(332, 204);
            this.lbEpisode.TabIndex = 61;
            // 
            // btnSubscribeChange
            // 
            this.btnSubscribeChange.Location = new System.Drawing.Point(645, 400);
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
            this.btnSubcribeDelete.Location = new System.Drawing.Point(747, 400);
            this.btnSubcribeDelete.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSubcribeDelete.Name = "btnSubcribeDelete";
            this.btnSubcribeDelete.Size = new System.Drawing.Size(81, 40);
            this.btnSubcribeDelete.TabIndex = 58;
            this.btnSubcribeDelete.Text = "Ta bort";
            this.btnSubcribeDelete.UseVisualStyleBackColor = true;
            // 
            // btnSubcribeAdd
            // 
            this.btnSubcribeAdd.Location = new System.Drawing.Point(542, 400);
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
            this.tbUrl.Location = new System.Drawing.Point(33, 352);
            this.tbUrl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbUrl.Name = "tbUrl";
            this.tbUrl.Size = new System.Drawing.Size(146, 26);
            this.tbUrl.TabIndex = 56;
            // 
            // lblSubscribeName
            // 
            this.lblSubscribeName.AutoSize = true;
            this.lblSubscribeName.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.lblSubscribeName.Location = new System.Drawing.Point(196, 328);
            this.lblSubscribeName.Name = "lblSubscribeName";
            this.lblSubscribeName.Size = new System.Drawing.Size(59, 20);
            this.lblSubscribeName.TabIndex = 55;
            this.lblSubscribeName.Text = " Namn:";
            // 
            // cbSubscribeCategory
            // 
            this.cbSubscribeCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSubscribeCategory.FormattingEnabled = true;
            this.cbSubscribeCategory.Location = new System.Drawing.Point(559, 350);
            this.cbSubscribeCategory.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbSubscribeCategory.Name = "cbSubscribeCategory";
            this.cbSubscribeCategory.Size = new System.Drawing.Size(121, 28);
            this.cbSubscribeCategory.TabIndex = 54;
            // 
            // lblSubscribeCategory
            // 
            this.lblSubscribeCategory.AutoSize = true;
            this.lblSubscribeCategory.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.lblSubscribeCategory.Location = new System.Drawing.Point(556, 325);
            this.lblSubscribeCategory.Name = "lblSubscribeCategory";
            this.lblSubscribeCategory.Size = new System.Drawing.Size(76, 20);
            this.lblSubscribeCategory.TabIndex = 53;
            this.lblSubscribeCategory.Text = " Kategori:";
            // 
            // cbTime
            // 
            this.cbTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTime.FormattingEnabled = true;
            this.cbTime.Location = new System.Drawing.Point(382, 352);
            this.cbTime.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbTime.Name = "cbTime";
            this.cbTime.Size = new System.Drawing.Size(140, 28);
            this.cbTime.TabIndex = 52;
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.lblTime.Location = new System.Drawing.Point(379, 328);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(99, 20);
            this.lblTime.TabIndex = 51;
            this.lblTime.Text = " Tidsintervall:";
            // 
            // tbSubscribeName
            // 
            this.tbSubscribeName.Location = new System.Drawing.Point(199, 352);
            this.tbSubscribeName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbSubscribeName.Name = "tbSubscribeName";
            this.tbSubscribeName.Size = new System.Drawing.Size(154, 26);
            this.tbSubscribeName.TabIndex = 50;
            // 
            // lblUrl
            // 
            this.lblUrl.AutoSize = true;
            this.lblUrl.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.lblUrl.Location = new System.Drawing.Point(29, 328);
            this.lblUrl.Name = "lblUrl";
            this.lblUrl.Size = new System.Drawing.Size(50, 20);
            this.lblUrl.TabIndex = 49;
            this.lblUrl.Text = " URL:";
            // 
            // lvSubscribe
            // 
            this.lvSubscribe.BackColor = System.Drawing.SystemColors.Window;
            this.lvSubscribe.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chEpisode,
            this.chName,
            this.chTime,
            this.chCategory,
            this.chType});
            this.lvSubscribe.HideSelection = false;
            this.lvSubscribe.Location = new System.Drawing.Point(33, 101);
            this.lvSubscribe.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lvSubscribe.Name = "lvSubscribe";
            this.lvSubscribe.Size = new System.Drawing.Size(795, 192);
            this.lvSubscribe.TabIndex = 48;
            this.lvSubscribe.UseCompatibleStateImageBehavior = false;
            this.lvSubscribe.View = System.Windows.Forms.View.Details;
            // 
            // chEpisode
            // 
            this.chEpisode.Text = "Avsnitt";
            // 
            // chName
            // 
            this.chName.Text = "Namn";
            this.chName.Width = 170;
            // 
            // chTime
            // 
            this.chTime.Text = "Tidsintervall";
            this.chTime.Width = 120;
            // 
            // chCategory
            // 
            this.chCategory.Text = "Kategori";
            this.chCategory.Width = 100;
            // 
            // chType
            // 
            this.chType.Text = "Typ";
            this.chType.Width = 100;
            // 
            // label7
            // 
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label7.Location = new System.Drawing.Point(14, 484);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(840, 344);
            this.label7.TabIndex = 70;
            // 
            // label6
            // 
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label6.Location = new System.Drawing.Point(14, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(840, 462);
            this.label6.TabIndex = 59;
            // 
            // label5
            // 
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.Location = new System.Drawing.Point(866, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(384, 816);
            this.label5.TabIndex = 72;
            // 
            // cbType
            // 
            this.cbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbType.FormattingEnabled = true;
            this.cbType.Location = new System.Drawing.Point(706, 350);
            this.cbType.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(121, 28);
            this.cbType.TabIndex = 78;
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.lblType.Location = new System.Drawing.Point(703, 325);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(38, 20);
            this.lblType.TabIndex = 77;
            this.lblType.Text = "Typ:";
            // 
            // tbWork
            // 
            this.tbWork.Location = new System.Drawing.Point(1318, 64);
            this.tbWork.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbWork.Multiline = true;
            this.tbWork.Name = "tbWork";
            this.tbWork.Size = new System.Drawing.Size(595, 719);
            this.tbWork.TabIndex = 79;
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1924, 845);
            this.Controls.Add(this.tbWork);
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
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form";
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
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbType;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.ColumnHeader chEpisode;
        private System.Windows.Forms.ColumnHeader chName;
        private System.Windows.Forms.ColumnHeader chTime;
        private System.Windows.Forms.ColumnHeader chCategory;
        private System.Windows.Forms.ColumnHeader chType;
        private System.Windows.Forms.TextBox tbWork;
    }
}

