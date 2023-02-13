using ElarosProject.Model;
using ElarosProject.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        protected void SignUpClick(object sender, EventArgs e)
        {
            // Set BindingContext for _loginVM attribute as LoginVM
            _loginVM = BindingContext as LoginVM;

            // Checks that no fields are left empty
            if (UserName.Text == null || PassWord.Text == null || Email.Text == null)
            {
                DisplayAlert("ERROR", "Entry fields cannot be blank. Please try again", "OK");
                UserName.Text = null;
                PassWord.Text = null;
                Email.Text = null;

                return;
            }

            // Checks username isn't already in use
            var username = _loginVM.LoginInfoList.Where(u => u.GetUsername() == UserName.Text);
            if (username.Any())
            {
                DisplayAlert("ERROR", "Username already exists, please try again.", "OK");
                UserName.Text = null;
                PassWord.Text = null;

                return;
            }

            // Success alert - account created
            _loginVM.LoginInfoList.Add(new LoginModel(UserName.Text, PassWord.Text, Email.Text));
            DisplayAlert("SIGNED UP", "You may now login with your username and password.", "OK");
            Navigation.PushAsync(new LogIn(_loginVM));
            
        }
    }
}