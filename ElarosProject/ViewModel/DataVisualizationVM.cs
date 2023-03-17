using Microcharts;
using SkiaSharp;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ElarosProject.ViewModel
{
    public class DataVisualizationViewModel : INotifyPropertyChanged
    {
        public ChartEntry[] _symptoms;
        public ChartEntry[] _disabilities;
        private Chart _symptomsChart;
        private Chart _disabilitiesChart;

        public event PropertyChangedEventHandler PropertyChanged;

        public Chart SymptomsChart
        {
            get => _symptomsChart;
            set => SetProperty(ref _symptomsChart, value);
        }

        public Chart DisabilitiesChart
        {
            get => _disabilitiesChart;
            set => SetProperty(ref _disabilitiesChart, value);
        }

        public DataVisualizationViewModel()
        {
            _symptoms = new[]
            {
                new ChartEntry(10)
                {
                    Label="Breathlessness",
                    ValueLabel="10",
                    Color = SKColor.Parse("#2F5CAF")
                },
                new ChartEntry(7)
                {
                    Label="Cough",
                    ValueLabel="7",
                    Color = SKColor.Parse("#FDDDC7")
                },
                new ChartEntry(3)
                {
                    Label="Swallowing",
                    ValueLabel="3",
                    Color = SKColor.Parse("#F7B176")
                },
                new ChartEntry(9)
                {
                    Label="Fatigue",
                    ValueLabel="9",
                    Color = SKColor.Parse("#54A08C")
                },
                new ChartEntry(8)
                {
                    Label="Continence",
                    ValueLabel = "8",
                    Color = SKColor.Parse("#7865B6")
                },
                new ChartEntry(4)
                {
                    Label="Pain",
                    ValueLabel = "4",
                    Color = SKColor.Parse("#EDD182")
                },
                new ChartEntry(5)
                {
                    Label="Cognition",
                    ValueLabel="5",
                    Color = SKColor.Parse("#2F5CAF")
                },
                new ChartEntry(2)
                {
                    Label="Anxiety",
                    ValueLabel = "2",
                    Color = SKColor.Parse("#FDDDC7")
                },
            };

            _disabilities = new[]
            {
                new ChartEntry(7)
                {
                    Label="Communication",
                    ValueLabel = "7",
                    Color = SKColor.Parse("#7865B6")
                },
                new ChartEntry(3)
                {
                    Label="Mobility",
                    ValueLabel = "3",
                    Color = SKColor.Parse("#54A08C")
                },
                new ChartEntry(4)
                {
                    Label="Personal-Care",
                    ValueLabel = "4",
                    Color = SKColor.Parse("#FDDDC7")
                },
                new ChartEntry(10)
                {
                    Label="Other",
                    ValueLabel = "10",
                    Color = SKColor.Parse("#2F5CAF")
                }
            };

            ShowRadarCharts();
        }

        public void ShowBarCharts()
        {
            SymptomsChart = new BarChart { Entries = _symptoms };
            DisabilitiesChart = new BarChart { Entries = _disabilities };
        }

        public void ShowRadarCharts()
        {
            SymptomsChart = new RadarChart { Entries = _symptoms };
            DisabilitiesChart = new RadarChart { Entries = _disabilities };
        }

        public void ShowRadialCharts()
        {
            SymptomsChart = new RadialGaugeChart { Entries = _symptoms };
            DisabilitiesChart = new RadialGaugeChart { Entries = _disabilities };
        }

        public ChartEntry[] GetRadarChartData(ChartEntry[] data)
        {
            return data;
        }

        public ChartEntry[] GetBarChartData(ChartEntry[] data)
        {
            return data;
        }

        public ChartEntry[] GetRadialChartData(ChartEntry[] data)
        {
            return data;
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

