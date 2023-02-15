using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ElarosProject.Model
{
    public class Symptom
    {
        public string SymptomName { get; set; }
        public bool IsChecked { get; set; }

        public Symptom(string name, bool ischecked)
        {
            SymptomName = name;
            IsChecked = ischecked;
        }

        public string GetSymptomName()
        {
            return SymptomName;
        }

        public bool SymptomChecked()
        {
            return IsChecked;
        }
    }
}
