using ElarosProject.Model;
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
    public partial class Goals : ContentPage
    {

        public Goals()
        {
            InitializeComponent();
        }

        protected void NewGoalClick(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new NewGoal());
        }

        protected void UpdateGoalClick(object sender, EventArgs e)
        {
             bool HasGoals = false;

            // code to search if goal have been created

            if(HasGoals == false)
            {
                DisplayAlert("Error", "You have no set goals", "OK");
            }
            else
            {
                this.Navigation.PushAsync(new UpdateGoals());
            }
        }

        protected void ViewGoalClick(object sender, EventArgs e)
        {
            bool HasGoals = false;

            // code to search if goal have been created

            if (HasGoals == false)
            {
                DisplayAlert("Error", "You have no set goals", "OK");
            }
            else 
            {
                this.Navigation.PushAsync(new ViewGoals());
            }
        }
    }
}