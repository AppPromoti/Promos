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
using Android.Support.V7.Widget;
using Project.ModelClasses;
using Project.BussinesLayer;

namespace Project.Adapters
{
    public class CatalogAdapter : RecyclerView.Adapter
    {
        private List<StoreClass> mStores = new List<StoreClass>();
        private Activity mActivity;

        public CatalogAdapter(Activity activity, List<StoreClass> stores)
        {
            mActivity = activity;
            mStores = stores;
        }

        public override int ItemCount
        {
            get { return mStores.Count; }
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder viewHolder, int position)
        {
            var store = mStores[position];

            var holder = viewHolder as CatalogViewHolder;
            holder.StoreLogo.SetImageResource(store.DrawableID);
            holder.StoreName.Text = store.Name;
            holder.StoreSphere.Text = store.Sphere;

            if (holder.ClickHandler!=null)
            {
                holder.View.Click -= holder.ClickHandler;
            }

            holder.ClickHandler = new EventHandler((sender, e) =>
              {
                  var context = holder.View.Context;
                  var intent = new Intent(context, typeof(StoreInfoActivity));
                  intent.PutExtra(StoreInfoActivity.STORE_ID, holder.BoundingID);

                  context.StartActivity(intent);
              });
            holder.View.Click += holder.ClickHandler;

        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var catalogView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.store_row, parent, false);

            return new CatalogViewHolder(catalogView);
        }

        public class CatalogViewHolder : RecyclerView.ViewHolder
        {
            public string BoundingID { get; set; }
            public View View { get; set; }
            public ImageView StoreLogo { get; set; }
            public ImageView IsFavorite { get; set; }
            public TextView StoreName { get; set; }
            public TextView StoreSphere { get; set; }
            public EventHandler ClickHandler { get; set; }

            public CatalogViewHolder(View view) : base(view)
            {
                View = view;
                StoreLogo = view.FindViewById<ImageView>(Resource.Id.store_logo);
                IsFavorite = view.FindViewById<ImageView>(Resource.Id.is_favorite);
                StoreName = view.FindViewById<TextView>(Resource.Id.store_name);
                StoreSphere = view.FindViewById<TextView>(Resource.Id.store_sphere);
            }
        }
    }
}