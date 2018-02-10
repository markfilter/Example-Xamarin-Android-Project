
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
    [Activity(Label = "Progress Bars")]
    public class ProgressIndicator : Activity
    {
        ProgressBar horizontalProgressBar;
        ProgressBar largeProgressIndicator;
        ProgressBar normalProgressIndicator;
        ProgressBar smallProgressIndicator;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.ProgressIndicator);

            // Initialize Progress Bars
            horizontalProgressBar = FindViewById<ProgressBar>(Resource.Id.progressBarHorizontal);
            largeProgressIndicator = FindViewById<ProgressBar>(Resource.Id.progressBarLarge);
            normalProgressIndicator = FindViewById<ProgressBar>(Resource.Id.progressBarNormal);
            smallProgressIndicator = FindViewById<ProgressBar>(Resource.Id.progressBarSmall);

            // Stop Animation
            StopIndefiniteAnimation();

            // Start Animation
            StartIndefiniteAnimation();

            // Setup Buttons
            Button startAnimationButton = FindViewById<Button>(Resource.Id.buttonStart);
            Button stopAnimationButton = FindViewById<Button>(Resource.Id.buttonStop);
            Button progressDialogButton = FindViewById<Button>(Resource.Id.buttonProgressDialog);

            startAnimationButton.Click += delegate {
                StartIndefiniteAnimation();
            }; 

            stopAnimationButton.Click += delegate {
                StopIndefiniteAnimation();
            }; 

            progressDialogButton.Click += delegate {
                Toast.MakeText(this, "Progress Dialog not yet implemented", ToastLength.Short).Show();
            }; 

        }

        private void StopIndefiniteAnimation()
        {
            horizontalProgressBar.Visibility = ViewStates.Invisible;
            largeProgressIndicator.Visibility = ViewStates.Invisible;
            normalProgressIndicator.Visibility = ViewStates.Invisible;
            smallProgressIndicator.Visibility = ViewStates.Invisible;
        }

        private void StartIndefiniteAnimation()
        {
            
            horizontalProgressBar.Visibility = ViewStates.Visible;
            largeProgressIndicator.Visibility = ViewStates.Visible;
            normalProgressIndicator.Visibility = ViewStates.Visible;
            smallProgressIndicator.Visibility = ViewStates.Visible;
        }
    }
}
