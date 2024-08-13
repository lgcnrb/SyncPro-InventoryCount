namespace SyncPro
{
    partial class DataBackupForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataBackupForm));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.SyncProStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.DatabaseTables = new System.Windows.Forms.CheckedListBox();
            this.BackupDatabaseButton = new System.Windows.Forms.Button();
            this.BackupSelectedTablesButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblMachineName = new System.Windows.Forms.Label();
            this.lblInstanceName = new System.Windows.Forms.Label();
            this.lblProductVersion = new System.Windows.Forms.Label();
            this.lblEdition = new System.Windows.Forms.Label();
            this.lblDatabaseName = new System.Windows.Forms.Label();
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
            this.statusStrip1.TabIndex = 25;
            this.statusStrip1.Text = "statusStrip";
            // 
            // SyncProStatusLabel
            // 
            this.SyncProStatusLabel.Name = "SyncProStatusLabel";
            this.SyncProStatusLabel.Size = new System.Drawing.Size(269, 17);
            this.SyncProStatusLabel.Spring = true;
            this.SyncProStatusLabel.Text = "SyncPro";
            // 
            // DatabaseTables
            // 
            this.DatabaseTables.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DatabaseTables.FormattingEnabled = true;
            this.DatabaseTables.Location = new System.Drawing.Point(12, 25);
            this.DatabaseTables.Name = "DatabaseTables";
            this.DatabaseTables.ScrollAlwaysVisible = true;
            this.DatabaseTables.Size = new System.Drawing.Size(260, 165);
            this.DatabaseTables.TabIndex = 26;
            // 
            // BackupDatabaseButton
            // 
            this.BackupDatabaseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BackupDatabaseButton.Location = new System.Drawing.Point(197, 343);
            this.BackupDatabaseButton.Name = "BackupDatabaseButton";
            this.BackupDatabaseButton.Size = new System.Drawing.Size(75, 23);
            this.BackupDatabaseButton.TabIndex = 28;
            this.BackupDatabaseButton.Text = "Backup All";
            this.BackupDatabaseButton.UseVisualStyleBackColor = true;
            this.BackupDatabaseButton.Click += new System.EventHandler(this.btnBackupAll_Click);
            // 
            // BackupSelectedTablesButton
            // 
            this.BackupSelectedTablesButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BackupSelectedTablesButton.Location = new System.Drawing.Point(12, 343);
            this.BackupSelectedTablesButton.Name = "BackupSelectedTablesButton";
            this.BackupSelectedTablesButton.Size = new System.Drawing.Size(75, 23);
            this.BackupSelectedTablesButton.TabIndex = 29;
            this.BackupSelectedTablesButton.Text = "Backup Sel";
            this.BackupSelectedTablesButton.UseVisualStyleBackColor = true;
            this.BackupSelectedTablesButton.Click += new System.EventHandler(this.btnBackupSelected_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 30;
            this.label1.Text = "Tables:";
            // 
            // lblMachineName
            // 
            this.lblMachineName.Location = new System.Drawing.Point(12, 193);
            this.lblMachineName.Name = "lblMachineName";
            this.lblMachineName.Size = new System.Drawing.Size(260, 23);
            this.lblMachineName.TabIndex = 31;
            this.lblMachineName.Text = "lblMachineName";
            this.lblMachineName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblInstanceName
            // 
            this.lblInstanceName.Location = new System.Drawing.Point(12, 216);
            this.lblInstanceName.Name = "lblInstanceName";
            this.lblInstanceName.Size = new System.Drawing.Size(260, 23);
            this.lblInstanceName.TabIndex = 32;
            this.lblInstanceName.Text = "lblInstanceName";
            this.lblInstanceName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblProductVersion
            // 
            this.lblProductVersion.Location = new System.Drawing.Point(12, 239);
            this.lblProductVersion.Name = "lblProductVersion";
            this.lblProductVersion.Size = new System.Drawing.Size(260, 23);
            this.lblProductVersion.TabIndex = 33;
            this.lblProductVersion.Text = "lblProductVersion";
            this.lblProductVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblEdition
            // 
            this.lblEdition.Location = new System.Drawing.Point(12, 262);
            this.lblEdition.Name = "lblEdition";
            this.lblEdition.Size = new System.Drawing.Size(260, 23);
            this.lblEdition.TabIndex = 34;
            this.lblEdition.Text = "lblEdition";
            this.lblEdition.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDatabaseName
            // 
            this.lblDatabaseName.Location = new System.Drawing.Point(12, 285);
            this.lblDatabaseName.Name = "lblDatabaseName";
            this.lblDatabaseName.Size = new System.Drawing.Size(260, 55);
            this.lblDatabaseName.TabIndex = 35;
            this.lblDatabaseName.Text = "lblDatabaseName";
            this.lblDatabaseName.UseCompatibleTextRendering = true;
            // 
            // DataBackupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 391);
            this.Controls.Add(this.lblDatabaseName);
            this.Controls.Add(this.lblEdition);
            this.Controls.Add(this.lblProductVersion);
            this.Controls.Add(this.lblInstanceName);
            this.Controls.Add(this.lblMachineName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BackupSelectedTablesButton);
            this.Controls.Add(this.BackupDatabaseButton);
            this.Controls.Add(this.DatabaseTables);
            this.Controls.Add(this.statusStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DataBackupForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Data Backup";
            this.Load += new System.EventHandler(this.DataBackupForm_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel SyncProStatusLabel;
        private System.Windows.Forms.Button BackupDatabaseButton;
        private System.Windows.Forms.Button BackupSelectedTablesButton;
        private System.Windows.Forms.CheckedListBox DatabaseTables;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblMachineName;
        private System.Windows.Forms.Label lblInstanceName;
        private System.Windows.Forms.Label lblProductVersion;
        private System.Windows.Forms.Label lblEdition;
        private System.Windows.Forms.Label lblDatabaseName;
    }
}