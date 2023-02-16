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
    public partial class UpdateGoals : ContentPage
    {
        public UpdateGoals()
        {
            InitializeComponent();
        }

        protected void UpdateClick(object sender, EventArgs e)
        {
            //code to update goal

            DisplayAlert("SUCCESS", "Goal updated", "OK");
            this.Navigation.PushAsync( new Goals());
        }
    }
}