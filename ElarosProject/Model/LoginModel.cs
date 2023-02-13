using System;
using System.Collections.Generic;
using System.Text;

namespace ElarosProject.Model
{
    public class LoginModel
    {
        private string username { get; set; }
        private string password { get; set; }

        public LoginModel(string username, string password)
        {
            this.username = username;
            this.password = password;
        }
    }
}
