using System;
using Android.Content;
using Android.Graphics.Drawables;
using Android.Runtime;
using Android.Support.Wearable.Views;
using Android.Util;
using Android.Widget;

namespace transporte
{
    [Register("com.elbrinner.transporte.WearableListItemLayoutDevices")]
    public class WearableListItemLayoutDevices : LinearLayout, WearableListView.IOnCenterProximityListener
    {

        private ImageView mCircle;
        private TextView mName;

        private float mFadedTextAlpha;
        private int mFadedCircleColor;
        private int mChosenCircleColor;

        public WearableListItemLayoutDevices(Context context) : this(context, null)
        {
        }

        public WearableListItemLayoutDevices(Context context, IAttributeSet attrs) : this(context, attrs, 0)
        {
        }

        public WearableListItemLayoutDevices(Context context, IAttributeSet attrs, int defStyle) : base(context, attrs, defStyle)
        {
            mFadedTextAlpha = 40 / 100f;
            mFadedCircleColor = Resource.Color.grey;
            mChosenCircleColor = Resource.Color.blue;
        }

        protected override void OnFinishInflate()
        {
            base.OnFinishInflate();
            mCircle = (ImageView)FindViewById(Resource.Id.circle);
            mName = (TextView)FindViewById(Resource.Id.name);
        }

        public void OnCenterPosition(bool animate)
        {
            mName.Alpha = 1f;
           // ((GradientDrawable)mCircle.Drawable).SetColor(mChosenCircleColor);
        }

        public void OnNonCenterPosition(bool animate)
        {
           // ((GradientDrawable)mCircle.Drawable).SetColor(mFadedCircleColor);
            mName.Alpha = mFadedTextAlpha;
        }
    }
}
