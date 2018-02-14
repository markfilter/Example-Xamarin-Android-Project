
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android;
using Android.App;
using Android.Content;
using Android.Hardware.Fingerprints;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V4.App;
using Android.Support.V4.Content;
using Android.Support.V4.Hardware.Fingerprint;
using Android.Util;
using Android.Views;
using Android.Widget;
using Android.Support.V7.App;
using Android.Preferences;

namespace ExampleDroid
{
    [Activity(Label = "FingerprintAuthorization")]
    public class FingerprintAuthorization : AppCompatActivity
    {

        // Setup
        // An Android application must request the USE_FINGERPRINT permission in the manifest. 

        ISharedPreferences sharedPreferences;
        FingerprintManagerCompat fingerprintManagerCompat;
        Android.Support.V4.OS.CancellationSignal cancelationSignal;
        TextView fingerprintStatusTextView;
        Button buttonAuthenticate;
        Button buttonReset;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "FingerprintAuthorization" layout resource
            SetContentView(Resource.Layout.FingerprintAuthorization);

            sharedPreferences = PreferenceManager.GetDefaultSharedPreferences(this);
            fingerprintManagerCompat = FingerprintManagerCompat.From(this);
            cancelationSignal = new Android.Support.V4.OS.CancellationSignal();

            fingerprintStatusTextView = FindViewById<TextView>(Resource.Id.tvFingerprintStatusTextView);
            buttonAuthenticate = FindViewById<Button>(Resource.Id.buttonFingerPrintAuthenticate);
            buttonReset = FindViewById<Button>(Resource.Id.buttonFingerPrintReset);
            FindViewById<ProgressBar>(Resource.Id.pbFingerprintAuthenticationProgressBar).Visibility = ViewStates.Invisible;

            buttonAuthenticate.Click += (sender, e) => {
                // Implementation
                FindViewById<ProgressBar>(Resource.Id.pbFingerprintAuthenticationProgressBar).Visibility = ViewStates.Visible;

                if (CanUseFingerprintBiometric()) {
                    LogUserIn();
                }
                else 
                {
                    FindViewById<ProgressBar>(Resource.Id.pbFingerprintAuthenticationProgressBar).Visibility = ViewStates.Invisible;
                    Toast.MakeText(this, "This device is not configured for Fingerprint Biometrics", ToastLength.Long).Show();
                }

            };

            buttonReset.Click += (sender, e) => {
                // Implementation
                FindViewById<ProgressBar>(Resource.Id.pbFingerprintAuthenticationProgressBar).Visibility = ViewStates.Invisible;
                fingerprintStatusTextView.Text = "You Must Authenticate";
            };

        }

        private void LogUserIn()
        {
            fingerprintStatusTextView.Text = "Authenticating...";
            FingerprintManagerCompat.AuthenticationCallback authenticationCallback = new AuthenticationCallback(this, "user321032");
            fingerprintManagerCompat.Authenticate(null, 0, cancelationSignal, authenticationCallback, null);
        }

        private bool CanUseFingerprintBiometric()
        {
            if (fingerprintManagerCompat.IsHardwareDetected) {
                if (fingerprintManagerCompat.HasEnrolledFingerprints) 
                {
                    var permissionResult = ContextCompat.CheckSelfPermission(this, Manifest.Permission.UseFingerprint);
                    if (permissionResult == Android.Content.PM.Permission.Granted) 
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else 
                {
                    return false;    
                }
            }
            else 
            {
                return false;
            }
        }
    }

    class AuthenticationCallback : FingerprintManagerCompat.AuthenticationCallback 
    {
        Activity activity;
        string userId;

        public AuthenticationCallback(Activity activity, string userId) 
        {
            this.activity = activity;
            this.userId = userId;
        }

        public override void OnAuthenticationSucceeded(FingerprintManagerCompat.AuthenticationResult result)
        {
            base.OnAuthenticationSucceeded(result);
            this.activity.FindViewById<ProgressBar>(Resource.Id.pbFingerprintAuthenticationProgressBar).Visibility = ViewStates.Invisible;
            this.activity.FindViewById<TextView>(Resource.Id.tvFingerprintStatusTextView).Text = "You are signed in.";
            Intent intent = new Intent(activity, typeof(SuccessfulAuthentication));
            intent.PutExtra("userId", this.userId);
            this.activity.StartActivity(intent);
        }

        public override void OnAuthenticationFailed()
        {
            base.OnAuthenticationFailed();
            Toast.MakeText(activity, "Authentication failed", ToastLength.Long).Show();
        }

    }
}
