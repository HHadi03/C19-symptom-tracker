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
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        protected void SignUpClick(object sender, EventArgs e)
        {
            // Open Sign Up page
            Navigation.PushAsync(new SignUp());
        }

        protected void LogInClick(object sender, EventArgs e)
        {
            // Open Log In page
            Navigation.PushAsync(new LogIn());
        }
    }
}