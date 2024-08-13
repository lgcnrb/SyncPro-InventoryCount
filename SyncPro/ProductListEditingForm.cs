using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SyncPro
{
    public partial class ProductListEditingForm : Form
    {
        private string jsonFilePath = Properties.Settings.Default.FilterPath;
        private readonly UserInfoCollector userInfo;

        public class Product
        {
            public string ProductCode { get; set; }
            public string ProductName { get; set; }
        }
        public ProductListEditingForm(UserInfoCollector userInfo)
        {
            InitializeComponent();
            this.userInfo = userInfo;
            InitializeDataGridView();
            LoadJsonData();
        }

        private void ProductListEditingForm_Load(object sender, EventArgs e)
        {

        }
        private void InitializeDataGridView()
        {
            // DataGridView sütunlarını oluştur
            dataGridViewProducts.Columns.Clear();

            // ProductCode sütununu ekle ve Fill olarak ayarla
            var productCodeColumn = new DataGridViewTextBoxColumn
            {
                Name = "ProductCode",
                HeaderText = "Product Code",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };
            dataGridViewProducts.Columns.Add(productCodeColumn);

            // ProductName sütununu ekle ve Fill olarak ayarla
            var productNameColumn = new DataGridViewTextBoxColumn
            {
                Name = "ProductName",
                HeaderText = "Product Name",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };
            dataGridViewProducts.Columns.Add(productNameColumn);

            // DataGridView'in sütunları doldurması için düzenleme
            dataGridViewProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void LoadJsonData()
        {
            if (File.Exists(jsonFilePath))
            {
                string json = File.ReadAllText(jsonFilePath);

                // JSON verilerini deserialize et
                var products = JsonSerializer.Deserialize<List<Product>>(json);

                // DataGridView'e veri ekle
                dataGridViewProducts.Rows.Clear();
                foreach (var product in products)
                {
                    dataGridViewProducts.Rows.Add(product.ProductCode, product.ProductName);
                }
            }
            else
            {
                MessageBox.Show("JSON file not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // JSON içeriğini DataGridView'den al
            var products = new List<Product>();
            foreach (DataGridViewRow row in dataGridViewProducts.Rows)
            {
                if (!row.IsNewRow)
                {
                    products.Add(new Product
                    {
                        ProductCode = row.Cells["ProductCode"].Value?.ToString(),
                        ProductName = row.Cells["ProductName"].Value?.ToString()
                    });
                }
            }

            // JSON formatına dönüştür ve dosyaya yaz
            string jsonString = JsonSerializer.Serialize(products, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(jsonFilePath, jsonString);

            MessageBox.Show("JSON file saved successfully.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void NewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Varsayılan JSON içeriği oluştur
            var defaultContent = new List<Product>();
            string jsonString = JsonSerializer.Serialize(defaultContent, new JsonSerializerOptions { WriteIndented = true });

            // JSON içeriğini dosyaya yaz ve DataGridView'i güncelle
            SaveJsonToFile(jsonFilePath);
            dataGridViewProducts.Rows.Clear();

            MessageBox.Show("New JSON file created with default content.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void SaveJsonToFile(string path)
        {
            var products = new List<Product>();
            foreach (DataGridViewRow row in dataGridViewProducts.Rows)
            {
                if (!row.IsNewRow)
                {
                    products.Add(new Product
                    {
                        ProductCode = row.Cells["ProductCode"].Value?.ToString(),
                        ProductName = row.Cells["ProductName"].Value?.ToString()
                    });
                }
            }

            string jsonContent = JsonSerializer.Serialize(products, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(path, jsonContent);
            MessageBox.Show("JSON file saved successfully.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "JSON Files (*.json)|*.json|All Files (*.*)|*.*";
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    jsonFilePath = openFileDialog.FileName;

                    // JSON içeriğini oku ve DataGridView'e yükle
                    string json = File.ReadAllText(jsonFilePath);
                    var products = JsonSerializer.Deserialize<List<Product>>(json);
                    dataGridViewProducts.Rows.Clear();
                    foreach (var product in products)
                    {
                        dataGridViewProducts.Rows.Add(product.ProductCode, product.ProductName);
                    }
                }
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "JSON Files (*.json)|*.json|All Files (*.*)|*.*";
                saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    jsonFilePath = saveFileDialog.FileName;

                    // JSON içeriğini dosyaya yaz
                    SaveJsonToFile(jsonFilePath);
                }
            }
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

                    try
                    {
                        // Excel dosyasını oku
                        List<Product> products = ReadExcelFile(excelFilePath);

                        // JSON formatına dönüştür
                        string jsonString = JsonSerializer.Serialize(products, new JsonSerializerOptions { WriteIndented = true });

                        // JSON verisini DataGridView'de göster
                        dataGridViewProducts.Rows.Clear();
                        foreach (var product in products)
                        {
                            dataGridViewProducts.Rows.Add(product.ProductCode, product.ProductName);
                        }

                        // JSON dosyasını oluştur
                        string jsonFilePath = Path.ChangeExtension(excelFilePath, ".json");
                        File.WriteAllText(jsonFilePath, jsonString);

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
