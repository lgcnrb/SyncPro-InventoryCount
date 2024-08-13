namespace SyncPro
{
    partial class InventoryCountInformationForm
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
            System.Windows.Forms.Label countedByLabel;
            System.Windows.Forms.Label auditorLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InventoryCountInformationForm));
            this.countedByTextBox = new System.Windows.Forms.TextBox();
            this.auditorTextBox = new System.Windows.Forms.TextBox();
            this.StartCounting = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.SyncProStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.ExitButton = new System.Windows.Forms.Button();
            countedByLabel = new System.Windows.Forms.Label();
            auditorLabel = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // countedByLabel
            // 
            countedByLabel.AutoSize = true;
            countedByLabel.Location = new System.Drawing.Point(12, 9);
            countedByLabel.Name = "countedByLabel";
            countedByLabel.Size = new System.Drawing.Size(65, 13);
            countedByLabel.TabIndex = 5;
            countedByLabel.Text = "Counted By:";
            // 
            // auditorLabel
            // 
            auditorLabel.AutoSize = true;
            auditorLabel.Location = new System.Drawing.Point(12, 48);
            auditorLabel.Name = "auditorLabel";
            auditorLabel.Size = new System.Drawing.Size(43, 13);
            auditorLabel.TabIndex = 7;
            auditorLabel.Text = "Auditor:";
            // 
            // countedByTextBox
            // 
            this.countedByTextBox.Location = new System.Drawing.Point(12, 25);
            this.countedByTextBox.Name = "countedByTextBox";
            this.countedByTextBox.ReadOnly = true;
            this.countedByTextBox.Size = new System.Drawing.Size(260, 20);
            this.countedByTextBox.TabIndex = 6;
            // 
            // auditorTextBox
            // 
            this.auditorTextBox.Location = new System.Drawing.Point(12, 66);
            this.auditorTextBox.Name = "auditorTextBox";
            this.auditorTextBox.Size = new System.Drawing.Size(260, 20);
            this.auditorTextBox.TabIndex = 8;
            // 
            // StartCounting
            // 
            this.StartCounting.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.StartCounting.Location = new System.Drawing.Point(197, 92);
            this.StartCounting.Name = "StartCounting";
            this.StartCounting.Size = new System.Drawing.Size(75, 23);
            this.StartCounting.TabIndex = 9;
            this.StartCounting.Text = "Start";
            this.StartCounting.UseVisualStyleBackColor = true;
            this.StartCounting.Click += new System.EventHandler(this.StartCounting_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SyncProStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 118);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(284, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 22;
            this.statusStrip1.Text = "statusStrip";
            // 
            // SyncProStatusLabel
            // 
            this.SyncProStatusLabel.Name = "SyncProStatusLabel";
            this.SyncProStatusLabel.Size = new System.Drawing.Size(269, 17);
            this.SyncProStatusLabel.Spring = true;
            this.SyncProStatusLabel.Text = "SyncPro";
            // 
            // ExitButton
            // 
            this.ExitButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ExitButton.Location = new System.Drawing.Point(12, 92);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(75, 23);
            this.ExitButton.TabIndex = 23;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // InventoryCountInformationForm
            // 
            this.AcceptButton = this.StartCounting;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.ExitButton;
            this.ClientSize = new System.Drawing.Size(284, 140);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.StartCounting);
            this.Controls.Add(countedByLabel);
            this.Controls.Add(this.countedByTextBox);
            this.Controls.Add(auditorLabel);
            this.Controls.Add(this.auditorTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "InventoryCountInformationForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Count Information";
            this.Load += new System.EventHandler(this.InventoryCountInformationForm_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox countedByTextBox;
        private System.Windows.Forms.TextBox auditorTextBox;
        private System.Windows.Forms.Button StartCounting;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel SyncProStatusLabel;
        private System.Windows.Forms.Button ExitButton;
    }
}