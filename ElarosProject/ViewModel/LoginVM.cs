using ElarosProject.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ElarosProject.ViewModel
{
    public class LoginVM
    {
        public ObservableCollection<LoginModel> LoginInfoList { get; set; }

        public LoginVM()
        {
            LoginInfoList = new ObservableCollection<LoginModel>
            {
                new LoginModel("jchester", "jordan123"),
                new LoginModel("nsinnott", "niall123"),
                new LoginModel("srafiq", "sumaiya123"),
                new LoginModel("jboothman", "josh123"),
                new LoginModel("hhadi", "hassan123")
            };
        }
    }
}
