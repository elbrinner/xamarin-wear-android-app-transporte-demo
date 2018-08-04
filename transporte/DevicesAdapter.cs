using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Android.Content;
using Android.Support.Wearable.Views;
using Android.Views;
using Android.Widget;
using transporte.Service.Models;
using transporte.Service.Services;

namespace transporte
{
    public class DevicesAdapter : WearableListView.Adapter
    {
        Context context;
        // List<string> titles;
        List<Line> titles;

        public DevicesAdapter(Context context)
        {
            this.context = context;
        }

        private async Task<List<Line>> LoadData()
        {
            TransporteService service = new TransporteService();
            titles = await service.TransporteAhora();
            return titles;
        }


        public  DevicesAdapter(Context context, List<Line> titles) : this(context)
        {

            this.titles = titles;
        }

        public override void OnBindViewHolder(Android.Support.V7.Widget.RecyclerView.ViewHolder p0, int p1)
        {
            var name = p0.ItemView.FindViewById<TextView>(Resource.Id.name);
            name.Text = titles[p1].lineBound;

            var hora = p0.ItemView.FindViewById<TextView>(Resource.Id.hora);
            hora.Text = titles[p1].waitTime;

            var linea = p0.ItemView.FindViewById<TextView>(Resource.Id.linea);
            linea.Text = titles[p1].lineNumber;

            var circle = p0.ItemView.FindViewById<ImageView>(Resource.Id.circle);

            if(titles[p1].lineNumber.Contains("C1") || titles[p1].lineNumber.Contains("C10") || titles[p1].lineNumber.Contains("C8")){
                circle.SetImageResource(Resource.Drawable.renfer);
            }
            else
            {
                circle.SetImageResource(Resource.Drawable.bus);
            }

        }

        public override Android.Support.V7.Widget.RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup p0, int p1)
        {
            return new MyViewHolder(LayoutInflater.FromContext(context).Inflate(Resource.Layout.devices_item, null));
        }

        public override int ItemCount
        {
            get { return titles.Count; }
        }
    }
}
