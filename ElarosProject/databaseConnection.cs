using System;
using Firebase.Database;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Linq;
using ElarosProject.Model;

namespace ElarosProject
{
    public class databaseConnection
    {
        FirebaseClient fbClient = new FirebaseClient("https://elarosproject-default-rtdb.europe-west1.firebasedatabase.app/"); 


        public async Task<bool> SubmitLogin(Model.LoginModel login)
        {
            var data = await fbClient.Child(nameof(Model.LoginModel)).PostAsync(JsonConvert.SerializeObject(login));
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

        public async Task<bool> SaveGoals(Model.GoalModel goals)
        {
            var data = await fbClient.Child(nameof(Model.GoalModel)).PostAsync(JsonConvert.SerializeObject(goals));
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
                date = item.Object.date,
                userID = item.Object.userID
                
            }).ToList();
        }



        public async Task<List<Model.fatigueModel>> getDescEntries()
        {
            return (await fbClient.Child(nameof(Model.fatigueModel)).OnceAsync<Model.fatigueModel>()).Select(item => new Model.fatigueModel
            {
                fatigueLevel = item.Object.fatigueLevel,
                activities = item.Object.activities,
                date = item.Object.date,
                userID = item.Object.userID

            }).OrderByDescending(level=>level.fatigueLevel).ToList();
        }

        public async Task<List<Model.fatigueModel>> getEntriesByDate()
        {
            return (await fbClient.Child(nameof(Model.fatigueModel)).OnceAsync<Model.fatigueModel>()).Select(item => new Model.fatigueModel
            {
                fatigueLevel = item.Object.fatigueLevel,
                activities = item.Object.activities,
                date = item.Object.date,
                userID = item.Object.userID
            }).OrderBy(level => level.date).ToList();
        }


    }
}

