using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ElarosProject.ViewModel;
using System;
using System.ComponentModel;
using ElarosProject.Model;
using System.Linq;

namespace ElarosProject.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Assessment : ContentPage
    {
        private AssessmentVM _assessmentVM = Application.Current.Properties["_assessmentVM"] as AssessmentVM;
        private LoginVM _loginVM = Application.Current.Properties["_loginVM"] as LoginVM;
        private LoginModel User = Application.Current.Properties["currentUser"] as LoginModel;

        public Assessment()
        {
            InitializeComponent();
            BindingContext = _assessmentVM;
        }

        async void SubmitClick(object sender, EventArgs e)
        {
            _assessmentVM = BindingContext as AssessmentVM;        

            foreach (var item in SymptomsListView.ItemsSource)
            {
                // Cast item to a Symptom object
                var symptom = (Symptom)item;

                // Add to AssessmentResults if checked
                if (symptom.IsChecked)
                {
                    _assessmentVM.AssessmentResults.Add(new AssessmentModel(User, symptom, 5, DateTime.Now.ToLongDateString()));
                    //
                    // TODO: Add severity slider to Assessment.xaml and use that data in code above. Currently used 5 as a placeholder.
                    //
                }               
            }

            // Move onto Login Page - Carry over the viewmodel instances so data persists through the pages
            await Navigation.PushAsync(new LogIn());
            await DisplayAlert("Assessment Submitted", "You may now login with your username and password.", "OK");

        }

    }
}