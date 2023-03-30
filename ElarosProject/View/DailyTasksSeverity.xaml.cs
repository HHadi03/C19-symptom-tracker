using ElarosProject.Model;
using ElarosProject.ViewModel;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ElarosProject.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DailyTasksSeverity : ContentPage
	{
        private int selectedSeverity;
        private TaskCompletionSource<bool> inputValidatedTaskCompleted;
        private AssessmentVM _assessmentVM = Application.Current.Properties["_assessmentVM"] as AssessmentVM;
        private LoginModel currentUser = Application.Current.Properties["currentUser"] as LoginModel;
        databaseConnection myConnection = new databaseConnection();

        public DailyTasksSeverity ()
		{
			InitializeComponent ();
            inputValidatedTaskCompleted = new TaskCompletionSource<bool>();
            UpdateProgressBar();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            UpdateProgressBar();
        }

        private void DailyTasksPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            selectedSeverity = picker.SelectedIndex + 1;
        }

        private async void SubmitButtonClicked(object sender, EventArgs e)
        {
            if (selectedSeverity >= 1 && selectedSeverity <= 10)
            {
                AssessmentModel symptom = new AssessmentModel(currentUser.GetUserID(), "Daily tasks", selectedSeverity, DateTime.Now.ToString("dd/MM/yy"));

                _assessmentVM.AssessmentResults.Add(symptom);
                await myConnection.SaveSymptoms(symptom);

                AssessmentModel.completedPages++;
                UpdateProgressBar();

                await DisplayAlert("Submitted", "Your selection has been saved", "OK");
                inputValidatedTaskCompleted.SetResult(true);
            }
            else
            {
                await DisplayAlert("Invalid Selection", "Please select a severity between 1 and 10.", "OK");
            }
        }

        public async Task WaitForInputValidationAsync()
        {
            await inputValidatedTaskCompleted.Task;
        }

        private void UpdateProgressBar()
        {
            double progress = (double)AssessmentModel.completedPages / 12;
            //progressBar.Progress = progress;

            progressLabel.Text = $"{AssessmentModel.completedPages} Symptoms Selected";
        }
    }
}