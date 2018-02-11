
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
    [Activity(Label = "Pickers")]
    public class Pickers : Activity, NumberPicker.IOnValueChangeListener
    {

        NumberPicker numberPicker;
        TextView outputTextView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "Toasts" layout resource
            SetContentView(Resource.Layout.Pickers);
            outputTextView = FindViewById<TextView>(Resource.Id.textViewPickersOutput);
            SetupNumberPicker();
        }

        private void SetupNumberPicker()
        {
            numberPicker = FindViewById<NumberPicker>(Resource.Id.npPickersNumberPicker);
            numberPicker.MinValue = 0;
            numberPicker.MaxValue = 100;
            numberPicker.ScrollTo(0,0);
            numberPicker.SetOnValueChangedListener(this);
        }


        public void OnValueChange(NumberPicker picker, int oldVal, int newVal)
        {
            outputTextView.Text = newVal.ToString();
            Toast.MakeText(this, picker.Selected.ToString(), ToastLength.Short);
        }
    }
}
