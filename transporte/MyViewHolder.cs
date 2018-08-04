using System;
using Android.Views;
using Android.Widget;

namespace transporte
{
    public class MyViewHolder : Android.Support.Wearable.Views.WearableListView.ViewHolder
    {
        public TextView name { get; private set; }
        public ImageView icon { get; private set; }
        public MyViewHolder(View view) : base(view)
        {
            name = view.FindViewById<TextView>(Resource.Id.name);
            icon = view.FindViewById<ImageView>(Resource.Id.circle);
        }
    }
}
