namespace SyncPro
{
    partial class CountingReviewForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CountingReviewForm));
            this.syncProDatabaseDataSet = new SyncProDatabaseDataSet();
            this.stockCountTableAdapter = new SyncProDatabaseDataSetTableAdapters.StockCountTableAdapter();
            this.tableAdapterManager = new SyncProDatabaseDataSetTableAdapters.TableAdapterManager();
            this.stockCountBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.stockCountBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.DeleteButton = new System.Windows.Forms.ToolStripButton();
            this.EditButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ExportButton = new System.Windows.Forms.ToolStripButton();
            this.RefreshButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.SearchTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.FilterComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.SyncProStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.stockCountDataGridView = new System.Windows.Forms.DataGridView();
            this.ıdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.locationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.batchCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.countedQuantityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stocktakingListIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productCodeMatchDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.productNameMatchDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.locationMatchDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.quantityDifferenceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ısProductInSystemDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.userIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.syncProDatabaseDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockCountBindingNavigator)).BeginInit();
            this.stockCountBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stockCountBindingSource)).BeginInit();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stockCountDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // syncProDatabaseDataSet
            // 
            this.syncProDatabaseDataSet.DataSetName = "SyncProDatabaseDataSet";
            this.syncProDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // stockCountTableAdapter
            // 
            this.stockCountTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.StockCountTableAdapter = this.stockCountTableAdapter;
            this.tableAdapterManager.StocktakingListTableAdapter = null;
            this.tableAdapterManager.SystemInventoryTableAdapter = null;
            this.tableAdapterManager.TransactionHistoryTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = SyncProDatabaseDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.UsersTableAdapter = null;
            // 
            // stockCountBindingNavigator
            // 
            this.stockCountBindingNavigator.AddNewItem = null;
            this.stockCountBindingNavigator.BindingSource = this.stockCountBindingSource;
            this.stockCountBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.stockCountBindingNavigator.DeleteItem = null;
            this.stockCountBindingNavigator.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.stockCountBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.DeleteButton,
            this.EditButton,
            this.toolStripSeparator1,
            this.ExportButton,
            this.RefreshButton,
            this.toolStripSeparator2,
            this.SearchTextBox,
            this.FilterComboBox,
            this.toolStripSeparator3});
            this.stockCountBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.stockCountBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.stockCountBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.stockCountBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.stockCountBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.stockCountBindingNavigator.Name = "stockCountBindingNavigator";
            this.stockCountBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.stockCountBindingNavigator.Size = new System.Drawing.Size(1024, 25);
            this.stockCountBindingNavigator.TabIndex = 0;
            this.stockCountBindingNavigator.Text = "bindingNavigator1";
            // 
            // stockCountBindingSource
            // 
            this.stockCountBindingSource.DataMember = "StockCount";
            this.stockCountBindingSource.DataSource = this.syncProDatabaseDataSet;
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(29, 22);
            this.bindingNavigatorCountItem.Text = "/ {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Toplam öğe sayısı";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Başa taşı";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Öne taşı";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Konum";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Geçerli konum";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Arkaya taşı";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Sona taşı";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // DeleteButton
            // 
            this.DeleteButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.DeleteButton.Image = ((System.Drawing.Image)(resources.GetObject("DeleteButton.Image")));
            this.DeleteButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(23, 22);
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // EditButton
            // 
            this.EditButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.EditButton.Image = ((System.Drawing.Image)(resources.GetObject("EditButton.Image")));
            this.EditButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(23, 22);
            this.EditButton.Text = "Edit";
            this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // ExportButton
            // 
            this.ExportButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ExportButton.Image = ((System.Drawing.Image)(resources.GetObject("ExportButton.Image")));
            this.ExportButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ExportButton.Name = "ExportButton";
            this.ExportButton.Size = new System.Drawing.Size(23, 22);
            this.ExportButton.Text = "Export";
            this.ExportButton.Click += new System.EventHandler(this.ExportButton_Click);
            // 
            // RefreshButton
            // 
            this.RefreshButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.RefreshButton.Image = ((System.Drawing.Image)(resources.GetObject("RefreshButton.Image")));
            this.RefreshButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(23, 22);
            this.RefreshButton.Text = "Refresh";
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // SearchTextBox
            // 
            this.SearchTextBox.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.SearchTextBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.SearchTextBox.Name = "SearchTextBox";
            this.SearchTextBox.Size = new System.Drawing.Size(235, 25);
            this.SearchTextBox.Click += new System.EventHandler(this.SearchTextBox_Click);
            this.SearchTextBox.TextChanged += new System.EventHandler(this.SearchTextBox_TextChanged);
            // 
            // FilterComboBox
            // 
            this.FilterComboBox.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.FilterComboBox.Items.AddRange(new object[] {
            "UserId",
            "ProductCode",
            "ProductName",
            "Location",
            "BatchCode",
            "CountedQuantity",
            "StocktakingListId",
            "ProductCodeMatch",
            "ProductNameMatch",
            "LocationMatch",
            "QuantityDifference",
            "IsProductInSystem"});
            this.FilterComboBox.Name = "FilterComboBox";
            this.FilterComboBox.Size = new System.Drawing.Size(141, 25);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SyncProStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 579);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1024, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 22;
            this.statusStrip1.Text = "statusStrip";
            // 
            // SyncProStatusLabel
            // 
            this.SyncProStatusLabel.Name = "SyncProStatusLabel";
            this.SyncProStatusLabel.Size = new System.Drawing.Size(1009, 17);
            this.SyncProStatusLabel.Spring = true;
            this.SyncProStatusLabel.Text = "SyncPro";
            // 
            // stockCountDataGridView
            // 
            this.stockCountDataGridView.AllowUserToAddRows = false;
            this.stockCountDataGridView.AllowUserToDeleteRows = false;
            this.stockCountDataGridView.AutoGenerateColumns = false;
            this.stockCountDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.stockCountDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.stockCountDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ıdDataGridViewTextBoxColumn,
            this.productCodeDataGridViewTextBoxColumn,
            this.productNameDataGridViewTextBoxColumn,
            this.locationDataGridViewTextBoxColumn,
            this.batchCodeDataGridViewTextBoxColumn,
            this.countedQuantityDataGridViewTextBoxColumn,
            this.stocktakingListIdDataGridViewTextBoxColumn,
            this.productCodeMatchDataGridViewCheckBoxColumn,
            this.productNameMatchDataGridViewCheckBoxColumn,
            this.locationMatchDataGridViewCheckBoxColumn,
            this.quantityDifferenceDataGridViewTextBoxColumn,
            this.ısProductInSystemDataGridViewCheckBoxColumn,
            this.userIdDataGridViewTextBoxColumn});
            this.stockCountDataGridView.DataSource = this.stockCountBindingSource;
            this.stockCountDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stockCountDataGridView.Location = new System.Drawing.Point(0, 25);
            this.stockCountDataGridView.Name = "stockCountDataGridView";
            this.stockCountDataGridView.ReadOnly = true;
            this.stockCountDataGridView.RowHeadersVisible = false;
            this.stockCountDataGridView.Size = new System.Drawing.Size(1024, 554);
            this.stockCountDataGridView.TabIndex = 23;
            // 
            // ıdDataGridViewTextBoxColumn
            // 
            this.ıdDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.ıdDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.ıdDataGridViewTextBoxColumn.HeaderText = "Id";
            this.ıdDataGridViewTextBoxColumn.Name = "ıdDataGridViewTextBoxColumn";
            this.ıdDataGridViewTextBoxColumn.ReadOnly = true;
            this.ıdDataGridViewTextBoxColumn.Width = 41;
            // 
            // productCodeDataGridViewTextBoxColumn
            // 
            this.productCodeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.productCodeDataGridViewTextBoxColumn.DataPropertyName = "ProductCode";
            this.productCodeDataGridViewTextBoxColumn.HeaderText = "ProductCode";
            this.productCodeDataGridViewTextBoxColumn.Name = "productCodeDataGridViewTextBoxColumn";
            this.productCodeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // productNameDataGridViewTextBoxColumn
            // 
            this.productNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.productNameDataGridViewTextBoxColumn.DataPropertyName = "ProductName";
            this.productNameDataGridViewTextBoxColumn.HeaderText = "ProductName";
            this.productNameDataGridViewTextBoxColumn.Name = "productNameDataGridViewTextBoxColumn";
            this.productNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // locationDataGridViewTextBoxColumn
            // 
            this.locationDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.locationDataGridViewTextBoxColumn.DataPropertyName = "Location";
            this.locationDataGridViewTextBoxColumn.HeaderText = "Location";
            this.locationDataGridViewTextBoxColumn.Name = "locationDataGridViewTextBoxColumn";
            this.locationDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // batchCodeDataGridViewTextBoxColumn
            // 
            this.batchCodeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.batchCodeDataGridViewTextBoxColumn.DataPropertyName = "BatchCode";
            this.batchCodeDataGridViewTextBoxColumn.HeaderText = "BatchCode";
            this.batchCodeDataGridViewTextBoxColumn.Name = "batchCodeDataGridViewTextBoxColumn";
            this.batchCodeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // countedQuantityDataGridViewTextBoxColumn
            // 
            this.countedQuantityDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.countedQuantityDataGridViewTextBoxColumn.DataPropertyName = "CountedQuantity";
            this.countedQuantityDataGridViewTextBoxColumn.HeaderText = "CountedQuantity";
            this.countedQuantityDataGridViewTextBoxColumn.Name = "countedQuantityDataGridViewTextBoxColumn";
            this.countedQuantityDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // stocktakingListIdDataGridViewTextBoxColumn
            // 
            this.stocktakingListIdDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.stocktakingListIdDataGridViewTextBoxColumn.DataPropertyName = "StocktakingListId";
            this.stocktakingListIdDataGridViewTextBoxColumn.HeaderText = "StocktakingListId";
            this.stocktakingListIdDataGridViewTextBoxColumn.Name = "stocktakingListIdDataGridViewTextBoxColumn";
            this.stocktakingListIdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // productCodeMatchDataGridViewCheckBoxColumn
            // 
            this.productCodeMatchDataGridViewCheckBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.productCodeMatchDataGridViewCheckBoxColumn.DataPropertyName = "ProductCodeMatch";
            this.productCodeMatchDataGridViewCheckBoxColumn.HeaderText = "ProductCodeMatch";
            this.productCodeMatchDataGridViewCheckBoxColumn.Name = "productCodeMatchDataGridViewCheckBoxColumn";
            this.productCodeMatchDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // productNameMatchDataGridViewCheckBoxColumn
            // 
            this.productNameMatchDataGridViewCheckBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.productNameMatchDataGridViewCheckBoxColumn.DataPropertyName = "ProductNameMatch";
            this.productNameMatchDataGridViewCheckBoxColumn.HeaderText = "ProductNameMatch";
            this.productNameMatchDataGridViewCheckBoxColumn.Name = "productNameMatchDataGridViewCheckBoxColumn";
            this.productNameMatchDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // locationMatchDataGridViewCheckBoxColumn
            // 
            this.locationMatchDataGridViewCheckBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.locationMatchDataGridViewCheckBoxColumn.DataPropertyName = "LocationMatch";
            this.locationMatchDataGridViewCheckBoxColumn.HeaderText = "LocationMatch";
            this.locationMatchDataGridViewCheckBoxColumn.Name = "locationMatchDataGridViewCheckBoxColumn";
            this.locationMatchDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // quantityDifferenceDataGridViewTextBoxColumn
            // 
            this.quantityDifferenceDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.quantityDifferenceDataGridViewTextBoxColumn.DataPropertyName = "QuantityDifference";
            this.quantityDifferenceDataGridViewTextBoxColumn.HeaderText = "QuantityDifference";
            this.quantityDifferenceDataGridViewTextBoxColumn.Name = "quantityDifferenceDataGridViewTextBoxColumn";
            this.quantityDifferenceDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // ısProductInSystemDataGridViewCheckBoxColumn
            // 
            this.ısProductInSystemDataGridViewCheckBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ısProductInSystemDataGridViewCheckBoxColumn.DataPropertyName = "IsProductInSystem";
            this.ısProductInSystemDataGridViewCheckBoxColumn.HeaderText = "IsProductInSystem";
            this.ısProductInSystemDataGridViewCheckBoxColumn.Name = "ısProductInSystemDataGridViewCheckBoxColumn";
            this.ısProductInSystemDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // userIdDataGridViewTextBoxColumn
            // 
            this.userIdDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.userIdDataGridViewTextBoxColumn.DataPropertyName = "UserId";
            this.userIdDataGridViewTextBoxColumn.HeaderText = "UserId";
            this.userIdDataGridViewTextBoxColumn.Name = "userIdDataGridViewTextBoxColumn";
            this.userIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.userIdDataGridViewTextBoxColumn.Width = 63;
            // 
            // CountingReviewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 601);
            this.Controls.Add(this.stockCountDataGridView);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.stockCountBindingNavigator);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CountingReviewForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Counting Review";
            this.Load += new System.EventHandler(this.CountingReviewForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.syncProDatabaseDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockCountBindingNavigator)).EndInit();
            this.stockCountBindingNavigator.ResumeLayout(false);
            this.stockCountBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stockCountBindingSource)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stockCountDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SyncProDatabaseDataSet syncProDatabaseDataSet;
        private SyncProDatabaseDataSetTableAdapters.StockCountTableAdapter stockCountTableAdapter;
        private SyncProDatabaseDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingNavigator stockCountBindingNavigator;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton DeleteButton;
        private System.Windows.Forms.ToolStripButton EditButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton RefreshButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripTextBox SearchTextBox;
        private System.Windows.Forms.ToolStripComboBox FilterComboBox;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton ExportButton;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel SyncProStatusLabel;
        private System.Windows.Forms.DataGridView stockCountDataGridView;
        private System.Windows.Forms.BindingSource stockCountBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn ıdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn locationDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn batchCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn countedQuantityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn stocktakingListIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn productCodeMatchDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn productNameMatchDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn locationMatchDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityDifferenceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ısProductInSystemDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn userIdDataGridViewTextBoxColumn;
    }
}