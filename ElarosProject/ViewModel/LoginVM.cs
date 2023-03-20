using ElarosProject.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Common;
using System.Text;

namespace ElarosProject.ViewModel
{
    public class LoginVM
    {
        // Holds login information to use in Views
        public ObservableCollection<LoginModel> LoginInfoList { get; set; }
        databaseConnection myConnection = new databaseConnection();

        public LoginVM()
        {
            LoginInfoList = new ObservableCollection<LoginModel>();
            BuildList();
        }

        public async void BuildList()
        {
            List<LoginModel> LoginInfo = await myConnection.GetLogin();

            foreach (var entry in LoginInfo)
            {
                LoginInfoList.Add(entry);
            }
        }
    }
}
