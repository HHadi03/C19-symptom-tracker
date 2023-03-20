using ElarosProject.Model;
using ElarosProject.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ElarosProject.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewGoal : ContentPage
    {
        public LoginVM _loginVM = Application.Current.Properties["_loginVM"] as LoginVM;
        public AssessmentVM _assessmentVM = Application.Current.Properties["_assessmentVM"] as AssessmentVM;
        public GoalVM _goalVM = Application.Current.Properties["_goalVM"] as GoalVM;
        public LoginModel currentUser = Application.Current.Properties["currentUser"] as LoginModel;
        public ObservableCollection<AssessmentModel> userResults = new ObservableCollection<AssessmentModel>();
        public GoalModel newGoal = new GoalModel();

        public NewGoal()
        {
            InitializeComponent();
            userResults = (ObservableCollection<AssessmentModel>)Application.Current.Properties["userResults"];
            BindingContext = userResults;
            
        }

        protected void SaveClick(object sender, EventArgs e)
        {
            

            // checks if goal name is left blank
            if (GoalName.Text == null) 
            {
                DisplayAlert("Error", "Goal name can't be left blank", "OK");
                GoalName.Text = null;
                return;
            }

            //code to create goal object
            // Symptom pickerSymptom = (Symptom)SymptomPicker.SelectedItem;
            AssessmentModel pickerSymptom = (AssessmentModel)SymptomPicker.SelectedItem;
            string pickerSymptomName = pickerSymptom.Symptom;

            newGoal.Name = GoalName.Text;
            newGoal.GoalSymptom = pickerSymptomName;
            newGoal.SeverityLevel = GoalSeverity.SelectedItem.ToString();
            newGoal.StartDate = DateTime.Now.ToString("dd/MM/yyyy");
            newGoal.TargetDate = TargetDatePicker.Date.ToString("dd/MM/yyyy");

            _goalVM.GoalList.Add(new GoalModel(newGoal.Name, newGoal.GoalSymptom, newGoal.SeverityLevel, newGoal.StartDate, newGoal.TargetDate));

            // code to save goal to database

            DisplayAlert("SUCCESS", "Goal saved", "OK");
            this.Navigation.PushAsync(new Goals());
        }
    }
}