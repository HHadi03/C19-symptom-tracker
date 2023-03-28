using ElarosProject.Model;
using Microcharts;
using SkiaSharp;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ElarosProject.ViewModel
{
    public class DataVisualizationViewModel : INotifyPropertyChanged
    {
        public AssessmentVM _assessmentVM = Application.Current.Properties["_assessmentVM"] as AssessmentVM;

        public ChartEntry[] _userSymptoms;
        public ChartEntry[] _userDisabilities;
        private Chart _symptomsChart;
        private Chart _disabilityChart;

        public event PropertyChangedEventHandler PropertyChanged;
        public List<SKColor> colors = new List<SKColor>();
             
              
        public Chart SymptomsChart
        {
            get => _symptomsChart;
            set => SetProperty(ref _symptomsChart, value);
        }

        public Chart DisabilityChart
        {
            get => _disabilityChart;
            set => SetProperty(ref _disabilityChart, value);
        }

        public DataVisualizationViewModel()
        {
            // Add colors to list
            colors.Add(SKColor.Parse("#2F5CAF"));
            colors.Add(SKColor.Parse("#FDDDC7"));
            colors.Add(SKColor.Parse("#F7B176"));
            colors.Add(SKColor.Parse("#54A08C"));
            colors.Add(SKColor.Parse("#EDD182"));
            colors.Add(SKColor.Parse("#7865B6"));
            colors.Add(SKColor.Parse("#2F5CAF"));
            colors.Add(SKColor.Parse("#FDDDC7"));
            colors.Add(SKColor.Parse("#F7B176"));
            colors.Add(SKColor.Parse("#54A08C"));
            colors.Add(SKColor.Parse("#EDD182"));
            colors.Add(SKColor.Parse("#7865B6"));

            ShowBarCharts();
        }

        public ChartEntry[] BuildSymptomData(ObservableCollection<AssessmentModel> specificResults)
        {
            int colorCount = 0;
            List<ChartEntry> entryList = new List<ChartEntry>();

            foreach (var item in specificResults)
            {
                if (item.Symptom != "Communication" && item.Symptom != "Mobility" && item.Symptom != "Personal Care" && item.Symptom != "Daily tasks")
                {
                    entryList.Add(
                    new ChartEntry(item.Severity)
                    {
                        Label = item.Symptom,
                        ValueLabel = item.Severity.ToString(),
                        Color = colors[colorCount]
                    });
                    colorCount++;
                }
            }

            return entryList.ToArray();
        }

        public ChartEntry[] BuildDisabilityData(ObservableCollection<AssessmentModel> specificResults)
        {
            int colorCount = 0;
            List<ChartEntry> entryList = new List<ChartEntry>();

            foreach (var item in specificResults)
            {
                if (item.Symptom == "Communication" || item.Symptom == "Mobility" || item.Symptom == "Personal Care" || item.Symptom == "Daily tasks")
                {
                    entryList.Add(
                    new ChartEntry(item.Severity)
                    {
                        Label = item.Symptom,
                        ValueLabel = item.Severity.ToString(),
                        Color = colors[colorCount]
                    });
                    colorCount++;
                }
            }

            return entryList.ToArray();
        }

        public void ShowBarCharts()
        {
            SymptomsChart = new BarChart 
            { 
                Entries = _userSymptoms 
            };

            DisabilityChart = new BarChart
            {
                Entries = _userDisabilities
            };
        }

        public void ShowRadarCharts()
        {
            SymptomsChart = new RadarChart 
            { 
                Entries = _userSymptoms
            };

            DisabilityChart = new RadarChart
            {
                Entries = _userDisabilities
            };
        }

        public void ShowRadialCharts()
        {
            SymptomsChart = new RadialGaugeChart 
            { 
                Entries = _userSymptoms
            };

            DisabilityChart = new RadialGaugeChart
            {
                Entries = _userDisabilities
            };
        }

        private bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(storage, value))
            {
                return false;
            }

            storage = value;
            OnPropertyChanged(propertyName);

            return true;
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
