using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlasaMaturalna.Controls
{
    public interface IInterstitialAdManager
    {
        /// <summary>
        /// Show Interstitial Ad.
        /// </summary>
        Task Show(Action OnPresented = null);
    }
}
