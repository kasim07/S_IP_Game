using admob;

public class AdMobManager : SingletonManager<AdMobManager> {
    
    private string android_banner_id = "ca-app-pub-8512629740125748/7650284497";
    private string android_interstitial_id = "ca-app-pub-8512629740125748/5083260080";

    protected AdMobManager() { }
    void Awake()
    {    
        initAdmob();
        ShowBannerAd();
    }

    void initAdmob()
    {
        Admob ad = Admob.Instance();
        ad.bannerEventHandler += onBannerEvent;
        ad.interstitialEventHandler += onInterstitialEvent;
        ad.rewardedVideoEventHandler += onRewardedVideoEvent;
        ad.nativeBannerEventHandler += onNativeBannerEvent;
        ad.initAdmob(android_banner_id, android_interstitial_id);
    }

    void onInterstitialEvent(string eventName, string msg)
    {
    }
    void onBannerEvent(string eventName, string msg)
    {
    }
    void onRewardedVideoEvent(string eventName, string msg)
    {
    }
    void onNativeBannerEvent(string eventName, string msg)
    {
    }

    public void ShowBannerAd()
    {
        Admob.Instance().
            showBannerRelative(AdSize.SmartBanner, AdPosition.TOP_CENTER, 0);
    }

    public void HideBannerAd()
    {
        Admob.Instance().removeBanner();
    }
}