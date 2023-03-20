using System;
using System.Collections.Generic;
using System.Text;

namespace ElarosProject.Model
{
    public class LoginModel
    {
        public string UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public LoginModel(string uid, string username, string password, string email)
        {
            UserID = uid;
            Username = username;
            Password = password;
            Email = email;
        }

        public LoginModel() { }

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
