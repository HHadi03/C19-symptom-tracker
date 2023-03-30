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
        public ObservableCollection<AssessmentModel> SymptomUpdate { get; set; } //Holds user symptoms retrieved by User id, grouped by symptom to ensure it holds first occurence (most recent update of symptom)
        public LoginVM _loginVM = new LoginVM();
        databaseConnection myConnection = new databaseConnection();

        public AssessmentVM()
        {
            SymptomList = new ObservableCollection<Symptom>
            {
                new Symptom("Breathlessness", "BreathlessnessSeverity.xaml,"),
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
            SymptomUpdate = new ObservableCollection<AssessmentModel>();
            BuildList();
            UpdateSymptom(); //Build a list of symptoms by descending date 

        }

        public async void BuildList()
        {
            List<AssessmentModel> UserSymptoms = await myConnection.GetSymptoms();

            foreach (var entry in UserSymptoms)
            {
                AssessmentResults.Add(entry);
            }
        }

        public async void UpdateSymptom() 
        {
            List<AssessmentModel> symptomss = await myConnection.getUpdatedSymptom();
            foreach (var entry in symptomss)
            {
                SymptomUpdate.Add(entry);
            }

        }

        public ObservableCollection<AssessmentModel> getSymptomByUser(string userID) 
        {
            ObservableCollection<AssessmentModel> groupedSymptoms = new ObservableCollection<AssessmentModel>();
            var result = SymptomUpdate.Where(u => u.User == userID).GroupBy(s => s.Symptom);
            foreach (var record in result) 
            {
                groupedSymptoms.Add(record.FirstOrDefault());  
            }
            return groupedSymptoms;
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
