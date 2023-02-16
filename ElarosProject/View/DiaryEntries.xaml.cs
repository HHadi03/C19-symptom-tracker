using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace ElarosProject.Views
{
    public partial class DiaryEntries : ContentPage
    {
        public DiaryEntries()
        {
            InitializeComponent();
            BindingContext = new ViewModels.DiaryViewModel();
           
        }

       

    }
}

