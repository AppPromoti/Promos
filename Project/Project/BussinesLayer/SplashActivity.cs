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
using Android.Support.V7.App;

namespace Project.BussinesLayer
{
    [Activity(Label = "SplashActivity"/*, MainLauncher = true*/)]
    public class SplashActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            //ISharedPreferences pref = Application.Context.GetSharedPreferences(LoginActivity.PREF_NAME, FileCreationMode.Private);
            //string isLogin = pref.GetString(LoginActivity.EDIT_NAME, "");        
            
            //if(isLogin=="YES")
            //{
            //    StartActivity(typeof(MainActivity));
            //    Finish();
            //}else  {
            //    StartActivity(typeof(LoginActivity));
            //    Finish();
            //}
        }
    }
}