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
    public partial class Dashboard : TabbedPage
    {
        public Dashboard(LoginModel user)
        {
            InitializeComponent();
            BindingContext = new LoginVM();
            WelcomeLabel.Text = "Welcome " + user.GetUsername() + "!";
        }
    }
}