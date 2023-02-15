using System;
using System.Collections.Generic;
using System.Text;

namespace ElarosProject.Model
{
    public class LoginModel
    {
        private int UserID { get; set; }
        private string Username { get; set; }
        private string Password { get; set; }
        private string Email { get; set; }

        public LoginModel(int uid, string username, string password, string email)
        {
            UserID = uid;
            Username = username;
            Password = password;
            Email = email;
        }

        public int GetUserID()
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
    }
}
