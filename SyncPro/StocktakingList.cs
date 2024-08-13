using SyncPro.SyncProDatabaseDataSetTableAdapters;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zuby.ADGV;

namespace SyncPro
{
    public partial class StocktakingList : UserControl
    {
        private readonly UserInfoCollector userInfo;

        public StocktakingList(UserInfoCollector userInfo)
        {
            InitializeComponent();
            this.userInfo = userInfo;
            FilterComboBox.SelectedIndex = 0;
        }

        private async void StartCountingStripButton_Click(object sender, EventArgs e)
        {
            var repository = new StocktakingListRepository();
            if (!await repository.InventoryHasItemsAsync())
            {
                MessageBox.Show("No inventory items available to count.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (var inputForm = new InventoryCountInformationForm(userInfo))
            {
                if (inputForm.ShowDialog() == DialogResult.OK)
                {
                    var stocktakingList = new StocktakingListRepo
                    {
                        CreationDate = DateTime.Now,
                        CountedBy = inputForm.CountedByName,
                        Auditor = inputForm.AuditorName,
                        FinishDate = DateTime.MaxValue,
                        CountFinish = false,
                    };

                    try
                    {
                        int newListId = await repository.InsertAndGetIdAsync(stocktakingList);

                        if (newListId > 0)
                        {
                            MessageBox.Show("Stocktaking list created successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            stocktakingListTableAdapter.Fill(syncProDatabaseDataSet.StocktakingList);

                            var stockCountForm = new InventoryCountingForm(userInfo, newListId);
                            stockCountForm.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("Failed to create stocktaking list.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred while creating the stocktaking list: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void StocktakingList_Load(object sender, EventArgs e)
        {
            stocktakingListTableAdapter.Fill(syncProDatabaseDataSet.StocktakingList);
            CheckUserRestrictions(userInfo.Role);
        }
        private void CheckUserRestrictions(string role)
        {
            bool isRoot = (role == "Root");
            StartButton.Enabled = isRoot;
            FinishButton.Enabled = isRoot;
            DeleteButton.Enabled = isRoot;
        }
        private void stocktakingListDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = stocktakingListDataGridView.Rows[e.RowIndex];
                int stocktakingListId = Convert.ToInt32(row.Cells[0].Value);
                bool countFinish = Convert.ToBoolean(stocktakingListDataGridView.CurrentRow.Cells[5].Value);

                ShowStocktakingDetails(stocktakingListId, countFinish);
            }
        }

        private void ShowStocktakingDetails(int stocktakingListId, bool countFinish)
        {
            var reviewForm = new CountingReviewForm(userInfo,stocktakingListId, countFinish);
            reviewForm.ShowDialog();
        }

        private void ContinueButton_Click(object sender, EventArgs e)
        {
            if (stocktakingListDataGridView.CurrentRow != null)
            {
                try
                {
                    string selectedId = stocktakingListDataGridView.CurrentRow.Cells[0].Value?.ToString();
                    bool countFinish = Convert.ToBoolean(stocktakingListDataGridView.CurrentRow.Cells[5].Value);

                    if (string.IsNullOrEmpty(selectedId))
                    {
                        MessageBox.Show("The selected row does not contain a valid stocktaking list ID.", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (int.TryParse(selectedId, out int stocktakingListId))
                    {
                        if (countFinish)
                        {
                            MessageBox.Show("This stocktaking list has already been finished and cannot be edited.", "List Finished", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        var stockCountForm = new InventoryCountingForm(userInfo, stocktakingListId);
                        stockCountForm.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("The selected stocktaking list ID is not valid.", "Invalid ID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a stocktaking list to continue.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }



        private void SearchTextBox_TextChanged(object sender, EventArgs e)
        {
            string columnName = FilterComboBox.Text;

            if (string.IsNullOrEmpty(columnName) || string.IsNullOrEmpty(SearchTextBox.Text))
            {
                return;
            }

            using (SqlConnection con = new SqlConnection(Properties.Settings.Default.SyncProDatabaseConnectionString))
            {
                try
                {
                    con.Open();
                    string query = $"SELECT * FROM StocktakingList WHERE {columnName} LIKE @SearchValue + '%'";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@SearchValue", SearchTextBox.Text);

                        using (SqlDataAdapter adapt = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapt.Fill(dt);
                            stocktakingListDataGridView.DataSource = dt;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred during search: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void SearchTextBox_Click(object sender, EventArgs e)
        {
            SearchTextBox.Clear();
        }

        private async void FinishButton_Click(object sender, EventArgs e)
        {
            if (stocktakingListDataGridView.CurrentRow != null)
            {
                try
                {
                    string selectedId = stocktakingListDataGridView.CurrentRow.Cells[0].Value?.ToString();

                    if (string.IsNullOrEmpty(selectedId))
                    {
                        MessageBox.Show("The selected row does not contain a valid stocktaking list ID.", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (int.TryParse(selectedId, out int stocktakingListId))
                    {
                        var repository = new StocktakingListRepository();
                        DateTime finishDate = DateTime.Now;

                        bool success = await repository.UpdateFinishDateAsync(stocktakingListId, finishDate);

                        if (success)
                        {
                            MessageBox.Show("Stocktaking list marked as finished successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            stocktakingListTableAdapter.Fill(syncProDatabaseDataSet.StocktakingList);
                        }
                        else
                        {
                            MessageBox.Show("Failed to update stocktaking list.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("The selected stocktaking list ID is not valid.", "Invalid ID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a stocktaking list to finish.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        
        private async void DeleteButton_Click(object sender, EventArgs e)
        {
            if (stocktakingListDataGridView.CurrentRow != null)
            {
                try
                {
                    string selectedId = stocktakingListDataGridView.CurrentRow.Cells[0].Value?.ToString();

                    if (string.IsNullOrEmpty(selectedId))
                    {
                        MessageBox.Show("The selected row does not contain a valid stocktaking list ID.", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (int.TryParse(selectedId, out int stocktakingListId))
                    {
                        var repository = new StocktakingListRepository();

                        DialogResult result = MessageBox.Show("Are you sure you want to delete this stocktaking list and its related counts?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                        if (result == DialogResult.Yes)
                        {
                            bool success = await repository.DeleteStocktakingListAsync(stocktakingListId);

                            if (success)
                            {
                                MessageBox.Show("Stocktaking list deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                stocktakingListTableAdapter.Fill(syncProDatabaseDataSet.StocktakingList);
                            }
                            else
                            {
                                MessageBox.Show("Failed to delete stocktaking list.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("The selected stocktaking list ID is not valid.", "Invalid ID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a stocktaking list to delete.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void StartButton_Click(object sender, EventArgs e)
        {
            if (stocktakingListDataGridView.CurrentRow != null)
            {
                try
                {
                    string selectedId = stocktakingListDataGridView.CurrentRow.Cells[0].Value?.ToString();

                    if (string.IsNullOrEmpty(selectedId))
                    {
                        MessageBox.Show("The selected row does not contain a valid stocktaking list ID.", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (int.TryParse(selectedId, out int stocktakingListId))
                    {
                        var repository = new StocktakingListRepository();

                        bool countFinish = false;

                        bool success = await repository.UpdateFinishStatusAsync(stocktakingListId, countFinish);

                        if (success)
                        {
                            MessageBox.Show("Stocktaking list updated successfully with CountFinish set to false.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            stocktakingListTableAdapter.Fill(syncProDatabaseDataSet.StocktakingList);
                        }
                        else
                        {
                            MessageBox.Show("Failed to update stocktaking list.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("The selected stocktaking list ID is not valid.", "Invalid ID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a stocktaking list to start.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void OpenButton_Click(object sender, EventArgs e)
        {
            if (stocktakingListDataGridView.CurrentRow != null)
            {
                try
                {
                    int stocktakingListId = Convert.ToInt32(stocktakingListDataGridView.CurrentRow.Cells[0].Value?.ToString());
                    bool countFinish = Convert.ToBoolean(stocktakingListDataGridView.CurrentRow.Cells[5].Value?.ToString());
                    ShowStocktakingDetails(stocktakingListId, countFinish);

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while retrieving the details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a row in the DataGridView to view details.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            stocktakingListTableAdapter.Fill(syncProDatabaseDataSet.StocktakingList);
        }

        private void CompareButton_Click(object sender, EventArgs e)
        {
            if (stocktakingListDataGridView.CurrentRow != null)
            {
                try
                {
                    int stocktakingListId = Convert.ToInt32(stocktakingListDataGridView.CurrentRow.Cells[0].Value?.ToString());
                    var comparisonForm = new ComparisonReportForm(userInfo,stocktakingListId);
                    comparisonForm.ShowDialog();

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while retrieving the details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a row in the DataGridView to view details.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ComparisonReportButton_Click(object sender, EventArgs e)
        {
            if (stocktakingListDataGridView.CurrentRow != null)
            {
                try
                {
                    int stocktakingListId = Convert.ToInt32(stocktakingListDataGridView.CurrentRow.Cells[0].Value?.ToString());
                    string connectionString = Properties.Settings.Default.SyncProDatabaseConnectionString;

                    string query = @"
        SELECT 
            si.ProductCode,
            si.ProductName,
            si.Location,
            si.BatchCode,
            si.StockQuantity AS SystemStockQuantity
        FROM 
            SystemInventory si
        LEFT JOIN 
            StockCount sc 
            ON si.ProductCode = sc.ProductCode 
            AND si.ProductName = sc.ProductName 
            AND si.Location = sc.Location 
            AND si.BatchCode = sc.BatchCode 
            AND sc.StocktakingListId = @StocktakingListId
        WHERE 
            sc.ProductCode IS NULL;";

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        try
                        {
                            connection.Open();

                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@StocktakingListId", stocktakingListId);

                                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                                {
                                    DataTable comparisonTable = new DataTable();
                                    adapter.Fill(comparisonTable);

                                    // Verileri Excel'e aktar
                                    ExternalMethods.ExportToExcelTable(comparisonTable, "ComparisonData");
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"An error occurred while loading comparison data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while retrieving the details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a row in the DataGridView to view details.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
