
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
    [Activity(Label = "Passing Data")]
    public class PassingData : AppCompatActivity
    {

        TextView outputTextView;
        public static int REQUEST_CODE_PASSING_DATA = 0x0010;
        public static string REQUEST_KEY_WORD_OF_THE_DAY = "com.markzfilter.ExampleDroid.REQUEST_KEY_WORD_OF_THE_DAY";

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "Passing Data" layout resource
            SetContentView(Resource.Layout.PassingData);

            outputTextView = FindViewById<TextView>(Resource.Id.textViewPickersOutput);

            FindViewById<Button>(Resource.Id.buttonPassingDataGetStringData).Click += (sender, e) => {
                StartActivityForResult(typeof(PassingData2), REQUEST_CODE_PASSING_DATA);
            };

        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            // NOTE
            // Typically not required in Native Android development; however, in Xamarin,
            // if you do not re-initialize the TextView, you will get a NullReferenceException.
            // You could just store the returned value into another variable, and then update
            // the TextView onResume; however, this is more straight-forward and easier to
            // follow. Refer to:
            // https://developer.xamarin.com/recipes/android/fundamentals/activity/start_activity_for_result/ 

            outputTextView = FindViewById<TextView>(Resource.Id.textViewPassingDataOutput);


            if (resultCode == Result.Ok)
            {
                if (requestCode == REQUEST_CODE_PASSING_DATA) {
                    string resultingWord = data.GetStringExtra(REQUEST_KEY_WORD_OF_THE_DAY);
                    if (resultingWord != null)
                        outputTextView.Text = resultingWord;
                    else
                        Toast.MakeText(this, "There was an error retrieving the word", ToastLength.Long).Show();
                }
                else {
                    Toast.MakeText(this, "There was an error. Wrong Request Code", ToastLength.Long).Show();
                }

            }
        }
    }
}
