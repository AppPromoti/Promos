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
using Android.Util;

namespace Project.ModifiedLayoutClasses
{
    public class SquareImageView:ImageView
    {
        public SquareImageView(Context context) : base(context)
        {

        }
        public SquareImageView(Context context, IAttributeSet attrs):base(context,attrs)
        {

        }
        public SquareImageView(Context context, IAttributeSet attrs, int defStyle) : base(context, attrs, defStyle)
        {

        }

        protected override void OnMeasure(int widthMeasureSpec, int heightMeasureSpec)
        {
            base.OnMeasure(widthMeasureSpec, heightMeasureSpec);
            SetMeasuredDimension(MeasuredWidth, MeasuredWidth);
        }
    }
}