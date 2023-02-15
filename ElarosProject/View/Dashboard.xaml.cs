﻿using ElarosProject.Model;
using ElarosProject.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ElarosProject.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Dashboard : TabbedPage
    {
        private ObservableCollection<AssessmentModel> specificAssessmentResults;
        private AssessmentVM _assessmentVM;
        private LoginModel currentUser;
        private int currentId;

        public Dashboard(LoginModel user, AssessmentVM assessmentVM)
        {
            InitializeComponent();

            // Set current user and their ID
            currentUser = user;
            currentId = currentUser.GetUserID();

            // Uses persisted AssessmentVM to calculate new AssessmentResults collection for specific user
            _assessmentVM = assessmentVM;
            BindingContext = _assessmentVM;
            specificAssessmentResults = _assessmentVM.SpecificAssessmentResults(currentId);
            BindingContext = specificAssessmentResults;
            
            // Display welcome to user
            WelcomeLabel.Text = "Welcome " + user.GetUsername() + "!";
        }
    }
}