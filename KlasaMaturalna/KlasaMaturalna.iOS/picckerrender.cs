using System;
using System.Collections.Generic;
using System.Text;
using KlasaMaturalna.Controls;
using KlasaMaturalna.iOS;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms.PlatformConfiguration;

[assembly: ExportRenderer(typeof(MyPicker), typeof(MyPickerRenderer))]

namespace KlasaMaturalna.iOS
{
    public class MyPickerRenderer : PickerRenderer
    {
        // Override the OnElementChanged method so we can tweak this renderer post-initial setup
        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                this.Control.TextColor = UIColor.White;
                this.Control.BackgroundColor=(UIColor.FromRGBA(160, 0, 0, 0));
            }
        }

    }
}
