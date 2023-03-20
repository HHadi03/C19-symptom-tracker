using System;
using Firebase.Database;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Linq;
using ElarosProject.Model;
using Xamarin.Essentials;

namespace ElarosProject
{
    public class databaseConnection
    {
        FirebaseClient fbClient = new FirebaseClient("https://elarosdb-default-rtdb.europe-west1.firebasedatabase.app/"); 


        public async Task<bool> SubmitLogin(LoginModel login)
        {
            var data = await fbClient.Child("Login Info").PostAsync(JsonConvert.SerializeObject(login));
            if (!string.IsNullOrEmpty(data.Key))
            {
                return true;
            }
            return false;
        }

        public async Task<List<LoginModel>> GetLogin()
        {
            return (await fbClient.Child("Login Info").OnceAsync<LoginModel>()).Select(item => new LoginModel
            {
                Email = item.Object.Email,
                Password = item.Object.Password,
                Username = item.Object.Username,
                UserID = item.Object.UserID
            }).ToList();
        }

        public async Task<bool> SaveGoals(GoalModel goals)
        {
            var data = await fbClient.Child("Goals").PostAsync(JsonConvert.SerializeObject(goals));
            if (!string.IsNullOrEmpty(data.Key))
            {
                return true;
            }
            return false;
        }

        public async Task<bool> SaveSymptoms(AssessmentModel userSymptom)
        {
            var data = await fbClient.Child("User Symptoms").PostAsync(JsonConvert.SerializeObject(userSymptom));
            if (!string.IsNullOrEmpty(data.Key))
            {
                return true;
            }
            return false;
        }

        public async Task<List<AssessmentModel>> GetSymptoms()
        {
            return (await fbClient.Child("User Symptoms").OnceAsync<AssessmentModel>()).Select(item => new AssessmentModel
            { 
                DateLogged = item.Object.DateLogged, 
                Severity = item.Object.Severity, 
                Symptom = item.Object.Symptom, 
                User = item.Object.User 
            }).ToList();
        }

        public async Task<bool> SaveFatigueTracker(fatigueModel myTracker)
        {
            var data = await fbClient.Child("Fatigue Diary").PostAsync(JsonConvert.SerializeObject(myTracker));
            if (!string.IsNullOrEmpty(data.Key))
            {
                return true;
            }
            return false;
        }

        public async Task<List<fatigueModel>> getEntries()
        {
            return (await fbClient.Child("Fatigue Diary").OnceAsync<fatigueModel>()).Select(item => new fatigueModel
            {
                fatigueLevel = item.Object.fatigueLevel,
                activities = item.Object.activities,
                date = item.Object.date

            }).ToList();
        }
    }
}

