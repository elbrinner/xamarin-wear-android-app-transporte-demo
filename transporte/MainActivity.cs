using System;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Support.Wearable.Views;
using Android.Views;
using Android.Widget;
using Plugin.Connectivity;
using transporte.Service.Services;

namespace transporte
{
    [Activity(Label = "Transporte", MainLauncher = true, Icon = "@mipmap/pickup")]
    public class MainActivity : Activity
    {
        /*
        int count = 1;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            var v = FindViewById<WatchViewStub>(Resource.Id.watch_view_stub);
            v.LayoutInflated += delegate
            {

                // Get our button from the layout resource,
                // and attach an event to it
                //Button button = FindViewById<Button>(Resource.Id.myButton);


            };
        }

*/

        WearableListView devices;
        protected async override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.devices);
            devices = FindViewById<WearableListView>(Resource.Id.devices);

            TransporteService service = new TransporteService();

            if (!CrossConnectivity.Current.IsConnected)
            {
                //You are offline, notify the user
                return;
            }
            var lineas = await service.TransporteAhora();
            var carga = FindViewById<ProgressBar>(Resource.Id.cargando);
            carga.Visibility = ViewStates.Invisible;
            devices.SetAdapter(new DevicesAdapter(this,lineas));
        }
    }
}


