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
using Firebase.Auth;

namespace ElarosProject.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DataVisualization : ContentPage
    {
        public DataVisualizationViewModel _viewModel;
        public AssessmentVM _assessmentVM = Application.Current.Properties["_assessmentVM"] as AssessmentVM;
        public ObservableCollection<AssessmentModel> specificAssessmentResults;
        public LoginModel currentUser = Application.Current.Properties["currentUser"] as LoginModel;
        public ObservableCollection<DataVisualizationModel> symptomLabels;
        public ObservableCollection<DataVisualizationModel> disabilityLabels;
        public string currentId;

        public DataVisualization()
        {
            InitializeComponent();

            currentId = currentUser.GetUserID();
            specificAssessmentResults = _assessmentVM.SpecificAssessmentResults(currentId);

            _viewModel = new DataVisualizationViewModel();
            symptomLabels = _viewModel.BuildSymptomLabel(specificAssessmentResults);
            disabilityLabels = _viewModel.BuildDisabilityLabel(specificAssessmentResults);
            _viewModel._userSymptomsBar = _viewModel.BuildSymptomDataBar(specificAssessmentResults);
            _viewModel._userDisabilitiesBar = _viewModel.BuildDisabilityDataBar(specificAssessmentResults);
            _viewModel._userSymptoms = _viewModel.BuildSymptomData(specificAssessmentResults);
            _viewModel._userDisabilities = _viewModel.BuildDisabilityData(specificAssessmentResults);

            symptomListView.BindingContext = symptomLabels;
            disabilityListView.BindingContext = disabilityLabels;

            if (_viewModel._userSymptoms.Count() == 0 && _viewModel._userSymptomsBar.Count() == 0)
            {
                symptomLabel.IsVisible = true;
                symptomFrame.HeightRequest = 25;
                chartViewSymptoms.IsVisible = false;
                chartViewSymptoms.HeightRequest = 80;
            }

            if (_viewModel._userDisabilities.Count() == 0 && _viewModel._userDisabilitiesBar.Count() == 0)
            {
                disabilityLabel.IsVisible = true;
                disabilityFrame.HeightRequest = 25;
                chartViewDisabilities.IsVisible = false;
                chartViewDisabilities.HeightRequest = 80;
            }

            if (_viewModel._userSymptoms.Count() > 5)
            {
                chartViewSymptoms.Chart = new RadialGaugeChart
                {
                    Entries = _viewModel._userSymptoms,
                    MaxValue = 10,
                    MinValue = 1,
                    LabelTextSize = 30f,
                    IsAnimated = true,
                    LineSize = 20
                };
            }
            else
            {
                chartViewSymptoms.Chart = new RadialGaugeChart
                {
                    Entries = _viewModel._userSymptoms,
                    MaxValue = 10,
                    MinValue = 1,
                    LabelTextSize = 30f,
                    IsAnimated = true,
                    LineSize = 30
                };
            }
            
            chartViewDisabilities.Chart = new RadialGaugeChart
            {
                Entries = _viewModel._userDisabilities,
                MaxValue = 10,
                MinValue = 1,
                LabelTextSize = 30f,
                IsAnimated = true,
                LineSize = 30
            };
        }

        private void BarChartClicked(object sender, EventArgs e)
        {
            chartViewSymptoms.Chart = new BarChart
            {
                Entries = _viewModel._userSymptomsBar,
                LabelTextSize = 30f,
                ValueLabelOrientation = Orientation.Horizontal,
                LabelOrientation = Orientation.Horizontal,
                LabelColor = SKColor.Parse("#000")
            };

            chartViewDisabilities.Chart = new BarChart
            {
                Entries = _viewModel._userDisabilitiesBar,
                LabelTextSize = 30f,
                ValueLabelOrientation = Orientation.Horizontal,
                LabelOrientation = Orientation.Horizontal,
                LabelColor = SKColor.Parse("#000"),
            };

        }

        private void RadarChartClicked(object sender, EventArgs e)
        {
            chartViewSymptoms.Chart = new RadarChart
            {
                Entries = _viewModel._userSymptoms,
                LabelTextSize = 30f,
                LineSize = 10,
                PointSize = 3
            };

            chartViewDisabilities.Chart = new RadarChart
            {
                Entries = _viewModel._userDisabilities,
                LabelTextSize = 30f,
                LineSize = 10,
                PointSize = 3
            };
        }

        private void RadialChartClicked(object sender, EventArgs e)
        {
            if (_viewModel._userSymptoms.Count() > 5)
            {
                chartViewSymptoms.Chart = new RadialGaugeChart
                {
                    Entries = _viewModel._userSymptoms,
                    MaxValue = 10,
                    MinValue = 1,
                    LabelTextSize = 30f,
                    IsAnimated = true,
                    LineSize = 20
                };
            }
            else
            {
                chartViewSymptoms.Chart = new RadialGaugeChart
                {
                    Entries = _viewModel._userSymptoms,
                    MaxValue = 10,
                    MinValue = 1,
                    LabelTextSize = 30f,
                    IsAnimated = true,
                    LineSize = 30
                };
            }

            chartViewDisabilities.Chart = new RadialGaugeChart
            {
                Entries = _viewModel._userDisabilities,
                MaxValue = 10,
                MinValue = 1,
                LabelTextSize = 30f,
                LineSize = 30,
            };
        }

        private async void helpIconTapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HelpPage());
        }

        async void LogoutClick(object sender, EventArgs e)
        {
            bool response = await DisplayAlert("Logout", "Do you want to logout?", "Yes", "No");

            if (response)
            {
                var authProvider = Application.Current.Properties["LoginState"] as FirebaseAuthClient;
                authProvider.SignOut();
                currentUser = null;
                await Navigation.PushAsync(new LoginPage());
            }
        }
    }
}