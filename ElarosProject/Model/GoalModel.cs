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
        public string UserID { get; set; }

        public GoalModel()
        {

        }

        public GoalModel(string Name, string symptomName, string SeverityLevel, string StartDate, string TargetDate, string userID)
        {
            this.Name = Name;
            this.GoalSymptom = symptomName;
            this.SeverityLevel = SeverityLevel;
            this.StartDate = StartDate;
            this.TargetDate = TargetDate;
            UserID = userID;
        }
    }
}
