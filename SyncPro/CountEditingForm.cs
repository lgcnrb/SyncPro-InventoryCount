using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SyncPro.ProductCodeEditorForm;

namespace SyncPro
{
    public partial class CountEditingForm : Form
    {
        private StockCountRepo currentProductData;
        private readonly string batchCode;
        private readonly UserInfoCollector userInfo;
        private List<Product> products;
        private readonly string jsonFilePath = Properties.Settings.Default.FilterPath;

        public CountEditingForm(UserInfoCollector userInfo, string batchCode)
        {
            InitializeComponent();
            this.userInfo = userInfo;
            this.batchCode = batchCode;
            LoadProductData();
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(productCodeTextBox.Text) ||
                string.IsNullOrWhiteSpace(productNameTextBox.Text) ||
                string.IsNullOrWhiteSpace(batchCodeTextBox.Text) ||
                string.IsNullOrWhiteSpace(countedQuantityTextBox.Text))
            {
                MessageBox.Show("Please fill in all the product details.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!int.TryParse(countedQuantityTextBox.Text, out _))
            {
                MessageBox.Show("Quantity must be a valid number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void LoadProductData()
        {
            if (File.Exists(jsonFilePath))
            {
                try
                {
                    string json = File.ReadAllText(jsonFilePath);
                    products = JsonSerializer.Deserialize<List<Product>>(json);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while loading the JSON data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("JSON file not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void EnterButton_Click(object sender, EventArgs e)
        {
            if (ValidateInputs())
            {
                var stockCount = new StockCountRepo
                {
                    UserId = userInfo.UserID,
                    ProductCode = productCodeTextBox.Text,
                    ProductName = productNameTextBox.Text,
                    Location = locationTextBox.Text,
                    BatchCode = batchCodeTextBox.Text,
                    CountedQuantity = int.Parse(countedQuantityTextBox.Text),
                };

                try
                {
                    var repository = new StockCountRepository();
                    bool success = await repository.Update(stockCount);

                    if (success)
                    {
                        MessageBox.Show("Stock count updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Failed to update stock count.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void productNameTextBox_TextChanged(object sender, EventArgs e)
        {
            string productName = productNameTextBox.Text;
            var product = products?.FirstOrDefault(p => p.ProductName.Equals(productName, StringComparison.OrdinalIgnoreCase));

            if (product != null)
            {
                productCodeTextBox.Text = product.ProductCode;
            }
            else
            {
                productCodeTextBox.Clear();
            }

            if (currentProductData != null)
            {
                UpdateTextBoxColor(productNameTextBox, currentProductData.ProductName);
                UpdateTextBoxColor(productCodeTextBox, currentProductData.ProductCode);
            }
            else
            {
                productCodeTextBox.BackColor = SystemColors.Control;
                productNameTextBox.BackColor = Color.White;
            }
        }

        private void countedQuantityTextBox_TextChanged(object sender, EventArgs e)
        {
            bool isParsed = int.TryParse(countedQuantityTextBox.Text, out var enteredQuantity);

            if (currentProductData != null)
            {
                bool isValid = isParsed && enteredQuantity == currentProductData.CountedQuantity;
                countedQuantityTextBox.BackColor = isValid ? Color.LightGreen : Color.LightCoral;
            }
            else
            {
                countedQuantityTextBox.BackColor = Color.White;
            }
        }

        private void locationTextBox_TextChanged(object sender, EventArgs e)
        {
            UpdateTextBoxColors();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UpdateTextBoxStates()
        {
            bool isBatchCodeEntered = !string.IsNullOrWhiteSpace(batchCodeTextBox.Text);
            productNameTextBox.Enabled = isBatchCodeEntered;
            locationTextBox.Enabled = isBatchCodeEntered;
            countedQuantityTextBox.Enabled = isBatchCodeEntered;
        }

        private async Task LoadProductDataByBatchCode(string batchCode)
        {
            string connectionString = Properties.Settings.Default.SyncProDatabaseConnectionString;
            string query = "SELECT ProductCode, ProductName, Location, BatchCode, CountedQuantity FROM StockCount WHERE BatchCode = @BatchCode";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@BatchCode", batchCode);
                        await connection.OpenAsync();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                productCodeTextBox.Text = reader["ProductCode"].ToString();
                                productNameTextBox.Text = reader["ProductName"].ToString();
                                locationTextBox.Text = reader["Location"].ToString();
                                batchCodeTextBox.Text = reader["BatchCode"].ToString();
                                countedQuantityTextBox.Text = reader["CountedQuantity"].ToString();
                            }
                            else
                            {
                                ClearFields();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadProductDataByBatchCodeTemp(string batchCode)
        {
            string connectionString = Properties.Settings.Default.SyncProDatabaseConnectionString;
            string query = "SELECT ProductCode, ProductName, Location, BatchCode, StockQuantity FROM SystemInventory WHERE BatchCode = @BatchCode";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@BatchCode", batchCode);
                        await connection.OpenAsync();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                currentProductData = new StockCountRepo
                                {
                                    ProductCode = reader["ProductCode"].ToString(),
                                    ProductName = reader["ProductName"].ToString(),
                                    Location = reader["Location"].ToString(),
                                    BatchCode = reader["BatchCode"].ToString(),
                                    CountedQuantity = int.Parse(reader["StockQuantity"].ToString()), // Düzeltildi
                                };
                            }
                            else
                            {
                                currentProductData = null;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                currentProductData = null;
            }
        }

        private void UpdateTextBoxColors()
        {
            UpdateTextBoxColor(productCodeTextBox, currentProductData?.ProductCode);
            UpdateTextBoxColor(productNameTextBox, currentProductData?.ProductName);
            UpdateTextBoxColor(locationTextBox, currentProductData?.Location);
            UpdateTextBoxColor(countedQuantityTextBox, currentProductData?.CountedQuantity.ToString() ?? string.Empty);
            UpdateTextBoxColor(batchCodeTextBox, currentProductData?.BatchCode);
        }

        private void UpdateTextBoxColor(TextBox textBox, string expectedValue)
        {
            if (string.IsNullOrEmpty(expectedValue))
            {
                textBox.BackColor = Color.White;
            }
            else if (textBox.Text.Equals(expectedValue, StringComparison.OrdinalIgnoreCase))
            {
                textBox.BackColor = Color.LightGreen;
            }
            else
            {
                textBox.BackColor = Color.LightCoral;
            }
        }

        private void ClearFields()
        {
            productCodeTextBox.Clear();
            productNameTextBox.Clear();
            locationTextBox.Clear();
            batchCodeTextBox.Clear();
            countedQuantityTextBox.Clear();
        }

        private async void CountEditingForm_Load(object sender, EventArgs e)
        {
            await LoadProductDataByBatchCode(batchCode);
            await LoadProductDataByBatchCodeTemp(batchCode);
            UpdateTextBoxColors();
        }
    }
}
