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
        }

        protected override async void OnAppearing() 
        {
            var userEntries = await myConnection.getEntries();
            listView.ItemsSource = userEntries;
           
        }
        
    }
}
