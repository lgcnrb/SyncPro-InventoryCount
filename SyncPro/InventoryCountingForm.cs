using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;
using System.IO;
using System.Data.SqlClient;
using static SyncPro.ProductCodeEditorForm;
using System.Media;

namespace SyncPro
{
    public partial class InventoryCountingForm : Form
    {
        public class ProductData
        {
            public string ProductCode { get; set; }
            public string ProductName { get; set; }
            public string Location { get; set; }
            public string BatchCode { get; set; }
            public int? StockQuantity { get; set; }
        }

        private ProductData currentProductData;
        private readonly int stocktakingListId;
        private readonly UserInfoCollector userInfo;
        private List<Product> products; // Ürün verilerini tutacak liste
        private string jsonFilePath = Properties.Settings.Default.FilterPath;

        public InventoryCountingForm(UserInfoCollector userInfo, int stocktakingListId)
        {
            InitializeComponent();
            this.userInfo = userInfo;
            this.stocktakingListId = stocktakingListId;
            LoadProductData();
            UpdateTextBoxStates();
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

        private async void EnterButton_Click(object sender, EventArgs e)
        {
            string soundFilePath = @"Resources\Sounds\DataReg.wav";
            if (ValidateInputs())
            {
                var stockCount = new StockCountRepo
                {
                    StocktakingListId = stocktakingListId,
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

                    bool success = await repository.Insert(stockCount);

                    if (success)
                    {
                        try
                        {
                            using (SoundPlayer player = new SoundPlayer(soundFilePath))
                            {
                                player.Play();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"An error occurred while playing sound: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        ClearFields();
                    }
                    else
                    {
                        MessageBox.Show("Failed to save stock count.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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
                productCodeTextBox.Clear(); // Ürün adı bulunamazsa ürün kodunu temizle
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

        private async void batchCodeTextBox_TextChanged(object sender, EventArgs e)
        {
            string batchCode = batchCodeTextBox.Text;
            await LoadProductDataByBatchCode(batchCode);
            UpdateTextBoxStates();
            if (currentProductData != null)
            {
                UpdateTextBoxColor(batchCodeTextBox, currentProductData.BatchCode);
            }
            else
            {
                ResetTextBoxColors();
            }
        }  

        private void countedQuantityTextBox_TextChanged(object sender, EventArgs e)
        {
            if (currentProductData?.StockQuantity.HasValue == true)
            {
                bool isValid = int.TryParse(countedQuantityTextBox.Text, out var countedQuantity) && countedQuantity == currentProductData.StockQuantity.Value;
                countedQuantityTextBox.BackColor = isValid ? Color.LightGreen : Color.LightCoral;
            }
            else
            {
                countedQuantityTextBox.BackColor = Color.White;
            }
        }

        private void locationTextBox_TextChanged(object sender, EventArgs e)
        {
            if (currentProductData != null)
            {
                UpdateTextBoxColor(locationTextBox, currentProductData.Location);
            }
            else
            {
                locationTextBox.BackColor = Color.White;
            }
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
                                currentProductData = new ProductData
                                {
                                    ProductCode = reader["ProductCode"].ToString(),
                                    ProductName = reader["ProductName"].ToString(),
                                    Location = reader["Location"].ToString(),
                                    BatchCode = reader["BatchCode"].ToString(),
                                    StockQuantity = int.TryParse(reader["StockQuantity"].ToString(), out var stockQuantity) ? stockQuantity : (int?)null
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

        private void UpdateTextBoxColor(TextBox textBox, string expectedValue)
        {
            if (textBox.Text.Equals(expectedValue, StringComparison.OrdinalIgnoreCase))
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

        private void ResetTextBoxColors()
        {
            productCodeTextBox.BackColor = SystemColors.Control;
            productNameTextBox.BackColor = Color.White;
            locationTextBox.BackColor = Color.White;
            batchCodeTextBox.BackColor = Color.White;
            countedQuantityTextBox.BackColor = Color.White;
        }
        private void PlaySound(string filePath)
        {
            try
            {
                using (SoundPlayer player = new SoundPlayer(filePath))
                {
                    player.Play();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while playing sound: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
