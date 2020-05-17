using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdController : MonoBehaviour
{
    #region singletons
    public static AdController instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    #endregion

    #region Variables and ID
    private string store_id = "3571061";

    private string video_ad = "video";
    private string rewarded_video_ad = "rewardedVideo";
    private string banner_ad = "BannerAd";
    private bool testMode = false; //false bila betul2 nk publish app
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        Advertisement.Initialize(store_id, testMode);
    }


    public void showVideoAd()
    {
        Advertisement.Show(video_ad);
    }
}

//https://www.youtube.com/watch?v=v7A3pvymquY
