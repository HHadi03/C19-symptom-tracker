using ElarosProject.Model;
using ElarosProject.ViewModel;
using Plugin.LocalNotification;
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
    public partial class Goals : ContentPage
    {
        public LoginVM _loginVM = Application.Current.Properties["_loginVM"] as LoginVM;
        public AssessmentVM _assessmentVM = Application.Current.Properties["_assessmentVM"] as AssessmentVM;
        public GoalVM _goalVM = Application.Current.Properties["_goalVM"] as GoalVM;
        public LoginModel currentUser = Application.Current.Properties["currentUser"] as LoginModel;

        public Goals()
        {
            InitializeComponent();
        }

        Boolean newGoalClicked = false;
        protected void NewGoalClick(object sender, EventArgs e)
        { 
            newGoalClicked = true; this.Navigation.PushAsync(new NewGoal());
        }

        public void SetupNotification()
        {
            if (!newGoalClicked)
            {
                var notification = new NotificationRequest
                {
                    Description = "You have not set any new goals today...",
                    Title = "Elaros Long Covid",
                    Schedule = new NotificationRequestSchedule
                    {
                        NotifyTime = DateTime.Now.AddMinutes(2)
                    }
                };

                LocalNotificationCenter.Current.Show(notification);
            }
        }

        protected void UpdateGoalClick(object sender, EventArgs e)
        {
            if (_goalVM.GoalList.Count == 0)
            {
                DisplayAlert("ERROR", "No goals have been set", "OK");
            }
            else
            {
                this.Navigation.PushAsync(new UpdateGoals());
            }
        }

        protected void ViewGoalClick(object sender, EventArgs e)
        {
            if (_goalVM.GoalList.Count == 0)
            {
                DisplayAlert("ERROR", "No goals have been set", "OK");
            }
            else
            {
                this.Navigation.PushAsync(new ViewGoals());
            }
        }
    }
}