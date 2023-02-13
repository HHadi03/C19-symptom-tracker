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
            _loginVM = BindingContext as LoginVM;

            _loginVM.LoginInfoList.Add(new LoginModel(UserName.Text, PassWord.Text, Email.Text));

            DisplayAlert("SIGNED UP", "You may now login with your username and password.", "OK");
            Navigation.PushAsync(new LogIn(_loginVM));
        }
    }
}