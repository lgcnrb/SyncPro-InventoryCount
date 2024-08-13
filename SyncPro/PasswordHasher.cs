using System;
using System.Security.Cryptography;
using System.Text;

public class PasswordHasher
{
    /// <summary>
    /// Bir parolayı verilen tuz ile birlikte SHA256 kullanarak hashler.
    /// </summary>
    /// <param name="password">Hashlenecek parola.</param>
    /// <param name="salt">Hashleme işleminde kullanılacak tuz.</param>
    /// <returns>Hexadecimal string olarak hashlenmiş parola.</returns>
    public static string HashPassword(string password, string salt)
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password + salt);
            byte[] hashedBytes = sha256.ComputeHash(passwordBytes);

            StringBuilder hashBuilder = new StringBuilder();
            foreach (byte b in hashedBytes)
            {
                hashBuilder.Append(b.ToString("x2"));
            }

            return hashBuilder.ToString();
        }
    }

    /// <summary>
    /// Kriptografik olarak güvenli bir tuz oluşturur.
    /// </summary>
    /// <returns>Base64 kodlu tuz stringi.</returns>
    public static string GenerateSalt()
    {
        byte[] saltBytes = new byte[16];
        using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(saltBytes);
        }

        return Convert.ToBase64String(saltBytes);
    }

    /// <summary>
    /// Girdi parolası, verilen tuz ile hashlenmiş olarak saklanan hashlenmiş parolaya eşit olup olmadığını doğrular.
    /// </summary>
    /// <param name="inputPassword">Doğrulanacak parola.</param>
    /// <param name="hashedPassword">Saklanan hashlenmiş parola.</param>
    /// <param name="salt">Hashleme işleminde kullanılan tuz.</param>
    /// <returns>Eğer parolalar eşleşiyorsa true, aksi halde false.</returns>
    public static bool VerifyPassword(string inputPassword, string hashedPassword, string salt)
    {
        string inputHash = HashPassword(inputPassword, salt);
        return string.Equals(inputHash, hashedPassword, StringComparison.OrdinalIgnoreCase);
    }
}
