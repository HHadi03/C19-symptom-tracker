using System;
using Firebase.Database;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Linq;

namespace ElarosProject
{
    public class databaseConnection
    {
        FirebaseClient fbClient = new FirebaseClient("https://elarosdb-default-rtdb.europe-west1.firebasedatabase.app/"); 


        public async Task<bool> SubmitLogin(Model.LoginModel login)
        {
            var data = await fbClient.Child(nameof(Model.LoginModel)).PostAsync(JsonConvert.SerializeObject(login));
            if (!string.IsNullOrEmpty(data.Key))
            {
                return true;
            }
            return false;
        }

        public async Task<bool> SaveGoals(Model.GoalModel goals)
        {
            var data = await fbClient.Child(nameof(Model.GoalModel)).PostAsync(JsonConvert.SerializeObject(goals));
            if (!string.IsNullOrEmpty(data.Key))
            {
                return true;
            }
            return false;
        }

        public async Task<bool> SaveSymptoms(Model.Symptom userSymptoms)
        {
            var data = await fbClient.Child(nameof(Model.Symptom)).PostAsync(JsonConvert.SerializeObject(userSymptoms));
            if (!string.IsNullOrEmpty(data.Key))
            {
                return true;
            }
            return false;
        }


        public async Task<bool> SaveFatigueTracker(Model.fatigueModel myTracker)
        {
            var data = await fbClient.Child(nameof(Model.fatigueModel)).PostAsync(JsonConvert.SerializeObject(myTracker));
            if (!string.IsNullOrEmpty(data.Key))
            {
                return true;
            }
            return false;
        }

        public async Task<List<Model.fatigueModel>> getEntries()
        {
            return (await fbClient.Child(nameof(Model.fatigueModel)).OnceAsync<Model.fatigueModel>()).Select(item => new Model.fatigueModel
            {
                fatigueLevel = item.Object.fatigueLevel,
                activities = item.Object.activities,
                date = item.Object.date

            }).ToList();
        }
    }
}

