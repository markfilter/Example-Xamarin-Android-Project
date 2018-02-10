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
        IListAdapter listAdapter;
        ListView menuListView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Populates the menu ListView for App Navigation
            populateMenu();
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
                        Toast.MakeText(this, selectedFromList, ToastLength.Short).Show();
                        StartActivity(typeof(ProgressIndicator));
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
        private void populateMenu()
        {
            menuCollection.Add("Progress Indicator");
            menuCollection.Add("Toasts");
            menuCollection.Add("Snackbars");
            menuCollection.Add("ListView");
            menuCollection.Add("GridView");
            menuCollection.Add("CardView");
            menuCollection.Add("Picker");
            menuCollection.Add("DatePicker");
            menuCollection.Add("Spinner");
            menuCollection.Add("Switch");
            menuCollection.Add("PagerView");
            menuCollection.Add("WebView");
            menuCollection.Add("Fingerprint Auth");
            menuCollection.Add("ImageView");
            menuCollection.Add("Camera");
            menuCollection.Add("Camera & ContentProvider");
            menuCollection.Add("Notifications");
            menuCollection.Add("Basic Fragment");
            menuCollection.Add("Fragment with Menu");
            menuCollection.Add("Fragment with Data");
            menuCollection.Add("Login Screen");

        }
    }
}

