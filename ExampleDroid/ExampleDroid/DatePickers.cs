
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
    [Activity(Label = "DatePickers")]
    public class DatePickers : Activity
    {
        TextView outputTextView;
        DatePicker datePicker;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "DatePickers" layout resource
            SetContentView(Resource.Layout.DatePickers);
            outputTextView = FindViewById<TextView>(Resource.Id.textViewDatePickersOutput);

            SetupDatePicker();

            FindViewById<Button>(Resource.Id.buttonDatePickersSelectDate).Click += (sender, e) => {
                string dateString = String.Concat(datePicker.Month+1) + "/" + String.Concat(datePicker.DayOfMonth) + "/" + String.Concat(datePicker.Year);
                outputTextView.Text = "Aliens will reveal themselves on " + dateString;
            };
        }

        /// <summary>
        /// Setups the date picker.
        /// </summary>
        private void SetupDatePicker()
        {
            DateTime currently = DateTime.Now;
            datePicker = FindViewById<DatePicker>(Resource.Id.dpDatePickersDatePicker);
            datePicker.MinDate = (long)currently.ToUniversalTime().Subtract(DateTime.MinValue.AddYears(1969)).TotalMilliseconds;
        }


    }
}
