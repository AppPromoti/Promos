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

namespace Project.Adapters
{
    public class PromotionAdapter : RecyclerView.Adapter
    {
        private Activity mActivity;
        private List<PromotionClass> mPromotions = new List<PromotionClass>();

        public PromotionAdapter(Activity activity, List<PromotionClass> promotions)
        {
            mActivity = activity;
            mPromotions = promotions;
        }


        public override int ItemCount
        {
            get { return mPromotions.Count; }
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder viewHolder, int position)
        {
            var promotion = mPromotions[position];

            var holder = viewHolder as PromotionViewHolder;
            holder.Text.Text = promotion.Name;
            holder.Picture.SetImageResource(promotion.DrawableID);
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var promotionView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.square_image_view, parent, false);

            return new PromotionViewHolder(promotionView);
        }

        public class PromotionViewHolder : RecyclerView.ViewHolder
        {
            public ImageView Picture { get; set; }
            public TextView Text { get; set; }

            public PromotionViewHolder(View view):base(view)
            {
                Picture = view.FindViewById<ImageView>(Resource.Id.picture);
                Text = view.FindViewById<TextView>(Resource.Id.text); 
            }
        }
    }
}