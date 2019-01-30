using GoogleMobileAds.Api;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reklam : MonoBehaviour
{

    static Reklam reklamKontrol;

    InterstitialAd interstitial;

    void Start()
    {

        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        if (reklamKontrol==null)
        {
            DontDestroyOnLoad(gameObject);
            reklamKontrol = this;

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
            //string adUnitId = "ca-app-pub-3940256099942544/1033173712";
            string adUnitId = "ca-app-pub-2599972005525985/3498240584"; //Test
            #elif UNITY_IPHONE
        string adUnitId = "ca-app-pub-3940256099942544/4411468910";
            #else
        string adUnitId = "unexpected_platform";
            #endif

            interstitial = new InterstitialAd(adUnitId);

            //3. Asama----------------------------------------------------

            AdRequest request = new AdRequest.Builder().Build(); 
  //          AdRequest request = new AdRequest.Builder()
  //.AddTestDevice(AdRequest.TestDeviceSimulator).AddTestDevice("2077ef9a63d2b398840261c8221a0c9b")
  //.Build();


            interstitial.LoadAd(request);

            //4. Asama----------------------------------------------------
        }
        else
        {
            Destroy(gameObject);
        }
        
       
    }

    public void ReklamiGoster()
    {
        if (interstitial.IsLoaded())
        {
            interstitial.Show();
            Debug.Log("GİRDİK");
        }
    }
}
