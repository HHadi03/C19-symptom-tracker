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
        private LoginVM _loginVM = Application.Current.Properties["_loginVM"] as LoginVM;
        private AssessmentVM _assessmentVM = Application.Current.Properties["_assessmentVM"] as AssessmentVM;

        // Default constructor for existing users
        public LogIn()
        {
            InitializeComponent();
            this.BindingContext = _loginVM;
        }

        protected void LogInClick(object sender, EventArgs e)
        {
            // Bool used to determine if user details were found.
            bool loginFound = false;

            // Set BindingContext for _loginVM attribute as LoginVM
            _loginVM = BindingContext as LoginVM;

            // Checks that no fields are left empty
            if (UserName.Text == null || PassWord.Text == null)
            {
                DisplayAlert("ERROR", "Entry fields cannot be blank. Please try again", "OK");
                UserName.Text = null;
                PassWord.Text = null;

                return;
            }

            // Loop through each user and if entered username / password matches then display success alert
            // NOTE: This will navigate to the Dashboard once created
            foreach (LoginModel login in _loginVM.LoginInfoList)
            {
                if (UserName.Text == login.GetUsername() && PassWord.Text == login.GetPassword())
                {
                    DisplayAlert("SUCCESS", "Login successful!", "OK");
                    loginFound = true;
                    Application.Current.Properties["currentUser"] = login;

                    // Moves to dashboard - carrying over viewmodel instances again so data persists
                    this.Navigation.PushAsync(new Dashboard());
                }               
            }

            // Display alert if user details were not found.
            if (loginFound == false)
            {
                DisplayAlert("ERROR", "Log in details incorrect", "OK");
            }
        }
    }
}