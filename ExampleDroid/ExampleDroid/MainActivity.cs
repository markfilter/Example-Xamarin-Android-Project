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
                        Toast.MakeText(this, "Not Currently Implemented", ToastLength.Short).Show();
                        StartActivity(typeof(StaticGridViews));
                        break;
                    case 7:
                        Toast.MakeText(this, "Not Currently Implemented", ToastLength.Short).Show();
                        StartActivity(typeof(DynamicGridViews));
                        break;
                    case 8:
                        Toast.MakeText(this, "Not Currently Implemented", ToastLength.Short).Show();
                        StartActivity(typeof(CustomGridViews));
                        break;
                    case 9:// Picker
                        Toast.MakeText(this, "Not Currently Implemented", ToastLength.Short).Show();
                        //StartActivity(typeof(GridViews));
                        break;
                    case 10: // Date Picker
                        Toast.MakeText(this, "Not Currently Implemented", ToastLength.Short).Show();
                        //StartActivity(typeof(GridViews));
                        break;
                    case 11:
                        Toast.MakeText(this, "Not Currently Implemented", ToastLength.Short).Show();
                        //StartActivity(typeof(GridViews));
                        break;
                    case 12:
                        Toast.MakeText(this, "Not Currently Implemented", ToastLength.Short).Show();
                        //StartActivity(typeof(GridViews));
                        break;
                    case 13:
                        Toast.MakeText(this, "Not Currently Implemented", ToastLength.Short).Show();
                        //StartActivity(typeof(GridViews));
                        break;
                    case 14:
                        Toast.MakeText(this, "Not Currently Implemented", ToastLength.Short).Show();
                        //StartActivity(typeof(GridViews));
                        break;
                    case 15:
                        Toast.MakeText(this, "Not Currently Implemented", ToastLength.Short).Show();
                        //StartActivity(typeof(GridViews));
                        break;
                    case 16:
                        Toast.MakeText(this, "Not Currently Implemented", ToastLength.Short).Show();
                        //StartActivity(typeof(GridViews));
                        break;
                    case 17:
                        Toast.MakeText(this, "Not Currently Implemented", ToastLength.Short).Show();
                        //StartActivity(typeof(GridViews));
                        break;
                    case 18:
                        Toast.MakeText(this, "Not Currently Implemented", ToastLength.Short).Show();
                        //StartActivity(typeof(GridViews));
                        break;
                    case 19:
                        Toast.MakeText(this, "Not Currently Implemented", ToastLength.Short).Show();
                        //StartActivity(typeof(GridViews));
                        break;
                    case 20:
                        Toast.MakeText(this, "Not Currently Implemented", ToastLength.Short).Show();
                        //StartActivity(typeof(GridViews));
                        break;
                    case 21:
                        Toast.MakeText(this, "Not Currently Implemented", ToastLength.Short).Show();
                        //StartActivity(typeof(GridViews));
                        break;
                    case 22:
                        Toast.MakeText(this, "Not Currently Implemented", ToastLength.Short).Show();
                        //StartActivity(typeof(GridViews));
                        break;
                    case 23:
                        Toast.MakeText(this, "Not Currently Implemented", ToastLength.Short).Show();
                        //StartActivity(typeof(GridViews));
                        break;
                    case 24:
                        Toast.MakeText(this, "Not Currently Implemented", ToastLength.Short).Show();
                        //StartActivity(typeof(GridViews));
                        break;
                    case 25:
                        Toast.MakeText(this, "Not Currently Implemented", ToastLength.Short).Show();
                        //StartActivity(typeof(GridViews));
                        break;
                    case 26:
                        Toast.MakeText(this, "Not Currently Implemented", ToastLength.Short).Show();
                        //StartActivity(typeof(GridViews));
                        break;
                    case 27:
                        Toast.MakeText(this, "Not Currently Implemented", ToastLength.Short).Show();
                        //StartActivity(typeof(GridViews));
                        break;
                    case 28:
                        Toast.MakeText(this, "Not Currently Implemented", ToastLength.Short).Show();
                        //StartActivity(typeof(GridViews));
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

