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
using KlasaMaturalna.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using KlasaMaturalna.Controls;
using Button = Xamarin.Forms.Button;

[assembly: ExportRenderer(typeof(CircleButton), typeof(circlebuttonrender))]

namespace KlasaMaturalna.Droid
{
     public class circlebuttonrender : ButtonRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
        {
            base.OnElementChanged(e);
            var btn = this.Control as Android.Widget.Button;
            btn?.SetBackgroundResource(Resource.Drawable.button_bg);
        }
    }
}