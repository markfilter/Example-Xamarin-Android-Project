
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
        private int progressBarStatus = 0;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "ProgressIndicator" layout resource
            SetContentView(Resource.Layout.ProgressIndicator);

            // Initialize Progress Bars
            horizontalProgressBar = FindViewById<ProgressBar>(Resource.Id.progressBarHorizontal);
            largeProgressIndicator = FindViewById<ProgressBar>(Resource.Id.progressBarLarge);
            normalProgressIndicator = FindViewById<ProgressBar>(Resource.Id.progressBarNormal);
            smallProgressIndicator = FindViewById<ProgressBar>(Resource.Id.progressBarSmall);
            horizontalProgressBar.Visibility = ViewStates.Invisible;
            largeProgressIndicator.Visibility = ViewStates.Invisible;
            normalProgressIndicator.Visibility = ViewStates.Invisible;
            smallProgressIndicator.Visibility = ViewStates.Invisible;

            // Setup Buttons
            Button startAnimationButton = FindViewById<Button>(Resource.Id.buttonStart);
            Button stopAnimationButton = FindViewById<Button>(Resource.Id.buttonStop);
            Button progressDialogButton = FindViewById<Button>(Resource.Id.buttonProgressDialog);

            // Start Indefinite Animation
            startAnimationButton.Click += StartIndefiniteAnimation;

            // Stop Indefinite Animation
            stopAnimationButton.Click += StopIndefiniteAnimation;

            // Progress Dialog
            progressDialogButton.Click += DisplayProgressDialog;
        }

        private void StopIndefiniteAnimation(Object sender, EventArgs e)
        {
            horizontalProgressBar.Visibility = ViewStates.Invisible;
            largeProgressIndicator.Visibility = ViewStates.Invisible;
            normalProgressIndicator.Visibility = ViewStates.Invisible;
            smallProgressIndicator.Visibility = ViewStates.Invisible;
        }

        private void StartIndefiniteAnimation(Object sender, EventArgs e)
        {
            
            horizontalProgressBar.Visibility = ViewStates.Visible;
            largeProgressIndicator.Visibility = ViewStates.Visible;
            normalProgressIndicator.Visibility = ViewStates.Visible;
            smallProgressIndicator.Visibility = ViewStates.Visible;
        }

        private void DisplayProgressDialog(Object sender, EventArgs e)
        {
            ProgressDialog progressDialog = new ProgressDialog(this);
            progressDialog.SetMessage("You are downloading the Internet");
            progressDialog.SetProgressStyle(ProgressDialogStyle.Horizontal);
            progressDialog.Progress = 0;
            progressDialog.Max = 100;
            progressDialog.SetCancelable(true);
            progressDialog.Show();

            progressBarStatus = 0;

            new Thread(new ThreadStart(delegate {
                while(progressBarStatus < 100) 
                {
                    progressBarStatus += 10;
                    progressDialog.Progress = progressBarStatus;
                    Thread.Sleep(500);
                }
                progressDialog.Dismiss();

                RunOnUiThread(() => {
                    Toast.MakeText(this, "Internet Download Complete", ToastLength.Short).Show();
                });
            })).Start();// using System.Threading
        }

    }
}
