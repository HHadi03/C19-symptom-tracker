using ElarosProject.Model;
using Firebase.Auth;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace ElarosProject.View
{	
	public partial class FatigueTracker : ContentPage 
	{
        LoginModel currentUser = Application.Current.Properties["currentUser"] as LoginModel;
        databaseConnection myConnection = new databaseConnection();
        private string userEntry;

        public FatigueTracker()
		{

            InitializeComponent();
            showDate.Text = DateTime.Today.ToString("dd/MM/yyyy");

        }

        void sliderChange(object sender, ValueChangedEventArgs e)
        {

            var Step = Math.Round(e.NewValue / 1);
            slider.Value = Step;

        }

        void entryUpdated(object sender,TextChangedEventArgs e)
        {
            userEntry = e.NewTextValue;
        }

        void addItem(object sender, EventArgs args)
        {
            var newActivity = new Entry { Placeholder = "Add Entry", PlaceholderColor = Color.Black, ClearButtonVisibility = ClearButtonVisibility.WhileEditing, FontFamily = "myFont"  };
            myLayout.Children.Insert(myLayout.Children.Count - 1, newActivity);
            newActivity.TextChanged += entryUpdated;
        }
    
        private async void OnButtonClicked(Object sender, EventArgs e) 
        {
            string date = showDate.Text;
            string fatigueLevel = slider.Value.ToString();
            string activity = userEntry;

            if(string.IsNullOrEmpty(activity))
            {
                await DisplayAlert("Error","you must enter at least one activity to proceed","Cancel");
            }

            fatigueModel myModel = new fatigueModel();
            myModel.userID = currentUser.UserID;
            myModel.date = date;
            myModel.activities = activity;
            myModel.fatigueLevel = fatigueLevel;
            var savedEntry=await myConnection.SaveFatigueTracker(myModel);

            if(savedEntry)
            {
                await DisplayAlert("Success", "Entry Saved, Click Ok to continue", "Ok");
                await this.Navigation.PushAsync(new fatigueEntries());
            }
            else
            {
                await DisplayAlert("Error", "Unable to save entry", "Ok");
            }

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
    }
}


