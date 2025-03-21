using System;
using Firebase.Database;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Linq;
using ElarosProject.Model;
using Firebase.Database.Query;
using ElarosProject.View;


namespace ElarosProject
{
    public class databaseConnection
    {
        FirebaseClient fbClient = new FirebaseClient("https://elarosdb-default-rtdb.europe-west1.firebasedatabase.app/",
                                  new FirebaseOptions 
                                  { 
                                      AuthTokenAsyncFactory = () => Task.FromResult() 
                                  });

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

        public async Task<bool> SaveGoals(Model.GoalModel goals, string goalKey)
        {
            var data = await fbClient.Child("User Goals").Child(goalKey).PostAsync(JsonConvert.SerializeObject(goals), false);
            if (!string.IsNullOrEmpty(data.Key))
            {
                return true;
            }
            return false;
        }

        public async Task<List<GoalModel>> GetGoals()
        {
            return (await fbClient.Child("User Goals").OnceAsync<GoalModel>()).Select(item => new GoalModel
            {
                Name = item.Object.Name,
                GoalSymptom = item.Object.GoalSymptom,
                SeverityLevel = item.Object.SeverityLevel,
                StartDate = item.Object.StartDate,
                TargetDate = item.Object.TargetDate,
                UserID = item.Object.UserID
            }).ToList();
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
            var data = await fbClient.Child(nameof(fatigueModel)).PostAsync(JsonConvert.SerializeObject(myTracker));
            if (!string.IsNullOrEmpty(data.Key))
            {
                return true;
            }
            return false;
        }

     
        public async Task<List<fatigueModel>> getEntries(string userID) 
        {
            return (await fbClient.Child("fatigueModel").OnceAsync<fatigueModel>()).Select(item => new Model.fatigueModel
            {
                fatigueLevel = item.Object.fatigueLevel,
                activities = item.Object.activities,
                date = item.Object.date,
                userID = item.Object.userID

            }).Where(result=> result.userID == userID).ToList();
        }

        
        public async Task<List<fatigueModel>> getDescEntries(string userID) //test method 
        {
            return (await fbClient.Child("fatigueModel").OnceAsync<Model.fatigueModel>()).Select(item => new Model.fatigueModel
            {
                fatigueLevel = item.Object.fatigueLevel,
                activities = item.Object.activities,
                date = item.Object.date,
                userID = item.Object.userID

            }).Where(result => result.userID == userID).OrderByDescending(level => level.fatigueLevel).ToList();
        }


        public async Task<List<fatigueModel>> getEntriesByDate() //check how to display
        {
            return (await fbClient.Child(nameof(fatigueModel)).OnceAsync<fatigueModel>()).Select(item => new Model.fatigueModel
            {
                fatigueLevel = item.Object.fatigueLevel,
                activities = item.Object.activities,
                date = item.Object.date,
                userID = item.Object.userID
            }).OrderBy(level => level.date).ToList();
        }

        public async Task<bool> SaveUpdatedSymptoms(AssessmentModel updateSymptom)
        {
            var data = await fbClient.Child("User Symptoms").PostAsync(JsonConvert.SerializeObject(updateSymptom));
            if (!string.IsNullOrEmpty(data.Key))
            {
                return true;
            }
            return false;
        }

        public async Task<List<AssessmentModel>> getUpdatedSymptom() //method to get all users' symptoms and sort by descending date 
        {
            return (await fbClient.Child("User Symptoms").OnceAsync<AssessmentModel>()).Select(item => new AssessmentModel
            {
                DateLogged = item.Object.DateLogged,
                Severity = item.Object.Severity,
                Symptom = item.Object.Symptom,
                User = item.Object.User,
                updatedSeverity=item.Object.updatedSeverity
            }).OrderByDescending(date => date.DateLogged).ToList();
        }
    }
}
