
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

namespace ExampleDroid.Services
{
    [Service(Exported = true, Name = "com.markzfilter.exampledroid.service.BasicService")]
    public class BasicService : Service
    {

        static readonly string TAG = "X:" + typeof(BasicService).Name;
        public static readonly string BROADCAST_RECEIVER_TAG = "com.markzfilter.exampledroid.service.BasicService.BROADCAST_RECEIVER_TAG";
        int NOTIFICATION_ID = 0x1001;
        IBinder binder;
        HttpClient client;





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

                client = new HttpClient();
                client.MaxResponseContentBufferSize = 256000;

                DoLongRunningWork(requestUri);

            }

            // Return the correct StartCommandResult for the type of service you are building
            return StartCommandResult.NotSticky;
        }








        /// <summary>
        /// Does the long running work.
        /// </summary>
        private void DoLongRunningWork(Uri url)
        {
            String responseData = "no data received";

            var heavyWorkThread = new Thread(() => {

                // <uses-permission android:name="android.permission.ACCESS_NETWORK_STATE"></uses-permission>
                ConnectivityManager connectivityManager = (ConnectivityManager)GetSystemService(ConnectivityService);
                NetworkInfo networkInfo = connectivityManager.ActiveNetworkInfo;
                if (networkInfo.IsConnected) {
                    // The NewtonSoft JSON.NET library is a widely used library for serializing and deserializing JSON messages.
                    WebRequest webRequest = WebRequest.Create(url.ToString());
                    WebResponse response = webRequest.GetResponse();
                    StreamReader streamReader = new StreamReader(response.GetResponseStream());
                    responseData = streamReader.ReadToEnd();

                    Intent broadcastMessage = new Intent();
                    broadcastMessage.PutExtra("key", responseData);
                    broadcastMessage.SetAction(BROADCAST_RECEIVER_TAG);
                    SendBroadcast(broadcastMessage);

                    StopSelf(); //Stop (and destroy) the service
                }




                //Thread.Sleep(1000);
                ////Sleeps for 1 s
                //Log.Debug(TAG, "Heavy work completed");

                //Intent broadcastMessage = new Intent();
                //broadcastMessage.PutExtra("key", responseData);
                //broadcastMessage.SetAction(BROADCAST_RECEIVER_TAG);

                ////Android.Support.V4.Content.LocalBroadcastManager.GetInstance(this).SendBroadcast(broadcastMessage);
                //SendBroadcast(broadcastMessage);

                //StopSelf(); //Stop (and destroy) the service
            });

            heavyWorkThread.Start();//Start the thread
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
