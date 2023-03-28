using System;
using System.Collections.Generic;
using Xamarin.Forms;
using ElarosProject.Model;
using ElarosProject.ViewModel;
using System.Collections.ObjectModel;
using Xamarin.Forms.Xaml;

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

        databaseConnection connect = new databaseConnection();

        public SymptomDiary()
        {
            InitializeComponent();
            uID = currentUser.GetUserID();
            updatedSymptom = _assessmentVM.getSymptomByUser(uID);
            BindingContext = this;
            SymptomCarousel.BindingContext = updatedSymptom;
            
        }

        void updateSeverity(Object sender, EventArgs e)
        {
            sliderContainer.IsVisible = !sliderContainer.IsVisible; //if update button clicked, shows/hides slider depending on current state
        }

        void deleteSymptom(Object sender, EventArgs e)
        {

        }

        void sliderChange(object sender, ValueChangedEventArgs e)
        {

            var Step = Math.Round(e.NewValue / 1);
            slider.Value = Step;

        }


        void submitUpdate(object sender, EventArgs e)
        {

        }

    }

}