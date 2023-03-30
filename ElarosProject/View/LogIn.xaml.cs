using ElarosProject.Model;
using ElarosProject.ViewModel;
using Firebase.Auth;
using Firebase.Auth.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
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

        // Default constructor for existing users
        public LogIn()
        {
            InitializeComponent();
            this.BindingContext = _loginVM;
        }

        protected async void LogInClick(object sender, EventArgs e)
        {
            LogInLoading.IsRunning = true;

            // Bool used to determine if user details were found.
            bool loginFound = false;

            // Set BindingContext for _loginVM attribute as LoginVM
            _loginVM = BindingContext as LoginVM;

            // Checks entered email is in the correct format
            if (IsValid(EmailAddress.Text.Trim()) == false)
            {
                await DisplayAlert("ERROR", "Email address is an incorrect format. Please try again.", "OK");
                EmailAddress.Text = null;
                PassWord.Text = null;
                LogInLoading.IsRunning = false;

                return;
            }

            // Checks that no fields are left empty
            if (EmailAddress.Text.Trim() == null || PassWord.Text == null)
            {
                await DisplayAlert("ERROR", "Entry fields cannot be blank. Please try again", "OK");
                EmailAddress.Text = null;
                PassWord.Text = null;
                LogInLoading.IsRunning = false;

                return;
            }

            // Log in with Firebase Authentication
            try
            {
                var authProvider = Application.Current.Properties["LoginState"] as FirebaseAuthClient;

                // Signs user in using email and password
                var auth = await authProvider.SignInWithEmailAndPasswordAsync(EmailAddress.Text.Trim(), PassWord.Text);
                
                if (auth != null)
                {
                    var user = auth.User;

                    // Gets a token to be used for Realtime Database (Not implemented yet)
                    var token = await user.GetIdTokenAsync();

                    // Loop through each user and if entered username / password matches then display success alert
                    foreach (LoginModel login in _loginVM.LoginInfoList)
                    {
                        if (EmailAddress.Text.Trim() == login.GetEmail() && PassWord.Text == login.GetPassword())
                        {
                            loginFound = true;
                            Application.Current.Properties["currentUser"] = login;
                            LogInLoading.IsRunning = false;

                            // Moves to dashboard
                            await Navigation.PushAsync(new Dashboard());
                            Goals Notifications = new Goals();
                            Notifications.SetupNotification();
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                LogInLoading.IsRunning = false;
                await App.Current.MainPage.DisplayAlert("Alert", ex.Message, "OK");
            }

            // Display alert if user details were not found.
            if (loginFound == false)
            {
                LogInLoading.IsRunning = false;
                await DisplayAlert("ERROR", "Log in details incorrect", "OK");
                EmailAddress.Text = null;
                PassWord.Text = null;
            }

        }

        private static bool IsValid(string email)
        {
            var valid = true;

            try
            {
                var emailAddress = new MailAddress(email);
            }
            catch
            {
                valid = false;
            }

            return valid;
        }
    }
}