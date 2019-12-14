using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monetizer : MonoBehaviour {

    public bool timeBanner;               // helps in showing ads for a certain duration
    public float bannerDuration;          // the duration for which you will show the banner ad

	void Start ()
    {
        AdsCtrl.instance.ShowBanner();
	}
	
	
	void OnDisable ()
    {
        if (!timeBanner)
            AdsCtrl.instance.HideBanner();
        else
            AdsCtrl.instance.HideBanner(bannerDuration);
	}
}
