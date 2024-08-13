namespace SyncPro
{
    partial class RestoreDatabaseForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RestoreDatabaseForm));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.SyncProStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.BackupList = new System.Windows.Forms.CheckedListBox();
            this.RestoreButton = new System.Windows.Forms.Button();
            this.lblDatabaseName = new System.Windows.Forms.Label();
            this.lblEdition = new System.Windows.Forms.Label();
            this.lblProductVersion = new System.Windows.Forms.Label();
            this.lblInstanceName = new System.Windows.Forms.Label();
            this.lblMachineName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SyncProStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 369);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(284, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 23;
            this.statusStrip1.Text = "statusStrip";
            // 
            // SyncProStatusLabel
            // 
            this.SyncProStatusLabel.Name = "SyncProStatusLabel";
            this.SyncProStatusLabel.Size = new System.Drawing.Size(269, 17);
            this.SyncProStatusLabel.Spring = true;
            this.SyncProStatusLabel.Text = "SyncPro";
            // 
            // BackupList
            // 
            this.BackupList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.BackupList.CheckOnClick = true;
            this.BackupList.FormattingEnabled = true;
            this.BackupList.Location = new System.Drawing.Point(12, 25);
            this.BackupList.Name = "BackupList";
            this.BackupList.ScrollAlwaysVisible = true;
            this.BackupList.Size = new System.Drawing.Size(260, 165);
            this.BackupList.TabIndex = 24;
            this.BackupList.UseCompatibleTextRendering = true;
            // 
            // RestoreButton
            // 
            this.RestoreButton.Location = new System.Drawing.Point(197, 343);
            this.RestoreButton.Name = "RestoreButton";
            this.RestoreButton.Size = new System.Drawing.Size(75, 23);
            this.RestoreButton.TabIndex = 25;
            this.RestoreButton.Text = "Restore";
            this.RestoreButton.UseVisualStyleBackColor = true;
            this.RestoreButton.Click += new System.EventHandler(this.RestoreButton_Click);
            // 
            // lblDatabaseName
            // 
            this.lblDatabaseName.Location = new System.Drawing.Point(12, 285);
            this.lblDatabaseName.Name = "lblDatabaseName";
            this.lblDatabaseName.Size = new System.Drawing.Size(260, 55);
            this.lblDatabaseName.TabIndex = 40;
            this.lblDatabaseName.Text = "lblDatabaseName";
            this.lblDatabaseName.UseCompatibleTextRendering = true;
            // 
            // lblEdition
            // 
            this.lblEdition.Location = new System.Drawing.Point(12, 262);
            this.lblEdition.Name = "lblEdition";
            this.lblEdition.Size = new System.Drawing.Size(260, 23);
            this.lblEdition.TabIndex = 39;
            this.lblEdition.Text = "lblEdition";
            this.lblEdition.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblProductVersion
            // 
            this.lblProductVersion.Location = new System.Drawing.Point(12, 239);
            this.lblProductVersion.Name = "lblProductVersion";
            this.lblProductVersion.Size = new System.Drawing.Size(260, 23);
            this.lblProductVersion.TabIndex = 38;
            this.lblProductVersion.Text = "lblProductVersion";
            this.lblProductVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblInstanceName
            // 
            this.lblInstanceName.Location = new System.Drawing.Point(12, 216);
            this.lblInstanceName.Name = "lblInstanceName";
            this.lblInstanceName.Size = new System.Drawing.Size(260, 23);
            this.lblInstanceName.TabIndex = 37;
            this.lblInstanceName.Text = "lblInstanceName";
            this.lblInstanceName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMachineName
            // 
            this.lblMachineName.Location = new System.Drawing.Point(12, 193);
            this.lblMachineName.Name = "lblMachineName";
            this.lblMachineName.Size = new System.Drawing.Size(260, 23);
            this.lblMachineName.TabIndex = 36;
            this.lblMachineName.Text = "lblMachineName";
            this.lblMachineName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 41;
            this.label1.Text = "Backups:";
            // 
            // RestoreDatabaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 391);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblDatabaseName);
            this.Controls.Add(this.lblEdition);
            this.Controls.Add(this.lblProductVersion);
            this.Controls.Add(this.lblInstanceName);
            this.Controls.Add(this.lblMachineName);
            this.Controls.Add(this.RestoreButton);
            this.Controls.Add(this.BackupList);
            this.Controls.Add(this.statusStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RestoreDatabaseForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Restore Database";
            this.Load += new System.EventHandler(this.RestoreDatabaseForm_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel SyncProStatusLabel;
        private System.Windows.Forms.CheckedListBox BackupList;
        private System.Windows.Forms.Button RestoreButton;
        private System.Windows.Forms.Label lblDatabaseName;
        private System.Windows.Forms.Label lblEdition;
        private System.Windows.Forms.Label lblProductVersion;
        private System.Windows.Forms.Label lblInstanceName;
        private System.Windows.Forms.Label lblMachineName;
        private System.Windows.Forms.Label label1;
    }
}