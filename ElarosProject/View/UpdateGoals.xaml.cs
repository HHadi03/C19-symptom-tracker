using ElarosProject.Model;
using ElarosProject.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ElarosProject.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UpdateGoals : ContentPage
    {
        public LoginVM _loginVM = Application.Current.Properties["_loginVM"] as LoginVM;
        public AssessmentVM _assessmentVM = Application.Current.Properties["_assessmentVM"] as AssessmentVM;
        public GoalVM _goalVM = Application.Current.Properties["_goalVM"] as GoalVM;
        public LoginModel currentUser = Application.Current.Properties["currentUser"] as LoginModel;

        public UpdateGoals()
        {
            InitializeComponent();
            ObservableCollection<GoalModel> GoalList = _goalVM.GoalList;
            BindingContext = GoalList;
        }

        protected void UpdateClick(object sender, EventArgs e)
        {
            //code to update goal

            DisplayAlert("SUCCESS", "Goal updated", "OK");
            this.Navigation.PushAsync( new Goals());
        }
    }
}