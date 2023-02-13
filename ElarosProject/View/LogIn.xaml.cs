using ElarosProject.Model;
using ElarosProject.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ElarosProject.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LogIn : ContentPage
    {
        private LoginVM _loginVM;

        public LogIn()
        {
            InitializeComponent();
            this.BindingContext = new LoginVM();
        }

        public LogIn(LoginVM login)
        {
            InitializeComponent();
            this._loginVM = login;
            this.BindingContext = login;
        }

        protected void LogInClick(object sender, EventArgs e)
        {
            bool loginFound = false;
            _loginVM = BindingContext as LoginVM;

            foreach (LoginModel login in _loginVM.LoginInfoList)
            {
                if (UserName.Text == login.GetUsername() && PassWord.Text == login.GetPassword())
                {
                    DisplayAlert("SUCCESS", "Login successful!", "OK");
                    loginFound = true;
                }               
            }

            if (loginFound == false)
            {
                DisplayAlert("ERROR", "Log in details incorrect", "OK");
            }
        }
    }
}