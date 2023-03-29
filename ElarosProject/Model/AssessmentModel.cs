using System;
using System.Collections.Generic;
using System.Text;

namespace ElarosProject.Model
{
    public class AssessmentModel
    {
        public string User { get; set; }
        public string Symptom { get; set; }
        public int Severity { get; set; }
        public string DateLogged { get; set; }
        public static int completedPages { get; set; } = 0; 

        public AssessmentModel(string user, string symptom, int severity, string dateLogged)
        {
            User = user;
            Symptom = symptom;
            Severity = severity;
            DateLogged = dateLogged;
        }

        public AssessmentModel() { }
    }
}
