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
        public List<Symptom> selectedSymptoms = new List<Symptom>();

        public Assessment()
        {
            InitializeComponent();
            BindingContext = _assessmentVM;
        }

        public static ContentPage CreateSeverityPage(Symptom symptom)
        {
            ContentPage severityPage = null;
            switch (symptom.SymptomName)
            {
                case "Breathlessness":
                    severityPage = new BreathlessnessSeverity();
                    break;
                case "Cough":
                    severityPage = new CoughSeverity();
                    break;
                case "Voice Change/Noisy Breathing":
                    severityPage = new VoiceSeverity();
                    break;
                case "Continence":
                    severityPage = new ContinenceSeverity();
                    break;
                case "Aches/Pains":
                    severityPage = new AchesSeverity();
                    break;
                case "Concentration/Short term memory":
                    severityPage = new ConcentrationSeverity();
                    break;
                case "Mental Health":
                    severityPage = new MentalHealthSeverity();
                    break;
                case "PTSD":
                    severityPage = new PTSDSeverity();
                    break;
                case "Communication":
                    severityPage = new CommunicationSeverity();
                    break;
                case "Mobility":
                    severityPage = new MobilitySeverity();
                    break;
                case "Personal Care":
                    severityPage = new PersonalCareSeverity();
                    break;
                case "Daily tasks":
                    severityPage = new DailyTasksSeverity();
                    break;
                default:
                    break;
            }

            return severityPage;
        }

        async void SubmitClick(object sender, EventArgs e)
        {
            var selectedSymptoms = _assessmentVM.SymptomList.Where(symptom => symptom.IsSelected).ToList();
            int selectedCount = selectedSymptoms.Count;

            if (selectedCount > 0)
            {
                for (int i = 0; i < selectedCount; i++)
                {
                    var symptom = selectedSymptoms[i];
                    if (symptom.IsSelected)
                    {
                        var severityPage = CreateSeverityPage(symptom);
                        await Navigation.PushAsync(severityPage);

                        if (severityPage is BreathlessnessSeverity breathlessnessPage)
                        {
                            await breathlessnessPage.WaitForInputValidationAsync();
                        }
                        else if (severityPage is CoughSeverity coughPage)
                        {
                            await coughPage.WaitForInputValidationAsync();
                        }
                        else if (severityPage is AchesSeverity achesPage)
                        {
                            await achesPage.WaitForInputValidationAsync();
                        }
                        else if (severityPage is VoiceSeverity voicePage)
                        {
                            await voicePage.WaitForInputValidationAsync();
                        }
                        else if (severityPage is ContinenceSeverity continencePage)
                        {
                            await continencePage.WaitForInputValidationAsync();
                        }
                        else if (severityPage is ConcentrationSeverity concentrationPage)
                        {
                            await concentrationPage.WaitForInputValidationAsync();
                        }
                        else if (severityPage is MentalHealthSeverity mentalHealthPage)
                        {
                            await mentalHealthPage.WaitForInputValidationAsync();
                        }
                        else if (severityPage is PTSDSeverity ptsdPage)
                        {
                            await ptsdPage.WaitForInputValidationAsync();
                        }
                        else if (severityPage is CommunicationSeverity communicationPage)
                        {
                            await communicationPage.WaitForInputValidationAsync();
                        }
                        else if (severityPage is MobilitySeverity mobilityPage)
                        {
                            await mobilityPage.WaitForInputValidationAsync();
                        }
                        else if (severityPage is PersonalCareSeverity personalCarePage)
                        {
                            await personalCarePage.WaitForInputValidationAsync();
                        }
                        else if (severityPage is DailyTasksSeverity dailyTasksPage)
                        {
                            await dailyTasksPage.WaitForInputValidationAsync();
                        }

                        if (i == selectedCount - 1)
                        {
                            await DisplayAlert("Assessment Submitted", "You may now login with your username and password.", "OK");
                            await Navigation.PushAsync(new LogIn());
                        }
                    }
                }
            }
            else
            {
                await DisplayAlert("No Symptoms Selected", "Please select at least one symptom to proceed with the assessment.", "OK");
            }
        }

    }
}