using ElarosProject.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ElarosProject.ViewModel
{
    public class LoginVM
    {
        // Holds login information to use in Views
        public ObservableCollection<LoginModel> LoginInfoList { get; set; }

        public LoginVM()
        {
            // Hard coded data for testing until DB is setup
            LoginInfoList = new ObservableCollection<LoginModel>
            {
                new LoginModel("jchester", "jordan123", "jchester@shu.com"),
                new LoginModel("nsinnott", "niall123", "nsinnott@shu.com"),
                new LoginModel("srafiq", "sumaiya123", "srafiq@shu.com"),
                new LoginModel("jboothman", "josh123", "jboothman@shu.com"),
                new LoginModel("hhadi", "hassan123", "hhadi@shu.com")
            };
        }
    }
}
