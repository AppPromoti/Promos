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

namespace Project.ModelClasses
{
    class UserClass
    {
        public string ID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public byte[] Salt { get; set; }
        public string Email { get; set; }
    }
}