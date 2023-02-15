using ElarosProject.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public AssessmentVM()
        {
            SymptomList = new ObservableCollection<Symptom>
            {
                new Symptom("Breathlessness", false),
                new Symptom("Cough", false),
                new Symptom("Voice Change/Noisy Breathing", false),
                new Symptom("Continence", false),
                new Symptom("Aches/Pains", false),
                new Symptom("Concentration/Short term memory", false),
                new Symptom("Mental Health", false),
                new Symptom("PTSD", false),
                new Symptom("Communication", false),
                new Symptom("Mobility", false),
                new Symptom("Personal Care", false),
                new Symptom("Daily tasks", false),
            };

            AssessmentResults = new ObservableCollection<AssessmentModel>
            {
                new AssessmentModel(_loginVM.LoginInfoList.Where(u => u.GetUserID() == 1).FirstOrDefault(), SymptomList.Where(s => s.GetSymptomName() == "Cough").FirstOrDefault(), 8, DateTime.Now.ToLongDateString()),
                new AssessmentModel(_loginVM.LoginInfoList.Where(u => u.GetUserID() == 1).FirstOrDefault(), SymptomList.Where(s => s.GetSymptomName() == "PTSD").FirstOrDefault(), 6, DateTime.Now.ToLongDateString()),
                new AssessmentModel(_loginVM.LoginInfoList.Where(u => u.GetUserID() == 4).FirstOrDefault(), SymptomList.Where(s => s.GetSymptomName() == "Breathlessness").FirstOrDefault(), 3, DateTime.Now.ToLongDateString()),
                new AssessmentModel(_loginVM.LoginInfoList.Where(u => u.GetUserID() == 4).FirstOrDefault(), SymptomList.Where(s => s.GetSymptomName() == "Cough").FirstOrDefault(), 6, DateTime.Now.ToLongDateString()),
                new AssessmentModel(_loginVM.LoginInfoList.Where(u => u.GetUserID() == 4).FirstOrDefault(), SymptomList.Where(s => s.GetSymptomName() == "Mobility").FirstOrDefault(), 10, DateTime.Now.ToLongDateString()),
                new AssessmentModel(_loginVM.LoginInfoList.Where(u => u.GetUserID() == 3).FirstOrDefault(), SymptomList.Where(s => s.GetSymptomName() == "Aches/Pains").FirstOrDefault(), 8, DateTime.Now.ToLongDateString()),
                new AssessmentModel(_loginVM.LoginInfoList.Where(u => u.GetUserID() == 3).FirstOrDefault(), SymptomList.Where(s => s.GetSymptomName() == "Mobility").FirstOrDefault(), 9, DateTime.Now.ToLongDateString()),
                new AssessmentModel(_loginVM.LoginInfoList.Where(u => u.GetUserID() == 2).FirstOrDefault(), SymptomList.Where(s => s.GetSymptomName() == "PTSD").FirstOrDefault(), 7, DateTime.Now.ToLongDateString())
            };            
        }

        public ObservableCollection<AssessmentModel> SpecificAssessmentResults(int currentId)
        {
            var userSpecific = AssessmentResults.Where(u => u.User.GetUserID() == currentId);
            ObservableCollection<AssessmentModel> results = new ObservableCollection<AssessmentModel>();
            foreach (var item in userSpecific)
            {
                results.Add(item);
            }

            return results;
        }

    }
}
