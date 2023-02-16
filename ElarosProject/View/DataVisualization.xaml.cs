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
                Color = SKColors.Blue
            },
            new ChartEntry(7)
            {
                Label="Cough",
                ValueLabel="7",
                Color = SKColors.Blue
            },
            new ChartEntry(3)
            {
                Label="Swallowing",
                ValueLabel="3",
                Color = SKColors.Blue
            },
            new ChartEntry(9)
            {
                Label="Fatigue",
                ValueLabel="9",
                Color = SKColors.Blue
            },
            new ChartEntry(8)
            {
                Label="Continence",
                ValueLabel = "8",
                Color = SKColors.Blue
            },
            new ChartEntry(4)
            {
                Label="Pain",
                ValueLabel = "4",
                Color = SKColors.Blue
            },
            new ChartEntry(5)
            {
                Label="Cognition",
                ValueLabel="5",
                Color = SKColors.Blue
            },
            new ChartEntry(2)
            {
                Label="Anxiety",
                ValueLabel = "2",
                Color = SKColors.Blue
            },
        };

        private readonly ChartEntry[] disabilities = new[]
        {
            new ChartEntry(7)
            {
                Label="Communication",
                ValueLabel = "7",
                Color = SKColors.Blue
            },
            new ChartEntry(3)
            {
                Label="Mobility",
                ValueLabel = "3",
                Color = SKColors.Blue
            },
            new ChartEntry(4)
            {
                Label="Personal-Care",
                ValueLabel = "4",
                Color = SKColors.Blue
            },
            new ChartEntry(10)
            {
                Label="Other",
                ValueLabel = "10",
                Color = SKColors.Blue
            }
        };
        public DataVisualization()
        {
            InitializeComponent();
            chartViewSymptoms.Chart = new RadarChart { Entries = symptoms };
            chartViewDisabilities.Chart = new RadarChart { Entries= disabilities };
        }
    }
}