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
using Java.Lang;
using Org.Json;
using Android.Support.V7.App;
using Project.ModelClasses;
using Newtonsoft.Json;
using Android.Util;
using PCLCrypto;
using Java.Util;

namespace Project.BussinesLayer
{
    [Activity(Label = "Регистрация", Icon = "@drawable/icon", MainLauncher = true)]
    public class RegisterActivity : AppCompatActivity
    {
        private ISharedPreferences mPref;
        private ISharedPreferencesEditor mEdit;

        private EditText mUserNameEdit;
        private EditText mPasswordEdit;
        private EditText mEmailEdit;
        private Button mRegButton;

        private string mUsername;
        private string mPassword;
        private string mEmail;

        private List<UserClass> mUsers = new List<UserClass>();
        private UserClass mUser = new UserClass();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            this.Window.SetFlags(WindowManagerFlags.Fullscreen, WindowManagerFlags.Fullscreen);

            SetContentView(Resource.Layout.register_activity);

            //mPref = GetSharedPreferences(PREF_NAME_LOGIN, FileCreationMode.Private);
            //mEdit = mPref.Edit();

            mUserNameEdit = FindViewById<EditText>(Resource.Id.edit_user_name);
            mPasswordEdit = FindViewById<EditText>(Resource.Id.edit_password);
            mEmailEdit = FindViewById<EditText>(Resource.Id.eidt_email);

            mRegButton = FindViewById<Button>(Resource.Id.register_button);
            mRegButton.Click += MRegButton_Click;
        }

        protected bool EmailChaeck(string email)
        {
            return Patterns.EmailAddress.Matcher(email).Matches();
        }


        private void MRegButton_Click(object sender, EventArgs e)
        {
            mUsername = mUserNameEdit.Text.Trim();
            mPassword = mPasswordEdit.Text.Trim();
            mEmail = mEmailEdit.Text.Trim();

            if (mUsername != string.Empty && mPassword != string.Empty && mEmail != string.Empty && EmailChaeck(mEmail))
            {
                mUser.ID = UUID.RandomUUID().ToString();
                mUser.UserName = mUsername;
                mUser.Email = mEmail;
                mUser.Password = GetSaltedPass(mPassword);
                mUsers.Add(mUser);

                var dialog = new Android.App.AlertDialog.Builder(this, Resource.Style.AlertDialogCustom)
                .SetTitle("Успешна Регистрация!")
                .SetMessage("Поздравленя, Вие, се регистрирахте успешно.")
                .SetNeutralButton("Напред", (send, args) =>
                {
                    StartActivity(typeof(MainActivity));
                    Finish();
                })
                .Show();
            }
            else
            {
                var dialog = new Android.App.AlertDialog.Builder(this, Resource.Style.AlertDialogCustom)
                .SetTitle("Моля попълнете всички полета!")               
                .SetNeutralButton("ОК", (send, args) =>
                {                   
                })
                .Show();
            }
        }

        private string GetSaltedPass(string pass)
        {
            byte[] salt = GetSalt();
            mUser.Salt = salt;
            int iterations = 5000;
            int keyLengthBytes = 25;
            byte[] key = NetFxCrypto.DeriveBytes.GetBytes(pass, salt, iterations, keyLengthBytes);
            return Convert.ToBase64String(key);
        }

        private byte[] GetSalt()
        {
            byte[] salt = new byte[16];
            NetFxCrypto.RandomNumberGenerator.GetBytes(salt);
            return salt;
        }
    }
}