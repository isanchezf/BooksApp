using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using BooksApp.ResilientHttp.ResilienceHttp;

namespace BooksApp.Droid
{
    [Activity(Label = "BooksApp", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            var factory = new ResilientHttpClientFactory();
            var httpClient = factory.CreateResilientHttpClient();
            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new BooksApp.App(httpClient));
        }
    }
}

