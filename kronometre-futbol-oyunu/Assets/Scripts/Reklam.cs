using GoogleMobileAds.Api;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reklam : MonoBehaviour
{

    private InterstitialAd interstitial;

    void Start()
    {
        //1. Asama----------------------------------------------------
        #if UNITY_ANDROID
        string appId = "ca-app-pub-2599972005525985~4349708701";
        #elif UNITY_IPHONE
            string appId = "ca-app-pub-3940256099942544~1458002511";
        #else
            string appId = "unexpected_platform";
        #endif

        MobileAds.Initialize(appId);

        //2. Asama----------------------------------------------------
        #if UNITY_ANDROID
        string adUnitId = "ca-app-pub-3940256099942544/1033173712"; //Test
        #elif UNITY_IPHONE
        string adUnitId = "ca-app-pub-3940256099942544/4411468910";
        #else
        string adUnitId = "unexpected_platform";
        #endif
        
        this.interstitial = new InterstitialAd(adUnitId);

        //3. Asama----------------------------------------------------

        //AdRequest request = new AdRequest.Builder().Build(); TEST

        AdRequest request = new AdRequest.Builder()
  .AddTestDevice("2077ef9a63d2b398840261c8221a0c9b")
  .Build();

        this.interstitial.LoadAd(request);

        //4. Asama----------------------------------------------------
    }

    public void ReklamiGoster()
    {
        if (interstitial.IsLoaded())
        {
            interstitial.Show();
        }
    }

}
