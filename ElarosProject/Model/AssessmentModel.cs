using System;
using System.Collections.Generic;
using System.Text;

namespace ElarosProject.Model
{
    public class AssessmentModel
    {
        public LoginModel User { get; set; }
        public Symptom Symptom { get; set; }
        public int Severity { get; set; }
        public string DateLogged { get; set; }

        public AssessmentModel(LoginModel user, Symptom symptom, int severity, string dateLogged)
        {
            User = user;
            Symptom = symptom;
            Severity = severity;
            DateLogged = dateLogged;
        }
    }
}
