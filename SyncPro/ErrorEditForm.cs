using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Text.Json;


namespace SyncPro
{
    public partial class ErrorEntryForm : Form
    {
        private readonly UserInfoCollector userInfo;
        private string jsonFilePath = Properties.Settings.Default.FilterPath;

        public ErrorEntryForm(UserInfoCollector userInfo)
        {
            InitializeComponent();
            this.userInfo = userInfo;
            LoadJsonDataIntoComboBoxes();
        }

        private void UploadButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    pictureBoxPhotoDefectivePart.Image = new Bitmap(openFileDialog.FileName);
                }
            }
        }

        private void UploadButton1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    pictureBoxPhotoBackSideDefectivePart.Image = new Bitmap(openFileDialog.FileName);
                }
            }
        }
        private byte[] ImageToByteArray(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                return ms.ToArray();
            }
        }

        private async void SaveButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(productionFactoryComboBox.Text))
            {
                MessageBox.Show("Production Factory cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(departmentComboBox.Text))
            {
                MessageBox.Show("Department cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(modelComboBox.Text))
            {
                MessageBox.Show("Model cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(productionProcessComboBox.Text))
            {
                MessageBox.Show("Production Process cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(partTypeComboBox.Text))
            {
                MessageBox.Show("Part Type cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(errorContentComboBox.Text))
            {
                MessageBox.Show("Error Content cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(processesErrorOccurredComboBox.Text))
            {
                MessageBox.Show("Processes Error Occurred cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(processesErrorDetectedComboBox.Text))
            {
                MessageBox.Show("Processes Error Detected cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(processErrorEmployeeNameComboBox.Text))
            {
                MessageBox.Show("Process Error Employee Name cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(processesErrorControllerNameComboBox.Text))
            {
                MessageBox.Show("Processes Error Controller Name cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(stageComboBox.Text))
            {
                MessageBox.Show("Stage cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(interventionComboBox.Text))
            {
                MessageBox.Show("Intervention cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(locationTextBox.Text))
            {
                MessageBox.Show("Location cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(errorDetailTextBox.Text))
            {
                MessageBox.Show("Error Detail cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(necessaryActionTakenTextBox.Text))
            {
                MessageBox.Show("Necessary Action Taken cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(requiredTransactionDescriptionTextBox.Text))
            {
                MessageBox.Show("Required Transaction Description cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(photo2DCodeTextBox.Text))
            {
                MessageBox.Show("Photo 2D Code cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(otherCommentsTextBox.Text))
            {
                MessageBox.Show("Other Comments cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(numberOfErrorsTextBox.Text, out int numberOfErrors) || numberOfErrors < 0)
            {
                MessageBox.Show("Number of Errors must be a non-negative integer.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ProductionErrors error = new ProductionErrors
            {
                ProductionFactory = productionFactoryComboBox.Text,
                DateOccurred = dateOccurredDateTimePicker.Value,
                WorkOrder = workOrderTextBox.Text,
                Model = modelComboBox.Text,
                Department = departmentComboBox.Text,
                ProductionProcess = productionProcessComboBox.Text,
                PartType = partTypeComboBox.Text,
                Location = locationTextBox.Text,
                ErrorContent = errorContentComboBox.Text,
                ErrorDetail = errorDetailTextBox.Text,
                ProcessesErrorOccurred = processesErrorOccurredComboBox.Text,
                ProcessesErrorDetected = processesErrorDetectedComboBox.Text,
                NecessaryActionTaken = necessaryActionTakenTextBox.Text,
                RequiredTransactionDescription = requiredTransactionDescriptionTextBox.Text,
                ProcessErrorEmployeeName = processErrorEmployeeNameComboBox.Text,
                ProcessesErrorControllerName = processesErrorControllerNameComboBox.Text,
                NumberOfErrors = numberOfErrors,
                ElectronicManagementNo = electronicManagementNoTextBox.Text,
                FCTLOTNo = fCTLOTNoTextBox.Text,
                DrawingNo = drawingNoTextBox.Text,
                Stage = stageComboBox.Text,
                PhotoDefectivePart = pictureBoxPhotoDefectivePart.Image != null ? ImageToByteArray(pictureBoxPhotoDefectivePart.Image) : null,
                PhotoBackSideDefectivePart = pictureBoxPhotoBackSideDefectivePart.Image != null ? ImageToByteArray(pictureBoxPhotoBackSideDefectivePart.Image) : null,
                Photo2DCode = photo2DCodeTextBox.Text,
                Intervention = interventionComboBox.Text,
                OtherComments = otherCommentsTextBox.Text,
                CreatedByUserId = userInfo.UserID
            };

            IProductionErrorsRepository repository = new ProductionErrorsRepository();
            bool result = await repository.Insert(error);

            if (result)
            {
                MessageBox.Show("Error saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearAllFields();
            }
            else
            {
                MessageBox.Show("Failed to save error.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void ClearAllFields()
        {
            locationTextBox.Clear();
            errorDetailTextBox.Clear();
            necessaryActionTakenTextBox.Clear();
            requiredTransactionDescriptionTextBox.Clear();
            photo2DCodeTextBox.Clear();
            otherCommentsTextBox.Clear();

            pictureBoxPhotoDefectivePart.Image = null;
            pictureBoxPhotoBackSideDefectivePart.Image = null;
        }
        private void LoadJsonDataIntoComboBoxes()
        {
            try
            {
                string jsonString = File.ReadAllText(jsonFilePath);

                var data = JsonSerializer.Deserialize<ErrorContents>(jsonString);

                if (data == null)
                {
                    MessageBox.Show("The JSON data could not be loaded. Please check the format.", "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                productionFactoryComboBox.Items.Clear();
                departmentComboBox.Items.Clear();
                modelComboBox.Items.Clear();
                productionProcessComboBox.Items.Clear();
                partTypeComboBox.Items.Clear();
                errorContentComboBox.Items.Clear();
                processesErrorOccurredComboBox.Items.Clear();
                processesErrorDetectedComboBox.Items.Clear();
                processesErrorControllerNameComboBox.Items.Clear();
                processErrorEmployeeNameComboBox.Items.Clear();
                stageComboBox.Items.Clear();
                interventionComboBox.Items.Clear();

                productionFactoryComboBox.Items.AddRange(data.ProductionFactory.ToArray());
                departmentComboBox.Items.AddRange(data.Department.ToArray());
                modelComboBox.Items.AddRange(data.Model.ToArray());
                productionProcessComboBox.Items.AddRange(data.ProductionProcess.ToArray());
                partTypeComboBox.Items.AddRange(data.PartType.ToArray());
                errorContentComboBox.Items.AddRange(data.ErrorContent.ToArray());
                processesErrorOccurredComboBox.Items.AddRange(data.ProcessesErrorOccurred.ToArray());
                processesErrorDetectedComboBox.Items.AddRange(data.ProcessesErrorDetected.ToArray());
                processesErrorControllerNameComboBox.Items.AddRange(data.ProcessesErrorControllerName.ToArray());
                processErrorEmployeeNameComboBox.Items.AddRange(data.ProcessErrorEmployeeName.ToArray());
                stageComboBox.Items.AddRange(data.Stage.ToArray());
                interventionComboBox.Items.AddRange(data.Intervention.ToArray());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading JSON data: {ex.Message}", "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
