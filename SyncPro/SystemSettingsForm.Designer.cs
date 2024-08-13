namespace SyncPro
{
    partial class SystemSettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SystemSettingsForm));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.SyncProStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.GeneratorSettings = new System.Windows.Forms.GroupBox();
            this.PassButton = new System.Windows.Forms.Button();
            this.PasswordLength = new System.Windows.Forms.Label();
            this.PasswordLengthNumbers = new System.Windows.Forms.NumericUpDown();
            this.NumbersCheckBox = new System.Windows.Forms.CheckBox();
            this.NumbersBox = new System.Windows.Forms.TextBox();
            this.Numbers = new System.Windows.Forms.Label();
            this.SpecialCheckBox = new System.Windows.Forms.CheckBox();
            this.SpecialBox = new System.Windows.Forms.TextBox();
            this.SpecialCharacter = new System.Windows.Forms.Label();
            this.UpperCheckBox = new System.Windows.Forms.CheckBox();
            this.UpperBox = new System.Windows.Forms.TextBox();
            this.UpperCase = new System.Windows.Forms.Label();
            this.LowerCheckBox = new System.Windows.Forms.CheckBox();
            this.LowerBox = new System.Windows.Forms.TextBox();
            this.LowerCase = new System.Windows.Forms.Label();
            this.BackupLocation = new System.Windows.Forms.GroupBox();
            this.ChooseBackup = new System.Windows.Forms.Button();
            this.BackupButton = new System.Windows.Forms.Button();
            this.BackupBox = new System.Windows.Forms.TextBox();
            this.ProductsFile = new System.Windows.Forms.GroupBox();
            this.ChooseProducts = new System.Windows.Forms.Button();
            this.ProductsButton = new System.Windows.Forms.Button();
            this.ProductsBox = new System.Windows.Forms.TextBox();
            this.ServerConnection = new System.Windows.Forms.GroupBox();
            this.ServerButton = new System.Windows.Forms.Button();
            this.ServerBox = new System.Windows.Forms.TextBox();
            this.Damain = new System.Windows.Forms.GroupBox();
            this.DomainComboBox = new System.Windows.Forms.ComboBox();
            this.DomainButton = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.GeneratorSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PasswordLengthNumbers)).BeginInit();
            this.BackupLocation.SuspendLayout();
            this.ProductsFile.SuspendLayout();
            this.ServerConnection.SuspendLayout();
            this.Damain.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SyncProStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 357);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(641, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 59;
            this.statusStrip1.Text = "statusStrip";
            // 
            // SyncProStatusLabel
            // 
            this.SyncProStatusLabel.Name = "SyncProStatusLabel";
            this.SyncProStatusLabel.Size = new System.Drawing.Size(626, 17);
            this.SyncProStatusLabel.Spring = true;
            this.SyncProStatusLabel.Text = "SyncPro";
            // 
            // GeneratorSettings
            // 
            this.GeneratorSettings.Controls.Add(this.PassButton);
            this.GeneratorSettings.Controls.Add(this.PasswordLength);
            this.GeneratorSettings.Controls.Add(this.PasswordLengthNumbers);
            this.GeneratorSettings.Controls.Add(this.NumbersCheckBox);
            this.GeneratorSettings.Controls.Add(this.NumbersBox);
            this.GeneratorSettings.Controls.Add(this.Numbers);
            this.GeneratorSettings.Controls.Add(this.SpecialCheckBox);
            this.GeneratorSettings.Controls.Add(this.SpecialBox);
            this.GeneratorSettings.Controls.Add(this.SpecialCharacter);
            this.GeneratorSettings.Controls.Add(this.UpperCheckBox);
            this.GeneratorSettings.Controls.Add(this.UpperBox);
            this.GeneratorSettings.Controls.Add(this.UpperCase);
            this.GeneratorSettings.Controls.Add(this.LowerCheckBox);
            this.GeneratorSettings.Controls.Add(this.LowerBox);
            this.GeneratorSettings.Controls.Add(this.LowerCase);
            this.GeneratorSettings.Location = new System.Drawing.Point(12, 12);
            this.GeneratorSettings.Name = "GeneratorSettings";
            this.GeneratorSettings.Size = new System.Drawing.Size(617, 126);
            this.GeneratorSettings.TabIndex = 60;
            this.GeneratorSettings.TabStop = false;
            this.GeneratorSettings.Text = "Password Generator Settings:";
            // 
            // PassButton
            // 
            this.PassButton.Location = new System.Drawing.Point(536, 97);
            this.PassButton.Name = "PassButton";
            this.PassButton.Size = new System.Drawing.Size(75, 23);
            this.PassButton.TabIndex = 14;
            this.PassButton.Text = "Save";
            this.PassButton.UseVisualStyleBackColor = true;
            this.PassButton.Click += new System.EventHandler(this.PassButton_Click);
            // 
            // PasswordLength
            // 
            this.PasswordLength.AutoSize = true;
            this.PasswordLength.Location = new System.Drawing.Point(6, 99);
            this.PasswordLength.Name = "PasswordLength";
            this.PasswordLength.Size = new System.Drawing.Size(92, 13);
            this.PasswordLength.TabIndex = 13;
            this.PasswordLength.Text = "Password Length:";
            // 
            // PasswordLengthNumbers
            // 
            this.PasswordLengthNumbers.Location = new System.Drawing.Point(104, 97);
            this.PasswordLengthNumbers.Name = "PasswordLengthNumbers";
            this.PasswordLengthNumbers.Size = new System.Drawing.Size(84, 20);
            this.PasswordLengthNumbers.TabIndex = 12;
            // 
            // NumbersCheckBox
            // 
            this.NumbersCheckBox.AutoSize = true;
            this.NumbersCheckBox.Location = new System.Drawing.Point(596, 74);
            this.NumbersCheckBox.Name = "NumbersCheckBox";
            this.NumbersCheckBox.Size = new System.Drawing.Size(15, 14);
            this.NumbersCheckBox.TabIndex = 11;
            this.NumbersCheckBox.UseVisualStyleBackColor = true;
            // 
            // NumbersBox
            // 
            this.NumbersBox.Location = new System.Drawing.Point(313, 71);
            this.NumbersBox.Name = "NumbersBox";
            this.NumbersBox.Size = new System.Drawing.Size(277, 20);
            this.NumbersBox.TabIndex = 10;
            // 
            // Numbers
            // 
            this.Numbers.AutoSize = true;
            this.Numbers.Location = new System.Drawing.Point(310, 55);
            this.Numbers.Name = "Numbers";
            this.Numbers.Size = new System.Drawing.Size(52, 13);
            this.Numbers.TabIndex = 9;
            this.Numbers.Text = "Numbers:";
            // 
            // SpecialCheckBox
            // 
            this.SpecialCheckBox.AutoSize = true;
            this.SpecialCheckBox.Location = new System.Drawing.Point(596, 35);
            this.SpecialCheckBox.Name = "SpecialCheckBox";
            this.SpecialCheckBox.Size = new System.Drawing.Size(15, 14);
            this.SpecialCheckBox.TabIndex = 8;
            this.SpecialCheckBox.UseVisualStyleBackColor = true;
            // 
            // SpecialBox
            // 
            this.SpecialBox.Location = new System.Drawing.Point(313, 32);
            this.SpecialBox.Name = "SpecialBox";
            this.SpecialBox.Size = new System.Drawing.Size(277, 20);
            this.SpecialBox.TabIndex = 7;
            // 
            // SpecialCharacter
            // 
            this.SpecialCharacter.AutoSize = true;
            this.SpecialCharacter.Location = new System.Drawing.Point(310, 16);
            this.SpecialCharacter.Name = "SpecialCharacter";
            this.SpecialCharacter.Size = new System.Drawing.Size(94, 13);
            this.SpecialCharacter.TabIndex = 6;
            this.SpecialCharacter.Text = "Special Character:";
            // 
            // UpperCheckBox
            // 
            this.UpperCheckBox.AutoSize = true;
            this.UpperCheckBox.Location = new System.Drawing.Point(292, 74);
            this.UpperCheckBox.Name = "UpperCheckBox";
            this.UpperCheckBox.Size = new System.Drawing.Size(15, 14);
            this.UpperCheckBox.TabIndex = 5;
            this.UpperCheckBox.UseVisualStyleBackColor = true;
            // 
            // UpperBox
            // 
            this.UpperBox.Location = new System.Drawing.Point(9, 71);
            this.UpperBox.Name = "UpperBox";
            this.UpperBox.Size = new System.Drawing.Size(277, 20);
            this.UpperBox.TabIndex = 4;
            // 
            // UpperCase
            // 
            this.UpperCase.AutoSize = true;
            this.UpperCase.Location = new System.Drawing.Point(6, 55);
            this.UpperCase.Name = "UpperCase";
            this.UpperCase.Size = new System.Drawing.Size(63, 13);
            this.UpperCase.TabIndex = 3;
            this.UpperCase.Text = "Upper Case";
            // 
            // LowerCheckBox
            // 
            this.LowerCheckBox.AutoSize = true;
            this.LowerCheckBox.Location = new System.Drawing.Point(292, 35);
            this.LowerCheckBox.Name = "LowerCheckBox";
            this.LowerCheckBox.Size = new System.Drawing.Size(15, 14);
            this.LowerCheckBox.TabIndex = 2;
            this.LowerCheckBox.UseVisualStyleBackColor = true;
            // 
            // LowerBox
            // 
            this.LowerBox.Location = new System.Drawing.Point(9, 32);
            this.LowerBox.Name = "LowerBox";
            this.LowerBox.Size = new System.Drawing.Size(277, 20);
            this.LowerBox.TabIndex = 1;
            // 
            // LowerCase
            // 
            this.LowerCase.AutoSize = true;
            this.LowerCase.Location = new System.Drawing.Point(6, 16);
            this.LowerCase.Name = "LowerCase";
            this.LowerCase.Size = new System.Drawing.Size(66, 13);
            this.LowerCase.TabIndex = 0;
            this.LowerCase.Text = "Lower Case:";
            // 
            // BackupLocation
            // 
            this.BackupLocation.Controls.Add(this.ChooseBackup);
            this.BackupLocation.Controls.Add(this.BackupButton);
            this.BackupLocation.Controls.Add(this.BackupBox);
            this.BackupLocation.Location = new System.Drawing.Point(12, 144);
            this.BackupLocation.Name = "BackupLocation";
            this.BackupLocation.Size = new System.Drawing.Size(617, 46);
            this.BackupLocation.TabIndex = 61;
            this.BackupLocation.TabStop = false;
            this.BackupLocation.Text = "Backup Location";
            // 
            // ChooseBackup
            // 
            this.ChooseBackup.Location = new System.Drawing.Point(455, 17);
            this.ChooseBackup.Name = "ChooseBackup";
            this.ChooseBackup.Size = new System.Drawing.Size(75, 23);
            this.ChooseBackup.TabIndex = 15;
            this.ChooseBackup.Text = "Choose";
            this.ChooseBackup.UseVisualStyleBackColor = true;
            this.ChooseBackup.Click += new System.EventHandler(this.ChooseBackup_Click);
            // 
            // BackupButton
            // 
            this.BackupButton.Location = new System.Drawing.Point(536, 17);
            this.BackupButton.Name = "BackupButton";
            this.BackupButton.Size = new System.Drawing.Size(75, 23);
            this.BackupButton.TabIndex = 14;
            this.BackupButton.Text = "Save";
            this.BackupButton.UseVisualStyleBackColor = true;
            this.BackupButton.Click += new System.EventHandler(this.BackupButton_Click);
            // 
            // BackupBox
            // 
            this.BackupBox.Location = new System.Drawing.Point(6, 19);
            this.BackupBox.Name = "BackupBox";
            this.BackupBox.Size = new System.Drawing.Size(440, 20);
            this.BackupBox.TabIndex = 1;
            // 
            // ProductsFile
            // 
            this.ProductsFile.Controls.Add(this.ChooseProducts);
            this.ProductsFile.Controls.Add(this.ProductsButton);
            this.ProductsFile.Controls.Add(this.ProductsBox);
            this.ProductsFile.Location = new System.Drawing.Point(12, 196);
            this.ProductsFile.Name = "ProductsFile";
            this.ProductsFile.Size = new System.Drawing.Size(617, 46);
            this.ProductsFile.TabIndex = 62;
            this.ProductsFile.TabStop = false;
            this.ProductsFile.Text = "Products File";
            // 
            // ChooseProducts
            // 
            this.ChooseProducts.Location = new System.Drawing.Point(455, 17);
            this.ChooseProducts.Name = "ChooseProducts";
            this.ChooseProducts.Size = new System.Drawing.Size(75, 23);
            this.ChooseProducts.TabIndex = 15;
            this.ChooseProducts.Text = "Choose";
            this.ChooseProducts.UseVisualStyleBackColor = true;
            this.ChooseProducts.Click += new System.EventHandler(this.ChooseProducts_Click);
            // 
            // ProductsButton
            // 
            this.ProductsButton.Location = new System.Drawing.Point(536, 17);
            this.ProductsButton.Name = "ProductsButton";
            this.ProductsButton.Size = new System.Drawing.Size(75, 23);
            this.ProductsButton.TabIndex = 14;
            this.ProductsButton.Text = "Save";
            this.ProductsButton.UseVisualStyleBackColor = true;
            this.ProductsButton.Click += new System.EventHandler(this.ProductsButton_Click);
            // 
            // ProductsBox
            // 
            this.ProductsBox.Location = new System.Drawing.Point(6, 19);
            this.ProductsBox.Name = "ProductsBox";
            this.ProductsBox.Size = new System.Drawing.Size(440, 20);
            this.ProductsBox.TabIndex = 1;
            // 
            // ServerConnection
            // 
            this.ServerConnection.Controls.Add(this.ServerButton);
            this.ServerConnection.Controls.Add(this.ServerBox);
            this.ServerConnection.Location = new System.Drawing.Point(12, 248);
            this.ServerConnection.Name = "ServerConnection";
            this.ServerConnection.Size = new System.Drawing.Size(617, 46);
            this.ServerConnection.TabIndex = 63;
            this.ServerConnection.TabStop = false;
            this.ServerConnection.Text = "Server Connection";
            // 
            // ServerButton
            // 
            this.ServerButton.Location = new System.Drawing.Point(536, 17);
            this.ServerButton.Name = "ServerButton";
            this.ServerButton.Size = new System.Drawing.Size(75, 23);
            this.ServerButton.TabIndex = 14;
            this.ServerButton.Text = "Save";
            this.ServerButton.UseVisualStyleBackColor = true;
            this.ServerButton.Click += new System.EventHandler(this.ServerButton_Click);
            // 
            // ServerBox
            // 
            this.ServerBox.Location = new System.Drawing.Point(6, 19);
            this.ServerBox.Name = "ServerBox";
            this.ServerBox.Size = new System.Drawing.Size(524, 20);
            this.ServerBox.TabIndex = 1;
            // 
            // Damain
            // 
            this.Damain.Controls.Add(this.DomainComboBox);
            this.Damain.Controls.Add(this.DomainButton);
            this.Damain.Location = new System.Drawing.Point(12, 300);
            this.Damain.Name = "Damain";
            this.Damain.Size = new System.Drawing.Size(617, 46);
            this.Damain.TabIndex = 64;
            this.Damain.TabStop = false;
            this.Damain.Text = "Damain";
            // 
            // DomainComboBox
            // 
            this.DomainComboBox.FormattingEnabled = true;
            this.DomainComboBox.Items.AddRange(new object[] {
            "syncpro.com",
            "gmail.com",
            "hotmail.com"});
            this.DomainComboBox.Location = new System.Drawing.Point(9, 19);
            this.DomainComboBox.Name = "DomainComboBox";
            this.DomainComboBox.Size = new System.Drawing.Size(521, 21);
            this.DomainComboBox.TabIndex = 15;
            // 
            // DomainButton
            // 
            this.DomainButton.Location = new System.Drawing.Point(536, 17);
            this.DomainButton.Name = "DomainButton";
            this.DomainButton.Size = new System.Drawing.Size(75, 23);
            this.DomainButton.TabIndex = 14;
            this.DomainButton.Text = "Save";
            this.DomainButton.UseVisualStyleBackColor = true;
            this.DomainButton.Click += new System.EventHandler(this.DomainButton_Click);
            // 
            // SystemSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 379);
            this.Controls.Add(this.Damain);
            this.Controls.Add(this.ServerConnection);
            this.Controls.Add(this.ProductsFile);
            this.Controls.Add(this.BackupLocation);
            this.Controls.Add(this.GeneratorSettings);
            this.Controls.Add(this.statusStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SystemSettingsForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "System Settings";
            this.Load += new System.EventHandler(this.SystemSettingsForm_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.GeneratorSettings.ResumeLayout(false);
            this.GeneratorSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PasswordLengthNumbers)).EndInit();
            this.BackupLocation.ResumeLayout(false);
            this.BackupLocation.PerformLayout();
            this.ProductsFile.ResumeLayout(false);
            this.ProductsFile.PerformLayout();
            this.ServerConnection.ResumeLayout(false);
            this.ServerConnection.PerformLayout();
            this.Damain.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel SyncProStatusLabel;
        private System.Windows.Forms.GroupBox GeneratorSettings;
        private System.Windows.Forms.CheckBox LowerCheckBox;
        private System.Windows.Forms.TextBox LowerBox;
        private System.Windows.Forms.Label LowerCase;
        private System.Windows.Forms.CheckBox NumbersCheckBox;
        private System.Windows.Forms.TextBox NumbersBox;
        private System.Windows.Forms.Label Numbers;
        private System.Windows.Forms.CheckBox SpecialCheckBox;
        private System.Windows.Forms.TextBox SpecialBox;
        private System.Windows.Forms.Label SpecialCharacter;
        private System.Windows.Forms.CheckBox UpperCheckBox;
        private System.Windows.Forms.TextBox UpperBox;
        private System.Windows.Forms.Label UpperCase;
        private System.Windows.Forms.Label PasswordLength;
        private System.Windows.Forms.NumericUpDown PasswordLengthNumbers;
        private System.Windows.Forms.Button PassButton;
        private System.Windows.Forms.GroupBox BackupLocation;
        private System.Windows.Forms.Button BackupButton;
        private System.Windows.Forms.TextBox BackupBox;
        private System.Windows.Forms.Button ChooseBackup;
        private System.Windows.Forms.GroupBox ProductsFile;
        private System.Windows.Forms.Button ChooseProducts;
        private System.Windows.Forms.Button ProductsButton;
        private System.Windows.Forms.TextBox ProductsBox;
        private System.Windows.Forms.GroupBox ServerConnection;
        private System.Windows.Forms.Button ServerButton;
        private System.Windows.Forms.TextBox ServerBox;
        private System.Windows.Forms.GroupBox Damain;
        private System.Windows.Forms.ComboBox DomainComboBox;
        private System.Windows.Forms.Button DomainButton;
    }
}