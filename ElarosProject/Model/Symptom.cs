using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ElarosProject.Model
{
    public class Symptom
    {
        public string SymptomName { get; set; }
        public string SeverityPage { get; set; }
        public bool IsSelected { get; set; }


        public Symptom(string name, string severityPage)
        {
            SymptomName = name;
            SeverityPage = severityPage;
            IsSelected = false;

        }

        public string GetSymptomName()
        {
            return SymptomName;
        }
    }
}
