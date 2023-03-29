using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ElarosProject.View;
using Plugin.FirebasePushNotification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElarosProject.Droid
{
    [Application]
    public class MainApplication : Application
    {
        public MainApplication(IntPtr handle, JniHandleOwnership transer) : base(handle, transer)
        {
        }

        public override void OnCreate()
        {
            base.OnCreate();

            if (Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.O)
            {
                FirebasePushNotificationManager.DefaultNotificationChannelId = "FirebasePushNotificationChannel";

                FirebasePushNotificationManager.DefaultNotificationChannelName = "General";
            }

            
#if DEBUG
            FirebasePushNotificationManager.Initialize(this, true);
#else
            FirebasePushNotificationManager.Initialize(this,false);
#endif

            CrossFirebasePushNotification.Current.OnNotificationReceived += (s, p) =>
            {
               
            };
        }
    }
}