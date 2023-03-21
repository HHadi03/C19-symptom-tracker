using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace ElarosProject.View
{
    public partial class fatigueEntries: ContentPage
    {
        databaseConnection myConnection = new databaseConnection();

        public fatigueEntries()
        {
            InitializeComponent();
            BindingContext =new ViewModel.fatigueViewModel();
        }

        protected override async void OnAppearing() 
        {
            var userEntries = await myConnection.getEntries();
            listView.ItemsSource = userEntries;
           
        }

        private async void sortBy(Object sender,EventArgs e)
        {
            var userEntries = await myConnection.getDescEntries();
            listView.ItemsSource = userEntries;
        }
        
    }
}
