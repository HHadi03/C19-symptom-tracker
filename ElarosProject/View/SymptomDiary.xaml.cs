using System;
using System.Collections.Generic;
using Xamarin.Forms;
using ElarosProject.Model;
using ElarosProject.ViewModel;
using System.Collections.ObjectModel;
using Xamarin.Forms.Xaml;
using System.Data.Common;
using Firebase.Auth;

namespace ElarosProject.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SymptomDiary : ContentPage
    {
        private LoginModel currentUser = Application.Current.Properties["currentUser"] as LoginModel;
        private AssessmentVM _assessmentVM = Application.Current.Properties["_assessmentVM"] as AssessmentVM;
        public LoginVM _loginVM = Application.Current.Properties["_loginVM"] as LoginVM;
        public string uID;
        public ObservableCollection<AssessmentModel> updatedSymptom;
        public List<AssessmentModel> UpdateList=new List<AssessmentModel>();

        public int currentItem;
        public AssessmentModel current;

        databaseConnection connect = new databaseConnection();

        public SymptomDiary()
        {
            InitializeComponent();
            uID = currentUser.GetUserID();
            //updatedSymptom = _assessmentVM.getSymptomByUser(uID);
            updatedSymptom = _assessmentVM.SpecificAssessmentResults(uID);
            SymptomCarousel.BindingContext = updatedSymptom;

        }
        
        void sliderChange(object sender, ValueChangedEventArgs e)
        {

            var Step = Math.Round(e.NewValue /1);
            slider.Value = Step;

        }

        void SymptomSwiped(Object sender, CurrentItemChangedEventArgs e)
        { 
            current = e.CurrentItem as AssessmentModel;
            current.updatedSeverity = slider.Value.ToString();
            current.DateLogged = DateTime.Today.ToString("dd-MM-yyyy");
            try
                {
                
                UpdateList.Insert(updatedSymptom.IndexOf(current),current);

                }
                catch (NullReferenceException)
                {

                }
        }

        async void submitUpdate(object sender, EventArgs e)
        {
            //foreach (var update in UpdateList)
            //{
            //    await connect.SaveUpdatedSymptoms(update);
            //}
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


