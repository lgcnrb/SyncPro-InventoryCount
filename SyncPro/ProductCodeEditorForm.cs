using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;
using System.Text.Json.Serialization;
using ExcelDataReader;

namespace SyncPro
{
    public partial class ProductCodeEditorForm : Form
    {
        private string jsonFilePath = "product_code.json";
        private readonly UserInfoCollector userInfo;
        public class Product
        {
            public string ProductCode { get; set; }
            public string ProductName { get; set; }
        }
        public ProductCodeEditorForm(UserInfoCollector userInfo)
        {
            InitializeComponent();
            this.userInfo = userInfo;
            LoadJsonData();
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Get JSON content from RichTextBox
            string jsonContent = richTextBoxJsonData.Text;

            // Save JSON content to file
            File.WriteAllText(jsonFilePath, jsonContent);

            MessageBox.Show("JSON file saved successfully.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void LoadJsonData()
        {
            if (File.Exists(jsonFilePath))
            {
                string json = File.ReadAllText(jsonFilePath);
                richTextBoxJsonData.Text = json; // Display JSON data in RichTextBox
            }
            else
            {
                MessageBox.Show("JSON file not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SaveJsonToFile(string path)
        {
            string jsonContent = richTextBoxJsonData.Text;
            File.WriteAllText(path, jsonContent);
            MessageBox.Show("JSON file saved successfully.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void NewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Create a new default JSON content
            var defaultContent = new { Products = new List<Product>() }; // Default content can be adjusted
            string jsonString = JsonSerializer.Serialize(defaultContent, new JsonSerializerOptions { WriteIndented = true });

            // Save and load the new JSON content
            SaveJsonToFile(jsonFilePath);
            richTextBoxJsonData.Text = jsonString;

            MessageBox.Show("New JSON file created with default content.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ErrorContentEditForm_Load(object sender, EventArgs e)
        {
            LoadJsonData();
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Open file dialog for opening JSON file
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "JSON Files (*.json)|*.json|All Files (*.*)|*.*";
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    jsonFilePath = openFileDialog.FileName;

                    // Read JSON content from file
                    string json = File.ReadAllText(jsonFilePath);
                    richTextBoxJsonData.Text = json;
                }
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Open file dialog for save as operation
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "JSON Files (*.json)|*.json|All Files (*.*)|*.*";
                saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    jsonFilePath = saveFileDialog.FileName;

                    // Get JSON content from RichTextBox
                    string jsonContent = richTextBoxJsonData.Text;

                    // Save JSON content to file
                    File.WriteAllText(jsonFilePath, jsonContent);

                    MessageBox.Show("JSON file saved successfully.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void UndoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBoxJsonData.Undo();
        }

        private void RedoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBoxJsonData.Redo();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBoxJsonData.Cut();
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBoxJsonData.Copy();
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBoxJsonData.Paste();
        }

        private void SelectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBoxJsonData.SelectAll();
        }
        private List<Product> ReadExcelFile(string filePath)
        {
            List<Product> products = new List<Product>();

            using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    var dataSet = reader.AsDataSet();
                    var dataTable = dataSet.Tables[0];

                    // Assume first row is header
                    for (int i = 1; i < dataTable.Rows.Count; i++)
                    {
                        var row = dataTable.Rows[i];
                        var product = new Product
                        {
                            ProductCode = row[0].ToString(),
                            ProductName = row[1].ToString()
                        };
                        products.Add(product);
                    }
                }
            }

            return products;
        }
        private void ImportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Excel Files (*.xls;*.xlsx)|*.xls;*.xlsx|All Files (*.*)|*.*";
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string excelFilePath = openFileDialog.FileName;
                    string jsonFilePath = Path.ChangeExtension(excelFilePath, ".json");

                    try
                    {
                        // Excel dosyasını oku
                        List<Product> products = ReadExcelFile(excelFilePath);

                        // JSON formatına dönüştür
                        string jsonString = JsonSerializer.Serialize(products, new JsonSerializerOptions { WriteIndented = true });

                        // JSON dosyasına yaz
                        File.WriteAllText(jsonFilePath, jsonString);

                        // JSON verisini RichTextBox'ta göster
                        richTextBoxJsonData.Text = jsonString;

                        MessageBox.Show("Excel data imported and saved as JSON successfully.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error importing Excel file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
