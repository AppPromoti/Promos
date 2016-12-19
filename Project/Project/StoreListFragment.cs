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
using V4Fragment = Android.Support.V4.App.Fragment;
using Android.Support.V7.Widget;
using Project.Adapters;
using Project.ModelClasses;

namespace Project
{
    public class StoreListFragment:V4Fragment
    {
        private View mView;
        private RecyclerView mRecycleView;
        private List<StoreClass> mStores = new List<StoreClass>();

        public StoreListFragment()
        {
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
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            mView = inflater.Inflate(Resource.Layout.fragment_stores_list, container, false);

            mRecycleView = mView.JavaCast<RecyclerView>();

            SetUpRecycleView(mRecycleView);

            return mRecycleView;
        }

        private void SetUpRecycleView(RecyclerView recycleView)
        {
            recycleView.SetLayoutManager(new LinearLayoutManager(recycleView.Context));
            recycleView.SetAdapter(new CatalogAdapter(Activity, mStores));
        }
    }
}