
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
using ExampleDroid.Services;
using Uri = Android.Net.Uri;
using Android.Util;

namespace ExampleDroid
{

    public delegate void TitleUpdated();

    public class UpdateTitleEventArgs : EventArgs 
    {
        public string title;
    }

    [Activity(Label = "Simple Service")]
    public class SimpleService : AppCompatActivity
    {

        ImageView imageView;
        TextView titleTextView;
        String downloadUrl;
        BasicServiceBroadcastReceiver basicServiceBroadcastReceiver;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "Simple Service" layout resource
            SetContentView(Resource.Layout.SimpleService);

            basicServiceBroadcastReceiver = new BasicServiceBroadcastReceiver();
            basicServiceBroadcastReceiver.UpdateTitle += BasicServiceBroadcastReceiver_UpdateTitle;

            downloadUrl = "https://www.reddit.com/search.json?q=star%20trek";

            imageView = FindViewById<ImageView>(Resource.Id.ivSimpleServiceImageView);
            titleTextView = FindViewById<TextView>(Resource.Id.textViewSimpleServiceTitleText);

            FindViewById<Button>(Resource.Id.buttonSimpleServiceStartService).Click += (sender, e) =>
            {
                // Implementation
                Intent downloadIntent = new Intent(this, typeof(BasicService));
                downloadIntent.SetData(Uri.Parse(downloadUrl)); // using Uri = Android.Net.Uri;
                StartService(downloadIntent);
                // can stop service by calling StopService(new Intent(this, typeOf(BasicService)));
            };

           
           
        }

        void BasicServiceBroadcastReceiver_UpdateTitle(object sender, EventArgs e)
        {
            if (((UpdateTitleEventArgs)e).title != null) {
                titleTextView.Text = ((UpdateTitleEventArgs)e).title;
            }
        }




        protected override void OnResume()
        {
            base.OnResume();
            RegisterReceiver(basicServiceBroadcastReceiver, new IntentFilter("com.markzfilter.exampledroid.service.BasicService.BROADCAST_RECEIVER_TAG"));
        }

        protected override void OnPause()
        {
            UnregisterReceiver(basicServiceBroadcastReceiver);
            base.OnPause();
        }





        [BroadcastReceiver(Enabled = true, Exported = false)]
        [IntentFilter(new[] { "com.markzfilter.exampledroid.service.BasicService.BROADCAST_RECEIVER_TAG" })]
        public class BasicServiceBroadcastReceiver : BroadcastReceiver
        {

        public event EventHandler UpdateTitle;

            public override void OnReceive(Context context, Intent intent)
            {
                if(intent.Action == "com.markzfilter.exampledroid.service.BasicService.BROADCAST_RECEIVER_TAG") 
                {
                    // Do stuff here.
                    String value = intent.GetStringExtra("key");
                    UpdateTitleEventArgs titleArgs = new UpdateTitleEventArgs();
                    titleArgs.title = value;
                    UpdateTitle?.Invoke(this, titleArgs);
                    Toast.MakeText(context, "Nested Received: " + value, ToastLength.Short).Show();
                    Log.Debug(BasicService.BROADCAST_RECEIVER_TAG, "Nested Received intent!");
                }

            }

        }

    }

}
