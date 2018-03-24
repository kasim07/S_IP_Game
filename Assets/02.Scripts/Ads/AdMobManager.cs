using UnityEngine;
using System.Collections;
using admob;

public class AdMobManager : MonoBehaviour {
    public static AdMobManager Instance;
    private string android_banner_id = "ca-app-pub-8512629740125748/6803655315";
    private string android_interstitial_id = "ca-app-pub-8512629740125748/5965403719";

    public bool isShow;


    void Start()
    {
        Instance = this;
        isShow = true;
        initAdmob();
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
    private void fixTransform(Vector3 size, Vector3 pos)
    {
    }

    public void ShowBannerAd()
    {
        isShow = true;
        Admob.Instance().showBannerRelative(AdSize.Banner, AdPosition.TOP_CENTER, 0);
    }

    public void CloseBannerAd()
    {
        isShow = false;
        Admob.Instance().removeBanner();
    }
}