
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Text;
using Android.Views;
using Android.Widget;
using Java.Lang;

namespace ExampleDroid
{
    [Activity(Label = "Passing Data 2")]
    public class PassingData2 : Activity, ITextWatcher
    {

        EditText inputEditText;
        Button saveWordButton;



        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "PassingData2" layout resource
            SetContentView(Resource.Layout.PassingData2);

            inputEditText = FindViewById<EditText>(Resource.Id.editTextPassingData2Input);
            saveWordButton = FindViewById<Button>(Resource.Id.buttonPassingData2SendStringData);
            saveWordButton.Click += SaveWordButton_Click;
            saveWordButton.Enabled = false;
            saveWordButton.Alpha = 0.5f;

            // AddTextChangedListener (ITextWatcher watcher)
            inputEditText.AddTextChangedListener(this);
        }

        void SaveWordButton_Click(object sender, EventArgs e)
        {
            Intent myIntent = new Intent(this, typeof(PassingData));
            myIntent.PutExtra(PassingData.REQUEST_KEY_WORD_OF_THE_DAY, inputEditText.Text);
            SetResult(Result.Ok, myIntent);
            Finish();
        }


        public void AfterTextChanged(IEditable s)
        {
            if (s == null || s.ToString() == "") {
                saveWordButton.Enabled = false;
                saveWordButton.Alpha = 0.5f;
            }
            else {
                saveWordButton.Enabled = true;
                saveWordButton.Alpha = 1.0f;
            }
        }

        public void BeforeTextChanged(ICharSequence s, int start, int count, int after)
        {
            // Intentionally left blank
        }

        public void OnTextChanged(ICharSequence s, int start, int before, int count)
        {
            // Intentionally left blank
        }
    }
}
