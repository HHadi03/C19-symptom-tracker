using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ElarosProject.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Assessment : ContentPage
    {
        public Assessment()
        {
            InitializeComponent();
            symptomsListView.ItemsSource = new List<Symptom>
            {
                new Symptom { Description = "Breathlessness" },
                new Symptom { Description = "Cough" },
                new Symptom { Description = "Voice Change/Noisy Breathing" },
                new Symptom { Description = "Continence" },
                new Symptom { Description = "Aches/Pains" },
                new Symptom { Description = "Concentration/Short term memory" },
                new Symptom { Description = "Mental Health (Anxiety/Depression)" },
                new Symptom { Description = "Have you experienced PTSD related to your illness" },
                new Symptom { Description = "Communication" },
                new Symptom { Description = "Mobility" },
                new Symptom { Description = "Personal Care" },
                new Symptom { Description = "Day to day tasks" },
                new Symptom { Description = "Do you provide care for another individual?" }
            };
        }

        public class Symptom
        {
            public string Description { get; set; }
            public bool IsChecked { get; set; }
        }
    }
}