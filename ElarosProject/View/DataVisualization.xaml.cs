using ElarosProject.ViewModel;
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
        private readonly DataVisualizationViewModel _viewModel;
        public DataVisualization()
        {
            InitializeComponent();

            _viewModel = new DataVisualizationViewModel();
            chartViewSymptoms.Chart = new RadarChart { Entries = _viewModel.GetRadarChartData(_viewModel._symptoms) };
            chartViewDisabilities.Chart = new RadarChart { Entries = _viewModel.GetRadarChartData(_viewModel._disabilities) };
        }

        private void BarChartClicked(object sender, EventArgs e)
        {
            chartViewSymptoms.Chart = new BarChart { Entries = _viewModel.GetBarChartData(_viewModel._symptoms) };
            chartViewDisabilities.Chart = new BarChart { Entries = _viewModel.GetBarChartData(_viewModel._disabilities) };
        }

        private void RadarChartClicked(object sender, EventArgs e)
        {
            chartViewSymptoms.Chart = new RadarChart { Entries = _viewModel.GetRadarChartData(_viewModel._symptoms) };
            chartViewDisabilities.Chart = new RadarChart { Entries = _viewModel.GetRadarChartData(_viewModel._disabilities) };
        }

        private void RadialChartClicked(object sender, EventArgs e)
        {
            chartViewSymptoms.Chart = new RadialGaugeChart { Entries = _viewModel.GetRadialChartData(_viewModel._symptoms) };
            chartViewDisabilities.Chart = new RadialGaugeChart { Entries = _viewModel.GetRadialChartData(_viewModel._disabilities) };
        }

        private async void helpIconTapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HelpPage());
        }
    }
}