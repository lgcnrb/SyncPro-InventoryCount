using System;

namespace SyncPro
{
    public class UserInfoCollector
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string Salt { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string Role { get; set; }
        public byte[] ProfileImage { get; set; }

    }
}
