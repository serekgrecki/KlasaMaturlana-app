using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Text.Style;
using Android.Views;
using Android.Widget;
using KlasaMaturalna.Controls;
using KlasaMaturalna.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(MyPicker), typeof(pickerrender))]

namespace KlasaMaturalna.Droid
{

    public class pickerrender : PickerRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                this.Control.SetTextColor(Android.Graphics.Color.White);
                this.Control.SetBackgroundColor(Android.Graphics.Color.Argb(160, 0, 0, 0));
            }

        }
    }
}