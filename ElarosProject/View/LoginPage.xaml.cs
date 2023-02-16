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
    public partial class LoginPage : ContentPage
    {
        private LoginVM _loginVM = new LoginVM();
        private AssessmentVM _assessmentVM = new AssessmentVM();

        public LoginPage()
        {
            InitializeComponent();

            // Sets VM objects as Application properties useable throughout
            Application.Current.Properties["_loginVM"] = _loginVM;
            Application.Current.Properties["_assessmentVM"] = _assessmentVM;
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