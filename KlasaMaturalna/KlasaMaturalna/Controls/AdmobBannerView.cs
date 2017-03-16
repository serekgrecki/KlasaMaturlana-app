using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace KlasaMaturalna.Controls
{
    public class AdmobBannerView : ContentView
    {
        public string AdUnitID { get; set; }

        public AdmobBannerView(string adUnitID)
        {
            AdUnitID = adUnitID;
        }
    }
}
