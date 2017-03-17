using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Gms.Ads;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using KlasaMaturalna.Controls;
using KlasaMaturalna.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(AdBanner), typeof(AdBannerRenderer))]
namespace KlasaMaturalna.Droid
{
    public class AdBannerRenderer : ViewRenderer
    {
        public AdBannerRenderer()
        {
        }

        public static void Init()
        {
            var debug = true;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.View> e)
        {
            base.OnElementChanged(e);
            if (Control == null)
            {
                var adsbanner = new AdsInterstitialImplementation(null);
                adsbanner.Show();
            }

        }
    }
}