using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace CovidApp.Views
{	
	public partial class FatigueTracker : ContentPage
	{
       
        public FatigueTracker ()
		{
            InitializeComponent();
            BindingContext = new ViewModels.FatigueTrackerViewModel();
        }

		void addItem(object sender,EventArgs args)
		{

            var newActivity = new Entry { Placeholder = "Add Entry", PlaceholderColor = Color.LightGray, ClearButtonVisibility = ClearButtonVisibility.WhileEditing,FontFamily="myFont"  };
            myLayout.Children.Insert(myLayout.Children.Count - 1, newActivity);
        }

        void submitActivities(object sender,EventArgs args)
        {
            
        }
    }
}

