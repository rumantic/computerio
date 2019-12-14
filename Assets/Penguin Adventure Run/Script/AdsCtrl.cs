using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;

public class AdsCtrl : MonoBehaviour {

    public static AdsCtrl instance = null;
    public string Android_Admob_Banner_ID;      // ca-app-pub-3940256099942544/6300978111
    public string Android_Admob_Interstitial_ID;// ca-app-pub-3940256099942544/1033173712

    public bool testMode;                       // to enable/disable test ads
    BannerView bannerView;                      // the container for the banner ad
    InterstitialAd interstitial;
    AdRequest request;

    void Start ()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

	}
	
	
	public void RequestBanner ()
    {
        if (testMode)
        {
            bannerView = new BannerView(Android_Admob_Banner_ID, AdSize.Banner, AdPosition.Top);
        }
        else
        {
            // code for live ad
        }

        AdRequest adRequest = new AdRequest.Builder().Build();

        bannerView.LoadAd(adRequest);

        HideBanner();
	}

    public void ShowBanner()
    {
        bannerView.Show();
    }

    public void HideBanner()
    {
        bannerView.Hide();
    }

    public void HideBanner(float duration)
    {
        StartCoroutine("HideBannerRoutine", duration);
    }

    IEnumerator HideBannerRoutine(float duration)
    {
        yield return new WaitForSeconds(duration);
        bannerView.Hide();
    }

    void RequestInterstitial()
    {
        if (testMode)
        {
            interstitial = new InterstitialAd(Android_Admob_Interstitial_ID);
        }
        else
        {
            // code for live ad
        }

        request = new AdRequest.Builder().Build();

        interstitial.LoadAd(request);

        interstitial.OnAdClosed += HandleOnAdClosed;
    }

    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        interstitial.Destroy();
        RequestInterstitial();
    }

    public void ShowInterstitial()
    {
        if (interstitial.IsLoaded())
        {
            interstitial.Show();
        }
    }

    private void OnEnable()
    {
        RequestBanner();

        RequestInterstitial();
    }

    private void OnDisable()
    {
        bannerView.Destroy();

        interstitial.Destroy();
    }
}
