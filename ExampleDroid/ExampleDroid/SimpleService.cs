﻿
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
using ExampleDroid.Data;

namespace ExampleDroid
{

    public delegate void TitleUpdated();

    public class UpdateTitleEventArgs : EventArgs 
    {
        public string title;
        public UpdateTitleEventArgs() {}
        public UpdateTitleEventArgs(InnerData redditPost) {
            this.title = redditPost.title;
        }
    }

    [Activity(Label = "Simple Service")]
    public class SimpleService : AppCompatActivity
    {

        ImageView imageView;
        TextView titleTextView;
        String downloadUrl;
        BasicServiceBroadcastReceiver basicServiceBroadcastReceiver;
        Intent downloadIntent;


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
                downloadIntent = new Intent(this, typeof(BasicService));
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
            RegisterReceiver(basicServiceBroadcastReceiver, new IntentFilter(BasicService.BROADCAST_RECEIVER_TAG));
        }

        protected override void OnPause()
        {
            UnregisterReceiver(basicServiceBroadcastReceiver);
            StopService(downloadIntent);
            base.OnPause();
        }





        [BroadcastReceiver(Enabled = true, Exported = false)]
        [IntentFilter(new[] { "com.markzfilter.exampledroid.service.BasicService.BROADCAST_RECEIVER_TAG" })]
        public class BasicServiceBroadcastReceiver : BroadcastReceiver
        {

        public event EventHandler UpdateTitle;

            public override void OnReceive(Context context, Intent intent)
            {
                if(intent.Action == BasicService.BROADCAST_RECEIVER_TAG) 
                {
                    // Do stuff here.
                    Bundle value = intent.GetBundleExtra("key");
                    InnerData redditPost = new InnerData(value);
                    UpdateTitleEventArgs titleArgs = new UpdateTitleEventArgs(redditPost);
                    UpdateTitle?.Invoke(this, titleArgs);
                    Log.Debug(BasicService.BROADCAST_RECEIVER_TAG, "Nested Received intent!");
                }

            }

        }

    }

}
