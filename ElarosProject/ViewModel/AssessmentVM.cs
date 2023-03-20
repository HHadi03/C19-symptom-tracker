using ElarosProject.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace ElarosProject.ViewModel
{
    public class AssessmentVM
    {
        // Holds symptom information to use in Views
        public ObservableCollection<AssessmentModel> AssessmentResults { get; set; }
        public ObservableCollection<Symptom> SymptomList { get; set; }
        public LoginVM _loginVM = new LoginVM();
        databaseConnection myConnection = new databaseConnection();

        public AssessmentVM()
        {
            SymptomList = new ObservableCollection<Symptom>
            {
                new Symptom("Breathlessness", "BreathlessnessSeverity.xaml"),
                new Symptom("Cough", "CoughSeverity.xaml"),
                new Symptom("Voice Change/Noisy Breathing", "VoiceSeverity.xaml"),
                new Symptom("Continence", "ContinenceSeverity.xaml"),
                new Symptom("Aches/Pains", "AchesSeverity.xaml"),
                new Symptom("Concentration/Short term memory", "ConcentrationSeverity.xaml"),
                new Symptom("Mental Health", "MentalHealthSeverity.xaml"),
                new Symptom("PTSD", "PTSDSeverity.xaml"),
                new Symptom("Communication", "CommunicationSeverity.xaml"),
                new Symptom("Mobility", "MobilitySeverity.xaml"),
                new Symptom("Personal Care", "PersonalCareSeverity.xaml"),
                new Symptom("Daily tasks", "DailyTasksSeverity.xaml")
            };

            AssessmentResults = new ObservableCollection<AssessmentModel>();

            BuildList();

        }

        public async void BuildList()
        {
            List<AssessmentModel> UserSymptoms = await myConnection.GetSymptoms();

            foreach (var entry in UserSymptoms)
            {
                AssessmentResults.Add(entry);
            }
        }

        public ObservableCollection<AssessmentModel> SpecificAssessmentResults(string currentId)
        {
            var userSpecific = AssessmentResults.Where(u => u.User == currentId);
            ObservableCollection<AssessmentModel> results = new ObservableCollection<AssessmentModel>();
            foreach (var item in userSpecific)
            {
                results.Add(item);
            }

            return results;
        }

    }
}
