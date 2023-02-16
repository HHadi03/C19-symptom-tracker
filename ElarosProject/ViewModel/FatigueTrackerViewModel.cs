using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;


namespace CovidApp.ViewModels
{
    public class FatigueTrackerViewModel : BaseViewModel
    {
        public ObservableCollection<Models.fatigueTracker> logActivities { get; set; }
        public string myDate { get; } = DateTime.Today.ToString("dd/MM/yyyy");

       
        public FatigueTrackerViewModel()
        {
            Title = "Fatigue Tracker";
            logActivities.Add(new Models.fatigueTracker(myDate));
        }

        
    }
}
