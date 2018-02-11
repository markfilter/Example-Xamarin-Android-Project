using Android.App;
using Android.Widget;
using Android.OS;
using System.Collections;
using System;
using Android.Views;

namespace ExampleDroid
{
    [Activity(Label = "Menu", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        // Properties
        ArrayList menuCollection = new ArrayList();
        ArrayAdapter<string> listAdapter;
        ListView menuListView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Populates the menu ListView for App Navigation
            PopulateMenu();
            setupListView();
        }

        /// <summary>
        /// Method sets up the ListView with an Adapter and an OnItemClickListener
        /// </summary>
        private void setupListView()
        {
            menuListView = FindViewById<ListView>(Resource.Id.listViewMenu);
            listAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, ((String[])menuCollection.ToArray(typeof(string))));
            menuListView.Adapter = listAdapter;
            menuListView.ItemClick += (object sender, AdapterView.ItemClickEventArgs e) => {

                String selectedFromList = (string)menuListView.GetItemAtPosition(e.Position);

                switch (e.Position)
                {
                    case 0:
                        StartActivity(typeof(ProgressIndicator));
                        break;
                    case 1:
                        StartActivity(typeof(Toasts));
                        break;
                    case 2:
                        StartActivity(typeof(Snackbars));
                        break;
                    case 3:
                        StartActivity(typeof(StaticListViews));
                        break;
                    case 4:
                        StartActivity(typeof(DynamicListViews));
                        break;
                    case 5:
                        StartActivity(typeof(CustomListViews));
                        break;
                    case 6:
                        StartActivity(typeof(StaticGridViews));
                        break;
                    case 7:
                        StartActivity(typeof(DynamicGridViews));
                        break;
                    case 8:
                        StartActivity(typeof(CustomGridViews));
                        break;
                    case 9:// Picker
                        StartActivity(typeof(Pickers));
                        break;
                    case 10: // Date Picker
                        StartActivity(typeof(DatePickers));
                        break;
                    case 11:
                        StartActivity(typeof(TimePickers));
                        break;
                    case 12: // Switches
                        Toast.MakeText(this, "Not Currently Implemented", ToastLength.Short).Show();
                        //StartActivity(typeof(Switches));
                        break;
                    case 13: // Fingerprint Authorization
                        Toast.MakeText(this, "Not Currently Implemented", ToastLength.Short).Show();
                        //StartActivity(typeof(FingerprintAuthorization));
                        break;
                    case 14: // ImageViews
                        Toast.MakeText(this, "Not Currently Implemented", ToastLength.Short).Show();
                        //StartActivity(typeof(ImageViews));
                        break;
                    case 15: // Cameras
                        Toast.MakeText(this, "Not Currently Implemented", ToastLength.Short).Show();
                        //StartActivity(typeof(Cameras));
                        break;
                    case 16: // Camera & ContentProvider
                        Toast.MakeText(this, "Not Currently Implemented", ToastLength.Short).Show();
                        //StartActivity(typeof(CameraAndContentProvider));
                        break;
                    case 17: // Passing Data
                        Toast.MakeText(this, "Not Currently Implemented", ToastLength.Short).Show();
                        //StartActivity(typeof(PassingData));
                        break;
                    case 18: // Passing Complex Data
                        Toast.MakeText(this, "Not Currently Implemented", ToastLength.Short).Show();
                        //StartActivity(typeof(PassingComplexData));
                        break;
                    case 19: // CardViews
                        Toast.MakeText(this, "Not Currently Implemented", ToastLength.Short).Show();
                        //StartActivity(typeof(CardViews));
                        break;
                    case 20: // PagerViews
                        Toast.MakeText(this, "Not Currently Implemented", ToastLength.Short).Show();
                        //StartActivity(typeof(PagerViews));
                        break;
                    case 21: // WebViews
                        Toast.MakeText(this, "Not Currently Implemented", ToastLength.Short).Show();
                        //StartActivity(typeof(WebViews));
                        break;
                    case 22: // Notifications
                        Toast.MakeText(this, "Not Currently Implemented", ToastLength.Short).Show();
                        //StartActivity(typeof(Notifications));
                        break;
                    case 23: // Basic Fragment
                        Toast.MakeText(this, "Not Currently Implemented", ToastLength.Short).Show();
                        //StartActivity(typeof(BasicFragment));
                        break;
                    case 24: // Fragment with Menu
                        Toast.MakeText(this, "Not Currently Implemented", ToastLength.Short).Show();
                        //StartActivity(typeof(FragmentWithMenu));
                        break;
                    case 25: // Fragment with Data
                        Toast.MakeText(this, "Not Currently Implemented", ToastLength.Short).Show();
                        //StartActivity(typeof(FragmentWithData));
                        break;
                    case 26: // Login Screen
                        Toast.MakeText(this, "Not Currently Implemented", ToastLength.Short).Show();
                        //StartActivity(typeof(LoginScreen));
                        break;
                    case 27: // RESTful Request
                        Toast.MakeText(this, "Not Currently Implemented", ToastLength.Short).Show();
                        //StartActivity(typeof(RESTfulRequest));
                        break;
                    case 28: // Remote Image Download
                        Toast.MakeText(this, "Not Currently Implemented", ToastLength.Short).Show();
                        //StartActivity(typeof(RemoteImageDownload));
                        break;
                    case 29: // SQLite CRUD
                        Toast.MakeText(this, "Not Currently Implemented", ToastLength.Short).Show();
                        //StartActivity(typeof(SQLiteCRUD));
                        break;
                    default:
                        Toast.MakeText(this, "Not Currently Implemented", ToastLength.Short).Show();
                        break;
                }

            };
        }

        /// <summary>
        /// Method adds String values to the menuCollection object for use to populate the menu ListView.
        /// </summary>
        private void PopulateMenu()
        {
            menuCollection.Add("Progress Indicator"); // 0
            menuCollection.Add("Toasts"); // 1
            menuCollection.Add("Snackbars"); // 2
            menuCollection.Add("Static ListView"); // 3
            menuCollection.Add("Dynamic ListView"); // 4
            menuCollection.Add("CustomListView"); // 5
            menuCollection.Add("Static GridView"); // 6
            menuCollection.Add("Dynamic GridView"); // 7
            menuCollection.Add("Custom GridView"); // 8
            menuCollection.Add("Picker"); // 9
            menuCollection.Add("DatePicker"); // 10
            menuCollection.Add("Spinner"); // 11
            menuCollection.Add("Switch"); // 12
            menuCollection.Add("Fingerprint Auth"); // 13
            menuCollection.Add("ImageView"); // 14
            menuCollection.Add("Camera"); // 15
            menuCollection.Add("Camera & ContentProvider"); // 16
            menuCollection.Add("Passing Data"); // 17
            menuCollection.Add("Passing Complex Data"); // 18
            menuCollection.Add("CardView"); // 19
            menuCollection.Add("PagerView"); // 20
            menuCollection.Add("WebView"); // 21
            menuCollection.Add("Notifications"); // 22
            menuCollection.Add("Basic Fragment"); // 23
            menuCollection.Add("Fragment with Menu"); // 24
            menuCollection.Add("Fragment with Data"); // 25
            menuCollection.Add("Login Screen"); // 26
            menuCollection.Add("RESTful Request"); // 27
            menuCollection.Add("Remote Image Download"); // 28
            menuCollection.Add("SQLite CRUD"); // 29
        }
    }
}

