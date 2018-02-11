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

namespace ExampleDroid
{
    [Activity(Label = "Static GridViews")]
    public class StaticGridViews : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "StaticGridViews" layout resource
            SetContentView(Resource.Layout.StaticGridViews);

        }
    }
}
