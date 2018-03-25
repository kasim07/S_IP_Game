using admob;

public class AdMobManager : SingletonManager<AdMobManager> {
    
    private string android_banner_id = "ca-app-pub-8512629740125748/7650284497";
    private string android_interstitial_id = "ca-app-pub-8512629740125748~1276447832";

    public bool m_ShowBanner;

    void Start()
    {
        if (m_ShowBanner == true)
        {
            initAdmob();
            ShowBannerAd();
        }
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
        Admob.Instance().showBannerRelative(AdSize.Banner, AdPosition.TOP_CENTER, 0);
    }

    public void HideBannerAd()
    {
        if (m_ShowBanner == true)
            Admob.Instance().removeBanner();
    }
}