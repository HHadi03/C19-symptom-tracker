using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace ElarosProject.Model
{
    public class GoalModel
    {
        public string Name { get; set; }
        public string GoalSymptom { get; set; }
        public string SeverityLevel { get; set; }
        public string StartDate { get; set; }
        public string TargetDate { get; set; }
        public string UpdateDate { get; set; }

        public GoalModel()
        {

        }

        public GoalModel(string Name, string symptomName, string SeverityLevel, string StartDate, string TargetDate)
        {
            this.Name = Name;
            this.GoalSymptom = symptomName;
            this.SeverityLevel = SeverityLevel;
            this.StartDate = StartDate;
            this.TargetDate = TargetDate;
        }

        public string GetName() { return Name; }
        public string GetSymptom() { return GoalSymptom; }
        public string GetSeverityLevel() { return SeverityLevel; }
        public string GetStartDate() { return StartDate; }
        public string GetTargetDate() { return TargetDate; }
        public string GetUpdateDate() { return UpdateDate; }
    }
}
