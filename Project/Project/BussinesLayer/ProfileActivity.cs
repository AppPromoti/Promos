using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Facebook;
using Android.Support.V7.App;
using Java.Lang;
using Xamarin.Facebook.Login.Widget;
using Xamarin.Facebook.Login;
using Project.ModelClasses;
using Newtonsoft.Json;
using static Project.ModelClasses.Helper;


namespace Project.BussinesLayer
{
    [Activity(Label = "ProfileAcrtivity")]
    public class ProfileActivity : AppCompatActivity
    {
        Profile profile;


        private Button mLogOutButton;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            FacebookSdk.SdkInitialize(this.ApplicationContext);

            SetContentView(Resource.Layout.profile_activity);

            

            mLogOutButton = FindViewById<Button>(Resource.Id.logout_button);
            mLogOutButton.Click += LogOutButton_Click;
            
        }

 
        private void LogOutButton_Click(object sender, EventArgs e)
        {
            if (AccessToken.CurrentAccessToken != null)
            {
                LoginManager.Instance.LogOut();
            }
        }
      
    }
}