using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using System.Management;

namespace SyncPro
{
    public partial class RestoreDatabaseForm : Form
    {
        private static readonly string backupFolderPath = Properties.Settings.Default.BackupFilePath;
        private string decryptionKey;
        private string decryptionIV;
        private readonly UserInfoCollector userInfo;

        public RestoreDatabaseForm(UserInfoCollector userInfo)
        {
            InitializeComponent();
            LoadBackupFiles();
            GenerateEncryptionKeyAndIV(); // Şifreleme anahtarı ve IV oluştur
            this.userInfo = userInfo;
        }

        private void LoadBackupFiles()
        {
            try
            {
                if (!Directory.Exists(backupFolderPath))
                {
                    Directory.CreateDirectory(backupFolderPath);
                }
                string[] backupFiles = Directory.GetFiles(backupFolderPath, "*.sql");
                foreach (string backupFile in backupFiles)
                {
                    BackupList.Items.Add(Path.GetFileName(backupFile));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading backup files: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RestoreButton_Click(object sender, EventArgs e)
        {
            RestoreSelectedBackups();
        }

        private void RestoreSelectedBackups()
        {
            var selectedFiles = BackupList.CheckedItems.Cast<string>().ToList();

            if (!selectedFiles.Any())
            {
                MessageBox.Show("No backup files selected!", "Restore Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (var backupFile in selectedFiles)
            {
                RestoreBackup(backupFile);
            }

            MessageBox.Show("Backup files restored successfully!", "Restore Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void RestoreBackup(string backupFile)
        {
            try
            {
                if (!Directory.Exists(backupFolderPath))
                {
                    MessageBox.Show("Backup folder not found!", "Restore Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string sqlFilePath = Path.Combine(backupFolderPath, backupFile);
                string sqlCommands = File.ReadAllText(sqlFilePath);
                string[] commands = sqlCommands.Split(new[] { ";\n" }, StringSplitOptions.RemoveEmptyEntries);

                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.SyncProDatabaseConnectionString))
                {
                    connection.Open();

                    foreach (var commandText in commands)
                    {
                        using (SqlCommand command = new SqlCommand())
                        {
                            command.Connection = connection;

                            // Tablolar için IDENTITY_INSERT özelliğini aç
                            if (commandText.StartsWith("INSERT INTO Users", StringComparison.OrdinalIgnoreCase) ||
                                commandText.StartsWith("INSERT INTO StockCount", StringComparison.OrdinalIgnoreCase) ||
                                commandText.StartsWith("INSERT INTO StocktakingList", StringComparison.OrdinalIgnoreCase))
                            {
                                string tableName = GetTableName(commandText);
                                command.CommandText = $"SET IDENTITY_INSERT {tableName} ON";
                                command.ExecuteNonQuery();
                            }

                            command.CommandText = commandText;
                            command.ExecuteNonQuery();

                            // Tablolar için IDENTITY_INSERT özelliğini kapat
                            if (commandText.StartsWith("INSERT INTO Users", StringComparison.OrdinalIgnoreCase) ||
                                commandText.StartsWith("INSERT INTO StockCount", StringComparison.OrdinalIgnoreCase) ||
                                commandText.StartsWith("INSERT INTO StocktakingList", StringComparison.OrdinalIgnoreCase))
                            {
                                string tableName = GetTableName(commandText);
                                command.CommandText = $"SET IDENTITY_INSERT {tableName} OFF";
                                command.ExecuteNonQuery();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error restoring backup file {backupFile}: {ex.Message}", "Restore Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetTableName(string commandText)
        {
            // SQL INSERT INTO ifadesinden tablo adını çıkar
            var parts = commandText.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            return parts[2]; // INSERT INTO TABLE_NAME kısmından tablo adını alır.
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
                decryptionKey = Convert.ToBase64String(hashBytes.Take(16).ToArray());
                decryptionIV = Convert.ToBase64String(hashBytes.Skip(16).Take(16).ToArray());
            }
        }

        private byte[] DecryptData(byte[] encryptedData)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = Convert.FromBase64String(decryptionKey);
                aes.IV = Convert.FromBase64String(decryptionIV);

                using (ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV))
                {
                    using (MemoryStream ms = new MemoryStream(encryptedData))
                    {
                        using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                        {
                            using (MemoryStream decryptedStream = new MemoryStream())
                            {
                                cs.CopyTo(decryptedStream);
                                return decryptedStream.ToArray();
                            }
                        }
                    }
                }
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
        private void RestoreDatabaseForm_Load(object sender, EventArgs e)
        {
            DisplayServerAndDatabaseInfo();
        }
    }
}
