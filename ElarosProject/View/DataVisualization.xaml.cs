using Microcharts;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ElarosProject.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DataVisualization : ContentPage
    {
        private readonly ChartEntry[] symptoms = new[]
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

        private readonly ChartEntry[] disabilities = new[]
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
        public DataVisualization()
        {
            InitializeComponent();
            chartViewSymptoms.Chart = new RadarChart { Entries = symptoms };
            chartViewDisabilities.Chart = new RadarChart { Entries = disabilities };
        }

        private void BarChartClicked(object sender, EventArgs e)
        {
            chartViewSymptoms.Chart = new BarChart { Entries = symptoms };
            chartViewDisabilities.Chart = new BarChart { Entries = disabilities };
        }

        private void RadarChartClicked(object sender, EventArgs e)
        {
            chartViewSymptoms.Chart = new RadarChart { Entries = symptoms };
            chartViewDisabilities.Chart = new RadarChart { Entries = disabilities };
        }

        private void RadialChartClicked(object sender, EventArgs e)
        {
            chartViewSymptoms.Chart = new RadialGaugeChart { Entries = symptoms };
            chartViewDisabilities.Chart = new RadialGaugeChart { Entries = disabilities };
        }
    }
}