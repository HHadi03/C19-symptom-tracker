using ElarosProject.Model;
using ElarosProject.ViewModel;
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
        private AssessmentVM _assessmentVM = Application.Current.Properties["_assessmentVM"] as AssessmentVM;
        private LoginModel currentUser = Application.Current.Properties["currentUser"] as LoginModel;
        private int currentId;

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

            // Binds new AssessmentResults collection data
            BindingContext = specificAssessmentResults;
            
            // Display welcome to user
            WelcomeLabel.Text = "Welcome " + currentUser.GetUsername() + "!";
        }
    }
}