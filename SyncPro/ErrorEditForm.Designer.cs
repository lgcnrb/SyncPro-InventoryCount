namespace SyncPro
{
    partial class ErrorEntryForm
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
            System.Windows.Forms.Label productionFactoryLabel;
            System.Windows.Forms.Label dateOccurredLabel;
            System.Windows.Forms.Label workOrderLabel;
            System.Windows.Forms.Label modelLabel;
            System.Windows.Forms.Label departmentLabel;
            System.Windows.Forms.Label productionProcessLabel;
            System.Windows.Forms.Label partTypeLabel;
            System.Windows.Forms.Label locationLabel;
            System.Windows.Forms.Label errorContentLabel;
            System.Windows.Forms.Label errorDetailLabel;
            System.Windows.Forms.Label processesErrorOccurredLabel;
            System.Windows.Forms.Label processesErrorDetectedLabel;
            System.Windows.Forms.Label necessaryActionTakenLabel;
            System.Windows.Forms.Label requiredTransactionDescriptionLabel;
            System.Windows.Forms.Label processErrorEmployeeNameLabel;
            System.Windows.Forms.Label processesErrorControllerNameLabel;
            System.Windows.Forms.Label numberOfErrorsLabel;
            System.Windows.Forms.Label electronicManagementNoLabel;
            System.Windows.Forms.Label fCTLOTNoLabel;
            System.Windows.Forms.Label drawingNoLabel;
            System.Windows.Forms.Label stageLabel;
            System.Windows.Forms.Label photoDefectivePartLabel;
            System.Windows.Forms.Label photoBackSideDefectivePartLabel;
            System.Windows.Forms.Label photo2DCodeLabel;
            System.Windows.Forms.Label interventionLabel;
            System.Windows.Forms.Label otherCommentsLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ErrorEntryForm));
            this.syncProDatabaseDataSet = new SyncProDatabaseDataSet();
            this.productionErrorsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.productionErrorsTableAdapter = new SyncProDatabaseDataSetTableAdapters.ProductionErrorsTableAdapter();
            this.tableAdapterManager = new SyncProDatabaseDataSetTableAdapters.TableAdapterManager();
            this.dateOccurredDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.workOrderTextBox = new System.Windows.Forms.TextBox();
            this.modelComboBox = new System.Windows.Forms.ComboBox();
            this.departmentComboBox = new System.Windows.Forms.ComboBox();
            this.productionProcessComboBox = new System.Windows.Forms.ComboBox();
            this.partTypeComboBox = new System.Windows.Forms.ComboBox();
            this.locationTextBox = new System.Windows.Forms.TextBox();
            this.errorContentComboBox = new System.Windows.Forms.ComboBox();
            this.errorDetailTextBox = new System.Windows.Forms.TextBox();
            this.processesErrorOccurredComboBox = new System.Windows.Forms.ComboBox();
            this.processesErrorDetectedComboBox = new System.Windows.Forms.ComboBox();
            this.necessaryActionTakenTextBox = new System.Windows.Forms.TextBox();
            this.requiredTransactionDescriptionTextBox = new System.Windows.Forms.TextBox();
            this.processErrorEmployeeNameComboBox = new System.Windows.Forms.ComboBox();
            this.processesErrorControllerNameComboBox = new System.Windows.Forms.ComboBox();
            this.numberOfErrorsTextBox = new System.Windows.Forms.TextBox();
            this.electronicManagementNoTextBox = new System.Windows.Forms.TextBox();
            this.fCTLOTNoTextBox = new System.Windows.Forms.TextBox();
            this.drawingNoTextBox = new System.Windows.Forms.TextBox();
            this.stageComboBox = new System.Windows.Forms.ComboBox();
            this.pictureBoxPhotoDefectivePart = new System.Windows.Forms.PictureBox();
            this.pictureBoxPhotoBackSideDefectivePart = new System.Windows.Forms.PictureBox();
            this.photo2DCodeTextBox = new System.Windows.Forms.TextBox();
            this.interventionComboBox = new System.Windows.Forms.ComboBox();
            this.otherCommentsTextBox = new System.Windows.Forms.TextBox();
            this.SaveButton = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.SyncProStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.UploadButton = new System.Windows.Forms.Button();
            this.UploadButton1 = new System.Windows.Forms.Button();
            this.productionFactoryComboBox = new System.Windows.Forms.ComboBox();
            productionFactoryLabel = new System.Windows.Forms.Label();
            dateOccurredLabel = new System.Windows.Forms.Label();
            workOrderLabel = new System.Windows.Forms.Label();
            modelLabel = new System.Windows.Forms.Label();
            departmentLabel = new System.Windows.Forms.Label();
            productionProcessLabel = new System.Windows.Forms.Label();
            partTypeLabel = new System.Windows.Forms.Label();
            locationLabel = new System.Windows.Forms.Label();
            errorContentLabel = new System.Windows.Forms.Label();
            errorDetailLabel = new System.Windows.Forms.Label();
            processesErrorOccurredLabel = new System.Windows.Forms.Label();
            processesErrorDetectedLabel = new System.Windows.Forms.Label();
            necessaryActionTakenLabel = new System.Windows.Forms.Label();
            requiredTransactionDescriptionLabel = new System.Windows.Forms.Label();
            processErrorEmployeeNameLabel = new System.Windows.Forms.Label();
            processesErrorControllerNameLabel = new System.Windows.Forms.Label();
            numberOfErrorsLabel = new System.Windows.Forms.Label();
            electronicManagementNoLabel = new System.Windows.Forms.Label();
            fCTLOTNoLabel = new System.Windows.Forms.Label();
            drawingNoLabel = new System.Windows.Forms.Label();
            stageLabel = new System.Windows.Forms.Label();
            photoDefectivePartLabel = new System.Windows.Forms.Label();
            photoBackSideDefectivePartLabel = new System.Windows.Forms.Label();
            photo2DCodeLabel = new System.Windows.Forms.Label();
            interventionLabel = new System.Windows.Forms.Label();
            otherCommentsLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.syncProDatabaseDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productionErrorsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPhotoDefectivePart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPhotoBackSideDefectivePart)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // productionFactoryLabel
            // 
            productionFactoryLabel.AutoSize = true;
            productionFactoryLabel.Location = new System.Drawing.Point(7, 9);
            productionFactoryLabel.Name = "productionFactoryLabel";
            productionFactoryLabel.Size = new System.Drawing.Size(99, 13);
            productionFactoryLabel.TabIndex = 4;
            productionFactoryLabel.Text = "Production Factory:";
            // 
            // dateOccurredLabel
            // 
            dateOccurredLabel.AutoSize = true;
            dateOccurredLabel.Location = new System.Drawing.Point(7, 36);
            dateOccurredLabel.Name = "dateOccurredLabel";
            dateOccurredLabel.Size = new System.Drawing.Size(80, 13);
            dateOccurredLabel.TabIndex = 6;
            dateOccurredLabel.Text = "Date Occurred:";
            // 
            // workOrderLabel
            // 
            workOrderLabel.AutoSize = true;
            workOrderLabel.Location = new System.Drawing.Point(7, 61);
            workOrderLabel.Name = "workOrderLabel";
            workOrderLabel.Size = new System.Drawing.Size(65, 13);
            workOrderLabel.TabIndex = 8;
            workOrderLabel.Text = "Work Order:";
            // 
            // modelLabel
            // 
            modelLabel.AutoSize = true;
            modelLabel.Location = new System.Drawing.Point(7, 87);
            modelLabel.Name = "modelLabel";
            modelLabel.Size = new System.Drawing.Size(39, 13);
            modelLabel.TabIndex = 10;
            modelLabel.Text = "Model:";
            // 
            // departmentLabel
            // 
            departmentLabel.AutoSize = true;
            departmentLabel.Location = new System.Drawing.Point(7, 114);
            departmentLabel.Name = "departmentLabel";
            departmentLabel.Size = new System.Drawing.Size(65, 13);
            departmentLabel.TabIndex = 12;
            departmentLabel.Text = "Department:";
            // 
            // productionProcessLabel
            // 
            productionProcessLabel.AutoSize = true;
            productionProcessLabel.Location = new System.Drawing.Point(387, 9);
            productionProcessLabel.Name = "productionProcessLabel";
            productionProcessLabel.Size = new System.Drawing.Size(102, 13);
            productionProcessLabel.TabIndex = 14;
            productionProcessLabel.Text = "Production Process:";
            // 
            // partTypeLabel
            // 
            partTypeLabel.AutoSize = true;
            partTypeLabel.Location = new System.Drawing.Point(387, 36);
            partTypeLabel.Name = "partTypeLabel";
            partTypeLabel.Size = new System.Drawing.Size(56, 13);
            partTypeLabel.TabIndex = 16;
            partTypeLabel.Text = "Part Type:";
            // 
            // locationLabel
            // 
            locationLabel.AutoSize = true;
            locationLabel.Location = new System.Drawing.Point(387, 63);
            locationLabel.Name = "locationLabel";
            locationLabel.Size = new System.Drawing.Size(51, 13);
            locationLabel.TabIndex = 18;
            locationLabel.Text = "Location:";
            // 
            // errorContentLabel
            // 
            errorContentLabel.AutoSize = true;
            errorContentLabel.Location = new System.Drawing.Point(387, 89);
            errorContentLabel.Name = "errorContentLabel";
            errorContentLabel.Size = new System.Drawing.Size(72, 13);
            errorContentLabel.TabIndex = 20;
            errorContentLabel.Text = "Error Content:";
            // 
            // errorDetailLabel
            // 
            errorDetailLabel.AutoSize = true;
            errorDetailLabel.Location = new System.Drawing.Point(387, 116);
            errorDetailLabel.Name = "errorDetailLabel";
            errorDetailLabel.Size = new System.Drawing.Size(62, 13);
            errorDetailLabel.TabIndex = 22;
            errorDetailLabel.Text = "Error Detail:";
            // 
            // processesErrorOccurredLabel
            // 
            processesErrorOccurredLabel.AutoSize = true;
            processesErrorOccurredLabel.Location = new System.Drawing.Point(767, 9);
            processesErrorOccurredLabel.Name = "processesErrorOccurredLabel";
            processesErrorOccurredLabel.Size = new System.Drawing.Size(131, 13);
            processesErrorOccurredLabel.TabIndex = 24;
            processesErrorOccurredLabel.Text = "Processes Error Occurred:";
            // 
            // processesErrorDetectedLabel
            // 
            processesErrorDetectedLabel.AutoSize = true;
            processesErrorDetectedLabel.Location = new System.Drawing.Point(767, 36);
            processesErrorDetectedLabel.Name = "processesErrorDetectedLabel";
            processesErrorDetectedLabel.Size = new System.Drawing.Size(131, 13);
            processesErrorDetectedLabel.TabIndex = 26;
            processesErrorDetectedLabel.Text = "Processes Error Detected:";
            // 
            // necessaryActionTakenLabel
            // 
            necessaryActionTakenLabel.AutoSize = true;
            necessaryActionTakenLabel.Location = new System.Drawing.Point(767, 61);
            necessaryActionTakenLabel.Name = "necessaryActionTakenLabel";
            necessaryActionTakenLabel.Size = new System.Drawing.Size(127, 13);
            necessaryActionTakenLabel.TabIndex = 28;
            necessaryActionTakenLabel.Text = "Necessary Action Taken:";
            // 
            // requiredTransactionDescriptionLabel
            // 
            requiredTransactionDescriptionLabel.AutoSize = true;
            requiredTransactionDescriptionLabel.Location = new System.Drawing.Point(767, 87);
            requiredTransactionDescriptionLabel.Name = "requiredTransactionDescriptionLabel";
            requiredTransactionDescriptionLabel.Size = new System.Drawing.Size(168, 13);
            requiredTransactionDescriptionLabel.TabIndex = 30;
            requiredTransactionDescriptionLabel.Text = "Required Transaction Description:";
            // 
            // processErrorEmployeeNameLabel
            // 
            processErrorEmployeeNameLabel.AutoSize = true;
            processErrorEmployeeNameLabel.Location = new System.Drawing.Point(767, 113);
            processErrorEmployeeNameLabel.Name = "processErrorEmployeeNameLabel";
            processErrorEmployeeNameLabel.Size = new System.Drawing.Size(153, 13);
            processErrorEmployeeNameLabel.TabIndex = 32;
            processErrorEmployeeNameLabel.Text = "Process Error Employee Name:";
            // 
            // processesErrorControllerNameLabel
            // 
            processesErrorControllerNameLabel.AutoSize = true;
            processesErrorControllerNameLabel.Location = new System.Drawing.Point(767, 140);
            processesErrorControllerNameLabel.Name = "processesErrorControllerNameLabel";
            processesErrorControllerNameLabel.Size = new System.Drawing.Size(162, 13);
            processesErrorControllerNameLabel.TabIndex = 34;
            processesErrorControllerNameLabel.Text = "Processes Error Controller Name:";
            // 
            // numberOfErrorsLabel
            // 
            numberOfErrorsLabel.AutoSize = true;
            numberOfErrorsLabel.Location = new System.Drawing.Point(767, 168);
            numberOfErrorsLabel.Name = "numberOfErrorsLabel";
            numberOfErrorsLabel.Size = new System.Drawing.Size(91, 13);
            numberOfErrorsLabel.TabIndex = 36;
            numberOfErrorsLabel.Text = "Number Of Errors:";
            // 
            // electronicManagementNoLabel
            // 
            electronicManagementNoLabel.AutoSize = true;
            electronicManagementNoLabel.Location = new System.Drawing.Point(767, 194);
            electronicManagementNoLabel.Name = "electronicManagementNoLabel";
            electronicManagementNoLabel.Size = new System.Drawing.Size(139, 13);
            electronicManagementNoLabel.TabIndex = 38;
            electronicManagementNoLabel.Text = "Electronic Management No:";
            // 
            // fCTLOTNoLabel
            // 
            fCTLOTNoLabel.AutoSize = true;
            fCTLOTNoLabel.Location = new System.Drawing.Point(767, 220);
            fCTLOTNoLabel.Name = "fCTLOTNoLabel";
            fCTLOTNoLabel.Size = new System.Drawing.Size(65, 13);
            fCTLOTNoLabel.TabIndex = 40;
            fCTLOTNoLabel.Text = "FCTLOTNo:";
            // 
            // drawingNoLabel
            // 
            drawingNoLabel.AutoSize = true;
            drawingNoLabel.Location = new System.Drawing.Point(767, 246);
            drawingNoLabel.Name = "drawingNoLabel";
            drawingNoLabel.Size = new System.Drawing.Size(66, 13);
            drawingNoLabel.TabIndex = 42;
            drawingNoLabel.Text = "Drawing No:";
            // 
            // stageLabel
            // 
            stageLabel.AutoSize = true;
            stageLabel.Location = new System.Drawing.Point(767, 272);
            stageLabel.Name = "stageLabel";
            stageLabel.Size = new System.Drawing.Size(38, 13);
            stageLabel.TabIndex = 44;
            stageLabel.Text = "Stage:";
            // 
            // photoDefectivePartLabel
            // 
            photoDefectivePartLabel.AutoSize = true;
            photoDefectivePartLabel.Location = new System.Drawing.Point(7, 145);
            photoDefectivePartLabel.Name = "photoDefectivePartLabel";
            photoDefectivePartLabel.Size = new System.Drawing.Size(109, 13);
            photoDefectivePartLabel.TabIndex = 46;
            photoDefectivePartLabel.Text = "Photo Defective Part:";
            // 
            // photoBackSideDefectivePartLabel
            // 
            photoBackSideDefectivePartLabel.AutoSize = true;
            photoBackSideDefectivePartLabel.Location = new System.Drawing.Point(387, 145);
            photoBackSideDefectivePartLabel.Name = "photoBackSideDefectivePartLabel";
            photoBackSideDefectivePartLabel.Size = new System.Drawing.Size(161, 13);
            photoBackSideDefectivePartLabel.TabIndex = 48;
            photoBackSideDefectivePartLabel.Text = "Photo Back Side Defective Part:";
            // 
            // photo2DCodeLabel
            // 
            photo2DCodeLabel.AutoSize = true;
            photo2DCodeLabel.Location = new System.Drawing.Point(767, 299);
            photo2DCodeLabel.Name = "photo2DCodeLabel";
            photo2DCodeLabel.Size = new System.Drawing.Size(77, 13);
            photo2DCodeLabel.TabIndex = 50;
            photo2DCodeLabel.Text = "Photo2DCode:";
            // 
            // interventionLabel
            // 
            interventionLabel.AutoSize = true;
            interventionLabel.Location = new System.Drawing.Point(767, 325);
            interventionLabel.Name = "interventionLabel";
            interventionLabel.Size = new System.Drawing.Size(66, 13);
            interventionLabel.TabIndex = 52;
            interventionLabel.Text = "Intervention:";
            // 
            // otherCommentsLabel
            // 
            otherCommentsLabel.AutoSize = true;
            otherCommentsLabel.Location = new System.Drawing.Point(767, 352);
            otherCommentsLabel.Name = "otherCommentsLabel";
            otherCommentsLabel.Size = new System.Drawing.Size(88, 13);
            otherCommentsLabel.TabIndex = 54;
            otherCommentsLabel.Text = "Other Comments:";
            // 
            // syncProDatabaseDataSet
            // 
            this.syncProDatabaseDataSet.DataSetName = "SyncProDatabaseDataSet";
            this.syncProDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // productionErrorsBindingSource
            // 
            this.productionErrorsBindingSource.DataMember = "ProductionErrors";
            this.productionErrorsBindingSource.DataSource = this.syncProDatabaseDataSet;
            // 
            // productionErrorsTableAdapter
            // 
            this.productionErrorsTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.ProductionErrorsTableAdapter = this.productionErrorsTableAdapter;
            this.tableAdapterManager.TransactionHistoryTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = SyncProDatabaseDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.UsersTableAdapter = null;
            // 
            // dateOccurredDateTimePicker
            // 
            this.dateOccurredDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.productionErrorsBindingSource, "DateOccurred", true));
            this.dateOccurredDateTimePicker.Location = new System.Drawing.Point(181, 32);
            this.dateOccurredDateTimePicker.Name = "dateOccurredDateTimePicker";
            this.dateOccurredDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.dateOccurredDateTimePicker.TabIndex = 7;
            // 
            // workOrderTextBox
            // 
            this.workOrderTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.productionErrorsBindingSource, "WorkOrder", true));
            this.workOrderTextBox.Location = new System.Drawing.Point(181, 58);
            this.workOrderTextBox.Name = "workOrderTextBox";
            this.workOrderTextBox.Size = new System.Drawing.Size(200, 20);
            this.workOrderTextBox.TabIndex = 9;
            // 
            // modelComboBox
            // 
            this.modelComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.productionErrorsBindingSource, "Model", true));
            this.modelComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.modelComboBox.FormattingEnabled = true;
            this.modelComboBox.Location = new System.Drawing.Point(181, 84);
            this.modelComboBox.Name = "modelComboBox";
            this.modelComboBox.Size = new System.Drawing.Size(200, 21);
            this.modelComboBox.TabIndex = 11;
            // 
            // departmentComboBox
            // 
            this.departmentComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.productionErrorsBindingSource, "Department", true));
            this.departmentComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.departmentComboBox.FormattingEnabled = true;
            this.departmentComboBox.Location = new System.Drawing.Point(181, 111);
            this.departmentComboBox.Name = "departmentComboBox";
            this.departmentComboBox.Size = new System.Drawing.Size(200, 21);
            this.departmentComboBox.TabIndex = 13;
            // 
            // productionProcessComboBox
            // 
            this.productionProcessComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.productionErrorsBindingSource, "ProductionProcess", true));
            this.productionProcessComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.productionProcessComboBox.FormattingEnabled = true;
            this.productionProcessComboBox.Location = new System.Drawing.Point(561, 6);
            this.productionProcessComboBox.Name = "productionProcessComboBox";
            this.productionProcessComboBox.Size = new System.Drawing.Size(200, 21);
            this.productionProcessComboBox.TabIndex = 15;
            // 
            // partTypeComboBox
            // 
            this.partTypeComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.productionErrorsBindingSource, "PartType", true));
            this.partTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.partTypeComboBox.FormattingEnabled = true;
            this.partTypeComboBox.Location = new System.Drawing.Point(561, 33);
            this.partTypeComboBox.Name = "partTypeComboBox";
            this.partTypeComboBox.Size = new System.Drawing.Size(200, 21);
            this.partTypeComboBox.TabIndex = 17;
            // 
            // locationTextBox
            // 
            this.locationTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.productionErrorsBindingSource, "Location", true));
            this.locationTextBox.Location = new System.Drawing.Point(561, 60);
            this.locationTextBox.Name = "locationTextBox";
            this.locationTextBox.Size = new System.Drawing.Size(200, 20);
            this.locationTextBox.TabIndex = 19;
            // 
            // errorContentComboBox
            // 
            this.errorContentComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.productionErrorsBindingSource, "ErrorContent", true));
            this.errorContentComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.errorContentComboBox.FormattingEnabled = true;
            this.errorContentComboBox.Location = new System.Drawing.Point(561, 86);
            this.errorContentComboBox.Name = "errorContentComboBox";
            this.errorContentComboBox.Size = new System.Drawing.Size(200, 21);
            this.errorContentComboBox.TabIndex = 21;
            // 
            // errorDetailTextBox
            // 
            this.errorDetailTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.productionErrorsBindingSource, "ErrorDetail", true));
            this.errorDetailTextBox.Location = new System.Drawing.Point(561, 113);
            this.errorDetailTextBox.Name = "errorDetailTextBox";
            this.errorDetailTextBox.Size = new System.Drawing.Size(200, 20);
            this.errorDetailTextBox.TabIndex = 23;
            // 
            // processesErrorOccurredComboBox
            // 
            this.processesErrorOccurredComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.productionErrorsBindingSource, "ProcessesErrorOccurred", true));
            this.processesErrorOccurredComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.processesErrorOccurredComboBox.FormattingEnabled = true;
            this.processesErrorOccurredComboBox.Location = new System.Drawing.Point(941, 6);
            this.processesErrorOccurredComboBox.Name = "processesErrorOccurredComboBox";
            this.processesErrorOccurredComboBox.Size = new System.Drawing.Size(200, 21);
            this.processesErrorOccurredComboBox.TabIndex = 25;
            // 
            // processesErrorDetectedComboBox
            // 
            this.processesErrorDetectedComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.productionErrorsBindingSource, "ProcessesErrorDetected", true));
            this.processesErrorDetectedComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.processesErrorDetectedComboBox.FormattingEnabled = true;
            this.processesErrorDetectedComboBox.Location = new System.Drawing.Point(941, 33);
            this.processesErrorDetectedComboBox.Name = "processesErrorDetectedComboBox";
            this.processesErrorDetectedComboBox.Size = new System.Drawing.Size(200, 21);
            this.processesErrorDetectedComboBox.TabIndex = 27;
            // 
            // necessaryActionTakenTextBox
            // 
            this.necessaryActionTakenTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.productionErrorsBindingSource, "NecessaryActionTaken", true));
            this.necessaryActionTakenTextBox.Location = new System.Drawing.Point(941, 58);
            this.necessaryActionTakenTextBox.Name = "necessaryActionTakenTextBox";
            this.necessaryActionTakenTextBox.Size = new System.Drawing.Size(200, 20);
            this.necessaryActionTakenTextBox.TabIndex = 29;
            // 
            // requiredTransactionDescriptionTextBox
            // 
            this.requiredTransactionDescriptionTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.productionErrorsBindingSource, "RequiredTransactionDescription", true));
            this.requiredTransactionDescriptionTextBox.Location = new System.Drawing.Point(941, 84);
            this.requiredTransactionDescriptionTextBox.Name = "requiredTransactionDescriptionTextBox";
            this.requiredTransactionDescriptionTextBox.Size = new System.Drawing.Size(200, 20);
            this.requiredTransactionDescriptionTextBox.TabIndex = 31;
            // 
            // processErrorEmployeeNameComboBox
            // 
            this.processErrorEmployeeNameComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.productionErrorsBindingSource, "ProcessErrorEmployeeName", true));
            this.processErrorEmployeeNameComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.processErrorEmployeeNameComboBox.FormattingEnabled = true;
            this.processErrorEmployeeNameComboBox.Location = new System.Drawing.Point(941, 110);
            this.processErrorEmployeeNameComboBox.Name = "processErrorEmployeeNameComboBox";
            this.processErrorEmployeeNameComboBox.Size = new System.Drawing.Size(200, 21);
            this.processErrorEmployeeNameComboBox.TabIndex = 33;
            // 
            // processesErrorControllerNameComboBox
            // 
            this.processesErrorControllerNameComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.productionErrorsBindingSource, "ProcessesErrorControllerName", true));
            this.processesErrorControllerNameComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.processesErrorControllerNameComboBox.FormattingEnabled = true;
            this.processesErrorControllerNameComboBox.Location = new System.Drawing.Point(941, 137);
            this.processesErrorControllerNameComboBox.Name = "processesErrorControllerNameComboBox";
            this.processesErrorControllerNameComboBox.Size = new System.Drawing.Size(200, 21);
            this.processesErrorControllerNameComboBox.TabIndex = 35;
            // 
            // numberOfErrorsTextBox
            // 
            this.numberOfErrorsTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.productionErrorsBindingSource, "NumberOfErrors", true));
            this.numberOfErrorsTextBox.Location = new System.Drawing.Point(941, 165);
            this.numberOfErrorsTextBox.Name = "numberOfErrorsTextBox";
            this.numberOfErrorsTextBox.Size = new System.Drawing.Size(200, 20);
            this.numberOfErrorsTextBox.TabIndex = 37;
            // 
            // electronicManagementNoTextBox
            // 
            this.electronicManagementNoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.productionErrorsBindingSource, "ElectronicManagementNo", true));
            this.electronicManagementNoTextBox.Location = new System.Drawing.Point(941, 191);
            this.electronicManagementNoTextBox.Name = "electronicManagementNoTextBox";
            this.electronicManagementNoTextBox.Size = new System.Drawing.Size(200, 20);
            this.electronicManagementNoTextBox.TabIndex = 39;
            // 
            // fCTLOTNoTextBox
            // 
            this.fCTLOTNoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.productionErrorsBindingSource, "FCTLOTNo", true));
            this.fCTLOTNoTextBox.Location = new System.Drawing.Point(941, 217);
            this.fCTLOTNoTextBox.Name = "fCTLOTNoTextBox";
            this.fCTLOTNoTextBox.Size = new System.Drawing.Size(200, 20);
            this.fCTLOTNoTextBox.TabIndex = 41;
            // 
            // drawingNoTextBox
            // 
            this.drawingNoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.productionErrorsBindingSource, "DrawingNo", true));
            this.drawingNoTextBox.Location = new System.Drawing.Point(941, 243);
            this.drawingNoTextBox.Name = "drawingNoTextBox";
            this.drawingNoTextBox.Size = new System.Drawing.Size(200, 20);
            this.drawingNoTextBox.TabIndex = 43;
            // 
            // stageComboBox
            // 
            this.stageComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.productionErrorsBindingSource, "Stage", true));
            this.stageComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.stageComboBox.FormattingEnabled = true;
            this.stageComboBox.Location = new System.Drawing.Point(941, 269);
            this.stageComboBox.Name = "stageComboBox";
            this.stageComboBox.Size = new System.Drawing.Size(200, 21);
            this.stageComboBox.TabIndex = 45;
            // 
            // pictureBoxPhotoDefectivePart
            // 
            this.pictureBoxPhotoDefectivePart.DataBindings.Add(new System.Windows.Forms.Binding("Image", this.productionErrorsBindingSource, "PhotoDefectivePart", true));
            this.pictureBoxPhotoDefectivePart.Location = new System.Drawing.Point(10, 168);
            this.pictureBoxPhotoDefectivePart.Name = "pictureBoxPhotoDefectivePart";
            this.pictureBoxPhotoDefectivePart.Size = new System.Drawing.Size(371, 230);
            this.pictureBoxPhotoDefectivePart.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxPhotoDefectivePart.TabIndex = 47;
            this.pictureBoxPhotoDefectivePart.TabStop = false;
            // 
            // pictureBoxPhotoBackSideDefectivePart
            // 
            this.pictureBoxPhotoBackSideDefectivePart.DataBindings.Add(new System.Windows.Forms.Binding("Image", this.productionErrorsBindingSource, "PhotoBackSideDefectivePart", true));
            this.pictureBoxPhotoBackSideDefectivePart.Location = new System.Drawing.Point(390, 168);
            this.pictureBoxPhotoBackSideDefectivePart.Name = "pictureBoxPhotoBackSideDefectivePart";
            this.pictureBoxPhotoBackSideDefectivePart.Size = new System.Drawing.Size(371, 230);
            this.pictureBoxPhotoBackSideDefectivePart.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxPhotoBackSideDefectivePart.TabIndex = 49;
            this.pictureBoxPhotoBackSideDefectivePart.TabStop = false;
            // 
            // photo2DCodeTextBox
            // 
            this.photo2DCodeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.productionErrorsBindingSource, "Photo2DCode", true));
            this.photo2DCodeTextBox.Location = new System.Drawing.Point(941, 296);
            this.photo2DCodeTextBox.Name = "photo2DCodeTextBox";
            this.photo2DCodeTextBox.Size = new System.Drawing.Size(200, 20);
            this.photo2DCodeTextBox.TabIndex = 51;
            // 
            // interventionComboBox
            // 
            this.interventionComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.productionErrorsBindingSource, "Intervention", true));
            this.interventionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.interventionComboBox.FormattingEnabled = true;
            this.interventionComboBox.Location = new System.Drawing.Point(941, 322);
            this.interventionComboBox.Name = "interventionComboBox";
            this.interventionComboBox.Size = new System.Drawing.Size(200, 21);
            this.interventionComboBox.TabIndex = 53;
            // 
            // otherCommentsTextBox
            // 
            this.otherCommentsTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.productionErrorsBindingSource, "OtherComments", true));
            this.otherCommentsTextBox.Location = new System.Drawing.Point(941, 349);
            this.otherCommentsTextBox.Name = "otherCommentsTextBox";
            this.otherCommentsTextBox.Size = new System.Drawing.Size(200, 20);
            this.otherCommentsTextBox.TabIndex = 55;
            // 
            // SaveButton
            // 
            this.SaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveButton.Location = new System.Drawing.Point(1066, 379);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 57;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SyncProStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 405);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1153, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 56;
            this.statusStrip1.Text = "statusStrip";
            // 
            // SyncProStatusLabel
            // 
            this.SyncProStatusLabel.Name = "SyncProStatusLabel";
            this.SyncProStatusLabel.Size = new System.Drawing.Size(1138, 17);
            this.SyncProStatusLabel.Spring = true;
            this.SyncProStatusLabel.Text = "SyncPro";
            // 
            // UploadButton
            // 
            this.UploadButton.Location = new System.Drawing.Point(306, 139);
            this.UploadButton.Name = "UploadButton";
            this.UploadButton.Size = new System.Drawing.Size(75, 23);
            this.UploadButton.TabIndex = 58;
            this.UploadButton.Text = "Upload";
            this.UploadButton.UseVisualStyleBackColor = true;
            this.UploadButton.Click += new System.EventHandler(this.UploadButton_Click);
            // 
            // UploadButton1
            // 
            this.UploadButton1.Location = new System.Drawing.Point(686, 139);
            this.UploadButton1.Name = "UploadButton1";
            this.UploadButton1.Size = new System.Drawing.Size(75, 23);
            this.UploadButton1.TabIndex = 59;
            this.UploadButton1.Text = "Upload";
            this.UploadButton1.UseVisualStyleBackColor = true;
            this.UploadButton1.Click += new System.EventHandler(this.UploadButton1_Click);
            // 
            // productionFactoryComboBox
            // 
            this.productionFactoryComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.productionFactoryComboBox.FormattingEnabled = true;
            this.productionFactoryComboBox.Location = new System.Drawing.Point(181, 5);
            this.productionFactoryComboBox.Name = "productionFactoryComboBox";
            this.productionFactoryComboBox.Size = new System.Drawing.Size(200, 21);
            this.productionFactoryComboBox.TabIndex = 60;
            // 
            // ErrorEntryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1153, 427);
            this.Controls.Add(this.productionFactoryComboBox);
            this.Controls.Add(this.UploadButton1);
            this.Controls.Add(this.UploadButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(productionFactoryLabel);
            this.Controls.Add(dateOccurredLabel);
            this.Controls.Add(this.dateOccurredDateTimePicker);
            this.Controls.Add(workOrderLabel);
            this.Controls.Add(this.workOrderTextBox);
            this.Controls.Add(modelLabel);
            this.Controls.Add(this.modelComboBox);
            this.Controls.Add(departmentLabel);
            this.Controls.Add(this.departmentComboBox);
            this.Controls.Add(productionProcessLabel);
            this.Controls.Add(this.productionProcessComboBox);
            this.Controls.Add(partTypeLabel);
            this.Controls.Add(this.partTypeComboBox);
            this.Controls.Add(locationLabel);
            this.Controls.Add(this.locationTextBox);
            this.Controls.Add(errorContentLabel);
            this.Controls.Add(this.errorContentComboBox);
            this.Controls.Add(errorDetailLabel);
            this.Controls.Add(this.errorDetailTextBox);
            this.Controls.Add(processesErrorOccurredLabel);
            this.Controls.Add(this.processesErrorOccurredComboBox);
            this.Controls.Add(processesErrorDetectedLabel);
            this.Controls.Add(this.processesErrorDetectedComboBox);
            this.Controls.Add(necessaryActionTakenLabel);
            this.Controls.Add(this.necessaryActionTakenTextBox);
            this.Controls.Add(requiredTransactionDescriptionLabel);
            this.Controls.Add(this.requiredTransactionDescriptionTextBox);
            this.Controls.Add(processErrorEmployeeNameLabel);
            this.Controls.Add(this.processErrorEmployeeNameComboBox);
            this.Controls.Add(processesErrorControllerNameLabel);
            this.Controls.Add(this.processesErrorControllerNameComboBox);
            this.Controls.Add(numberOfErrorsLabel);
            this.Controls.Add(this.numberOfErrorsTextBox);
            this.Controls.Add(electronicManagementNoLabel);
            this.Controls.Add(this.electronicManagementNoTextBox);
            this.Controls.Add(fCTLOTNoLabel);
            this.Controls.Add(this.fCTLOTNoTextBox);
            this.Controls.Add(drawingNoLabel);
            this.Controls.Add(this.drawingNoTextBox);
            this.Controls.Add(stageLabel);
            this.Controls.Add(this.stageComboBox);
            this.Controls.Add(photoDefectivePartLabel);
            this.Controls.Add(this.pictureBoxPhotoDefectivePart);
            this.Controls.Add(photoBackSideDefectivePartLabel);
            this.Controls.Add(this.pictureBoxPhotoBackSideDefectivePart);
            this.Controls.Add(photo2DCodeLabel);
            this.Controls.Add(this.photo2DCodeTextBox);
            this.Controls.Add(interventionLabel);
            this.Controls.Add(this.interventionComboBox);
            this.Controls.Add(otherCommentsLabel);
            this.Controls.Add(this.otherCommentsTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ErrorEntryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Error Entry";
            ((System.ComponentModel.ISupportInitialize)(this.syncProDatabaseDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productionErrorsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPhotoDefectivePart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPhotoBackSideDefectivePart)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.BindingSource productionErrorsBindingSource;
        private System.Windows.Forms.DateTimePicker dateOccurredDateTimePicker;
        private System.Windows.Forms.TextBox workOrderTextBox;
        private System.Windows.Forms.ComboBox modelComboBox;
        private System.Windows.Forms.ComboBox departmentComboBox;
        private System.Windows.Forms.ComboBox productionProcessComboBox;
        private System.Windows.Forms.ComboBox partTypeComboBox;
        private System.Windows.Forms.TextBox locationTextBox;
        private System.Windows.Forms.ComboBox errorContentComboBox;
        private System.Windows.Forms.TextBox errorDetailTextBox;
        private System.Windows.Forms.ComboBox processesErrorOccurredComboBox;
        private System.Windows.Forms.ComboBox processesErrorDetectedComboBox;
        private System.Windows.Forms.TextBox necessaryActionTakenTextBox;
        private System.Windows.Forms.TextBox requiredTransactionDescriptionTextBox;
        private System.Windows.Forms.ComboBox processErrorEmployeeNameComboBox;
        private System.Windows.Forms.ComboBox processesErrorControllerNameComboBox;
        private System.Windows.Forms.TextBox numberOfErrorsTextBox;
        private System.Windows.Forms.TextBox electronicManagementNoTextBox;
        private System.Windows.Forms.TextBox fCTLOTNoTextBox;
        private System.Windows.Forms.TextBox drawingNoTextBox;
        private System.Windows.Forms.ComboBox stageComboBox;
        private System.Windows.Forms.PictureBox pictureBoxPhotoDefectivePart;
        private System.Windows.Forms.PictureBox pictureBoxPhotoBackSideDefectivePart;
        private System.Windows.Forms.TextBox photo2DCodeTextBox;
        private System.Windows.Forms.ComboBox interventionComboBox;
        private System.Windows.Forms.TextBox otherCommentsTextBox;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel SyncProStatusLabel;
        private System.Windows.Forms.Button UploadButton;
        private System.Windows.Forms.Button UploadButton1;
        private SyncProDatabaseDataSet syncProDatabaseDataSet;
        private SyncProDatabaseDataSetTableAdapters.ProductionErrorsTableAdapter productionErrorsTableAdapter;
        private SyncProDatabaseDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.ComboBox productionFactoryComboBox;
    }
}