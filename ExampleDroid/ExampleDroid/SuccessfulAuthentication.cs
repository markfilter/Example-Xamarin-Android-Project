﻿
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

namespace ExampleDroid
{
    [Activity(Label = "SuccessfulAuthentication")]
    public class SuccessfulAuthentication : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "SuccessfulAuthentication" layout resource
            SetContentView(Resource.Layout.SuccessfulAuthentication);
        }
    }
}
