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
        public string WebAPIkey = "AIzaSyAnwLkBWEJDsJwmgs_1Hkpg7ydKW9T5rRM";

        // Default constructor for existing users
        public LogIn()
        {
            InitializeComponent();
            this.BindingContext = _loginVM;
        }

        protected async void LogInClick(object sender, EventArgs e)
        {
            // Bool used to determine if user details were found.
            bool loginFound = false;

            // Set BindingContext for _loginVM attribute as LoginVM
            _loginVM = BindingContext as LoginVM;

            // Checks entered email is in the correct format
            if (IsValid(EmailAddress.Text) == false)
            {
                await DisplayAlert("ERROR", "Email address is an incorrect format. Please try again.", "OK");
                EmailAddress.Text = null;
                PassWord.Text = null;

                return;
            }

            // Checks that no fields are left empty
            if (EmailAddress.Text == null || PassWord.Text == null)
            {
                await DisplayAlert("ERROR", "Entry fields cannot be blank. Please try again", "OK");
                EmailAddress.Text = null;
                PassWord.Text = null;

                return;
            }

            // Log in with Firebase Authentication
            try
            {
                var authProvider = new FirebaseAuthClient(new FirebaseAuthConfig
                {
                    ApiKey = WebAPIkey,
                    AuthDomain = "elarosdb.firebaseapp.com",
                    Providers = new FirebaseAuthProvider[]
                    {
                        new GoogleProvider().AddScopes("email"),
                        new EmailProvider()
                    }
                });
                
                var auth = await authProvider.SignInWithEmailAndPasswordAsync(EmailAddress.Text, PassWord.Text);
                
                if (auth != null)
                {
                    var user = auth.User;
                    var token = await user.GetIdTokenAsync();

                    // Loop through each user and if entered username / password matches then display success alert
                    // NOTE: This will navigate to the Dashboard once created
                    foreach (LoginModel login in _loginVM.LoginInfoList)
                    {
                        if (EmailAddress.Text == login.GetEmail() && PassWord.Text == login.GetPassword())
                        {
                            await DisplayAlert("SUCCESS", "Login successful!", "OK");
                            loginFound = true;
                            Application.Current.Properties["currentUser"] = login;

                            // Moves to dashboard
                            await Navigation.PushAsync(new Dashboard());
                        }
                    }

                    await Navigation.PushAsync(new Dashboard());
                }
                else
                {
                    await DisplayAlert("ERROR", "Invalid login information", "Cancel");
                    EmailAddress.Text = null;
                    PassWord.Text = null;
                }
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Alert", ex.Message, "OK");
            }

            // Display alert if user details were not found.
            if (loginFound == false)
            {
                await DisplayAlert("ERROR", "Log in details incorrect", "OK");
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