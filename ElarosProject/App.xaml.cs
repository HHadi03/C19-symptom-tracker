using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ElarosProject.View;
using System.Threading.Tasks;

namespace ElarosProject
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new LoginPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected async override void OnResume()
        {
            await MainPage.Navigation.PushModalAsync(new ResumePage(), false);
            await Task.Delay(800);
            await MainPage.Navigation.PopModalAsync(true);

            

        }
    }
}
