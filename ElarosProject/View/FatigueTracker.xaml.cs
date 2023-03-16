using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace ElarosProject.View
{	
	public partial class FatigueTracker : ContentPage 
	{

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

            var newActivity = new Entry { Placeholder = "Add Entry", PlaceholderColor = Color.LightGray, ClearButtonVisibility = ClearButtonVisibility.WhileEditing, FontFamily = "myFont"  };
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

            Model.fatigueModel myModel = new Model.fatigueModel();
            myModel.date = date;
            myModel.activities = activity;
            myModel.fatigueLevel = fatigueLevel;
            var savedEntry=await myConnection.SaveFatigueTracker(myModel);

            if(savedEntry)
            {
                await DisplayAlert("Info", "successfully saved entry", "ok");
                await this.Navigation.PushAsync(new fatigueEntries());
            }
            else
            {
                await DisplayAlert("error", "could not save", "ok");
            }

        }
    }
}

