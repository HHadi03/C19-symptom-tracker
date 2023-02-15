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

namespace ElarosProject.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignUp : ContentPage
    {
        private LoginVM _loginVM;
        

        public SignUp()
        {
            InitializeComponent();

            this.BindingContext = new LoginVM();
        }

        async void SignUpClick(object sender, EventArgs e)
        {
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
            var username = _loginVM.LoginInfoList.Where(u => u.GetUsername() == UserName.Text);
            if (username.Any())
            {
                await DisplayAlert("ERROR", "Username already exists, please try again.", "OK");
                UserName.Text = null;
                PassWord.Text = null;

                return;
            }

            // Checks entered email is in the correct format
            if (IsValid(Email.Text) == false)
            {
                await DisplayAlert("ERROR", "Email address is an incorrect format. Please try again.", "OK");
                UserName.Text = null;
                PassWord.Text = null;
                Email.Text = null;

                return;
            }

            // Success alert - account created
            _loginVM.LoginInfoList.Add(new LoginModel((_loginVM.LoginInfoList.Count + 1), UserName.Text, PassWord.Text, Email.Text));
            await Navigation.PushModalAsync(new Assessment());
            // await Navigation.PushAsync(new Assessment());
            await Navigation.PushAsync(new LogIn(_loginVM));
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