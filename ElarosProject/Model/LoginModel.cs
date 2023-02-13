using System;
using System.Collections.Generic;
using System.Text;

namespace ElarosProject.Model
{
    public class LoginModel
    {
        private string username { get; set; }
        private string password { get; set; }
        private string email { get; set; }

        public LoginModel(string username, string password, string email)
        {
            this.username = username;
            this.password = password;
            this.email = email;
        }

        public string GetUsername()
        {
            return username;
        }

        public string GetPassword()
        {
            return password;
        }
    }
}
