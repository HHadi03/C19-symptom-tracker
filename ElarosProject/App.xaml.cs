using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ElarosProject.View;
using System.Threading.Tasks;
using ElarosProject.ViewModel;
using ElarosProject.Model;
using Firebase.Auth.Providers;
using Firebase.Auth;
using Plugin.FirebasePushNotification;

namespace ElarosProject
{
    public partial class App : Application
    {
        public LoginVM LoginVMApp { get; set; }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new LoginPage());

            CrossFirebasePushNotification.Current.OnTokenRefresh += Current_OnTokenRefresh;

            // Sets VM objects as Application properties useable throughout
            Application.Current.Properties["_loginVM"] = new LoginVM();
            Application.Current.Properties["_assessmentVM"] = new AssessmentVM();
            Application.Current.Properties["_goalVM"] = new GoalVM();
            Application.Current.Properties["LoginState"] = new FirebaseAuthClient(new FirebaseAuthConfig
            {
                ApiKey = "AIzaSyAnwLkBWEJDsJwmgs_1Hkpg7ydKW9T5rRM",
                AuthDomain = "elarosdb.firebaseapp.com",
                Providers = new FirebaseAuthProvider[]
                    {
                        new GoogleProvider().AddScopes("email"),
                        new EmailProvider()
                    }
            });

        }

        private void Current_OnTokenRefresh(object source, FirebasePushNotificationTokenEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine($"Token: {e.Token}");
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
