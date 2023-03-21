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
        databaseConnection myConnection = new databaseConnection();

        public GoalVM()
        {
            GoalList = new ObservableCollection<GoalModel>();
            BuildGoalList();
        }

        public async void BuildGoalList()
        {
            List<GoalModel> GoalInfo = await myConnection.GetGoals();

            foreach (var entry in GoalInfo)
            {
                GoalList.Add(entry);
            }
        }

        public ObservableCollection<GoalModel> ReturnGoalList()
        {
            return GoalList;
        }

    }
}
