using ExcelDataReader;
using System;
using System.Data;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Transactions;
using SyncPro.SyncProDatabaseDataSetTableAdapters;
using System.Data.SqlClient;

namespace SyncPro
{
    public partial class SystemInventory : UserControl
    {
        private readonly UserInfoCollector userInfo;

        public SystemInventory(UserInfoCollector userInfo)
        {
            InitializeComponent();
            this.userInfo = userInfo;
            FilterComboBox.SelectedIndex = 0;

        }

        private async void ImportButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Excel Files|*.xlsx;*.xls",
                Title = "Select an Excel File"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                SystemInventoryRepository inventoryRepo = new SystemInventoryRepository();

                try
                {
                    using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
                    {
                        using (var reader = ExcelReaderFactory.CreateReader(stream))
                        {
                            var dataSet = reader.AsDataSet();
                            var dataTable = dataSet.Tables[0];

                            using (var transaction = new TransactionScope(TransactionScopeOption.Required,
                                new TransactionOptions { IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted }))
                            {
                                for (int row = 1; row < dataTable.Rows.Count; row++)
                                {
                                    var dataRow = dataTable.Rows[row];
                                    var productCode = dataRow[0]?.ToString().Trim();
                                    var productName = dataRow[1]?.ToString().Trim();
                                    var location = dataRow[2]?.ToString().Trim();
                                    var batchCode = dataRow[3]?.ToString().Trim();
                                    var stockQuantityText = dataRow[4]?.ToString().Trim();

                                    if (string.IsNullOrEmpty(productCode) || string.IsNullOrEmpty(productName) || string.IsNullOrEmpty(location) || string.IsNullOrEmpty(stockQuantityText))
                                    {
                                        MessageBox.Show($"Invalid data at row {row + 1}: Some required fields are missing.", "Data Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        continue;
                                    }

                                    if (!int.TryParse(stockQuantityText, out int stockQuantity))
                                    {
                                        MessageBox.Show($"Invalid stock quantity at row {row + 1}. It should be an integer.", "Data Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        continue;
                                    }

                                    SystemInventoryRepo inventory = new SystemInventoryRepo
                                    {
                                        ProductCode = productCode,
                                        ProductName = productName,
                                        Location = location,
                                        BatchCode = string.IsNullOrEmpty(batchCode) ? null : batchCode,
                                        StockQuantity = stockQuantity
                                    };

                                    bool success = await inventoryRepo.Insert(inventory);
                                    if (!success)
                                    {
                                        MessageBox.Show($"Failed to insert data at row {row + 1}. The product code might already exist.", "Insert Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }

                                transaction.Complete();
                            }

                            MessageBox.Show("Data imported successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            systemInventoryTableAdapter.Fill(syncProDatabaseDataSet.SystemInventory);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while importing data: {ex.Message}", "Import Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void SystemInventory_Load(object sender, EventArgs e)
        {
            systemInventoryTableAdapter.Fill(syncProDatabaseDataSet.SystemInventory);
        }

        private void RefreshToolButton_Click(object sender, EventArgs e)
        {
            systemInventoryTableAdapter.Fill(syncProDatabaseDataSet.SystemInventory);
        }

        private void ExportButton_Click(object sender, EventArgs e)
        {
            ExternalMethods.ExportToExcel(systemInventoryDataGridView, "SystemInventory");
        }

        private void EnterButton_Click(object sender, EventArgs e)
        {
            using (SystemInventoryForm systemInventoryForm = new SystemInventoryForm(userInfo))
            {
                systemInventoryForm.ShowDialog();
            }
            systemInventoryTableAdapter.Fill(syncProDatabaseDataSet.SystemInventory);
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (systemInventoryDataGridView.CurrentRow != null)
            {
                try
                {
                    string selectedbatchCode = systemInventoryDataGridView.CurrentRow.Cells[3].Value.ToString();

                    DialogResult result = MessageBox.Show("Are you sure you want to delete this record?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        bool deletionSuccessful = DeleteRecord(selectedbatchCode);
                        if (deletionSuccessful)
                        {
                            MessageBox.Show("Record deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            systemInventoryTableAdapter.Fill(syncProDatabaseDataSet.SystemInventory);
                        }
                        else
                        {
                            MessageBox.Show("No data deleted in the database!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a row in the DataGridView!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        bool DeleteRecord(string batchCode)
        {
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.SyncProDatabaseConnectionString))
            {
                connection.Open();
                string query = "DELETE FROM SystemInventory WHERE BatchCode = @BatchCode";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@BatchCode", batchCode);
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        private void SearchTextBox_TextChanged(object sender, EventArgs e)
        {
            string columnName = FilterComboBox.Text;

            using (SqlConnection con = new SqlConnection(Properties.Settings.Default.SyncProDatabaseConnectionString))
            {
                con.Open();

                string query = $"SELECT * FROM SystemInventory WHERE {columnName} LIKE @SearchValue + '%'";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@SearchValue", SearchTextBox.Text);

                    using (SqlDataAdapter adapt = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapt.Fill(dt);
                        systemInventoryDataGridView.DataSource = dt;
                    }
                }
            }
        }

        private void SearchTextBox_Click(object sender, EventArgs e)
        {
            SearchTextBox.Clear();
        }

        private void DeleteAllButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete all records?", "Delete All Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.SyncProDatabaseConnectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM SystemInventory";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("All records deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("No data deleted in the database!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                systemInventoryTableAdapter.Fill(syncProDatabaseDataSet.SystemInventory);
            }
        }

    }
}
