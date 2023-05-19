using UnityEngine;
using System.Collections;

public class Ads : MonoBehaviour
{
    string ModeName; // mode of game - Arcede or classic

    void Start()
    {
        if (PLayerInfo.MODE == 1)
            ModeName = "ARCADE ";
        else
            ModeName = "CLASSIC ";
        MusicController.Music.BG_play();

        // check show admob interstitial or no
        if (!Timer.timer.isreq)
        {
            if (GoogleMobileAdsScript.advertise != null)
            {
                GoogleMobileAdsScript.advertise.RequestInterstitial();
            }

            Timer.timer.isreq = true;
        }

        // show banner
        if (GoogleMobileAdsScript.advertise != null)
        {
            GoogleMobileAdsScript.advertise.ShowBanner();
        }

        // request Google Analytics
        if (AdmobGA.load != null)
        {
            AdmobGA.load.GA.LogScreen(ModeName + "Level: " + PLayerInfo.MapPlayer.Level);
        }
    }
}