using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace SyncPro
{
    public class StocktakingListRepository
    {
        private readonly string _connectionString = Properties.Settings.Default.SyncProDatabaseConnectionString;

        /// <summary>
        /// Inserts a new stocktaking list into the database and returns the ID of the inserted record.
        /// </summary>
        /// <param name="list">The stocktaking list to insert.</param>
        /// <returns>The ID of the inserted stocktaking list.</returns>
        public async Task<int> InsertAndGetIdAsync(StocktakingListRepo list)
        {
            const string query = @"
                INSERT INTO StocktakingList (CreationDate, FinishDate, CountedBy, Auditor, CountFinish)
                VALUES (@CreationDate, @FinishDate, @CountedBy, @Auditor, @CountFinish);
                SELECT SCOPE_IDENTITY();";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CreationDate", list.CreationDate);
                    command.Parameters.AddWithValue("@FinishDate", list.FinishDate.HasValue ? (object)list.FinishDate.Value : DBNull.Value);
                    command.Parameters.AddWithValue("@CountedBy", list.CountedBy);
                    command.Parameters.AddWithValue("@Auditor", list.Auditor);
                    command.Parameters.AddWithValue("@CountFinish", list.CountFinish);

                    object result = await command.ExecuteScalarAsync();
                    return Convert.ToInt32(result);
                }
            }
        }

        /// <summary>
        /// Updates the finish status of a stocktaking list.
        /// </summary>
        /// <param name="stocktakingListId">The ID of the stocktaking list to update.</param>
        /// <param name="countFinish">The new finish status.</param>
        /// <returns>True if the update was successful, otherwise false.</returns>
        public async Task<bool> UpdateFinishStatusAsync(int stocktakingListId, bool countFinish)
        {
            const string query = "UPDATE StocktakingList SET CountFinish = @CountFinish WHERE StocktakingListId = @StocktakingListId";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CountFinish", countFinish);
                    command.Parameters.AddWithValue("@StocktakingListId", stocktakingListId);

                    await connection.OpenAsync();
                    int rowsAffected = await command.ExecuteNonQueryAsync();
                    return rowsAffected > 0;
                }
            }
        }

        /// <summary>
        /// Deletes a stocktaking list and its related counts from the database.
        /// </summary>
        /// <param name="stocktakingListId">The ID of the stocktaking list to delete.</param>
        /// <returns>True if the deletion was successful, otherwise false.</returns>
        public async Task<bool> DeleteStocktakingListAsync(int stocktakingListId)
        {
            const string deleteCountsQuery = "DELETE FROM StockCount WHERE StocktakingListId = @StocktakingListId";
            const string deleteListQuery = "DELETE FROM StocktakingList WHERE StocktakingListId = @StocktakingListId";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        using (SqlCommand deleteCountsCommand = new SqlCommand(deleteCountsQuery, connection, transaction))
                        {
                            deleteCountsCommand.Parameters.AddWithValue("@StocktakingListId", stocktakingListId);
                            await deleteCountsCommand.ExecuteNonQueryAsync();
                        }

                        using (SqlCommand deleteListCommand = new SqlCommand(deleteListQuery, connection, transaction))
                        {
                            deleteListCommand.Parameters.AddWithValue("@StocktakingListId", stocktakingListId);
                            int rowsAffected = await deleteListCommand.ExecuteNonQueryAsync();

                            if (rowsAffected > 0)
                            {
                                transaction.Commit();
                                return true;
                            }
                        }

                        transaction.Rollback();
                        return false;
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        /// <summary>
        /// Inserts a new stocktaking list into the database.
        /// </summary>
        /// <param name="list">The stocktaking list to insert.</param>
        /// <returns>True if the insertion was successful, otherwise false.</returns>
        public async Task<bool> InsertAsync(StocktakingListRepo list)
        {
            int id = await InsertAndGetIdAsync(list);
            return id > 0;
        }

        /// <summary>
        /// Checks if there are any items in the SystemInventory table.
        /// </summary>
        /// <returns>True if there are items in the inventory, otherwise false.</returns>
        public async Task<bool> InventoryHasItemsAsync()
        {
            const string query = "SELECT COUNT(1) FROM SystemInventory";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    int count = (int)await command.ExecuteScalarAsync();
                    return count > 0;
                }
            }
        }

        /// <summary>
        /// Updates the finish date and status of a stocktaking list.
        /// </summary>
        /// <param name="stocktakingListId">The ID of the stocktaking list to update.</param>
        /// <param name="finishDate">The finish date to set.</param>
        /// <returns>True if the update was successful, otherwise false.</returns>
        public async Task<bool> UpdateFinishDateAsync(int stocktakingListId, DateTime finishDate)
        {
            const string query = @"
                UPDATE StocktakingList
                SET FinishDate = @FinishDate, CountFinish = 1
                WHERE StocktakingListId = @StocktakingListId";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FinishDate", finishDate);
                    command.Parameters.AddWithValue("@StocktakingListId", stocktakingListId);

                    int rowsAffected = await command.ExecuteNonQueryAsync();
                    return rowsAffected > 0;
                }
            }
        }
    }
}
