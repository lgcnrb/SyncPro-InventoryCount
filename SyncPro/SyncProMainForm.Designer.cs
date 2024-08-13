namespace SyncPro
{
    partial class SyncProMainForm
    {
        /// <summary> 
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Bileşen Tasarımcısı üretimi kod

        /// <summary> 
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SyncProMainForm));
            this.dateTimeLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.AboutButton = new System.Windows.Forms.Button();
            this.UserInformationButton = new System.Windows.Forms.Button();
            this.UserDashboardButton = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.StocktakingListButton = new System.Windows.Forms.Button();
            this.SystemInventoryButton = new System.Windows.Forms.Button();
            this.ProfileBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProfileBox)).BeginInit();
            this.SuspendLayout();
            // 
            // dateTimeLabel
            // 
            this.dateTimeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimeLabel.Location = new System.Drawing.Point(614, 509);
            this.dateTimeLabel.Name = "dateTimeLabel";
            this.dateTimeLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dateTimeLabel.Size = new System.Drawing.Size(202, 20);
            this.dateTimeLabel.TabIndex = 60;
            this.dateTimeLabel.Text = "Date";
            this.dateTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.Location = new System.Drawing.Point(614, 489);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label4.Size = new System.Drawing.Size(202, 20);
            this.label4.TabIndex = 59;
            this.label4.Text = "Role";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.Location = new System.Drawing.Point(614, 449);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(202, 20);
            this.label3.TabIndex = 58;
            this.label3.Text = "Username";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Location = new System.Drawing.Point(614, 469);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(202, 20);
            this.label2.TabIndex = 57;
            this.label2.Text = "Mail";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Location = new System.Drawing.Point(614, 429);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(202, 20);
            this.label1.TabIndex = 56;
            this.label1.Text = "Name";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 433);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(96, 96);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 61;
            this.pictureBox1.TabStop = false;
            // 
            // AboutButton
            // 
            this.AboutButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AboutButton.Image = ((System.Drawing.Image)(resources.GetObject("AboutButton.Image")));
            this.AboutButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.AboutButton.Location = new System.Drawing.Point(514, 50);
            this.AboutButton.Name = "AboutButton";
            this.AboutButton.Size = new System.Drawing.Size(110, 110);
            this.AboutButton.TabIndex = 66;
            this.AboutButton.Text = "About";
            this.AboutButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.AboutButton.UseVisualStyleBackColor = true;
            this.AboutButton.Click += new System.EventHandler(this.AboutButton_Click);
            // 
            // UserInformationButton
            // 
            this.UserInformationButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.UserInformationButton.Image = ((System.Drawing.Image)(resources.GetObject("UserInformationButton.Image")));
            this.UserInformationButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.UserInformationButton.Location = new System.Drawing.Point(398, 50);
            this.UserInformationButton.Name = "UserInformationButton";
            this.UserInformationButton.Size = new System.Drawing.Size(110, 110);
            this.UserInformationButton.TabIndex = 63;
            this.UserInformationButton.Text = "User Information";
            this.UserInformationButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.UserInformationButton.UseVisualStyleBackColor = true;
            this.UserInformationButton.Click += new System.EventHandler(this.UserInformationButton_Click);
            // 
            // UserDashboardButton
            // 
            this.UserDashboardButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.UserDashboardButton.Image = ((System.Drawing.Image)(resources.GetObject("UserDashboardButton.Image")));
            this.UserDashboardButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.UserDashboardButton.Location = new System.Drawing.Point(282, 50);
            this.UserDashboardButton.Name = "UserDashboardButton";
            this.UserDashboardButton.Size = new System.Drawing.Size(110, 110);
            this.UserDashboardButton.TabIndex = 62;
            this.UserDashboardButton.Text = "User Dashboard";
            this.UserDashboardButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.UserDashboardButton.UseVisualStyleBackColor = true;
            this.UserDashboardButton.Click += new System.EventHandler(this.UserDashboardButton_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // StocktakingListButton
            // 
            this.StocktakingListButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.StocktakingListButton.Image = ((System.Drawing.Image)(resources.GetObject("StocktakingListButton.Image")));
            this.StocktakingListButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.StocktakingListButton.Location = new System.Drawing.Point(166, 50);
            this.StocktakingListButton.Name = "StocktakingListButton";
            this.StocktakingListButton.Size = new System.Drawing.Size(110, 110);
            this.StocktakingListButton.TabIndex = 71;
            this.StocktakingListButton.Text = "Stocktaking List";
            this.StocktakingListButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.StocktakingListButton.UseVisualStyleBackColor = true;
            this.StocktakingListButton.Click += new System.EventHandler(this.StocktakingListButton_Click);
            // 
            // SystemInventoryButton
            // 
            this.SystemInventoryButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SystemInventoryButton.Image = ((System.Drawing.Image)(resources.GetObject("SystemInventoryButton.Image")));
            this.SystemInventoryButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.SystemInventoryButton.Location = new System.Drawing.Point(50, 50);
            this.SystemInventoryButton.Name = "SystemInventoryButton";
            this.SystemInventoryButton.Size = new System.Drawing.Size(110, 110);
            this.SystemInventoryButton.TabIndex = 72;
            this.SystemInventoryButton.Text = "System Inventory";
            this.SystemInventoryButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.SystemInventoryButton.UseVisualStyleBackColor = true;
            this.SystemInventoryButton.Click += new System.EventHandler(this.SystemInventoryButton_Click);
            // 
            // ProfileBox
            // 
            this.ProfileBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ProfileBox.Location = new System.Drawing.Point(822, 433);
            this.ProfileBox.Name = "ProfileBox";
            this.ProfileBox.Size = new System.Drawing.Size(96, 96);
            this.ProfileBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ProfileBox.TabIndex = 73;
            this.ProfileBox.TabStop = false;
            // 
            // SyncProMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ProfileBox);
            this.Controls.Add(this.SystemInventoryButton);
            this.Controls.Add(this.StocktakingListButton);
            this.Controls.Add(this.AboutButton);
            this.Controls.Add(this.UserInformationButton);
            this.Controls.Add(this.UserDashboardButton);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dateTimeLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "SyncProMainForm";
            this.Size = new System.Drawing.Size(921, 533);
            this.Load += new System.EventHandler(this.SyncProMainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProfileBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label dateTimeLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button AboutButton;
        private System.Windows.Forms.Button UserInformationButton;
        private System.Windows.Forms.Button UserDashboardButton;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button StocktakingListButton;
        private System.Windows.Forms.Button SystemInventoryButton;
        private System.Windows.Forms.PictureBox ProfileBox;
    }
}
