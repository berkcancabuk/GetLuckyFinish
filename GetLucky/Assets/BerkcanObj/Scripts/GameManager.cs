using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using GoogleMobileAds.Api;
public class GameManager : MonoBehaviour
{

    //public ParticleBikinis particle_bikinis;
    //public UImanager UI_manager;
    //public GameObject poolScene;
    //public GameObject bikini_1;
    public UImanager UI_manager;

    public TextMeshProUGUI timer;
    public int minutes = 59;
    public float seconds = 59.0f;
    public int hours = 23;
    public int days = 1;
    public int minutesLastGame = 0;
    public int secondsLastGame = 0;
    public int hoursLastGame = 0;
    public int daysLastGame = 0;
    public DateTime dateTime;
    public string lastGame;
    public ulong lastChestOpen;
    public string surpriseboxOpenString;
    public TimeSpan passingTime;
    public bool surpriseBoxClaimTrue = false;
    public int sceneToContinue;

    public bool isHitBikini1 = false;
    public bool isHitBikini2 = false;
    public bool isHitBikini3 = false;
    public bool isHitBikini4 = false;
    public bool isHitBikini5 = false;
    public bool isHitBikini6 = false;

    public int howMuchBikini = 0;

    private InterstitialAd InterGecisReklami;
    private InterstitialAd InterGecisVideoReklami;
    public string AndroidBannerReklamKimligi;
    public string ÝosBannerReklamKimligi;
    public string VideoAndroidBannerReklamKimligi;
    public string VideoÝosBannerReklamKimligi;
    string reklamId;
    string reklamId2;
    public Text logkaydim;
    void Awake()
    {
        

        
        
    }

    void Start()
    {

        //RequestGecis();

        if (passingTime.Hours == 24)
        {
            print("24 saat geçti oldu");
            PlayerPrefs.SetInt("surpriseBox", 0);
        }

        //print(date + "oyundan çýkma");
        //print(passingTime + "OpenBox-Oyundan çýkma süresi");
        //print(passingTime.Seconds + "second");
        //print(passingTime.Minutes + "minut");
        //print(passingTime.Hours + "hours");
        //print(passingTime.Days + "days");
        print(surpriseBoxClaimTrue);
        if (PlayerPrefs.GetInt("isOutOfTheGame") == 1)
        {
            lastGame = PlayerPrefs.GetString("CloseGame");
            dateTime = System.DateTime.Parse(lastGame);
            StartCoroutine(delayStart());

            PlayerPrefs.SetInt("isOutOfTheGame", 0);
        }

    }
    public BannerView bannerWiew;
    public void RequestGecis()
    {
#if UNITY_ANDROID
        reklamId = AndroidBannerReklamKimligi;
#else
                        Reklamid = "Tanýmsýz Platform";
#endif
        AdSize adsize = new AdSize(320, 50);
        bannerWiew = new BannerView(reklamId, adsize, AdPosition.Bottom);
        //InterGecisReklami = new InterstitialAd(reklamId);

        //InterGecisReklami.OnAdLoaded += yuklendimi;
        //InterGecisReklami.OnAdFailedToLoad += yuklemedesorunvar;
        //InterGecisReklami.OnAdOpening += acildi;
        //InterGecisReklami.OnAdClosed += kapatildi;

        AdRequest request = new AdRequest.Builder().Build();

        bannerWiew.LoadAd(request);


    }


    public IEnumerator delayStart()
    {
        yield return new WaitForSeconds(3.3f);
        if (PlayerPrefs.GetInt("surpriseBox") == 1)
        {
            
            //UI_manager.surpriseBoxOpen = System.DateTime.Parse(PlayerPrefs.GetString("SurpriseBoxOpen"));

            days = 1;
            minutes = 59;
            hours = 23;
            seconds = 59.0f;
            passingTime = dateTime - UI_manager.surpriseBoxOpen;
            secondsLastGame += passingTime.Seconds;
            minutesLastGame += passingTime.Minutes;
            hoursLastGame += passingTime.Hours;
            daysLastGame += passingTime.Days;
            seconds = seconds - secondsLastGame;
            minutes = minutes - minutesLastGame;
            hours -= hoursLastGame;
            
            if (passingTime.Days == 1)
            {
                PlayerPrefs.SetInt("surpriseBox", 0);
            }
            print("uý da geldimi ");
        }
    }
    public IEnumerator addScript()
    {
        GameObject UIman = GameObject.Find("UImanager");
        if (UIman != null)
        {
            yield return new WaitForSeconds(.002f);
            GameObject surprisecountdown24hours = GameObject.Find("CountDown24Hours");
            print("buldu2");

            UI_manager = UIman.GetComponent<UImanager>();
            timer =surprisecountdown24hours.GetComponent<TextMeshProUGUI>();
            print(surprisecountdown24hours);
            


        }
        print("add script worked");
    }
    //private void OnApplicationQuit()
    //{
        
