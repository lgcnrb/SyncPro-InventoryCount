using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SyncPro.ProductCodeEditorForm;

namespace SyncPro
{
    public partial class SystemInventoryForm : Form
    {
        private readonly UserInfoCollector userInfo;
        private string jsonFilePath = Properties.Settings.Default.FilterPath;
        private List<Product> products; // Ürün verilerini tutacak liste

        public SystemInventoryForm(UserInfoCollector userInfo)
        {
            InitializeComponent();
            this.userInfo = userInfo;
            LoadProductData();
            UpdateTextBoxStates();
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
        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(productCodeTextBox.Text) ||
                string.IsNullOrWhiteSpace(productNameTextBox.Text) ||
                string.IsNullOrWhiteSpace(batchCodeTextBox.Text) ||
                string.IsNullOrWhiteSpace(stockQuantityTextBox.Text))
            {
                MessageBox.Show("Please fill in all the product details.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!int.TryParse(stockQuantityTextBox.Text, out _))
            {
                MessageBox.Show("Quantity must be a valid number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
        private void ExitButton_Click(object sender, EventArgs e)
        {

        }
        private void ClearFields()
        {
            productCodeTextBox.Clear();
            productNameTextBox.Clear();
            locationTextBox.Clear();
            batchCodeTextBox.Clear();
            stockQuantityTextBox.Clear();
        }

        private async void EnterButton_Click(object sender, EventArgs e)
        {
            string soundFilePath = @"Resources\Sounds\DataReg.wav";
            if (ValidateInputs())
            {
                var inventory = new SystemInventoryRepo
                {
                    ProductCode = productCodeTextBox.Text,
                    ProductName = productNameTextBox.Text,
                    Location = locationTextBox.Text,
                    BatchCode = batchCodeTextBox.Text,
                    StockQuantity = int.Parse(stockQuantityTextBox.Text),
                };

                try
                {
                    var repository = new SystemInventoryRepository();

                    bool success = await repository.Insert(inventory);

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
        private void UpdateTextBoxStates()
        {
            bool isBatchCodeEntered = !string.IsNullOrWhiteSpace(batchCodeTextBox.Text);
            productNameTextBox.Enabled = isBatchCodeEntered;
            locationTextBox.Enabled = isBatchCodeEntered;
            stockQuantityTextBox.Enabled = isBatchCodeEntered;
        }
        private void batchCodeTextBox_TextChanged(object sender, EventArgs e)
        {
            UpdateTextBoxStates();

        }
    }
}
