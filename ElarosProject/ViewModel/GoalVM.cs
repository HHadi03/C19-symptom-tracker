using ElarosProject.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace ElarosProject.ViewModel
{
    public class GoalVM
    {
        public ObservableCollection<GoalModel> GoalList { get; set; }

        public GoalVM()
        {
            GoalList = new ObservableCollection<GoalModel>();
        }

        public ObservableCollection<GoalModel> ReturnGoalList()
        {
            return GoalList;
        }

    }
}