    //    PlayerPrefs.SetInt("isOutOfTheGame", 1);
    //    sceneToContinue = SceneManager.GetActiveScene().buildIndex;
    //    PlayerPrefs.SetInt("hours", hours);
    //    PlayerPrefs.SetInt("minutes",minutes);
    //    PlayerPrefs.SetInt("seconds", (int)seconds);
    //    PlayerPrefs.SetInt("SavedScene", sceneToContinue);
    //    date = DateTime.Now;
    //    PlayerPrefs.SetString("CloseGame", date.ToString());
    //}
    public void countDown24Hours()
    {
        if (PlayerPrefs.GetInt("surpriseBox") == 1)
        {


            timer.text = "" + hours + ":" + minutes + ":" + (int)seconds;
            seconds -= Time.deltaTime;
            if (seconds <= 0)
            {
                minutes--;
                seconds = 59;
                if (minutes <= 0)
                {
                    hours--;
                    minutes = 59;
                    if (hours == 0 && minutes == 0 && seconds == 0)
                    {
                        print("1 gün geçti");
                        PlayerPrefs.SetInt("surpriseBox", 0);
                    }
                }
            }
        }

    }
    private void OnApplicationFocus(bool focus)
    {

        if (!focus)
        {
            print("focus kayboldu");
            PlayerPrefs.SetInt("isOutOfTheGame", 1);
            sceneToContinue = SceneManager.GetActiveScene().buildIndex;
            PlayerPrefs.SetInt("hours", hours);
            PlayerPrefs.SetInt("minutes", minutes);
            PlayerPrefs.SetInt("seconds", (int)seconds);
            PlayerPrefs.SetInt("SavedScene", sceneToContinue);
           
        }
        else if (focus)
        {
            print("focus oldu");
            if (PlayerPrefs.GetInt("isOutOfTheGame") == 1)
            {
                dateTime = DateTime.Now;
                PlayerPrefs.SetString("CloseGame", dateTime.ToString());
                dateTime = System.DateTime.Parse(PlayerPrefs.GetString("CloseGame"));
                StartCoroutine(delayStart());

                PlayerPrefs.SetInt("isOutOfTheGame", 0);
            }
            passingTime = dateTime - UI_manager.surpriseBoxOpen;
        }
    }
    //private void OnApplicationPause(bool pause)
    //{
    //    if (pause)
    //    {
    //        hours = PlayerPrefs.GetInt("hours");
    //        minutes = PlayerPrefs.GetInt("minutes");
    //        seconds = PlayerPrefs.GetInt("seconds");
    //        days = 1;
    //        minutes = 59;
    //        hours = 23;
    //        seconds = 59.0f;


    //        if (passingTime.Hours == 24)
    //        {
    //            print("24 saat geçti oldu");
    //            PlayerPrefs.SetInt("surpriseBox", 0);
    //        }

    //        //print(date + "oyundan çýkma");
    //        //print(passingTime + "OpenBox-Oyundan çýkma süresi");
    //        //print(passingTime.Seconds + "second");
    //        //print(passingTime.Minutes + "minut");
    //        //print(passingTime.Hours + "hours");
    //        //print(passingTime.Days + "days");
    //        print(surpriseBoxClaimTrue);
    //        if (PlayerPrefs.GetInt("isOutOfTheGame") == 1)
    //        {
    //            lastGame = PlayerPrefs.GetString("CloseGame");
    //            date = System.DateTime.Parse(lastGame);
    //            StartCoroutine(delayStart());

    //            PlayerPrefs.SetInt("isOutOfTheGame", 0);
    //        }
    //    }
    //    else
    //    {
    //        PlayerPrefs.SetInt("isOutOfTheGame", 1);
    //        sceneToContinue = SceneManager.GetActiveScene().buildIndex;
    //        PlayerPrefs.SetInt("hours", hours);
    //        PlayerPrefs.SetInt("minutes", minutes);
    //        PlayerPrefs.SetInt("seconds", (int)seconds);
    //        PlayerPrefs.SetInt("SavedScene", sceneToContinue);
    //        date = DateTime.Now;
    //        PlayerPrefs.SetString("CloseGame", date.ToString());
    //    }
    //    }
}

