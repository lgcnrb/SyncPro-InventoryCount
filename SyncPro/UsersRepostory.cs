using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace SyncPro
{
    public class UsersRepository : IUsersRepository
    {
        public async Task<bool> Insert(UsersControl user)
        {
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.SyncProDatabaseConnectionString))
            {
                await connection.OpenAsync();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"
                IF NOT EXISTS (SELECT UserName FROM Users WHERE UserName = @UserName)
                BEGIN
                    INSERT INTO Users (FirstName, LastName, UserName, PasswordHash, Salt, Email, RegistrationDate, Role, ProfileImage) 
                    VALUES (@FirstName, @LastName, @UserName, @PasswordHash, @Salt, @Email, @RegistrationDate, @Role, @ProfileImage);
                    SELECT 1;
                END
                ELSE
                BEGIN
                    SELECT 0;
                END";
                    command.CommandType = CommandType.Text;

                    command.Parameters.AddWithValue("@FirstName", user.FirstName);
                    command.Parameters.AddWithValue("@LastName", user.LastName);
                    command.Parameters.AddWithValue("@UserName", user.UserName);
                    command.Parameters.AddWithValue("@PasswordHash", user.PasswordHash);
                    command.Parameters.AddWithValue("@Salt", user.Salt);
                    command.Parameters.AddWithValue("@Email", user.Email);
                    command.Parameters.AddWithValue("@RegistrationDate", user.RegistrationDate);
                    command.Parameters.AddWithValue("@Role", user.Role);
                    command.Parameters.AddWithValue("@ProfileImage", user.ProfileImage);

                    int result = (int)await command.ExecuteScalarAsync();
                    return result == 1;
                }
            }
        }

        public async Task<bool> Update(UsersControl user)
        {
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.SyncProDatabaseConnectionString))
            {
                await connection.OpenAsync();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"
                IF EXISTS (SELECT UserID FROM Users WHERE UserID = @UserID)
                BEGIN
                    UPDATE Users
                    SET FirstName = @FirstName,
                        LastName = @LastName,
                        UserName = @UserName,
                        PasswordHash = @PasswordHash,
                        Salt = @Salt,
                        Email = @Email,
                        RegistrationDate = @RegistrationDate,
                        Role = @Role,
                        ProfileImage = @ProfileImage
                    WHERE UserID = @UserID;
                    SELECT 1;
                END
                ELSE
                BEGIN
                    SELECT 0;
                END";
                    command.CommandType = CommandType.Text;

                    command.Parameters.AddWithValue("@UserID", user.UserID);
                    command.Parameters.AddWithValue("@FirstName", user.FirstName);
                    command.Parameters.AddWithValue("@LastName", user.LastName);
                    command.Parameters.AddWithValue("@UserName", user.UserName);
                    command.Parameters.AddWithValue("@PasswordHash", user.PasswordHash);
                    command.Parameters.AddWithValue("@Salt", user.Salt);
                    command.Parameters.AddWithValue("@Email", user.Email);
                    command.Parameters.AddWithValue("@RegistrationDate", user.RegistrationDate);
                    command.Parameters.AddWithValue("@Role", user.Role);
                    command.Parameters.AddWithValue("@ProfileImage", user.ProfileImage);

                    int result = (int)await command.ExecuteScalarAsync();
                    return result == 1;
                }
            }
        }
        public async Task<bool> UpdatePassword(UsersControl user)
        {
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.SyncProDatabaseConnectionString))
            {
                await connection.OpenAsync();

                string query = @"
            UPDATE Users
            SET FirstName = @FirstName,
                LastName = @LastName,
                UserName = @UserName,
                PasswordHash = @PasswordHash,
                Salt = @Salt,
                Email = @Email,
                RegistrationDate = @RegistrationDate,
                Role = @Role
            WHERE UserID = @UserID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserID", user.UserID);
                    command.Parameters.AddWithValue("@FirstName", user.FirstName);
                    command.Parameters.AddWithValue("@LastName", user.LastName);
                    command.Parameters.AddWithValue("@UserName", user.UserName);
                    command.Parameters.AddWithValue("@PasswordHash", user.PasswordHash);
                    command.Parameters.AddWithValue("@Salt", user.Salt);
                    command.Parameters.AddWithValue("@Email", user.Email);
                    command.Parameters.AddWithValue("@RegistrationDate", user.RegistrationDate);
                    command.Parameters.AddWithValue("@Role", user.Role);

                    int result = await command.ExecuteNonQueryAsync();
                    return result > 0;
                }
            }
        }

        public async Task<UsersControl> GetByUsername(string username)
        {
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.SyncProDatabaseConnectionString))
            {
                await connection.OpenAsync();
                string query = "SELECT * FROM Users WHERE UserName = @UserName";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserName", username);

                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        if (reader.Read())
                        {
                            return new UsersControl
                            {
                                UserID = reader.GetInt32(reader.GetOrdinal("UserID")),
                                UserName = reader.GetString(reader.GetOrdinal("UserName")),
                                PasswordHash = reader.GetString(reader.GetOrdinal("PasswordHash")),
                                Salt = reader.GetString(reader.GetOrdinal("Salt")),
                                Email = reader["Email"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("Email")) : null,
                                FirstName = reader["FirstName"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("FirstName")) : null,
                                LastName = reader["LastName"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("LastName")) : null,
                                RegistrationDate = reader.GetDateTime(reader.GetOrdinal("RegistrationDate")),
                                Role = reader.GetString(reader.GetOrdinal("Role")),
                                ProfileImage = reader["ProfileImage"] as byte[] // Profil resmi
                            };
                        }
                    }
                }
            }
            return null;
        }

        public async Task<UsersControl> GetByEmail(string email)
        {
            using (var connection = new SqlConnection(Properties.Settings.Default.SyncProDatabaseConnectionString))
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand("SELECT * FROM Users WHERE Email = @Email", connection))
                {
                    command.Parameters.AddWithValue("@Email", email);
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            return new UsersControl
                            {
                                UserID = reader.GetInt32(0),
                                UserName = reader.GetString(1),
                                PasswordHash = reader.GetString(2),
                                Salt = reader.GetString(3),
                                Email = reader.GetString(4),
                                FirstName = reader.GetString(5),
                                LastName = reader.GetString(6),
                                RegistrationDate = reader.GetDateTime(7),
                                Role = reader.GetString(8),
                                ProfileImage = reader["ProfileImage"] as byte[] // Profil resmi
                            };
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }

        public async Task<int> InsertAndGetId(UsersControl user)
        {
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.SyncProDatabaseConnectionString))
            {
                await connection.OpenAsync();

                string query = @"
            INSERT INTO Users (FirstName, LastName, UserName, PasswordHash, Salt, Email, RegistrationDate, Role, ProfileImage)
            VALUES (@FirstName, @LastName, @UserName, @PasswordHash, @Salt, @Email, @RegistrationDate, @Role, @ProfileImage);
            SELECT SCOPE_IDENTITY();";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FirstName", user.FirstName);
                    command.Parameters.AddWithValue("@LastName", user.LastName);
                    command.Parameters.AddWithValue("@UserName", user.UserName);
                    command.Parameters.AddWithValue("@PasswordHash", user.PasswordHash);
                    command.Parameters.AddWithValue("@Salt", user.Salt);
                    command.Parameters.AddWithValue("@Email", user.Email ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@RegistrationDate", user.RegistrationDate);
                    command.Parameters.AddWithValue("@Role", user.Role);

                    // Set the ProfileImage parameter, ensuring it handles null values
                    command.Parameters.AddWithValue("@ProfileImage", user.ProfileImage != null ? (object)user.ProfileImage : DBNull.Value);

                    return Convert.ToInt32(await command.ExecuteScalarAsync());
                }
            }
        }

    }
}
