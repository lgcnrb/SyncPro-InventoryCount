using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

public static class EncryptionHelper
{
    private static readonly string EncryptionKey = GenerateEncryptionKey();

    public static string EncryptString(string plainText)
    {
        using (Aes aes = Aes.Create())
        {
            aes.Key = Convert.FromBase64String(EncryptionKey);
            aes.GenerateIV(); // Her şifrelemede yeni bir IV oluşturulur
            ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter sw = new StreamWriter(cs))
                    {
                        sw.Write(plainText);
                    }
                    byte[] iv = aes.IV;
                    byte[] encrypted = ms.ToArray();
                    return Convert.ToBase64String(iv) + ":" + Convert.ToBase64String(encrypted);
                }
            }
        }
    }

    public static string DecryptString(string cipherText)
    {
        string[] parts = cipherText.Split(':');
        byte[] iv = Convert.FromBase64String(parts[0]);
        byte[] cipherBytes = Convert.FromBase64String(parts[1]);

        using (Aes aes = Aes.Create())
        {
            aes.Key = Convert.FromBase64String(EncryptionKey);
            aes.IV = iv;
            ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

            using (MemoryStream ms = new MemoryStream(cipherBytes))
            {
                using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                {
                    using (StreamReader sr = new StreamReader(cs))
                    {
                        return sr.ReadToEnd();
                    }
                }
            }
        }
    }

    private static string GenerateEncryptionKey()
    {
        string hardwareId = HardwareIdHelper.GetHardwareId();

        if (string.IsNullOrEmpty(hardwareId))
        {
            throw new Exception("Hardware ID could not be retrieved.");
        }

        // Şifreleme anahtarını oluştur
        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] keyBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(hardwareId));
            return Convert.ToBase64String(keyBytes).Substring(0, 32); // 32 byte (256 bit) uzunluğunda bir anahtar
        }
    }

    public static byte[] DecryptData(byte[] encryptedData, string encryptionKey, string encryptionIV)
    {
        using (Aes aes = Aes.Create())
        {
            aes.Key = Convert.FromBase64String(encryptionKey);
            aes.IV = Convert.FromBase64String(encryptionIV);
            ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

            using (MemoryStream ms = new MemoryStream(encryptedData))
            {
                using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                {
                    using (MemoryStream originalData = new MemoryStream())
                    {
                        cs.CopyTo(originalData);
                        return originalData.ToArray();
                    }
                }
            }
        }
    }

    public static byte[] EncryptData(byte[] data, string key, string iv)
    {
        using (Aes aes = Aes.Create())
        {
            aes.Key = Convert.FromBase64String(key);
            aes.IV = Convert.FromBase64String(iv);

            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(data, 0, data.Length);
                    cs.FlushFinalBlock(); // Bu, verinin tamamını yazdırmak için önemlidir
                }
                return ms.ToArray();
            }
        }
    }
}
