using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace CovidApp.Views
{
    public partial class DiaryEntries : ContentPage
    {
        public DiaryEntries()
        {
            InitializeComponent();
            BindingContext = new ViewModels.FatigueTrackerViewModel();
           
        }

       

    }
}

