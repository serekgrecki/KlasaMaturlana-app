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
using Android.Gms.Ads;
using KlasaMaturalna.Controls;
using KlasaMaturalna.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using View = Xamarin.Forms.View;

[assembly: ExportRenderer(typeof(AdMobView), typeof(AdMobViewRenderer))]

namespace KlasaMaturalna.Droid
{
    public class AdMobViewRenderer : ViewRenderer<AdMobView, Android.Gms.Ads.AdView>
    {
        protected override void OnElementChanged(ElementChangedEventArgs<AdMobView> elementChangedEventArgs)
        {
            base.OnElementChanged(elementChangedEventArgs);

            if (Control == null)
            {
                var ad = new Android.Gms.Ads.AdView(Forms.Context);
                ad.AdSize = Android.Gms.Ads.AdSize.Banner;
                ad.AdUnitId = "ca-app-pub-4454936709409872/1516548545";
                var requestbuilder = new Android.Gms.Ads.AdRequest.Builder();

#if DEBUG
                requestbuilder.AddTestDevice("you can add your device id here for testing");
#endif

                ad.LoadAd(requestbuilder.Build());

                SetNativeControl(ad);
            }
        }
    }
}