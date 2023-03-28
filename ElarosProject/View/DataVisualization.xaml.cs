using ElarosProject.ViewModel;
using Microcharts;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElarosProject.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ElarosProject.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DataVisualization : ContentPage
    {
        public DataVisualizationViewModel _viewModel;
        public AssessmentVM _assessmentVM = Application.Current.Properties["_assessmentVM"] as AssessmentVM;
        public ObservableCollection<AssessmentModel> specificAssessmentResults;
        public LoginModel currentUser = Application.Current.Properties["currentUser"] as LoginModel;
        public string currentId;

        public DataVisualization()
        {
            InitializeComponent();

            currentId = currentUser.GetUserID();
            specificAssessmentResults = _assessmentVM.SpecificAssessmentResults(currentId);

            _viewModel = new DataVisualizationViewModel();
            _viewModel._userSymptoms = _viewModel.BuildSymptomData(specificAssessmentResults);
            _viewModel._userDisabilities = _viewModel.BuildDisabilityData(specificAssessmentResults);

            chartViewSymptoms.Chart = new BarChart 
            { 
                Entries = _viewModel._userSymptoms
            };

            chartViewDisabilities.Chart = new BarChart
            {
                Entries = _viewModel._userDisabilities
            };
        }

        private void BarChartClicked(object sender, EventArgs e)
        {
            chartViewSymptoms.Chart = new BarChart 
            { 
                Entries = _viewModel._userSymptoms
            };

            chartViewDisabilities.Chart = new BarChart
            {
                Entries = _viewModel._userDisabilities
            };

        }

        private void RadarChartClicked(object sender, EventArgs e)
        {
            chartViewSymptoms.Chart = new RadarChart 
            { 
                Entries = _viewModel._userSymptoms
            };

            chartViewDisabilities.Chart = new RadarChart
            {
                Entries = _viewModel._userDisabilities
            };
        }

        private void RadialChartClicked(object sender, EventArgs e)
        {
            chartViewSymptoms.Chart = new RadialGaugeChart 
            { 
                Entries = _viewModel._userSymptoms
            };

            chartViewDisabilities.Chart = new RadialGaugeChart
            {
                Entries = _viewModel._userDisabilities
            };
        }

        private async void helpIconTapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HelpPage());
        }
    }
}