using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ElarosProject.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class VoiceSeverity : ContentPage
	{
        private int selectedSeverity;
        private TaskCompletionSource<bool> inputValidatedTaskCompleted;
        public VoiceSeverity ()
		{
			InitializeComponent ();
            inputValidatedTaskCompleted = new TaskCompletionSource<bool>();
        }

        private void VoicePicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            selectedSeverity = picker.SelectedIndex + 1;
        }

        private async void SubmitButtonClicked(object sender, EventArgs e)
        {
            if (selectedSeverity >= 1 && selectedSeverity <= 10)
            {
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
    }
}