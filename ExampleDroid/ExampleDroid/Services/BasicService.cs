
using System;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Net;
using Android.OS;
using Android.Util;
using Android.Widget;
using Org.Json;
using Uri = Android.Net.Uri;
using System.Net.Http;
using Newtonsoft.Json;
using ExampleDroid.Data;
using System.Collections.Generic;

namespace ExampleDroid.Services
{
    [Service(Exported = true, Name = "com.markzfilter.exampledroid.service.BasicService")]
    public class BasicService : Service
    {

        static readonly string TAG = "X:" + typeof(BasicService).Name;
        public static readonly string BROADCAST_RECEIVER_TAG = "com.markzfilter.exampledroid.service.BasicService.BROADCAST_RECEIVER_TAG";
        int NOTIFICATION_ID = 0x1001;
        IBinder binder;






        public override StartCommandResult OnStartCommand(Android.Content.Intent intent, StartCommandFlags flags, int startId)
        {
            // start your service logic here
            Log.Debug(TAG, "StartCommandResult");

            Uri requestUri = intent.Data;

            if (requestUri == null) {
                StopSelf();
                Log.Debug(TAG, "Request URI was NULL");
            }
            else {
                Log.Debug(TAG, $"OnStartCommand requestUri {requestUri}, flags={flags}, startid={startId}");

                DisplayNotification();
                DisplayToastToUser();

                // <uses-permission android:name="android.permission.ACCESS_NETWORK_STATE"></uses-permission>
                ConnectivityManager connectivityManager = (ConnectivityManager)GetSystemService(ConnectivityService);
                NetworkInfo networkInfo = connectivityManager.ActiveNetworkInfo;
                if (networkInfo.IsConnected)
                {
                    var jsonResponse = GetRemoteJSONStringData(requestUri);

                }
                    StopSelf(); //Stop (and destroy) the service

            }

            // Return the correct StartCommandResult for the type of service you are building
            return StartCommandResult.NotSticky;
        }





        /// <summary>
        /// Displaies the toast to user.
        /// </summary>
        private void DisplayToastToUser()
        {
            // Any UI updates that are made directly from code in a service that is running on a 
            // separate thread can be performed in the Post method of a handler as follows:
            var myHandler = new Handler();
            myHandler.Post(() => {
                Toast.MakeText(this, "Service Started", ToastLength.Long).Show();
            });
        }

        /// <summary>
        /// Displaies the notification.
        /// </summary>
        private void DisplayNotification()
        {
            // Notify via Notification that service started
            var nMgr = (NotificationManager)GetSystemService(NotificationService);
            var notification = new Notification(Resource.Drawable.notification_template_icon_bg, "Service Started");
            notification.Category = "category_simple_service";
            var pendingIntent = PendingIntent.GetActivity(this, 0, new Intent(this, typeof(SimpleService)),0);
            notification.ContentIntent = pendingIntent;
            nMgr.Notify(NOTIFICATION_ID, notification);
        }

        private async Task<InnerData> GetRemoteJSONStringData(Uri requestUri)
        {
            InnerData responsePost = null;

            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(requestUri.ToString());
                var json = await response.Content.ReadAsStringAsync();
                MZFReddit redditDataObjects = JsonConvert.DeserializeObject<MZFReddit>(json);
                responsePost = redditDataObjects.data.children[0].data;
            }

            Intent broadcastMessage = new Intent();
            broadcastMessage.PutExtra("key", responsePost.GetBundle());
            broadcastMessage.SetAction(BROADCAST_RECEIVER_TAG);
            SendBroadcast(broadcastMessage);

            return responsePost;
        }

        public override IBinder OnBind(Intent intent)
        {
            Log.Debug(TAG, "OnBind");
            binder = new BasicServiceBinder(this);
            return binder;
        }

        public override bool OnUnbind(Intent intent)
        {
            // This method is optional to implement
            Log.Debug(TAG, "OnUnbind");
            return base.OnUnbind(intent);
        }

        public override void OnDestroy()
        {
            // This method is optional to implement
            Log.Debug(TAG, "OnDestroy");
            var nMgr = (NotificationManager)GetSystemService(NotificationService);
            nMgr.Cancel(NOTIFICATION_ID);
            binder = null;
            base.OnDestroy();
        }
    }

    public class BasicServiceBinder : Binder
    {
        readonly BasicService service;

        public BasicServiceBinder(BasicService service)
        {
            this.service = service;
        }

        public BasicService GetBasicService()
        {
            return service;
        }
    }
}
