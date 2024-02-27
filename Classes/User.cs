using System;

namespace ClassFormWithDb.Classes
{
    public class User
    {
        public int User_id { get; set; }
        public string ProfilePic { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime Registration_date { get; set; }
        public string PassId { get; set; }
        public string Platform_account { get; set; }

        List<Task> tasksList { get; set; }

        public User() { }

        public User(
            int userId,
            string profilePic,
            string email,
            string username,
            string password,
            DateTime registrationDate,
            string passId,
            string platformAccount
        )
        {
            User_id = userId;
            ProfilePic = profilePic;
            Email = email;
            Username = username;
            Password = password;
            Registration_date = registrationDate;
            PassId = passId;
            Platform_account = platformAccount;
        }
    }

}
