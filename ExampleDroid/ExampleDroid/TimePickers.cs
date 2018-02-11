
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
    [Activity(Label = "Time Pickers")]
    public class TimePickers : Activity
    {

        TimePicker timePicker;
        TextView outputTextView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "Time Pickers" layout resource
            SetContentView(Resource.Layout.TimePickers);
            outputTextView = FindViewById<TextView>(Resource.Id.textViewTimePickersOutput);

            SetupTimePicker();


            FindViewById<Button>(Resource.Id.buttonTimePickersSetTime).Click += (sender, e) => {
                string timeString = String.Concat(timePicker.Hour) + ":" + String.Concat(timePicker.Minute);
                outputTextView.Text = "My brain turns on at " + timeString;
            };
        }

        /// <summary>
        /// Setups the time picker.
        /// </summary>
        private void SetupTimePicker()
        {
            timePicker = FindViewById<TimePicker>(Resource.Id.tpTimePickersTimePicker);
        }
    }
}
