package md5d4aa9512ee049fa05051427e7dd2bb5c;


public class AdInterstitialListener
	extends com.google.android.gms.ads.AdListener
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onAdLoaded:()V:GetOnAdLoadedHandler\n" +
			"n_onAdClosed:()V:GetOnAdClosedHandler\n" +
			"n_onAdFailedToLoad:(I)V:GetOnAdFailedToLoad_IHandler\n" +
			"";
		mono.android.Runtime.register ("KlasaMaturalna.Droid.AdInterstitialListener, KlasaMaturalna.Android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", AdInterstitialListener.class, __md_methods);
	}


	public AdInterstitialListener () throws java.lang.Throwable
	{
		super ();
		if (getClass () == AdInterstitialListener.class)
			mono.android.TypeManager.Activate ("KlasaMaturalna.Droid.AdInterstitialListener, KlasaMaturalna.Android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

	public AdInterstitialListener (com.google.android.gms.ads.InterstitialAd p0) throws java.lang.Throwable
	{
		super ();
		if (getClass () == AdInterstitialListener.class)
			mono.android.TypeManager.Activate ("KlasaMaturalna.Droid.AdInterstitialListener, KlasaMaturalna.Android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Gms.Ads.InterstitialAd, Xamarin.GooglePlayServices.Ads, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", this, new java.lang.Object[] { p0 });
	}


	public void onAdLoaded ()
	{
		n_onAdLoaded ();
	}

	private native void n_onAdLoaded ();


	public void onAdClosed ()
	{
		n_onAdClosed ();
	}

	private native void n_onAdClosed ();


	public void onAdFailedToLoad (int p0)
	{
		n_onAdFailedToLoad (p0);
	}

	private native void n_onAdFailedToLoad (int p0);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
