namespace SyncPro
{
    partial class CountEditingForm
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
            System.Windows.Forms.Label locationLabel;
            System.Windows.Forms.Label countedQuantityLabel;
            System.Windows.Forms.Label productNameLabel;
            System.Windows.Forms.Label productCodeLabel;
            System.Windows.Forms.Label batchCodeLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CountEditingForm));
            this.locationTextBox = new System.Windows.Forms.TextBox();
            this.productNameTextBox = new System.Windows.Forms.TextBox();
            this.countedQuantityTextBox = new System.Windows.Forms.TextBox();
            this.batchCodeTextBox = new System.Windows.Forms.TextBox();
            this.productCodeTextBox = new System.Windows.Forms.TextBox();
            this.ExitButton = new System.Windows.Forms.Button();
            this.EnterButton = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.SyncProStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            locationLabel = new System.Windows.Forms.Label();
            countedQuantityLabel = new System.Windows.Forms.Label();
            productNameLabel = new System.Windows.Forms.Label();
            productCodeLabel = new System.Windows.Forms.Label();
            batchCodeLabel = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // locationLabel
            // 
            locationLabel.AutoSize = true;
            locationLabel.Location = new System.Drawing.Point(12, 83);
            locationLabel.Name = "locationLabel";
            locationLabel.Size = new System.Drawing.Size(51, 13);
            locationLabel.TabIndex = 58;
            locationLabel.Text = "Location:";
            // 
            // countedQuantityLabel
            // 
            countedQuantityLabel.AutoSize = true;
            countedQuantityLabel.Location = new System.Drawing.Point(12, 122);
            countedQuantityLabel.Name = "countedQuantityLabel";
            countedQuantityLabel.Size = new System.Drawing.Size(92, 13);
            countedQuantityLabel.TabIndex = 60;
            countedQuantityLabel.Text = "Counted Quantity:";
            // 
            // productNameLabel
            // 
            productNameLabel.AutoSize = true;
            productNameLabel.Location = new System.Drawing.Point(12, 44);
            productNameLabel.Name = "productNameLabel";
            productNameLabel.Size = new System.Drawing.Size(78, 13);
            productNameLabel.TabIndex = 57;
            productNameLabel.Text = "Product Name:";
            // 
            // productCodeLabel
            // 
            productCodeLabel.AutoSize = true;
            productCodeLabel.Location = new System.Drawing.Point(12, 161);
            productCodeLabel.Name = "productCodeLabel";
            productCodeLabel.Size = new System.Drawing.Size(75, 13);
            productCodeLabel.TabIndex = 55;
            productCodeLabel.Text = "Product Code:";
            // 
            // batchCodeLabel
            // 
            batchCodeLabel.AutoSize = true;
            batchCodeLabel.Location = new System.Drawing.Point(12, 5);
            batchCodeLabel.Name = "batchCodeLabel";
            batchCodeLabel.Size = new System.Drawing.Size(66, 13);
            batchCodeLabel.TabIndex = 59;
            batchCodeLabel.Text = "Batch Code:";
            // 
            // locationTextBox
            // 
            this.locationTextBox.Location = new System.Drawing.Point(12, 99);
            this.locationTextBox.Name = "locationTextBox";
            this.locationTextBox.Size = new System.Drawing.Size(260, 20);
            this.locationTextBox.TabIndex = 52;
            this.locationTextBox.TextChanged += new System.EventHandler(this.locationTextBox_TextChanged);
            // 
            // productNameTextBox
            // 
            this.productNameTextBox.Location = new System.Drawing.Point(12, 60);
            this.productNameTextBox.Name = "productNameTextBox";
            this.productNameTextBox.Size = new System.Drawing.Size(260, 20);
            this.productNameTextBox.TabIndex = 51;
            this.productNameTextBox.TextChanged += new System.EventHandler(this.productNameTextBox_TextChanged);
            // 
            // countedQuantityTextBox
            // 
            this.countedQuantityTextBox.Location = new System.Drawing.Point(12, 138);
            this.countedQuantityTextBox.Name = "countedQuantityTextBox";
            this.countedQuantityTextBox.Size = new System.Drawing.Size(260, 20);
            this.countedQuantityTextBox.TabIndex = 53;
            this.countedQuantityTextBox.TextChanged += new System.EventHandler(this.countedQuantityTextBox_TextChanged);
            // 
            // batchCodeTextBox
            // 
            this.batchCodeTextBox.Enabled = false;
            this.batchCodeTextBox.Location = new System.Drawing.Point(12, 21);
            this.batchCodeTextBox.Name = "batchCodeTextBox";
            this.batchCodeTextBox.ReadOnly = true;
            this.batchCodeTextBox.Size = new System.Drawing.Size(260, 20);
            this.batchCodeTextBox.TabIndex = 50;
            // 
            // productCodeTextBox
            // 
            this.productCodeTextBox.Enabled = false;
            this.productCodeTextBox.Location = new System.Drawing.Point(12, 177);
            this.productCodeTextBox.Name = "productCodeTextBox";
            this.productCodeTextBox.ReadOnly = true;
            this.productCodeTextBox.Size = new System.Drawing.Size(260, 20);
            this.productCodeTextBox.TabIndex = 56;
            // 
            // ExitButton
            // 
            this.ExitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ExitButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ExitButton.Location = new System.Drawing.Point(12, 209);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(75, 23);
            this.ExitButton.TabIndex = 62;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.EnterButton_Click);
            // 
            // EnterButton
            // 
            this.EnterButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.EnterButton.Location = new System.Drawing.Point(197, 209);
            this.EnterButton.Name = "EnterButton";
            this.EnterButton.Size = new System.Drawing.Size(75, 23);
            this.EnterButton.TabIndex = 61;
            this.EnterButton.Text = "Enter";
            this.EnterButton.UseVisualStyleBackColor = true;
            this.EnterButton.Click += new System.EventHandler(this.EnterButton_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SyncProStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 235);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(284, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 54;
            this.statusStrip1.Text = "statusStrip";
            // 
            // SyncProStatusLabel
            // 
            this.SyncProStatusLabel.Name = "SyncProStatusLabel";
            this.SyncProStatusLabel.Size = new System.Drawing.Size(269, 17);
            this.SyncProStatusLabel.Spring = true;
            this.SyncProStatusLabel.Text = "SyncPro";
            // 
            // CountEditingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 257);
            this.Controls.Add(locationLabel);
            this.Controls.Add(this.locationTextBox);
            this.Controls.Add(this.productNameTextBox);
            this.Controls.Add(countedQuantityLabel);
            this.Controls.Add(productNameLabel);
            this.Controls.Add(this.countedQuantityTextBox);
            this.Controls.Add(this.batchCodeTextBox);
            this.Controls.Add(productCodeLabel);
            this.Controls.Add(batchCodeLabel);
            this.Controls.Add(this.productCodeTextBox);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.EnterButton);
            this.Controls.Add(this.statusStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CountEditingForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Count Editing";
            this.Load += new System.EventHandler(this.CountEditingForm_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox locationTextBox;
        private System.Windows.Forms.TextBox productNameTextBox;
        private System.Windows.Forms.TextBox countedQuantityTextBox;
        private System.Windows.Forms.TextBox batchCodeTextBox;
        private System.Windows.Forms.TextBox productCodeTextBox;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Button EnterButton;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel SyncProStatusLabel;
    }
}