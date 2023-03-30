using ElarosProject.Model;
using ElarosProject.ViewModel;
using Firebase.Auth;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
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
        private ObservableCollection<AssessmentModel> specificAssessmentResults;
        private ObservableCollection<GoalModel> specificGoals;
        private AssessmentVM _assessmentVM = Application.Current.Properties["_assessmentVM"] as AssessmentVM;
        private GoalVM _goalVM = Application.Current.Properties["_goalVM"] as GoalVM;
        private LoginModel currentUser = Application.Current.Properties["currentUser"] as LoginModel;
        private string currentId;

        public Dashboard()
        {
            InitializeComponent();

            // Code to load Dashboard (3rd tab) as initial page
            var pages = Children.GetEnumerator();
            pages.MoveNext(); // Moves to first tab
            pages.MoveNext(); // Moves to second tab
            pages.MoveNext(); // Moves to third tab (The Dashboard tab)
            CurrentPage = pages.Current;

            // Set current user and their ID
            currentId = currentUser.GetUserID();

            // Uses persisted AssessmentVM to calculate new AssessmentResults collection for specific user
            specificAssessmentResults = _assessmentVM.SpecificAssessmentResults(currentId);
            Application.Current.Properties["userResults"] = specificAssessmentResults;

            // Uses persisted GoalVM to calculate new GoalList collection for specific user
            specificGoals = _goalVM.SpecificGoals(currentId);
            Application.Current.Properties["userGoals"] = specificGoals;

            // Binds new AssessmentResults collection data
            SymptomCarousel.BindingContext = specificAssessmentResults;
            GoalCarousel.BindingContext = specificGoals;
            
            // Display welcome to user
            WelcomeLabel.Text = "Welcome " + currentUser.GetUsername() + "!";

            // Autoscroll carousels
            CarouselScroll();
        }

        async void CarouselScroll()
        {
            Device.StartTimer(TimeSpan.FromSeconds(5), (Func<bool>)(() =>
            {
                if (specificAssessmentResults.Count > 0)
                {
                    SymptomCarousel.Position = (SymptomCarousel.Position + 1) % specificAssessmentResults.Count;
                }

                if (specificGoals.Count > 0)
                {
                    GoalCarousel.Position = (GoalCarousel.Position + 1) % specificGoals.Count;
                }

                return true;
            })
            );
        }

        async void LogoutClick(object sender, EventArgs e)
        {
            bool response = await DisplayAlert("Logout", "Do you want to logout?", "Yes", "No");

            if (response)
            {
                var authProvider = Application.Current.Properties["LoginState"] as FirebaseAuthClient;
                authProvider.SignOut();
                currentUser = null;
                await Navigation.PushAsync(new LoginPage());
            }
        }

        // Prevents user pressing back on their device and returning to login
        protected override bool OnBackButtonPressed() { return true; }
    }
}