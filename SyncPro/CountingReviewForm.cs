using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SyncPro
{
    public partial class CountingReviewForm : Form
    {
        private readonly int stocktakingListId;
        private readonly bool countFinish;
        private readonly UserInfoCollector userInfo;

        public CountingReviewForm(UserInfoCollector userInfo, int stocktakingListId, bool countFinish)
        {
            InitializeComponent();
            this.stocktakingListId = stocktakingListId;
            this.userInfo = userInfo;
            this.countFinish = countFinish;
            FilterComboBox.SelectedIndex = 0;
        }

        private void CountingReviewForm_Load(object sender, EventArgs e)
        {
            this.stockCountTableAdapter.FillByStocktakingListId(this.syncProDatabaseDataSet.StockCount, stocktakingListId);
            CheckCountFinish(countFinish);
        }
        private void CheckCountFinish(bool countFinish)
        {
            DeleteButton.Enabled = !countFinish;
            EditButton.Enabled = !countFinish;
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            if (stockCountDataGridView.CurrentRow != null)
            {
                try
                {
                    string selectedBatchCode = stockCountDataGridView.CurrentRow.Cells[4].Value.ToString();
                    CountEditingForm countEditingForm = new CountEditingForm(userInfo, selectedBatchCode);
                    countEditingForm.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while opening the form: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                this.stockCountTableAdapter.FillByStocktakingListId(this.syncProDatabaseDataSet.StockCount, stocktakingListId);
            }
            else
            {
                MessageBox.Show("Please select a row in the DataGridView to edit.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void ExportButton_Click(object sender, EventArgs e)
        {
            ExternalMethods.ExportToExcel(stockCountDataGridView, "Counting");
        }

        
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (stockCountDataGridView.CurrentRow != null)
            {
                try
                {
                    string selectedBatchCode = stockCountDataGridView.CurrentRow.Cells[0].Value.ToString();

                    DialogResult result = MessageBox.Show($"Are you sure you want to delete the record with BatchCode: {selectedBatchCode}?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        StockCountRepository stockCountRepo = new StockCountRepository();

                        bool deletionSuccessful = DeleteByBatchCode(selectedBatchCode);

                        if (deletionSuccessful)
                        {
                            MessageBox.Show("Record deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            this.stockCountTableAdapter.FillByStocktakingListId(this.syncProDatabaseDataSet.StockCount, stocktakingListId);
                        }
                        else
                        {
                            MessageBox.Show("Failed to delete the record. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while deleting the record: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a row in the DataGridView to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public bool DeleteByBatchCode(string Id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.SyncProDatabaseConnectionString))
                {
                    connection.Open();

                    string query = "DELETE FROM StockCount WHERE Id = @Id";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", Id);

                        int rowsAffected = command.ExecuteNonQuery();

                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while deleting the record.", ex);
            }
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            this.stockCountTableAdapter.FillByStocktakingListId(this.syncProDatabaseDataSet.StockCount, stocktakingListId);
        }

        private void SearchTextBox_TextChanged(object sender, EventArgs e)
        {
            string columnName = FilterComboBox.Text;

            using (SqlConnection con = new SqlConnection(Properties.Settings.Default.SyncProDatabaseConnectionString))
            {
                con.Open();
                string searchValue = SearchTextBox.Text;

                string query = $"SELECT * FROM StockCount WHERE {columnName} LIKE @SearchValue + '%' AND StocktakingListId = @StocktakingListId";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@SearchValue", searchValue);
                    cmd.Parameters.AddWithValue("@StocktakingListId", stocktakingListId);

                    using (SqlDataAdapter adapt = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapt.Fill(dt);
                        stockCountDataGridView.DataSource = dt;
                    }
                }
            }
        }

        private void SearchTextBox_Click(object sender, EventArgs e)
        {
            SearchTextBox.Clear();
        }
    }
}
