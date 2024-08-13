﻿namespace SyncPro
{
    partial class SystemInventoryForm
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
            System.Windows.Forms.Label productCodeLabel;
            System.Windows.Forms.Label productNameLabel;
            System.Windows.Forms.Label locationLabel;
            System.Windows.Forms.Label batchCodeLabel;
            System.Windows.Forms.Label stockQuantityLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SystemInventoryForm));
            this.productCodeTextBox = new System.Windows.Forms.TextBox();
            this.productNameTextBox = new System.Windows.Forms.TextBox();
            this.locationTextBox = new System.Windows.Forms.TextBox();
            this.batchCodeTextBox = new System.Windows.Forms.TextBox();
            this.stockQuantityTextBox = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.SyncProStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.ExitButton = new System.Windows.Forms.Button();
            this.EnterButton = new System.Windows.Forms.Button();
            productCodeLabel = new System.Windows.Forms.Label();
            productNameLabel = new System.Windows.Forms.Label();
            locationLabel = new System.Windows.Forms.Label();
            batchCodeLabel = new System.Windows.Forms.Label();
            stockQuantityLabel = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // productCodeLabel
            // 
            productCodeLabel.AutoSize = true;
            productCodeLabel.Location = new System.Drawing.Point(12, 166);
            productCodeLabel.Name = "productCodeLabel";
            productCodeLabel.Size = new System.Drawing.Size(75, 13);
            productCodeLabel.TabIndex = 1;
            productCodeLabel.Text = "Product Code:";
            // 
            // productNameLabel
            // 
            productNameLabel.AutoSize = true;
            productNameLabel.Location = new System.Drawing.Point(12, 48);
            productNameLabel.Name = "productNameLabel";
            productNameLabel.Size = new System.Drawing.Size(78, 13);
            productNameLabel.TabIndex = 3;
            productNameLabel.Text = "Product Name:";
            // 
            // locationLabel
            // 
            locationLabel.AutoSize = true;
            locationLabel.Location = new System.Drawing.Point(12, 88);
            locationLabel.Name = "locationLabel";
            locationLabel.Size = new System.Drawing.Size(51, 13);
            locationLabel.TabIndex = 5;
            locationLabel.Text = "Location:";
            // 
            // batchCodeLabel
            // 
            batchCodeLabel.AutoSize = true;
            batchCodeLabel.Location = new System.Drawing.Point(12, 9);
            batchCodeLabel.Name = "batchCodeLabel";
            batchCodeLabel.Size = new System.Drawing.Size(66, 13);
            batchCodeLabel.TabIndex = 7;
            batchCodeLabel.Text = "Batch Code:";
            // 
            // stockQuantityLabel
            // 
            stockQuantityLabel.AutoSize = true;
            stockQuantityLabel.Location = new System.Drawing.Point(12, 127);
            stockQuantityLabel.Name = "stockQuantityLabel";
            stockQuantityLabel.Size = new System.Drawing.Size(80, 13);
            stockQuantityLabel.TabIndex = 9;
            stockQuantityLabel.Text = "Stock Quantity:";
            // 
            // productCodeTextBox
            // 
            this.productCodeTextBox.Enabled = false;
            this.productCodeTextBox.Location = new System.Drawing.Point(12, 182);
            this.productCodeTextBox.Name = "productCodeTextBox";
            this.productCodeTextBox.ReadOnly = true;
            this.productCodeTextBox.Size = new System.Drawing.Size(260, 20);
            this.productCodeTextBox.TabIndex = 2;
            // 
            // productNameTextBox
            // 
            this.productNameTextBox.Location = new System.Drawing.Point(12, 64);
            this.productNameTextBox.Name = "productNameTextBox";
            this.productNameTextBox.Size = new System.Drawing.Size(260, 20);
            this.productNameTextBox.TabIndex = 2;
            this.productNameTextBox.TextChanged += new System.EventHandler(this.productNameTextBox_TextChanged);
            // 
            // locationTextBox
            // 
            this.locationTextBox.Location = new System.Drawing.Point(12, 104);
            this.locationTextBox.Name = "locationTextBox";
            this.locationTextBox.Size = new System.Drawing.Size(260, 20);
            this.locationTextBox.TabIndex = 3;
            // 
            // batchCodeTextBox
            // 
            this.batchCodeTextBox.Location = new System.Drawing.Point(12, 25);
            this.batchCodeTextBox.Name = "batchCodeTextBox";
            this.batchCodeTextBox.Size = new System.Drawing.Size(260, 20);
            this.batchCodeTextBox.TabIndex = 1;
            this.batchCodeTextBox.TextChanged += new System.EventHandler(this.batchCodeTextBox_TextChanged);
            // 
            // stockQuantityTextBox
            // 
            this.stockQuantityTextBox.Location = new System.Drawing.Point(12, 143);
            this.stockQuantityTextBox.Name = "stockQuantityTextBox";
            this.stockQuantityTextBox.Size = new System.Drawing.Size(260, 20);
            this.stockQuantityTextBox.TabIndex = 4;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SyncProStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 235);
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
            // ExitButton
            // 
            this.ExitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ExitButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ExitButton.Location = new System.Drawing.Point(12, 209);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(75, 23);
            this.ExitButton.TabIndex = 6;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // EnterButton
            // 
            this.EnterButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.EnterButton.Location = new System.Drawing.Point(197, 209);
            this.EnterButton.Name = "EnterButton";
            this.EnterButton.Size = new System.Drawing.Size(75, 23);
            this.EnterButton.TabIndex = 5;
            this.EnterButton.Text = "Enter";
            this.EnterButton.UseVisualStyleBackColor = true;
            this.EnterButton.Click += new System.EventHandler(this.EnterButton_Click);
            // 
            // SystemInventoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 257);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.EnterButton);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(productCodeLabel);
            this.Controls.Add(this.productCodeTextBox);
            this.Controls.Add(productNameLabel);
            this.Controls.Add(this.productNameTextBox);
            this.Controls.Add(locationLabel);
            this.Controls.Add(this.locationTextBox);
            this.Controls.Add(batchCodeLabel);
            this.Controls.Add(this.batchCodeTextBox);
            this.Controls.Add(stockQuantityLabel);
            this.Controls.Add(this.stockQuantityTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SystemInventoryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "System Inventory Enter";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox productCodeTextBox;
        private System.Windows.Forms.TextBox productNameTextBox;
        private System.Windows.Forms.TextBox locationTextBox;
        private System.Windows.Forms.TextBox batchCodeTextBox;
        private System.Windows.Forms.TextBox stockQuantityTextBox;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel SyncProStatusLabel;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Button EnterButton;
    }
}