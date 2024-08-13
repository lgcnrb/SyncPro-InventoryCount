namespace SyncPro
{
    partial class PasswordUpdateForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PasswordUpdateForm));
            this.GeneratePassButton = new System.Windows.Forms.Button();
            this.PasswordOldBox = new System.Windows.Forms.TextBox();
            this.SaveButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.PasswordReTextBox = new System.Windows.Forms.TextBox();
            this.PasswordList = new System.Windows.Forms.ImageList(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.SyncProStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.ShowHidePass = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // GeneratePassButton
            // 
            this.GeneratePassButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.GeneratePassButton.Location = new System.Drawing.Point(12, 116);
            this.GeneratePassButton.Name = "GeneratePassButton";
            this.GeneratePassButton.Size = new System.Drawing.Size(75, 23);
            this.GeneratePassButton.TabIndex = 75;
            this.GeneratePassButton.Text = "Genarate";
            this.GeneratePassButton.UseVisualStyleBackColor = true;
            this.GeneratePassButton.Click += new System.EventHandler(this.GeneratePassButton_Click);
            // 
            // PasswordOldBox
            // 
            this.PasswordOldBox.Location = new System.Drawing.Point(12, 25);
            this.PasswordOldBox.Name = "PasswordOldBox";
            this.PasswordOldBox.Size = new System.Drawing.Size(260, 20);
            this.PasswordOldBox.TabIndex = 1;
            this.PasswordOldBox.UseSystemPasswordChar = true;
            // 
            // SaveButton
            // 
            this.SaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveButton.Location = new System.Drawing.Point(197, 116);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 72;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 70;
            this.label3.Text = "New Password:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 69;
            this.label1.Text = "Old Password:";
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Location = new System.Drawing.Point(12, 64);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.Size = new System.Drawing.Size(260, 20);
            this.PasswordTextBox.TabIndex = 2;
            this.PasswordTextBox.UseSystemPasswordChar = true;
            // 
            // PasswordReTextBox
            // 
            this.PasswordReTextBox.Location = new System.Drawing.Point(12, 90);
            this.PasswordReTextBox.Name = "PasswordReTextBox";
            this.PasswordReTextBox.Size = new System.Drawing.Size(231, 20);
            this.PasswordReTextBox.TabIndex = 3;
            this.PasswordReTextBox.UseSystemPasswordChar = true;
            // 
            // PasswordList
            // 
            this.PasswordList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("PasswordList.ImageStream")));
            this.PasswordList.TransparentColor = System.Drawing.Color.Transparent;
            this.PasswordList.Images.SetKeyName(0, "HidePass-16.png");
            this.PasswordList.Images.SetKeyName(1, "ShowPass-16.png");
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SyncProStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 142);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(284, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 79;
            this.statusStrip1.Text = "statusStrip";
            // 
            // SyncProStatusLabel
            // 
            this.SyncProStatusLabel.Name = "SyncProStatusLabel";
            this.SyncProStatusLabel.Size = new System.Drawing.Size(269, 17);
            this.SyncProStatusLabel.Spring = true;
            this.SyncProStatusLabel.Text = "SyncPro";
            // 
            // ShowHidePass
            // 
            this.ShowHidePass.BackColor = System.Drawing.Color.Transparent;
            this.ShowHidePass.ImageIndex = 1;
            this.ShowHidePass.ImageList = this.PasswordList;
            this.ShowHidePass.Location = new System.Drawing.Point(248, 90);
            this.ShowHidePass.Name = "ShowHidePass";
            this.ShowHidePass.Size = new System.Drawing.Size(24, 20);
            this.ShowHidePass.TabIndex = 80;
            this.ShowHidePass.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ShowHidePass.Click += new System.EventHandler(this.ShowHidePass_Click);
            // 
            // PasswordUpdateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 164);
            this.Controls.Add(this.ShowHidePass);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.GeneratePassButton);
            this.Controls.Add(this.PasswordOldBox);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PasswordTextBox);
            this.Controls.Add(this.PasswordReTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PasswordUpdateForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Password Update";
            this.Load += new System.EventHandler(this.PasswordUpdateForm_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button GeneratePassButton;
        private System.Windows.Forms.TextBox PasswordOldBox;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox PasswordTextBox;
        private System.Windows.Forms.TextBox PasswordReTextBox;
        private System.Windows.Forms.ImageList PasswordList;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel SyncProStatusLabel;
        private System.Windows.Forms.Label ShowHidePass;
    }
}