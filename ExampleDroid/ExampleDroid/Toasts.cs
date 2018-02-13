
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
    [Activity(Label = "Toasts")]
    public class Toasts : AppCompatActivity
    {
        Toast toast;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "Toasts" layout resource
            SetContentView(Resource.Layout.Toasts);

            Button shortToastButton = FindViewById<Button>(Resource.Id.buttonToastsShort);
            Button longToastButton = FindViewById<Button>(Resource.Id.buttonToastsLong);

            // Sets handler methods for buttons
            shortToastButton.Click += DisplayShortToast;
            longToastButton.Click += DisplayLongToast;
        }

        /// <summary>
        /// Displaies the short toast.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        private void DisplayShortToast(Object sender, EventArgs e)
        {
            if (toast != null)
            {
                toast.Cancel();
            }
            toast = Toast.MakeText(this, "Short Toast", ToastLength.Short);
            toast.Show();
        }

        /// <summary>
        /// Displaies the long toast.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        private void DisplayLongToast(Object sender, EventArgs e)
        {
            if (toast != null)
            {
                toast.Cancel();
            }
            toast = Toast.MakeText(this, "Long Toast", ToastLength.Long);
            toast.Show();
        }
    }
}
