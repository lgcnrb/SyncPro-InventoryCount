using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncPro
{
    public class SystemInventoryRepository
    {
        private readonly string _connectionString = Properties.Settings.Default.SyncProDatabaseConnectionString;

        public async Task<bool> Insert(SystemInventoryRepo inventory)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"
                        IF NOT EXISTS (SELECT BatchCode FROM SystemInventory WHERE BatchCode = @BatchCode)
                        BEGIN
                            INSERT INTO SystemInventory (ProductCode, ProductName, Location, BatchCode, StockQuantity) 
                            VALUES (@ProductCode, @ProductName, @Location, @BatchCode, @StockQuantity);
                            SELECT 1;
                        END
                        ELSE
                        BEGIN
                            SELECT 0;
                        END";
                    command.CommandType = CommandType.Text;

                    command.Parameters.AddWithValue("@ProductCode", inventory.ProductCode);
                    command.Parameters.AddWithValue("@ProductName", inventory.ProductName);
                    command.Parameters.AddWithValue("@Location", inventory.Location);
                    command.Parameters.AddWithValue("@BatchCode", inventory.BatchCode);
                    command.Parameters.AddWithValue("@StockQuantity", inventory.StockQuantity);

                    int result = (int)await command.ExecuteScalarAsync();
                    return result == 1;
                }
            }
        }
        public async Task<bool> Update(SystemInventoryRepo inventory)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"
                        IF EXISTS (SELECT ProductCode FROM SystemInventory WHERE ProductCode = @ProductCode)
                        BEGIN
                            UPDATE SystemInventory
                            SET ProductName = @ProductName,
                                Location = @Location,
                                BatchCode = @BatchCode,
                                StockQuantity = @StockQuantity
                            WHERE ProductCode = @ProductCode;
                            SELECT 1;
                        END
                        ELSE
                        BEGIN
                            SELECT 0;
                        END";
                    command.CommandType = CommandType.Text;

                    command.Parameters.AddWithValue("@ProductCode", inventory.ProductCode);
                    command.Parameters.AddWithValue("@ProductName", inventory.ProductName);
                    command.Parameters.AddWithValue("@Location", inventory.Location);
                    command.Parameters.AddWithValue("@BatchCode", inventory.BatchCode);
                    command.Parameters.AddWithValue("@StockQuantity", inventory.StockQuantity);

                    int result = (int)await command.ExecuteScalarAsync();
                    return result == 1;
                }
            }
        }        
    }
}
