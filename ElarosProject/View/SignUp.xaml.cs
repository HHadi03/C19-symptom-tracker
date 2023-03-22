using ElarosProject.Model;
using ElarosProject.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Firebase.Auth.Providers;
using Firebase.Auth;
using System.Threading;

namespace ElarosProject.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignUp : ContentPage
    {
        private LoginVM _loginVM = Application.Current.Properties["_loginVM"] as LoginVM;
        databaseConnection myConnection = new databaseConnection();

        public SignUp()
        {
            InitializeComponent();
            this.BindingContext = _loginVM;
        }

        async void SignUpClick(object sender, EventArgs e)
        {
            SignUpLoading.IsRunning = true;
            string email = Email.Text.Trim();
            string username = UserName.Text.Trim();
            string password = PassWord.Text;

            // Set BindingContext for _loginVM attribute as LoginVM
            _loginVM = BindingContext as LoginVM;

            // Checks that no fields are left empty
            if (UserName.Text == null || PassWord.Text == null || Email.Text == null)
            {
                await DisplayAlert("ERROR", "Entry fields cannot be blank. Please try again", "OK");
                UserName.Text = null;
                PassWord.Text = null;
                Email.Text = null;

                return;
            }

            // Checks username isn't already in use
            var usernameCheck = _loginVM.LoginInfoList.Where(u => u.GetUsername() == username);
            if (usernameCheck.Any())
            {
                await DisplayAlert("ERROR", "Username already exists, please try again.", "OK");
                UserName.Text = null;
                PassWord.Text = null;

                return;
            }

            // Checks entered email is in the correct format
            if (IsValid(email) == false)
            {
                await DisplayAlert("ERROR", "Email address is an incorrect format. Please try again.", "OK");
                UserName.Text = null;
                PassWord.Text = null;
                Email.Text = null;

                return;
            }

            // Register new user with Firebase Authentication
            try
            {
                var authProvider = Application.Current.Properties["LoginState"] as FirebaseAuthClient;

                // Create user with entered info
                var auth = await authProvider.CreateUserWithEmailAndPasswordAsync(email, password, username);
                var user = auth.User;

                // Gets a token to be used for Realtime Database (Not implemented yet)
                var token = await user.GetIdTokenAsync();

                // Creates a new LoginModel for user & adds to VM list
                LoginModel newUser = new LoginModel(user.Uid, username, password, email);
                _loginVM.LoginInfoList.Add(newUser);

                // Saves user info to firebase
                await myConnection.SubmitLogin(newUser);

                // Sets current application user to the new user
                Application.Current.Properties["currentUser"] = newUser;

                SignUpLoading.IsRunning = false;

                // Signs user in using email and password
                var loginAuth = await authProvider.SignInWithEmailAndPasswordAsync(email, password);

                await Navigation.PushAsync(new Assessment());
            }
            catch (Exception ex)
            {
                SignUpLoading.IsRunning = false;
                await App.Current.MainPage.DisplayAlert("Exception occurred", ex.Message, "OK");
            }
            
        }

        // Uses MailAddress from System.Net.Mail to check if an email address is in the valid format. Used in
        // verification checks when new user signs up.
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