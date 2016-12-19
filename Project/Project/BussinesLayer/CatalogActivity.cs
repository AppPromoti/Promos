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
using V7SearchView = Android.Support.V7.Widget.SearchView;
using Android.Support.V4.Widget;
using V7Toolbar = Android.Support.V7.Widget.Toolbar;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Views.InputMethods;
using Project.Adapters;
using Project.ModelClasses;
using Android.Support.V7.Widget;
using RVLayoutManager = Android.Support.V7.Widget.RecyclerView.LayoutManager;

namespace Project.BussinesLayer
{
    [Activity(Label = "CatalogActivity")]
    public class CatalogActivity : AppCompatActivity,NavigationView.IOnNavigationItemSelectedListener
    {
        private DrawerLayout mDrawerLayout;
        private V7SearchView mSearchView;
        private V7Toolbar mToolbar;
        private CatalogAdapter mAdapter;
        private RecyclerView mRecyclerView;
        private RVLayoutManager mLayoutManager;

        private List<StoreClass> mStores = new List<StoreClass>();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.catalog_activity);

            mToolbar = FindViewById<V7Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(mToolbar);

            SupportActionBar.SetHomeAsUpIndicator(Resource.Drawable.ic_menu);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);

            mDrawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);

            var navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);
            navigationView.SetNavigationItemSelectedListener(this);

            mRecyclerView = FindViewById<RecyclerView>(Resource.Id.recycler_view);

            mStores.Add(new StoreClass() { ID = 0, IsFavorite = true, Name = "Store_Name", DrawableID = Resource.Drawable.icon, Sphere = "Store_Sphere" });
            mStores.Add(new StoreClass() { ID = 1, IsFavorite = true, Name = "Store_Name", DrawableID = Resource.Drawable.icon, Sphere = "Store_Sphere" });
            mStores.Add(new StoreClass() { ID = 0, IsFavorite = true, Name = "Store_Name", DrawableID = Resource.Drawable.icon, Sphere = "Store_Sphere" });
            mStores.Add(new StoreClass() { ID = 1, IsFavorite = true, Name = "Store_Name", DrawableID = Resource.Drawable.icon, Sphere = "Store_Sphere" });
            mStores.Add(new StoreClass() { ID = 0, IsFavorite = true, Name = "Store_Name", DrawableID = Resource.Drawable.icon, Sphere = "Store_Sphere" });
            mStores.Add(new StoreClass() { ID = 1, IsFavorite = true, Name = "Store_Name", DrawableID = Resource.Drawable.icon, Sphere = "Store_Sphere" });
            mStores.Add(new StoreClass() { ID = 0, IsFavorite = true, Name = "Store_Name", DrawableID = Resource.Drawable.icon, Sphere = "Store_Sphere" });
            mStores.Add(new StoreClass() { ID = 1, IsFavorite = true, Name = "Store_Name", DrawableID = Resource.Drawable.icon, Sphere = "Store_Sphere" });
            mStores.Add(new StoreClass() { ID = 0, IsFavorite = true, Name = "Store_Name", DrawableID = Resource.Drawable.icon, Sphere = "Store_Sphere" });
            mStores.Add(new StoreClass() { ID = 1, IsFavorite = true, Name = "Store_Name", DrawableID = Resource.Drawable.icon, Sphere = "Store_Sphere" });
            mStores.Add(new StoreClass() { ID = 0, IsFavorite = true, Name = "Store_Name", DrawableID = Resource.Drawable.icon, Sphere = "Store_Sphere" });
            mStores.Add(new StoreClass() { ID = 1, IsFavorite = true, Name = "Store_Name", DrawableID = Resource.Drawable.icon, Sphere = "Store_Sphere" });

            mAdapter = new CatalogAdapter(this, mStores);
            mRecyclerView.SetAdapter(mAdapter);
            mLayoutManager = new LinearLayoutManager(this, LinearLayoutManager.Vertical, false);
            mRecyclerView.SetLayoutManager(mLayoutManager);

        }

        private void SetUpViewPager(ViewPager viewPager)
        {
            throw new NotImplementedException();
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
                case Resource.Id.action_main:
                    StartActivity(typeof(MainActivity));
                    return true;
                case Resource.Id.action_stores:
                    StartActivity(typeof(StoresActivity));
                    return true;
                case Resource.Id.action_promotions:
                    StartActivity(typeof(PromotionsActivity));
                    return true;
                case Resource.Id.action_favorites:
                    StartActivity(typeof(FavoritesActivity));
                    return true;
            }


            return true;
        }
    }
}