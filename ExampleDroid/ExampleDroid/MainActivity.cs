using Android.App;
using Android.Widget;
using Android.OS;
using System.Collections;
using System;
using Android.Views;
using Android.Support.V7.App;

namespace ExampleDroid
{
    [Activity(Label = "Menu", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : AppCompatActivity
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
                        Toast.MakeText(this, "Not Currently Implemented", ToastLength.Short).Show();
                        //StartActivity(typeof(DynamicListViews));
                        break;
                    case 5:
                        Toast.MakeText(this, "Not Currently Implemented", ToastLength.Short).Show();
                        //StartActivity(typeof(CustomListViews));
                        break;
                    case 6:
                        Toast.MakeText(this, "Not Currently Implemented", ToastLength.Short).Show();
                        //StartActivity(typeof(StaticGridViews));
                        break;
                    case 7:
                        Toast.MakeText(this, "Not Currently Implemented", ToastLength.Short).Show();
                        //StartActivity(typeof(DynamicGridViews));
                        break;
                    case 8:
                        Toast.MakeText(this, "Not Currently Implemented", ToastLength.Short).Show();
                        //StartActivity(typeof(CustomGridViews));
                        break;
                    case 9:
                        StartActivity(typeof(Pickers));
                        break;
                    case 10:
                        StartActivity(typeof(DatePickers));
                        break;
                    case 11:
                        StartActivity(typeof(TimePickers));
                        break;
                    case 12: 
                        StartActivity(typeof(Spinners));
                        break;
                    case 13:
                        StartActivity(typeof(Switches));
                        break;
                    case 14:
                        StartActivity(typeof(FingerprintAuthorization));
                        break;
                    case 15: // ImageViews
                        Toast.MakeText(this, "Not Currently Implemented", ToastLength.Short).Show();
                        //StartActivity(typeof(ImageViews));
                        break;
                    case 16: // Simple Service
                        StartActivity(typeof(SimpleService));
                        break;
                    case 17: // Cameras
                        Toast.MakeText(this, "Not Currently Implemented", ToastLength.Short).Show();
                        //StartActivity(typeof(Cameras));
                        break;
                    case 18: // Camera & ContentProvider
                        Toast.MakeText(this, "Not Currently Implemented", ToastLength.Short).Show();
                        //StartActivity(typeof(CameraAndContentProvider));
                        break;
                    case 19: // Passing Data
                        StartActivity(typeof(PassingData));
                        break;
                    case 20: // Passing Complex Data
                        Toast.MakeText(this, "Not Currently Implemented", ToastLength.Short).Show();
                        //StartActivity(typeof(PassingComplexData));
                        break;
                    case 21: // CardViews
                        Toast.MakeText(this, "Not Currently Implemented", ToastLength.Short).Show();
                        //StartActivity(typeof(CardViews));
                        break;
                    case 22: // PagerViews
                        Toast.MakeText(this, "Not Currently Implemented", ToastLength.Short).Show();
                        //StartActivity(typeof(PagerViews));
                        break;
                    case 23: // WebViews
                        Toast.MakeText(this, "Not Currently Implemented", ToastLength.Short).Show();
                        //StartActivity(typeof(WebViews));
                        break;
                    case 24: // Notifications
                        Toast.MakeText(this, "Not Currently Implemented", ToastLength.Short).Show();
                        //StartActivity(typeof(Notifications));
                        break;
                    case 25: // Basic Fragment
                        Toast.MakeText(this, "Not Currently Implemented", ToastLength.Short).Show();
                        //StartActivity(typeof(BasicFragment));
                        break;
                    case 26: // Fragment with Menu
                        Toast.MakeText(this, "Not Currently Implemented", ToastLength.Short).Show();
                        //StartActivity(typeof(FragmentWithMenu));
                        break;
                    case 27: // Fragment with Data
                        Toast.MakeText(this, "Not Currently Implemented", ToastLength.Short).Show();
                        //StartActivity(typeof(FragmentWithData));
                        break;
                    case 28: // SQLite CRUD
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
            menuCollection.Add("Progress Indicator"); // 0 : DONE
            menuCollection.Add("Toasts"); // 1 : DONE
            menuCollection.Add("Snackbars"); // 2 : DONE
            menuCollection.Add("Static ListView"); // 3
            menuCollection.Add("Dynamic ListView"); // 4
            menuCollection.Add("CustomListView"); // 5
            menuCollection.Add("Static GridView"); // 6
            menuCollection.Add("Dynamic GridView"); // 7
            menuCollection.Add("Custom GridView"); // 8

            menuCollection.Add("Picker"); // 9 : DONE
            menuCollection.Add("DatePicker"); // 10 : DONE
            menuCollection.Add("TimePicker"); // 11 : DONE

            menuCollection.Add("Spinner"); // 12 : DONE
            menuCollection.Add("Switch"); // 13 : DONE
            menuCollection.Add("Login Screen & Fingerprint"); // 14 : WIP

            menuCollection.Add("File System"); // 15
            menuCollection.Add("Simple Service"); // 16 Login Screen

            menuCollection.Add("Camera"); // 17
            menuCollection.Add("Camera & ContentProvider"); // 18

            menuCollection.Add("Passing Data"); // 19
            menuCollection.Add("Passing Complex Data"); // 20

            menuCollection.Add("CardView"); // 21
            menuCollection.Add("PagerView"); // 22

            menuCollection.Add("WebView"); // 23
            menuCollection.Add("Notifications"); // 24

            menuCollection.Add("Basic Fragment"); // 25
            menuCollection.Add("Fragment with Menu"); // 26
            menuCollection.Add("Fragment with Data"); // 27

            menuCollection.Add("SQLite CRUD"); // 28
        }
    }
}

