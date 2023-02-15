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
        private AssessmentVM _assessmentVM;

        // Default constructor for existing users
        public LogIn()
        {
            InitializeComponent();
            _assessmentVM = new AssessmentVM();
            this.BindingContext = new LoginVM();
        }

        // Constructor used by those newly signed up - uses the same LoginVM instance used by SignUp page
        // as the BindingContext so the new user details are available in the collection.
        // NOTE: This will be redundant once a database is connected with user info
        public LogIn(LoginVM login, AssessmentVM assessmentVM)
        {
            InitializeComponent();
            _assessmentVM = assessmentVM;
            this._loginVM = login;
            this.BindingContext = login;
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

                    // Moves to dashboard - carrying over viewmodel instances again so data persists
                    this.Navigation.PushAsync(new Dashboard(login, _assessmentVM));
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