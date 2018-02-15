
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
using System.Net.Http;
using System.Threading.Tasks;
using Android.Media;
using Android.Graphics;

namespace ExampleDroid
{

    public delegate void TitleUpdated();

    public class UpdateTitleEventArgs : EventArgs 
    {
        public string title;
        public string imageUrl;

        public UpdateTitleEventArgs() {}
        public UpdateTitleEventArgs(InnerData redditPost) {
            this.title = redditPost.title;
            this.imageUrl = redditPost.thumbnail;
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

        /// <summary>
        /// BasicService BroadcastReceiver - updates title and image.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        void BasicServiceBroadcastReceiver_UpdateTitle(object sender, EventArgs e)
        {
            if (((UpdateTitleEventArgs)e).title != null) {
                // Update Title
                titleTextView.Text = ((UpdateTitleEventArgs)e).title;

                // Download Image and Update ImageView
                var wasSuccessful = DownloadImageFromUrl(((UpdateTitleEventArgs)e).imageUrl);
            }
        }

        /// <summary>
        /// Downloads the image from URL.
        /// </summary>
        /// <returns>The image from URL.</returns>
        /// <param name="imageUrl">Image URL.</param>
        private async Task<Boolean> DownloadImageFromUrl(string imageUrl)
        {
            Bitmap downloadedImage = null;

            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(imageUrl);
                var imageData = await response.Content.ReadAsByteArrayAsync();
                downloadedImage = BitmapFactory.DecodeByteArray(imageData, 0, imageData.Length);
            }

            if (downloadedImage != null)
            {
                imageView.SetImageBitmap(downloadedImage);
                imageView.SetScaleType(ImageView.ScaleType.CenterCrop);
                return true;
            }
            else
            {
                Toast.MakeText(this, "No image could be downloaded", ToastLength.Long).Show();
            }

            return false;
        }


        protected override void OnResume()
        {
            base.OnResume();
            RegisterReceiver(basicServiceBroadcastReceiver, new IntentFilter(BasicService.BROADCAST_RECEIVER_TAG));
        }


        protected override void OnPause()
        {
            UnregisterReceiver(basicServiceBroadcastReceiver);
            if (downloadIntent != null) 
            {
                StopService(downloadIntent);
            }
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
                    Log.Debug(BasicService.BROADCAST_RECEIVER_TAG, "Nested Received intent! RedditPost.title = " + redditPost.title);
                    Log.Debug(BasicService.BROADCAST_RECEIVER_TAG, "Nested Received intent! RedditPost.thumbnail = " + redditPost.thumbnail);
                }

            }

        }

    }

}
