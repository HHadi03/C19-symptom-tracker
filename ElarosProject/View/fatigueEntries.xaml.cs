using System;
using System.Collections.Generic;
using Xamarin.Forms;
using ElarosProject.Model;
using ElarosProject.ViewModel;

namespace ElarosProject.View
{
    public partial class fatigueEntries: ContentPage
    {
        databaseConnection myConnection = new databaseConnection();
        private LoginModel currentUser = Application.Current.Properties["currentUser"] as LoginModel;
        private AssessmentVM _assessmentVM = Application.Current.Properties["_assessmentVM"] as AssessmentVM;
        public LoginVM _loginVM = Application.Current.Properties["_loginVM"] as LoginVM;

        public string uID;
        public fatigueEntries()
        {
            InitializeComponent();
            BindingContext =new fatigueViewModel();
            uID = currentUser.GetUserID();
        }

        protected override async void OnAppearing() 
        {
       
            var userEntries = await myConnection.getEntries(uID);
            listView.ItemsSource = userEntries;
           
        }

        private async void sortBy(Object sender,EventArgs e)
        {
            var userEntries = await myConnection.getDescEntries(uID);
            listView.ItemsSource = userEntries;
        }
        
    }
}
