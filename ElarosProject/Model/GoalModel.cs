using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace ElarosProject.Model
{
    public class GoalModel
    {
        public string Name { get; set; }
        public string Symptom { get; set; }
        public string SeverityLevel { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime TargetDate { get; set; }

        public GoalModel()
        {

        }

        public GoalModel(string Name, string Symptom, string SeverityLevel, DateTime StartDate, DateTime TargetDate)
        {
            this.Name = Name;
            this.Symptom = Symptom;
            this.SeverityLevel = SeverityLevel;
            this.StartDate = StartDate;
            this.TargetDate = TargetDate;
        }

        public string GetName() { return Name; }
        public string GetSymptom() { return Symptom; }
        public string GetSeverityLevel() { return SeverityLevel; }
        public DateTime GetStartDate() { return StartDate; }
        public DateTime GetTargetDate() { return TargetDate; }
    }
}
