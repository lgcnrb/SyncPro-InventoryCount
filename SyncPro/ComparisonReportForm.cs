using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SyncPro
{
    public partial class ComparisonReportForm : Form
    {
        public int SelectedStocktakingListId { get; private set; }  // Seçilen StocktakingListId
        private readonly UserInfoCollector userInfo;

        public ComparisonReportForm(UserInfoCollector userInfo, int stocktakingListId)
        {
            InitializeComponent();
            SelectedStocktakingListId = stocktakingListId;
            this.userInfo = userInfo;

            InitializeDataGridView();
            OptimizeDataGridView();
        }

        private void ComparisonReportForm_Load(object sender, EventArgs e)
        {
            LoadComparisonData();
        }

        // DataGridView'in sanallaştırma modu ve performans için gerekli ayarları yapılır.
        private void InitializeDataGridView()
        {
            advancedDataGridView1.VirtualMode = true;
            advancedDataGridView1.CellValueNeeded += AdvancedDataGridView1_CellValueNeeded;
        }

        // DataGridView'in performansını artırmak için bazı otomatik boyutlandırma özellikleri devre dışı bırakılır.
        private void OptimizeDataGridView()
        {
            advancedDataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            advancedDataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            advancedDataGridView1.AllowUserToResizeColumns = false;
            advancedDataGridView1.AllowUserToResizeRows = false;
            advancedDataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        }

        // Sanallaştırma modunda, sadece ekranda görünen hücreler işlenir.
        private void AdvancedDataGridView1_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            if (advancedDataGridView1.DataSource is DataTable dataTable && e.RowIndex < dataTable.Rows.Count)
            {
                e.Value = dataTable.Rows[e.RowIndex][e.ColumnIndex];
            }
        }

        // Veritabanından verileri çeker ve filtre uygulanmışsa sadece o verilere odaklanır.
        private void LoadComparisonData(string filter = "")
        {
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
                    sc.ProductCode IS NULL";

            // Eğer filtre parametresi varsa, sorguya WHERE koşulu eklenir.
            if (!string.IsNullOrEmpty(filter))
            {
                query += " AND si.ProductName LIKE @Filter";
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@StocktakingListId", SelectedStocktakingListId);

                        if (!string.IsNullOrEmpty(filter))
                        {
                            command.Parameters.AddWithValue("@Filter", $"%{filter}%");
                        }

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable comparisonTable = new DataTable();
                            adapter.Fill(comparisonTable);
                            advancedDataGridView1.DataSource = comparisonTable;
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                // Daha spesifik bir hata mesajı için SQL hatalarını ele alıyoruz.
                MessageBox.Show($"A database error occurred while loading comparison data: {sqlEx.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // Diğer genel hatalar için bir genel hata mesajı.
                MessageBox.Show($"An error occurred while loading comparison data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Veri filtresi uygulamak için kullanılır. Filtre ifadesi sağlanır.
        private void FilterData(string filterExpression)
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                if (advancedDataGridView1.DataSource is DataTable dataTable)
                {
                    dataTable.DefaultView.RowFilter = filterExpression;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while applying the filter: {ex.Message}", "Filter Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
    }
}
