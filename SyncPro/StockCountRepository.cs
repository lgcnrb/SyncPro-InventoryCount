using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SyncPro
{
    public class StockCountRepository
    {
        private readonly string _connectionString = Properties.Settings.Default.SyncProDatabaseConnectionString;
        public async Task<bool> Insert(StockCountRepo count)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                // Check if the product is in the system
                bool isProductInSystem = await CheckIfProductInSystem(connection, count.BatchCode);

                // Get stock quantity and difference if the product is in the system
                int stockQuantity = 0;
                int quantityDifference = 0;
                if (isProductInSystem)
                {
                    (stockQuantity, quantityDifference) = await GetStockQuantityAndDifference(connection, count.BatchCode, count);
                }
                else
                {
                    quantityDifference = count.CountedQuantity;
                }

                // Check if the batch code with the given stocktaking list ID already exists
                using (SqlCommand checkCommand = new SqlCommand(@"
            SELECT COUNT(*)
            FROM StockCount
            WHERE BatchCode = @BatchCode AND StocktakingListId = @StocktakingListId", connection))
                {
                    checkCommand.Parameters.AddWithValue("@BatchCode", count.BatchCode);
                    checkCommand.Parameters.AddWithValue("@StocktakingListId", count.StocktakingListId);
                    int existingCount = (int)await checkCommand.ExecuteScalarAsync();

                    if (existingCount > 0)
                    {
                        MessageBox.Show("The batch code already exists for this stocktaking list. Please enter a unique batch code.", "Duplicate Batch Code", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }

                // Insert new record
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"
            INSERT INTO StockCount (UserId, ProductCode, ProductName, Location, BatchCode, CountedQuantity, StocktakingListId, IsProductInSystem, QuantityDifference, ProductCodeMatch, ProductNameMatch, LocationMatch)
            VALUES (@UserId, @ProductCode, @ProductName, @Location, @BatchCode, @CountedQuantity, @StocktakingListId, @IsProductInSystem, @QuantityDifference, @ProductCodeMatch, @ProductNameMatch, @LocationMatch)";
                    command.CommandType = CommandType.Text;

                    command.Parameters.AddWithValue("@UserId", count.UserId);
                    command.Parameters.AddWithValue("@ProductCode", count.ProductCode);
                    command.Parameters.AddWithValue("@ProductName", count.ProductName);
                    command.Parameters.AddWithValue("@Location", count.Location);
                    command.Parameters.AddWithValue("@BatchCode", count.BatchCode);
                    command.Parameters.AddWithValue("@CountedQuantity", count.CountedQuantity);
                    command.Parameters.AddWithValue("@StocktakingListId", count.StocktakingListId);
                    command.Parameters.AddWithValue("@IsProductInSystem", isProductInSystem);
                    command.Parameters.AddWithValue("@QuantityDifference", quantityDifference);
                    command.Parameters.AddWithValue("@ProductCodeMatch", count.ProductCodeMatch);
                    command.Parameters.AddWithValue("@ProductNameMatch", count.ProductNameMatch);
                    command.Parameters.AddWithValue("@LocationMatch", count.LocationMatch);

                    int rowsAffected = await command.ExecuteNonQueryAsync();
                    return rowsAffected > 0;
                }
            }
        }

        private async Task<bool> CheckIfProductInSystem(SqlConnection connection, string batchCode)
        {
            string query = "SELECT COUNT(*) FROM SystemInventory WHERE BatchCode = @BatchCode";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@BatchCode", batchCode);
                int countInSystem = (int)await command.ExecuteScalarAsync();
                return countInSystem > 0;
            }
        }
        public async Task<bool> Update(StockCountRepo count)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                bool isProductInSystem = await CheckIfProductInSystem(connection, count.BatchCode);

                int stockQuantity = 0;
                int quantityDifference = 0;
                if (isProductInSystem)
                {
                    (stockQuantity, quantityDifference) = await GetStockQuantityAndDifference(connection, count.BatchCode, count);
                }
                else
                {
                    quantityDifference = count.CountedQuantity;
                }

                try
                {
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = @"
                            UPDATE StockCount
                            SET ProductCode = @ProductCode,
                                ProductName = @ProductName,
                                Location = @Location,
                                CountedQuantity = @CountedQuantity,
                                IsProductInSystem = @IsProductInSystem,
                                QuantityDifference = @QuantityDifference,
                                ProductCodeMatch = @ProductCodeMatch,
                                ProductNameMatch = @ProductNameMatch,
                                LocationMatch = @LocationMatch
                            WHERE BatchCode = @BatchCode";
                        command.CommandType = CommandType.Text;

                        command.Parameters.AddWithValue("@ProductCode", count.ProductCode);
                        command.Parameters.AddWithValue("@ProductName", count.ProductName);
                        command.Parameters.AddWithValue("@Location", count.Location);
                        command.Parameters.AddWithValue("@BatchCode", count.BatchCode);
                        command.Parameters.AddWithValue("@CountedQuantity", count.CountedQuantity);
                        command.Parameters.AddWithValue("@IsProductInSystem", isProductInSystem);
                        command.Parameters.AddWithValue("@QuantityDifference", quantityDifference);
                        command.Parameters.AddWithValue("@ProductCodeMatch", count.ProductCodeMatch);
                        command.Parameters.AddWithValue("@ProductNameMatch", count.ProductNameMatch);
                        command.Parameters.AddWithValue("@LocationMatch", count.LocationMatch);

                        int rowsAffected = await command.ExecuteNonQueryAsync();
                        if (rowsAffected > 0)
                        {
                            return true;
                        }
                        else
                        {
                            Console.WriteLine("No rows affected.");
                            return false;
                        }
                    }
                }
                catch (SqlException sqlEx)
                {
                    // SQL hatalarını detaylı göster
                    Console.WriteLine($"SQL Error: {sqlEx.Message}");
                    return false;
                }
                catch (Exception ex)
                {
                    // Diğer hataları detaylı göster
                    Console.WriteLine($"An error occurred: {ex.Message}");
                    return false;
                }
            }
        }

        private async Task<(int stockQuantity, int quantityDifference)> GetStockQuantityAndDifference(SqlConnection connection, string batchCode, StockCountRepo count)
        {
            string query = "SELECT ProductCode, ProductName, Location, StockQuantity FROM SystemInventory WHERE BatchCode = @BatchCode";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@BatchCode", batchCode);

                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        int stockQuantity = Convert.ToInt32(reader["StockQuantity"]);
                        bool productCodeMatch = count.ProductCode.Equals(reader["ProductCode"].ToString(), StringComparison.OrdinalIgnoreCase);
                        bool productNameMatch = count.ProductName.Equals(reader["ProductName"].ToString(), StringComparison.OrdinalIgnoreCase);
                        bool locationMatch = count.Location.Equals(reader["Location"].ToString(), StringComparison.OrdinalIgnoreCase);

                        count.ProductCodeMatch = productCodeMatch;
                        count.ProductNameMatch = productNameMatch;
                        count.LocationMatch = locationMatch;

                        int quantityDifference = count.CountedQuantity - stockQuantity;
                        return (stockQuantity, quantityDifference);
                    }
                    else
                    {
                        return (0, count.CountedQuantity);
                    }
                }
            }
        }
    }
}
