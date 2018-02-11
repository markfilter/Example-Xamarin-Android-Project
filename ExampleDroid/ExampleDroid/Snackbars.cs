
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
using Android.Support.Design.Widget;

namespace ExampleDroid
{
    [Activity(Label = "Snackbars")]
    public class Snackbars : AppCompatActivity
    {
        CoordinatorLayout myCoordinatorLayout;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "Snackbars" layout resource
            SetContentView(Resource.Layout.Snackbars);
            myCoordinatorLayout = FindViewById<CoordinatorLayout>(Resource.Id.myCoordinatorLayout);
            Button displaySnackbarButton = FindViewById<Button>(Resource.Id.buttonSnackbarsDisplaySnackbar);
            displaySnackbarButton.Click += DisplaySnackBar;
        }

        private void DisplaySnackBar(Object sender, EventArgs e) {
            
            // Intermittent Crash: Java.Lang.ClassCastException has been thrown
            // android.support.design.widget.Snackbar$SnackbarLayout cannot be cast to 
            // android.support.design.internal.SnackbarContentLayout

            try {
                Snackbar.Make(myCoordinatorLayout, "You have a message", Snackbar.LengthLong)
                .SetAction("Read Message", delegate {
                    TextView outputTextView = FindViewById<TextView>(Resource.Id.textViewSnackbarsOutput);
                    outputTextView.Text = "Follow the white rabbit.";
                })
                .Show();
            } catch (Java.Lang.ClassCastException exception) {
                var alertDialog = new Android.App.AlertDialog.Builder(this);

                alertDialog.SetMessage(exception.Message);
                alertDialog.SetPositiveButton("OK", delegate {});

                alertDialog.Show();
            }
             
        }
    }
}
