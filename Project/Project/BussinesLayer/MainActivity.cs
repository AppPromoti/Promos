using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using V7Toolbar = Android.Support.V7.Widget.Toolbar;
using V4Fragment = Android.Support.V4.App.Fragment;
using V4FragmentManager = Android.Support.V4.App.FragmentManager;
using Android.Support.V4.Widget;
using Android.Support.Design.Widget;
using System.Collections.Generic;
using Android.Support.V4.View;
using V7SearchView = Android.Support.V7.Widget.SearchView;
using Android.Support.V7.Widget;
using Android.Views.InputMethods;
using Android.Content.PM;
using Java.Security;

namespace Project.BussinesLayer
{
    [Activity(Label = "Project"/*, MainLauncher = true, Icon = "@drawable/icon"*/)]
    public class MainActivity : AppCompatActivity,NavigationView.IOnNavigationItemSelectedListener
    {

        private DrawerLayout mDrawerLayout;
        private V7SearchView mSearchView;
        private V7Toolbar mToolbar;
        private CardView mCardView;        

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView (Resource.Layout.main_activity);

            mToolbar = FindViewById<V7Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(mToolbar);

            SupportActionBar.SetHomeAsUpIndicator(Resource.Drawable.ic_menu);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);

            mDrawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);

            var navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);
            navigationView.SetNavigationItemSelectedListener(this);

            var header = navigationView.GetHeaderView(0);

            mCardView = (CardView)header.FindViewById(Resource.Id.card_view);
            mCardView.Click += MCardView_Click;
        }
     
        private void MCardView_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(ProfileActivity));
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.sample_actions, menu);

            var item = menu.FindItem(Resource.Id.action_search);

            var searchView = MenuItemCompat.GetActionView(item);

            mSearchView = searchView.JavaCast<V7SearchView>();

            ((EditText)searchView.FindViewById(Resource.Id.search_src_text)).SetHint(Resource.String.search_hint);
            mSearchView.SetIconifiedByDefault(false);
            mSearchView.QueryTextSubmit += MSearchView_QueryTextSubmit;

            return true;
         
        }

        private void MSearchView_QueryTextSubmit(object sender, V7SearchView.QueryTextSubmitEventArgs e)
        {
            string lineId = e.Query.Trim();
            //mGoogleMap.Clear();
            //try
            //{
            //    DrawLinesRoute(lineId);
            //}
            //catch (Exception)
            //{
            //    Toast.MakeText(this, "Грешна линия", ToastLength.Short).Show();
            //    mSearchView.ClearAnimation();
            //}
            View view = this.CurrentFocus;
            if (view != null)
            {
                InputMethodManager imm = (InputMethodManager)GetSystemService(Context.InputMethodService);
                imm.HideSoftInputFromWindow(view.WindowToken, 0);
            }
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    mDrawerLayout.OpenDrawer(GravityCompat.Start);
                    return true;
                    
            }
            return base.OnOptionsItemSelected(item);
        }

     

        public bool OnNavigationItemSelected(IMenuItem menuItem)
        {
            if (menuItem.IsChecked)
            {
                menuItem.SetChecked(false);
            }
            else
            {
                menuItem.SetChecked(true);
            }

            mDrawerLayout.CloseDrawers();

            switch (menuItem.ItemId)
            {
                case Resource.Id.action_promotions:
                    StartActivity(typeof(PromotionsActivity));
                    return true;
                case Resource.Id.action_stores:
                    StartActivity(typeof(StoresActivity));
                    return true;
                case Resource.Id.action_catalog:
                    StartActivity(typeof(CatalogActivity));
                    return true;
                case Resource.Id.action_favorites:
                    StartActivity(typeof(FavoritesActivity));
                    return true;
            }


            return true;
        }
    }
}

