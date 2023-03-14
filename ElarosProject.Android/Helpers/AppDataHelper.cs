using Android.App;
using Android.Content;
using Android.Gms.Common.Data;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Firebase;
using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElarosProject.Droid.Helpers
{
    public static class AppDataHelper
    {
        public static FirebaseDatabase GetDatabase()
        {
            var app = FirebaseApp.InitializeApp(Application.Context);
            FirebaseDatabase database;

            if (app == null)
            {
                var option = new FirebaseOptions.Builder()
                    .SetApplicationId("elarosdb")
                    .SetApiKey("AIzaSyAnwLkBWEJDsJwmgs_1Hkpg7ydKW9T5rRM")
                    .SetDatabaseUrl("https://elarosdb-default-rtdb.europe-west1.firebasedatabase.app")
                    .SetStorageBucket("elarosdb.appspot.com")
                    .Build();

                app = FirebaseApp.InitializeApp(Application.Context, option);
                database = FirebaseDatabase.GetInstance(app);
            }

            else
            {
                database = FirebaseDatabase.GetInstance(app);
            }

            return database;
        }
    }
}