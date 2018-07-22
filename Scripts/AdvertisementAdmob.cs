using UnityEngine;
using System.Collections;
using admob;
public class AdvertisementAdmob : MonoBehaviour {
    public static AdvertisementAdmob Instance;
    Admob ad;
    private bool IsShowing;
    void Awake()
    {
        Instance = this;
    }
	// Use this for initialization
	void Start () {
        initAdmob();
    }
    void initAdmob()
    {

        //  isAdmobInited = true;
        ad = Admob.Instance();
        ad.bannerEventHandler += onBannerEvent;
        ad.interstitialEventHandler += onInterstitialEvent;
        ad.rewardedVideoEventHandler += onRewardedVideoEvent;
        ad.initAdmob("ca-app-pub-3076192958641421/3391964194", "ca-app-pub-3076192958641421/4868697393");
        //   ad.setTesting(true);
        ad.setGender(AdmobGender.MALE);
        string[] keywords = { "game", "crash", "male game" };
        ad.setKeywords(keywords);
        Debug.Log("admob inited -------------");

    }
    // Update is called once per frame
    void Update () {
	
	}
   public void ShowBanner()
    {
        if (!IsShowing)
        {
            Admob.Instance().showBannerRelative(AdSize.SmartBanner, AdPosition.BOTTOM_CENTER, 0);
            IsShowing = true;
        }
    }
   public void CloseBanner()
    {
        if (IsShowing)
        {
            Admob.Instance().removeBanner();
            IsShowing = false;
        }
    }
   public void ShowInterstitial()
    {
        if (ad.isInterstitialReady())
        {
            ad.showInterstitial();
        }
        else
        {
            ad.loadInterstitial();
        }
    }
   public void ShowRewardedVideo()
    {
        if (ad.isRewardedVideoReady())
        {
            ad.showRewardedVideo();
        }
        else
        {


            ad.loadRewardedVideo("ca-app-pub-2706666117164991/6051402869");
        }
    }
    void onInterstitialEvent(string eventName, string msg)
    {
        Debug.Log("handler onAdmobEvent---" + eventName + "   " + msg);
        if (eventName == AdmobEvent.onAdLoaded)
        {
            Admob.Instance().showInterstitial();
        }
    }
    void onBannerEvent(string eventName, string msg)
    {
        Debug.Log("handler onAdmobBannerEvent---" + eventName + "   " + msg);
    }
    void onRewardedVideoEvent(string eventName, string msg)
    {
        Debug.Log("handler onRewardedVideoEvent---" + eventName + "   " + msg);
        if (eventName == AdmobEvent.onRewardedVideoStarted)
        {
           
        }
        
    }
   
}
