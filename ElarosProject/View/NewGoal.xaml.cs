using ElarosProject.Model;
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
    public partial class NewGoal : ContentPage
    {
        public NewGoal()
        {
            InitializeComponent();
        }

        protected void SaveClick(object sender, EventArgs e, GoalModel Ngoal)
        {
            // checks if goal name is left blank
            if (GoalName.Text == null) 
            {
                DisplayAlert("Error", "Goal name can't be left blank", "OK");
                GoalName.Text = null;
                return;
            }

            //code to create goal object
            Ngoal.Name = GoalName.Text;
            Ngoal.Symptom = GoalSymptom.SelectedItem.ToString();
            Ngoal.SeverityLevel = GoalSeverity.SelectedItem.ToString();
            Ngoal.StartDate = DateTime.Now;
            Ngoal.TargetDate = TargetDatePicker.Date;

            // code to save goal to database

            DisplayAlert("SUCCESS", "Goal saved", "OK");
            this.Navigation.PushAsync(new Goals());
        }
    }
}