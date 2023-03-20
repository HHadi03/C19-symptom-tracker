using System;
using System.Collections.Generic;
using System.Text;

namespace ElarosProject.Model
{
    public class LoginModel
    {
        private string UserID { get; set; }
        private string Username { get; set; }
        private string Password { get; set; }
        private string Email { get; set; }

        public LoginModel(string uid, string username, string password, string email)
        {
            UserID = uid;
            Username = username;
            Password = password;
            Email = email;
        }

        public string GetUserID()
        {
            return UserID;
        }

        public string GetUsername()
        {
            return Username;
        }

        public string GetPassword()
        {
            return Password;
        }

        public string GetEmail()
        {
            return Email;
        }
    }
}
