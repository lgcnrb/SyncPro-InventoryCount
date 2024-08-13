using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

public class GenerationFunctions
{
    public static string GenerateRandomUsername(string name, string surname)
    {
        Func<string, string, string>[] approaches = {
                (n, s) => RemoveTurkishCharacters(n.ToLower() + s.ToLower()),                   // Adın Tamamı + Soyadın Tamamı
                (n, s) => RemoveTurkishCharacters(n.Substring(0, 1).ToLower() + s.ToLower()),  // Adın İlk Harfi + Soyadın Tamamı
                (n, s) => RemoveTurkishCharacters(n.ToLower() + s.Substring(0, 1).ToLower()),  // Adın Tamamı + Soyadın İlk Harfi
                (n, s) => RemoveTurkishCharacters(n.Substring(0, 1).ToLower() + s.Substring(0, 1).ToLower()),  // Adın İlk Harfi + Soyadın İlk Harfi
                (n, s) => RemoveTurkishCharacters(n.ToLower() + GenerateRandomNumber()),       // Adın Tamamı + Rastgele Rakam
                (n, s) => RemoveTurkishCharacters(n.Substring(0, 1).ToLower() + GenerateRandomNumber())       // Adın İlk Harfi + Rastgele Rakam
            };

        Random random = new Random();
        Func<string, string, string> selectedApproach = approaches[random.Next(approaches.Length)];

        return selectedApproach(name, surname);
    }

    public static string GenerateRandomEmail(string name, string surname, string domain)
    {
        Func<string, string, string, string>[] approaches = {
                (n, s, d) => RemoveTurkishCharacters(n.ToLower() + s.ToLower() + "@" + d),                   // Adın Tamamı + Soyadın Tamamı
                (n, s, d) => RemoveTurkishCharacters(n.Substring(0, 1).ToLower() + s.ToLower() + "@" + d),  // Adın İlk Harfi + Soyadın Tamamı
                (n, s, d) => RemoveTurkishCharacters(n.ToLower() + s.Substring(0, 1).ToLower() + "@" + d),  // Adın Tamamı + Soyadın İlk Harfi
                (n, s, d) => RemoveTurkishCharacters(n.Substring(0, 1).ToLower() + s.Substring(0, 1).ToLower() + "@" + d),  // Adın İlk Harfi + Soyadın İlk Harfi
                (n, s, d) => RemoveTurkishCharacters(n.ToLower() + GenerateRandomNumber() + "@" + d),       // Adın Tamamı + Rastgele Rakam
                (n, s, d) => RemoveTurkishCharacters(n.Substring(0, 1).ToLower() + GenerateRandomNumber() + "@" + d)       // Adın İlk Harfi + Rastgele Rakam
            };

        Random random = new Random();
        Func<string, string, string, string> selectedApproach = approaches[random.Next(approaches.Length)];

        return selectedApproach(name, surname, domain);
    }

    public static string RemoveTurkishCharacters(string input)
    {
        string turkishChars = "çÇğĞıİöÖşŞüÜ";
        string englishChars = "cCgGiIoOsSuU";

        for (int i = 0; i < turkishChars.Length; i++)
        {
            input = input.Replace(turkishChars[i], englishChars[i]);
        }

        return input;
    }
    public static string GenerateStrongPassword()
    {
        char[] password = new char[SyncPro.Properties.Settings.Default.PasswordLength];
        string charSet = "";
        System.Random _random = new Random();
        if (SyncPro.Properties.Settings.Default.LowerCase)
            charSet += SyncPro.Properties.Settings.Default.LOWER_CASE;
        if (SyncPro.Properties.Settings.Default.UpperCase)
            charSet += SyncPro.Properties.Settings.Default.UPPER_CASE;
        if (SyncPro.Properties.Settings.Default.NumericCase)
            charSet += SyncPro.Properties.Settings.Default.NUMBERIC;
        if (SyncPro.Properties.Settings.Default.SpacialCase)
            charSet += SyncPro.Properties.Settings.Default.SPECIAL_CHARACTER;
        for (int i = 0; i < SyncPro.Properties.Settings.Default.PasswordLength; i++)
            password[i] = charSet[_random.Next(charSet.Length - 1)];
        return string.Join(null, password);
    }

    public static string GenerateRandomNumber()
    {
        Random random = new Random();
        return random.Next(1000, 9999).ToString();
    }
}
