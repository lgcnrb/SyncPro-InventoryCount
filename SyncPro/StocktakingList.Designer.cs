namespace SyncPro
{
    partial class StocktakingList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StocktakingList));
            this.syncProDatabaseDataSet = new SyncProDatabaseDataSet();
            this.stocktakingListTableAdapter = new SyncProDatabaseDataSetTableAdapters.StocktakingListTableAdapter();
            this.tableAdapterManager = new SyncProDatabaseDataSetTableAdapters.TableAdapterManager();
            this.stocktakingListBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.StartCountingStripButton = new System.Windows.Forms.ToolStripButton();
            this.ContinueButton = new System.Windows.Forms.ToolStripButton();
            this.OpenButton = new System.Windows.Forms.ToolStripButton();
            this.CompareButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.SearchTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.FilterComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.StartButton = new System.Windows.Forms.ToolStripButton();
            this.FinishButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.DeleteButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.RefreshButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.stocktakingListDataGridView = new System.Windows.Forms.DataGridView();
            this.stocktakingListIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.creationDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.countedByDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.auditorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.finishDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.countFinishDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.stocktakingListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ComparisonReportButton = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.syncProDatabaseDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stocktakingListBindingNavigator)).BeginInit();
            this.stocktakingListBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stocktakingListDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stocktakingListBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // syncProDatabaseDataSet
            // 
            this.syncProDatabaseDataSet.DataSetName = "SyncProDatabaseDataSet";
            this.syncProDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // stocktakingListTableAdapter
            // 
            this.stocktakingListTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.StockCountTableAdapter = null;
            this.tableAdapterManager.StocktakingListTableAdapter = this.stocktakingListTableAdapter;
            this.tableAdapterManager.SystemInventoryTableAdapter = null;
            this.tableAdapterManager.TransactionHistoryTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = SyncProDatabaseDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.UsersTableAdapter = null;
            // 
            // stocktakingListBindingNavigator
            // 
            this.stocktakingListBindingNavigator.AddNewItem = null;
            this.stocktakingListBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.stocktakingListBindingNavigator.DeleteItem = null;
            this.stocktakingListBindingNavigator.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.stocktakingListBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.StartCountingStripButton,
            this.ContinueButton,
            this.OpenButton,
            this.CompareButton,
            this.toolStripSeparator2,
            this.SearchTextBox,
            this.FilterComboBox,
            this.toolStripSeparator1,
            this.StartButton,
            this.FinishButton,
            this.toolStripSeparator3,
            this.DeleteButton,
            this.toolStripSeparator4,
            this.RefreshButton,
            this.toolStripSeparator5,
            this.ComparisonReportButton});
            this.stocktakingListBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.stocktakingListBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.stocktakingListBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.stocktakingListBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.stocktakingListBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.stocktakingListBindingNavigator.Name = "stocktakingListBindingNavigator";
            this.stocktakingListBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.stocktakingListBindingNavigator.Size = new System.Drawing.Size(1016, 25);
            this.stocktakingListBindingNavigator.TabIndex = 0;
            this.stocktakingListBindingNavigator.Text = "bindingNavigator1";
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
            // StartCountingStripButton
            // 
            this.StartCountingStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.StartCountingStripButton.Image = ((System.Drawing.Image)(resources.GetObject("StartCountingStripButton.Image")));
            this.StartCountingStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.StartCountingStripButton.Name = "StartCountingStripButton";
            this.StartCountingStripButton.Size = new System.Drawing.Size(23, 22);
            this.StartCountingStripButton.Text = "Start Counting";
            this.StartCountingStripButton.Click += new System.EventHandler(this.StartCountingStripButton_Click);
            // 
            // ContinueButton
            // 
            this.ContinueButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ContinueButton.Image = ((System.Drawing.Image)(resources.GetObject("ContinueButton.Image")));
            this.ContinueButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ContinueButton.Name = "ContinueButton";
            this.ContinueButton.Size = new System.Drawing.Size(23, 22);
            this.ContinueButton.Text = "Continue";
            this.ContinueButton.ToolTipText = "Continue";
            this.ContinueButton.Click += new System.EventHandler(this.ContinueButton_Click);
            // 
            // OpenButton
            // 
            this.OpenButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.OpenButton.Image = ((System.Drawing.Image)(resources.GetObject("OpenButton.Image")));
            this.OpenButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.OpenButton.Name = "OpenButton";
            this.OpenButton.Size = new System.Drawing.Size(23, 22);
            this.OpenButton.Text = "Open";
            this.OpenButton.Click += new System.EventHandler(this.OpenButton_Click);
            // 
            // CompareButton
            // 
            this.CompareButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.CompareButton.Image = ((System.Drawing.Image)(resources.GetObject("CompareButton.Image")));
            this.CompareButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CompareButton.Name = "CompareButton";
            this.CompareButton.Size = new System.Drawing.Size(23, 22);
            this.CompareButton.Text = "Compare";
            this.CompareButton.Click += new System.EventHandler(this.CompareButton_Click);
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
            this.SearchTextBox.Size = new System.Drawing.Size(250, 25);
            this.SearchTextBox.Click += new System.EventHandler(this.SearchTextBox_Click);
            this.SearchTextBox.TextChanged += new System.EventHandler(this.SearchTextBox_TextChanged);
            // 
            // FilterComboBox
            // 
            this.FilterComboBox.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.FilterComboBox.AutoCompleteCustomSource.AddRange(new string[] {
            "StocktakingListId",
            "CreationDate",
            "FinishDate",
            "CountedBy",
            "Auditor ",
            "CountFinish"});
            this.FilterComboBox.Items.AddRange(new object[] {
            "StocktakingListId",
            "CreationDate",
            "FinishDate",
            "CountedBy",
            "Auditor",
            "CountFinish"});
            this.FilterComboBox.Name = "FilterComboBox";
            this.FilterComboBox.Size = new System.Drawing.Size(141, 25);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // StartButton
            // 
            this.StartButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.StartButton.Image = ((System.Drawing.Image)(resources.GetObject("StartButton.Image")));
            this.StartButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(23, 22);
            this.StartButton.Text = "Start";
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // FinishButton
            // 
            this.FinishButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.FinishButton.Image = ((System.Drawing.Image)(resources.GetObject("FinishButton.Image")));
            this.FinishButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.FinishButton.Name = "FinishButton";
            this.FinishButton.Size = new System.Drawing.Size(23, 22);
            this.FinishButton.Text = "Finish";
            this.FinishButton.Click += new System.EventHandler(this.FinishButton_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // DeleteButton
            // 
            this.DeleteButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.DeleteButton.Image = ((System.Drawing.Image)(resources.GetObject("DeleteButton.Image")));
            this.DeleteButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(23, 22);
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.ToolTipText = "Delete";
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // RefreshButton
            // 
            this.RefreshButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.RefreshButton.Image = ((System.Drawing.Image)(resources.GetObject("RefreshButton.Image")));
            this.RefreshButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(23, 22);
            this.RefreshButton.Text = "RefreshButton";
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // stocktakingListDataGridView
            // 
            this.stocktakingListDataGridView.AllowUserToAddRows = false;
            this.stocktakingListDataGridView.AllowUserToDeleteRows = false;
            this.stocktakingListDataGridView.AutoGenerateColumns = false;
            this.stocktakingListDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.stocktakingListDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.stocktakingListDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.stocktakingListIdDataGridViewTextBoxColumn,
            this.creationDateDataGridViewTextBoxColumn,
            this.countedByDataGridViewTextBoxColumn,
            this.auditorDataGridViewTextBoxColumn,
            this.finishDateDataGridViewTextBoxColumn,
            this.countFinishDataGridViewCheckBoxColumn});
            this.stocktakingListDataGridView.DataSource = this.stocktakingListBindingSource;
            this.stocktakingListDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stocktakingListDataGridView.Location = new System.Drawing.Point(0, 25);
            this.stocktakingListDataGridView.Name = "stocktakingListDataGridView";
            this.stocktakingListDataGridView.ReadOnly = true;
            this.stocktakingListDataGridView.RowHeadersVisible = false;
            this.stocktakingListDataGridView.Size = new System.Drawing.Size(1016, 543);
            this.stocktakingListDataGridView.TabIndex = 1;
            this.stocktakingListDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.stocktakingListDataGridView_CellDoubleClick);
            // 
            // stocktakingListIdDataGridViewTextBoxColumn
            // 
            this.stocktakingListIdDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.stocktakingListIdDataGridViewTextBoxColumn.DataPropertyName = "StocktakingListId";
            this.stocktakingListIdDataGridViewTextBoxColumn.HeaderText = "StocktakingListId";
            this.stocktakingListIdDataGridViewTextBoxColumn.Name = "stocktakingListIdDataGridViewTextBoxColumn";
            this.stocktakingListIdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // creationDateDataGridViewTextBoxColumn
            // 
            this.creationDateDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.creationDateDataGridViewTextBoxColumn.DataPropertyName = "CreationDate";
            this.creationDateDataGridViewTextBoxColumn.HeaderText = "CreationDate";
            this.creationDateDataGridViewTextBoxColumn.Name = "creationDateDataGridViewTextBoxColumn";
            this.creationDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // countedByDataGridViewTextBoxColumn
            // 
            this.countedByDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.countedByDataGridViewTextBoxColumn.DataPropertyName = "CountedBy";
            this.countedByDataGridViewTextBoxColumn.HeaderText = "CountedBy";
            this.countedByDataGridViewTextBoxColumn.Name = "countedByDataGridViewTextBoxColumn";
            this.countedByDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // auditorDataGridViewTextBoxColumn
            // 
            this.auditorDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.auditorDataGridViewTextBoxColumn.DataPropertyName = "Auditor";
            this.auditorDataGridViewTextBoxColumn.HeaderText = "Auditor";
            this.auditorDataGridViewTextBoxColumn.Name = "auditorDataGridViewTextBoxColumn";
            this.auditorDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // finishDateDataGridViewTextBoxColumn
            // 
            this.finishDateDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.finishDateDataGridViewTextBoxColumn.DataPropertyName = "FinishDate";
            this.finishDateDataGridViewTextBoxColumn.HeaderText = "FinishDate";
            this.finishDateDataGridViewTextBoxColumn.Name = "finishDateDataGridViewTextBoxColumn";
            this.finishDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // countFinishDataGridViewCheckBoxColumn
            // 
            this.countFinishDataGridViewCheckBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.countFinishDataGridViewCheckBoxColumn.DataPropertyName = "CountFinish";
            this.countFinishDataGridViewCheckBoxColumn.HeaderText = "CountFinish";
            this.countFinishDataGridViewCheckBoxColumn.Name = "countFinishDataGridViewCheckBoxColumn";
            this.countFinishDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // stocktakingListBindingSource
            // 
            this.stocktakingListBindingSource.DataMember = "StocktakingList";
            this.stocktakingListBindingSource.DataSource = this.syncProDatabaseDataSet;
            // 
            // ComparisonReportButton
            // 
            this.ComparisonReportButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ComparisonReportButton.Image = ((System.Drawing.Image)(resources.GetObject("ComparisonReportButton.Image")));
            this.ComparisonReportButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ComparisonReportButton.Name = "ComparisonReportButton";
            this.ComparisonReportButton.Size = new System.Drawing.Size(23, 22);
            this.ComparisonReportButton.Text = "Comparison Report";
            this.ComparisonReportButton.Click += new System.EventHandler(this.ComparisonReportButton_Click);
            // 
            // StocktakingList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.stocktakingListDataGridView);
            this.Controls.Add(this.stocktakingListBindingNavigator);
            this.Name = "StocktakingList";
            this.Size = new System.Drawing.Size(1016, 568);
            this.Load += new System.EventHandler(this.StocktakingList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.syncProDatabaseDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stocktakingListBindingNavigator)).EndInit();
            this.stocktakingListBindingNavigator.ResumeLayout(false);
            this.stocktakingListBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stocktakingListDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stocktakingListBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SyncProDatabaseDataSet syncProDatabaseDataSet;
        private SyncProDatabaseDataSetTableAdapters.StocktakingListTableAdapter stocktakingListTableAdapter;
        private SyncProDatabaseDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingNavigator stocktakingListBindingNavigator;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.DataGridView stocktakingListDataGridView;
        private System.Windows.Forms.ToolStripButton StartCountingStripButton;
        private System.Windows.Forms.ToolStripButton ContinueButton;
        private System.Windows.Forms.ToolStripTextBox SearchTextBox;
        private System.Windows.Forms.ToolStripComboBox FilterComboBox;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.DataGridViewTextBoxColumn stocktakingListIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn creationDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn countedByDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn auditorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn finishDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn countFinishDataGridViewCheckBoxColumn;
        private System.Windows.Forms.BindingSource stocktakingListBindingSource;
        private System.Windows.Forms.ToolStripButton FinishButton;
        private System.Windows.Forms.ToolStripButton RefreshButton;
        private System.Windows.Forms.ToolStripButton DeleteButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton StartButton;
        private System.Windows.Forms.ToolStripButton OpenButton;
        private System.Windows.Forms.ToolStripButton CompareButton;
        private System.Windows.Forms.ToolStripButton ComparisonReportButton;
    }
}
