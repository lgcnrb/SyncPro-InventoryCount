using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Management;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace SyncPro
{
    public partial class DataBackupForm : Form
    {
        private static readonly string backupFolderPath = Properties.Settings.Default.BackupFilePath; // Yedekleme dosya yolu
        private static string encryptionKey;
        private static string encryptionIV;
        private readonly UserInfoCollector userInfo;

        public DataBackupForm(UserInfoCollector userInfo)
        {
            InitializeComponent();
            this.userInfo = userInfo;
            LoadTables(); // Form yüklenirken tabloları yükle
            GenerateEncryptionKeyAndIV(); // Şifreleme anahtarı ve IV oluştur
        }
        private void LoadTables()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.SyncProDatabaseConnectionString))
                {
                    connection.Open();
                    DataTable tables = connection.GetSchema("Tables");
                    foreach (DataRow row in tables.Rows)
                    {
                        string tableName = row[2].ToString();
                        DatabaseTables.Items.Add(tableName);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading tables: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private string GetPCIdentifier()
        {
            string cpuId = "";
            string motherboardSerial = "";

            // CPU ID'sini al
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT ProcessorId FROM Win32_Processor");
            ManagementObjectCollection results = searcher.Get();
            foreach (ManagementObject obj in results)
            {
                cpuId = obj["ProcessorId"].ToString();
            }

            // Anakart Seri Numarasını al
            searcher = new ManagementObjectSearcher("SELECT SerialNumber FROM Win32_BaseBoard");
            results = searcher.Get();
            foreach (ManagementObject obj in results)
            {
                motherboardSerial = obj["SerialNumber"].ToString();
            }

            // İkisini birleştir ve geri döndür
            return $"{cpuId}-{motherboardSerial}";
        }

        private void GenerateEncryptionKeyAndIV()
        {
            string pcIdentifier = GetPCIdentifier();
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(pcIdentifier));
                encryptionKey = Convert.ToBase64String(hashBytes.Take(16).ToArray());
                encryptionIV = Convert.ToBase64String(hashBytes.Skip(16).Take(16).ToArray());
            }
        }
        private void BackupTable(string tableName)
        {
            try
            {
                if (!Directory.Exists(backupFolderPath))
                {
                    Directory.CreateDirectory(backupFolderPath);
                }

                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.SyncProDatabaseConnectionString))
                {
                    connection.Open();
                    string query = tableName.Equals("Users", StringComparison.OrdinalIgnoreCase)
                        ? $"SELECT * FROM {tableName} WHERE UserID != 1"
                        : $"SELECT * FROM {tableName}";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            StringBuilder sqlBackup = new StringBuilder();
                            int recordCount = 0;

                            while (reader.Read())
                            {
                                sqlBackup.Append($"INSERT INTO {tableName} (");

                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    sqlBackup.Append(reader.GetName(i));
                                    if (i < reader.FieldCount - 1)
                                        sqlBackup.Append(", ");
                                }

                                sqlBackup.Append(") VALUES (");

                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    if (reader.IsDBNull(i))
                                    {
                                        sqlBackup.Append("NULL");
                                    }
                                    else
                                    {
                                        Type fieldType = reader.GetFieldType(i);

                                        if (fieldType == typeof(string))
                                        {
                                            sqlBackup.Append($"'{reader.GetString(i).Replace("'", "''")}'");
                                        }
                                        else if (fieldType == typeof(DateTime))
                                        {
                                            DateTime dateValue = reader.GetDateTime(i);
                                            sqlBackup.Append($"'{dateValue:yyyy-MM-dd HH:mm:ss}'");
                                        }
                                        else if (fieldType == typeof(byte[]))
                                        {
                                            byte[] bytes = (byte[])reader.GetValue(i);
                                            byte[] encryptedBytes = EncryptionHelper.EncryptData(bytes, encryptionKey, encryptionIV);
                                            string hexString = BitConverter.ToString(encryptedBytes).Replace("-", "");
                                            sqlBackup.Append($"0x{hexString}");
                                        }
                                        else if (fieldType == typeof(bool))  // bool yerine bit olarak aktar
                                        {
                                            sqlBackup.Append((bool)reader.GetValue(i) ? "1" : "0");
                                        }
                                        else
                                        {
                                            sqlBackup.Append(reader.GetValue(i));
                                        }
                                    }

                                    if (i < reader.FieldCount - 1)
                                        sqlBackup.Append(", ");
                                }

                                sqlBackup.Append(");\n");
                                recordCount++;
                            }

                            if (sqlBackup.Length > 0)
                            {
                                string timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
                                string sqlFilePath = Path.Combine(backupFolderPath, $"{tableName}_Backup_{timestamp}.sql");
                                File.WriteAllText(sqlFilePath, sqlBackup.ToString());
                                MessageBox.Show($"{tableName} table has been successfully backed up!", "Backup Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show($"{tableName} table has no data to backup.", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{tableName} table backup error: {ex.Message}", "Backup Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBackupSelected_Click(object sender, EventArgs e)
        {
            BackupSelectedTables();
        }

        private void btnBackupAll_Click(object sender, EventArgs e)
        {
            BackupAllTables();
        }

        private void BackupSelectedTables()
        {
            foreach (string tableName in DatabaseTables.CheckedItems)
            {
                BackupTable(tableName);
            }
        }

        private void BackupAllTables()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.SyncProDatabaseConnectionString))
                {
                    connection.Open();
                    DataTable tables = connection.GetSchema("Tables");

                    foreach (DataRow row in tables.Rows)
                    {
                        string tableName = row[2].ToString();
                        BackupTable(tableName);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while backing up all tables: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DisplayServerAndDatabaseInfo()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.SyncProDatabaseConnectionString))
                {
                    connection.Open();

                    // Get SQL Server and Database Information
                    string serverInfoQuery = "SELECT SERVERPROPERTY('MachineName') AS MachineName, SERVERPROPERTY('InstanceName') AS InstanceName, SERVERPROPERTY('ProductVersion') AS ProductVersion, SERVERPROPERTY('Edition') AS Edition";
                    string databaseInfoQuery = "SELECT DB_NAME() AS CurrentDatabase";

                    using (SqlCommand serverCommand = new SqlCommand(serverInfoQuery, connection))
                    {
                        using (SqlDataReader reader = serverCommand.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string machineName = reader["MachineName"].ToString();
                                string instanceName = reader["InstanceName"].ToString();
                                string productVersion = reader["ProductVersion"].ToString();
                                string edition = reader["Edition"].ToString();

                                lblMachineName.Text = $"Machine Name: {machineName}";
                                lblInstanceName.Text = $"Instance Name: {instanceName}";
                                lblProductVersion.Text = $"Product Version: {productVersion}";
                                lblEdition.Text = $"Edition: {edition}";
                            }
                        }
                    }

                    using (SqlCommand databaseCommand = new SqlCommand(databaseInfoQuery, connection))
                    {
                        using (SqlDataReader reader = databaseCommand.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string currentDatabase = reader["CurrentDatabase"].ToString();
                                lblDatabaseName.Text = $"Current Database: {currentDatabase}";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while retrieving server and database info: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DataBackupForm_Load(object sender, EventArgs e)
        {
            DisplayServerAndDatabaseInfo();

        }
    }
}
