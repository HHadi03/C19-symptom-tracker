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
        private AssessmentVM _assessmentVM;

        public Assessment()
        {
            InitializeComponent();
            BindingContext = new AssessmentVM();
            
        }

        protected void SubmitClick(object sender, EventArgs e)
        {
            _assessmentVM = BindingContext as AssessmentVM;        

            foreach (var item in SymptomsListView.ItemsSource)
            {
                // Cast item to a Symptom object
                var symptom = (Symptom)item;

                // Add to AssessmentResults if checked
                if (symptom.IsChecked)
                {
                    _assessmentVM.AssessmentResults.Add(new AssessmentModel(_assessmentVM._loginVM.LoginInfoList.Where(u => u.GetUserID() == 1).FirstOrDefault(), symptom, 5));
                    //
                    // TODO: Add severity slider to Assessment.xaml and use that data in code above. Currently used 5 as a placeholder.
                    //
                }               
            }

            this.Navigation.PopModalAsync();
            DisplayAlert("Assessment Submitted", "You may now login with your username and password.", "OK");

        }

    }
}