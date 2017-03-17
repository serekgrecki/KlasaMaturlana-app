using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KlasaMaturalna.Droid;

namespace KlasaMaturalna.Controls
{
    public class CrossAdmobManager
    {
        private static List<string> testDevicesId;
        public static void Init(string admobKey, List<string> testDevices = null)
        {
            AdmobKey = "ca-app-pub-4454936709409872/1119595746";
            testDevicesId = testDevices;
            IsInitialized = true;
        }

        public static string AdmobKey = "ca-app-pub-4454936709409872/1119595746";

        public static bool IsInitialized
        {
            get;
            private set;
        }

        static Lazy<IInterstitialAdManager> Implementation = new Lazy<IInterstitialAdManager>(() => CreateGameCenterManager(), System.Threading.LazyThreadSafetyMode.PublicationOnly);

        public static IInterstitialAdManager Current
        {
            get
            {
                if (!IsInitialized)
                {
                    Debug.WriteLine("You Must Call Xamarinos.AdMob.Forms.Current.Init() before to use it");
                    throw new NotImplementedException("You Must Call Xamarinos.AdMob.Forms.Current.Init() before to use it");
                }
                var ret = Implementation.Value;
                if (ret == null)
                {
                    throw NotImplementedInReferenceAssembly();
                }
                return ret;
            }
        }

        public CrossAdmobManager()
        {
        }

        static IInterstitialAdManager CreateGameCenterManager()
        {
#if PORTABLE
			return null;
#else
            return new AdsInterstitialImplementation(testDevicesId);
#endif
        }

        internal static Exception NotImplementedInReferenceAssembly()
        {
            return new NotImplementedException("This functionality is not implemented in the portable version of this assembly.  You should reference the NuGet package from your main application project in order to reference the platform-specific implementation.");
        }
    }
}
