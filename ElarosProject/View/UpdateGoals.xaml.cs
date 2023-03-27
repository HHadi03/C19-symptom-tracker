using ElarosProject.Model;
using ElarosProject.ViewModel;
using Firebase.Database;
using Firebase.Database.Query;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
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
        FirebaseClient fbClient = new FirebaseClient("https://elarosdb-default-rtdb.europe-west1.firebasedatabase.app/",
                                  new FirebaseOptions
                                  {
                                      AuthTokenAsyncFactory = () => Task.FromResult("XnCOqCvY6p3hd7G440YmHXABryEhMKCoINcshr2a")
                                  });

        public UpdateGoals()
        {
            InitializeComponent();
            ObservableCollection<GoalModel> GoalList = _goalVM.GoalList;
            BindingContext = GoalList;
        }

        protected async void UpdateClick(object sender, EventArgs e)
        {
            GoalModel fromPicker = (GoalModel)GoalPicker.SelectedItem;
            string goalName = fromPicker.Name;

            //code to update goal
            foreach (GoalModel goal in _goalVM.GoalList)
            {
                if (goal.Name == goalName)
                {
                    goal.SeverityLevel = SeverityPicker.SelectedItem.ToString();
                    goal.TargetDate = TargetDatePicker.Date.ToString("dd/MM/yyyy");
                    goal.UpdateDate = DateTime.Now.ToString("dd/MM/yyyy");

                    GoalModel newGoal = new GoalModel(goal.Name, goal.GoalSymptom, goal.SeverityLevel, goal.StartDate, goal.TargetDate, goal.UserID);

                    await fbClient.Child("User Goals").Child(goal.Name + " - " + goal.UserID).PutAsync(JsonConvert.SerializeObject(newGoal));
                }
            }

            await DisplayAlert("SUCCESS", "Goal updated", "OK");
            await this.Navigation.PushAsync(new Dashboard());
        }

        protected async void DeleteClick(object sender, EventArgs e)
        {
            GoalModel fromPicker = (GoalModel)GoalPicker.SelectedItem;
            string goalName = fromPicker.Name;

            bool response = await DisplayAlert("Delete record", "Are you sure you want to delete this goal?", "Yes", "No");

            if (response)
            {
                foreach (GoalModel goal in _goalVM.GoalList)
                {
                    if (goal.Name == goalName)
                    {
                        await fbClient.Child("User Goals").Child(goal.Name + " - " + goal.UserID).DeleteAsync();
                    }
                }

                var item = _goalVM.GoalList.SingleOrDefault(x => x.Name == goalName);
                if (item != null)
                {
                    _goalVM.GoalList.Remove(item);
                }

                await DisplayAlert("SUCCESS", "Goal deleted", "OK");
                await this.Navigation.PushAsync(new Dashboard());
            }      
        }
    }
}