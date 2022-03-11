using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class UImanager : MonoBehaviour
{   public Ranking rank;
    public CharactersSetMaterial characters_set_material;
    public ParticleBikinis particle_bikinis;
    public CountDown count_down;
    public SwerveInputSystem swerve_input;
    public GameManager game_manager;
    public MainChar main_char;
    public TextMeshProUGUI coin;
    public TextMeshProUGUI noPoolText;
    public GameObject textConfident;
    public GameObject textBubbly;
    public GameObject sexyImage;
    public GameObject SpicyImage;
    public GameObject textAngry;
    public Image colorbar;
    public Image bar = null;
    public Animator settinAnim;
    public GameObject fireAnim;
    public GameObject layer;
    public GameObject shine;
    public GameObject get3x;
    public GameObject restartPanel;
    public GameObject vipPanel;
    public GameObject cuteButton;
    public GameObject vipButton;
    public GameObject storeClose;
    public GameObject vipClose;
    public GameObject bikinisPanel;
    public GameObject storeGamePanel;
    public GameObject storePanel;
    public bool isStopGame = false;
    public GameObject settingObjectAnim;
    public GameObject settingObjectClose;
    public GameObject settingobjectOpen;
    public bool isvipPanels = false;
    public bool isCutePanel = false;
    public GameObject hotBarParent;
    //public GameObject FirstBikini;
    //public GameObject FirstBikiniOpen;
    public GameObject rankBoard;
    public GameObject continues;
    public GameObject continueLose;
    public GameObject loseImage;
    public GameObject undressImage;
    public GameObject gameover;
    public TextMeshProUGUI x3Coins;
    public GameObject hotText;
    public GameObject hotImageBarParent;
    public GameObject vibrationOff;
    public GameObject soundOff;
    public GameObject vibrationOn;
    public GameObject soundOn;
    public bool isSoundOpen = false;
    public Image HeartCircle;
    public bool isBikiniPanelOpen = false;
    public TextMeshProUGUI Textlevel;
    public int levelValue;
    public GameObject textNoInPool;
    public GameObject complated;
    public GameObject redHotCanvas;
    public int levelCount = 1;
    public GameObject surprisePanel;
    public GameObject countdownSurpriseBoxImage;
    //public GameObject gm;

    public GameObject keepitPanel, fantastictext, loseitbutton;
    public GameObject LeaderBoard;

    public bool isLoseItButtonClick = false;
    // Start is called before the first frame update

    //public List<GameObject> PictureGreen = new List<GameObject>();
    //public List<GameObject> BackGround = new List<GameObject>();
    //public GameObject char1PictureGreen;
    //public GameObject char2PictureGreen, char2BackGround;
    //public GameObject char3PictureGreen, char3BackGround;
    //public GameObject char4PictureGreen, char4BackGround;
    //public GameObject char5PictureGreen, char5BackGround;
    //public GameObject char6PictureGreen, char6BackGround;
    //public GameObject char7PictureGreen, char7BackGround;
    //public GameObject char8PictureGreen, char8BackGround;

    private void Awake()
    {
        StartCoroutine(RestarPanel());
        StartCoroutine(DelayedStart());

    }
    void Start()
    {
        
        addBikinisCheckOpen();

        GameObject gamemanager = GameObject.Find("Game Manager");
        game_manager = gamemanager.GetComponent<GameManager>();
        StartCoroutine(game_manager.addScript());


        restartPanel.SetActive(true);
        if (PlayerPrefs.GetInt("surpriseBox") == 1)
        {
            countdownSurpriseBoxImage.SetActive(true);
            surpriseBoxOpen = System.DateTime.Parse(PlayerPrefs.GetString("SurpriseBoxOpen"));

        }

        coin.text = PlayerPrefs.GetInt("mycoin").ToString();
        InstantiateBikiniScene();
    }
    Touch touch;
    // Update is called once per frame
    void Update()
    {
        game_manager.countDown24Hours();



        //if (/*(Input.GetMouseButton(0) || */(swerve_input.touch.phase == TouchPhase.Moved || swerve_input.touch.phase == TouchPhase.Stationary))
        //{
        //    if (!IsPointerOverUIObject(Input.GetTouch(0)))
        //    {
        //        hotBarParent.SetActive(true);
        //        bikinisPanel.SetActive(false);
        //        storeGamePanel.SetActive(false);
        //        undressImage.SetActive(false);
        //        countdownSurpriseBoxImage.SetActive(false);
        //    }
        //        //print((EventSystem.current.currentSelectedGameObject.gameObject.name) + "  objeleri kapatýrken");

        //    }
    }
        public void InstantiateBikiniScene()
    {
        for (int i = 1; i < 7; i++)
        {
            
            if (PlayerPrefs.GetInt("Bikini" + i) == 0)
            {
                particle_bikinis.Bikinis[i - 1].SetActive(true);
                print(i + "  bikini instantiate i kaç ");

                break;
            }

        }

    }
    public void addBikinisCheckOpen()
    {
        if (PlayerPrefs.GetInt("currentAddBikini1") == 1)
        {
            watchAddBikini[0].SetActive(true);
            main_char.BackGroundBikini[0].SetActive(false);
        }
        if (PlayerPrefs.GetInt("currentAddBikini2") == 1)
        {
            watchAddBikini[1].SetActive(true);
            main_char.BackGroundBikini[1].SetActive(false);
        }
        if (PlayerPrefs.GetInt("currentAddBikini3") == 3)
        {
            watchAddBikini[2].SetActive(true);
            main_char.BackGroundBikini[2].SetActive(false);
        }
        if (PlayerPrefs.GetInt("currentAddBikini4") == 4)
        {
            watchAddBikini[3].SetActive(true);
            main_char.BackGroundBikini[3].SetActive(false);
        }
        if (PlayerPrefs.GetInt("currentAddBikini5") == 5)
        {
            watchAddBikini[4].SetActive(true);
            main_char.BackGroundBikini[4].SetActive(false);
        }
        if (PlayerPrefs.GetInt("currentAddBikini6") == 6)
        {
            watchAddBikini[5].SetActive(true);
            main_char.BackGroundBikini[5].SetActive(false);
        }
    }
    public void KeepItPanelClose()
    {
        main_char.sound_manager.SoundPlay(4);
        keepitPanel.SetActive(false);
        fantastictext.SetActive(false);
        loseitbutton.SetActive(false);
        particle_bikinis.isOpenKeepItPanel = false;
        ShineGetOpenPanel2();
        isLoseItButtonClick = true;
    }
    public List<GameObject> watchAddBikini = new List<GameObject>();

    public void addBikinisPanelOpenBikini(int bikiniNumber)
    {
        main_char.sound_manager.SoundPlay(4);
        main_char.isStopped = true;
        main_char.swerveAmount = 0;
        swerve_input.finish = false;
        main_char.swerveAmount = 0;
        //count_down.gameObject.SetActive(true);
        //count_down.countdownTime = 10;
        //count_down.countdownDisplay.text = count_down.countdownTime.ToString();
        //StartCoroutine(count_down.CountdownsAddOpen());
        //count_down.texts.SetActive(true);
        //count_down.rewardin.SetActive(true);
        //count_down.recieved.SetActive(false);
        
        PlayerPrefs.SetInt("currentBikini", bikiniNumber + 1);
        watchAddBikini[bikiniNumber].SetActive(false);
        PlayerPrefs.SetInt("currentAddBikini" + (bikiniNumber + 1), 0);
        if (PlayerPrefs.GetInt("currentBikini") == 1)
        {
            main_char.MainCharBikinis[0].SetActive(false);
            main_char.MainCharBikinis[1].SetActive(true);
            main_char.MainCharBikinis[2].SetActive(false);
            main_char.MainCharBikinis[3].SetActive(false);
            main_char.MainCharBikinis[4].SetActive(false);
            main_char.MainCharBikinis[5].SetActive(false);
            main_char.MainCharBikinis[6].SetActive(false);
            main_char.BackGroundBikini[0].SetActive(false);
            main_char.BikiniImage[0].SetActive(true);
            main_char.BlueBackGround[5].SetActive(false);
            main_char.BlueBackGround[4].SetActive(false);
            main_char.BlueBackGround[3].SetActive(false);
            main_char.BlueBackGround[2].SetActive(false);
            main_char.BlueBackGround[1].SetActive(false);
            main_char.BlueBackGround[0].SetActive(true);
            PlayerPrefs.SetInt("Bikini1", 1);

        }
        if (PlayerPrefs.GetInt("currentBikini") == 2)
        {
            main_char.MainCharBikinis[0].SetActive(false);
            main_char.MainCharBikinis[1].SetActive(false);
            main_char.MainCharBikinis[2].SetActive(true);
            main_char.MainCharBikinis[3].SetActive(false);
            main_char.MainCharBikinis[4].SetActive(false);
            main_char.MainCharBikinis[5].SetActive(false);
            main_char.MainCharBikinis[6].SetActive(false);
            main_char.BlueBackGround[5].SetActive(false);
            main_char.BlueBackGround[4].SetActive(false);
            main_char.BlueBackGround[3].SetActive(false);
            main_char.BlueBackGround[2].SetActive(false);
            main_char.BlueBackGround[1].SetActive(true);
            main_char.BlueBackGround[0].SetActive(false);
            main_char.BackGroundBikini[1].SetActive(false);
            main_char.BikiniImage[1].SetActive(true);
            PlayerPrefs.SetInt("Bikini2", 1);
        }
        if (PlayerPrefs.GetInt("currentBikini") == 3)
        {
            main_char.MainCharBikinis[0].SetActive(false);
            main_char.MainCharBikinis[1].SetActive(false);
            main_char.MainCharBikinis[2].SetActive(false);
            main_char.MainCharBikinis[3].SetActive(true);
            main_char.MainCharBikinis[4].SetActive(false);
            main_char.MainCharBikinis[5].SetActive(false);
            main_char.MainCharBikinis[6].SetActive(false);
            main_char.BackGroundBikini[2].SetActive(false);
            main_char.BikiniImage[2].SetActive(true);
            main_char.BlueBackGround[5].SetActive(false);
            main_char.BlueBackGround[4].SetActive(false);
            main_char.BlueBackGround[3].SetActive(false);
            main_char.BlueBackGround[2].SetActive(true);
            main_char.BlueBackGround[1].SetActive(false);
            main_char.BlueBackGround[0].SetActive(false);
            PlayerPrefs.SetInt("Bikini3", 1);
        }
        if (PlayerPrefs.GetInt("currentBikini") == 4)
        {
            main_char.MainCharBikinis[0].SetActive(false);
            main_char.MainCharBikinis[1].SetActive(false);
            main_char.MainCharBikinis[2].SetActive(false);
            main_char.MainCharBikinis[3].SetActive(false);
            main_char.MainCharBikinis[4].SetActive(true);
            main_char.MainCharBikinis[5].SetActive(false);
            main_char.MainCharBikinis[6].SetActive(false);
            main_char.BackGroundBikini[3].SetActive(false);
            main_char.BikiniImage[3].SetActive(true);
            main_char.BlueBackGround[5].SetActive(false);
            main_char.BlueBackGround[4].SetActive(false);
            main_char.BlueBackGround[3].SetActive(true);
            main_char.BlueBackGround[2].SetActive(false);
            main_char.BlueBackGround[1].SetActive(false);
            main_char.BlueBackGround[0].SetActive(false);
            PlayerPrefs.SetInt("Bikini4", 1);
        }
        if (PlayerPrefs.GetInt("currentBikini") == 5)
        {
            main_char.MainCharBikinis[0].SetActive(false);
            main_char.MainCharBikinis[1].SetActive(false);
            main_char.MainCharBikinis[2].SetActive(false);
            main_char.MainCharBikinis[3].SetActive(false);
            main_char.MainCharBikinis[4].SetActive(false);
            main_char.MainCharBikinis[5].SetActive(true);
            main_char.MainCharBikinis[6].SetActive(false);
            main_char.BackGroundBikini[4].SetActive(false);
            main_char.BikiniImage[4].SetActive(true);
            main_char.BlueBackGround[5].SetActive(false);
            main_char.BlueBackGround[4].SetActive(true);
            main_char.BlueBackGround[3].SetActive(false);
            main_char.BlueBackGround[2].SetActive(false);
            main_char.BlueBackGround[1].SetActive(false);
            main_char.BlueBackGround[0].SetActive(false);
            PlayerPrefs.SetInt("Bikini5", 1);
        }
        if (PlayerPrefs.GetInt("currentBikini") == 6)
        {
            main_char.MainCharBikinis[0].SetActive(false);
            main_char.MainCharBikinis[1].SetActive(false);
            main_char.MainCharBikinis[2].SetActive(false);
            main_char.MainCharBikinis[3].SetActive(false);
            main_char.MainCharBikinis[4].SetActive(false);
            main_char.MainCharBikinis[5].SetActive(false);
            main_char.MainCharBikinis[6].SetActive(true);
            main_char.BackGroundBikini[5].SetActive(false);
            main_char.BikiniImage[5].SetActive(true);
            main_char.BlueBackGround[5].SetActive(true);
            main_char.BlueBackGround[4].SetActive(false);
            main_char.BlueBackGround[3].SetActive(false);
            main_char.BlueBackGround[2].SetActive(false);
            main_char.BlueBackGround[1].SetActive(false);
            main_char.BlueBackGround[0].SetActive(false);
            PlayerPrefs.SetInt("Bikini6", 1);
        }

    }
    public void OpenSetting()
    {
        main_char.sound_manager.SoundPlay(4);
        main_char.playerAnim.SetBool("Idle", true);
        main_char.playerAnim.SetBool("Walk", false);
        if (isStopGame == false)
        {
            settingObjectAnim.gameObject.SetActive(true);
            settingobjectOpen.SetActive(true);
            settingObjectClose.SetActive(false);
            //main_char.isStopped = true;
            //main_char.swerve_InputSystem.finish = false;
            isStopGame = true;
            //Time.timeScale = 0f;
        }
        else if (isStopGame == true)
        {
            settingObjectClose.SetActive(true);
            settingobjectOpen.SetActive(false);
            settinAnim.SetBool("TouchOff", true);
            StartCoroutine(settingobjeFalse());
            //Time.timeScale = 1f;
            main_char.swerve_InputSystem.touch.phase = TouchPhase.Ended;
            //main_char.swerve_InputSystem.finish = true;

            //main_char.isStopped = false;
            isStopGame = false;

        }

    }
    public void OpenBikinisPanel()
    {
        main_char.sound_manager.SoundPlay(4);
        var bikiniPanelAnim = bikinisPanel.GetComponent<Animator>();
        if (isBikiniPanelOpen == false)
        {
            storeGamePanel.SetActive(false);
            bikiniPanelAnim.SetBool("BikinisOn", true);
            bikiniPanelAnim.SetBool("BikinisOff", false);
            isBikiniPanelOpen = true;
        }
        else if (isBikiniPanelOpen == true)
        {
            StartCoroutine(storeGamePanels());
            bikiniPanelAnim.SetBool("BikinisOff", true);
            bikiniPanelAnim.SetBool("BikinisOn", false);
            isBikiniPanelOpen = false;
        }
    }
    public void openVipPanel()
    {
        main_char.sound_manager.SoundPlay(4);
        storePanel.SetActive(false);

        vipPanel.SetActive(true);
    }
    public void cutePanelOpen()
    {
        main_char.sound_manager.SoundPlay(4);
        vipPanel.SetActive(false);
        storePanel.SetActive(true);
    }
    public bool isUndressOpen = false;
    public void CloseStorePanel()
    {
        Textlevel.gameObject.SetActive(true);
        if (isUndressOpen == false)
        {
            undressImage.SetActive(true);
        }
        
        cuteButton.SetActive(false);
        vipButton.SetActive(false);
        main_char.sound_manager.SoundPlay(4);
        main_char.camera2.SetActive(false);
        bikinisPanel.SetActive(true);
        storeGamePanel.SetActive(true);
        vipPanel.SetActive(false);
        storePanel.SetActive(false);
        storeClose.SetActive(false);
        main_char.swerve_InputSystem.touch.phase = TouchPhase.Ended;
        main_char.isStopped = false;

        main_char.swerve_InputSystem.finish = true;
        
        
    }
    public void OpenBikiniStorePanel()
    {
        Textlevel.gameObject.SetActive(false);
        undressImage.SetActive(false);
        main_char.sound_manager.SoundPlay(4);
        main_char.playerAnim.SetBool("Idle", true);
        main_char.playerAnim.SetBool("Walk", false);
        DOTween.Pause("parentween");
        main_char.isStopped = true;
        main_char.swerveAmount = 0;
        main_char.swerve_InputSystem.finish = false;
        main_char.swerveAmount = 0;
        main_char.camera2.SetActive(true);
        storePanel.SetActive(true);
        cuteButton.SetActive(true);
        vipButton.SetActive(true);
        storeClose.SetActive(true);
        storeGamePanel.SetActive(false);
        bikinisPanel.SetActive(false);
    }
    public bool isStart = false;
    public void ContinueButton()
    {
        main_char.sound_manager.SoundPlay(4);
        PlayerPrefs.SetInt("mycoin", main_char.coins);

        SceneManager.LoadScene(game_manager.sceneToContinue + 1);
        PlayerPrefs.SetInt("SavedScene", game_manager.sceneToContinue + 1);
        game_manager.sceneToContinue = SceneManager.GetActiveScene().buildIndex + 1;
        main_char.collectedÝnGame = 0;
        levelCount++;
        isStart = true;
        for (int i = 1; i < 7; i++)
        {
            if (main_char.MainCharBikinis[i].activeSelf == true)
            {
                PlayerPrefs.SetInt("Bikini" + i, 1);

                if (count_down.isKeepItOnClick == true)
                {
                    PlayerPrefs.SetInt("currentBikini", i);
                }
                if (isLoseItButtonClick == true)
                {
                    PlayerPrefs.SetInt("currentAddBikini" + i, 1);
                }
            }

        }


        }
      public IEnumerator settingobjeFalse()
    {
        yield return new WaitForSeconds(0.2f);
        settingObjectAnim.gameObject.SetActive(false);
    }
    IEnumerator BeFalseLayer()
    {
        yield return new WaitForSeconds(0.15f);
        layer.transform.DOLocalMoveY(-470, 0.16f);
        layer.SetActive(false);
    }
    public IEnumerator ShineGetOpenPanel()
    {
        yield return new WaitForSeconds(2f);
        DOTween.Pause("parentween");
        isStopGame = true;
        main_char.swerveAmount = 0;
        main_char.swerve_InputSystem.finish = false;
        main_char.isStopped = true; main_char.swerveAmount = 0;
        ShineGetOpenPanel2();
        StartCoroutine(OpenKeepItPanel());
    }
    public void ShineGetOpenPanel2()
    {
        if (particle_bikinis.isOpenKeepItPanel == false)
        {
            
            print("shinegetopen");
            complated.SetActive(true);
            shine.SetActive(true);
            get3x.SetActive(true);
            x3Coins.text = main_char.collectedÝnGame * 3 + "coins";
            rank.sortList();
            rankBoard.SetActive(true);
            continues.SetActive(true);
            main_char.sound_manager.SoundPlay(13);
        }
    }
    public IEnumerator DelayedStart()
    {
        yield return new WaitForSeconds(0.5f);
        //if (PlayerPrefs.GetInt("surpriseBox") == 1)
        //{
        //    surpriseBoxOpen = System.DateTime.Parse(PlayerPrefs.GetString("SurpriseBoxOpen"));
        //    print("uý da geldimi ");
        //}
        Textlevel.text = "Level " + game_manager.sceneToContinue;
        print(game_manager.sceneToContinue);
        if (PlayerPrefs.GetInt("Voice") == 1)
        {
            soundOff.SetActive(false);
            soundOn.SetActive(true);
            main_char.sound_manager.isSoundActive = true;
        }
        else if (PlayerPrefs.GetInt("Voice") == 0)
        {
            main_char.sound_manager.isSoundActive = false;
            soundOff.SetActive(true);
            soundOn.SetActive(false);
        }
        if (PlayerPrefs.GetInt("Vibration") == 1)
        {
            main_char.sound_manager.isVibrationActive = true;
            vibrationOff.SetActive(false);
            vibrationOn.SetActive(true);
            //PlayerPrefs.SetInt("Vibration", 0);
        }
        else if (PlayerPrefs.GetInt("Vibration") == 0)
        {
            main_char.sound_manager.isVibrationActive = false;
            //PlayerPrefs.SetInt("Vibration", 1);
            vibrationOff.SetActive(true);
            vibrationOn.SetActive(false);
            
        }
        print(game_manager.sceneToContinue + "sceneContinue 3 Den büyük mü");
        if (game_manager.sceneToContinue >= 3 && PlayerPrefs.GetInt("surpriseBox") == 0)
        {
           
            surprisePanel.SetActive(true);
        }
        //game_manager.passingTime = game_manager.date - surpriseBoxOpen;
        //game_manager.secondsLastGame += game_manager.passingTime.Seconds;
        //game_manager.minutesLastGame += game_manager.passingTime.Minutes;
        //game_manager.hoursLastGame += game_manager.passingTime.Hours;
        //game_manager.seconds = game_manager.seconds - game_manager.secondsLastGame;
        //game_manager.minutes = game_manager.minutes - game_manager.minutesLastGame;
        //game_manager.hours -= game_manager.hoursLastGame;
        print(game_manager.passingTime.Minutes + "minute");
        print(game_manager.passingTime.Seconds + "second");
        print(game_manager.passingTime.Hours + "hours");
        

        print(surpriseBoxOpen);

    }
    public IEnumerator RestarPanel()
    {
        yield return new WaitForSeconds(0.5f);
        restartPanel.SetActive(false);



    }
    IEnumerator storeGamePanels()
    {
        yield return new WaitForSeconds(.5f);
        storeGamePanel.SetActive(true); main_char.sound_manager.SoundPlay(4);
    }
    public int HowMuchHitGirl = 0;
    public void GameOver()
    {
        
        if (bar.fillAmount == 1)
        {
            print(HowMuchHitGirl + " iLk baþta howmuchgirl value");

            if (HowMuchHitGirl >= 2)
            {
                print(HowMuchHitGirl + "howmuchgirl value");
                main_char.sound_manager.SoundPlay(11);
                print("heartcircle 5 sn");
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            HeartCircle.DOFillAmount(1, 5f);
            StartCoroutine(heartCircleTryAgain());

            main_char.swerveSpeed = 0;
            main_char.isStopped = true;
            main_char.swerveAmount = 0;
            main_char.swerve_InputSystem.finish = false;
            main_char.swerveAmount = 0;
            gameover.SetActive(true);


            main_char.playerAnim.SetBool("fall", true);


        }
    }
    
    public IEnumerator heartCircleTryAgain()
    {
        yield return new WaitForSeconds(5.8f);
        
        if ((HeartCircle.fillAmount >= 0.8f && HeartCircle.gameObject.activeSelf == true) || (HowMuchHitGirl == 2))
        {
            main_char.sound_manager.SoundPlay(11);
            print("heartcircle 5 sn");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            //Scene scene = SceneManager.GetActiveScene();
            //SceneManager.LoadScene(scene.name);
        }
    }
    public IEnumerator printText()
    {
        if (game_manager.sceneToContinue == 1)
        {
            string noPool = "NO CLOTHES IN THE POOL ";
            for (int i = 0; i < noPool.Length; i++)
            {
                yield return new WaitForSeconds(0.1f);
                noPoolText.text += noPool[i];
            }
        }
        
    }
    public void TryAgain()
    {
        PlayerPrefs.SetInt("restartValue", PlayerPrefs.GetInt("restartValue") + 1);
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
        //main_char.coins -= main_char.collectedÝnGame;
        //PlayerPrefs.SetInt("mycoin", main_char.coins);
    }
    public void VibrationOpen()
    {
        main_char.sound_manager.SoundPlay(4);
        if (PlayerPrefs.GetInt("Vibration") == 1)
        {
            main_char.sound_manager.isVibrationActive = false;
            vibrationOff.SetActive(true);
            vibrationOn.SetActive(false);
            PlayerPrefs.SetInt("Vibration", 0);
        }
        else if (PlayerPrefs.GetInt("Vibration") == 0)
        {
            main_char.sound_manager.isVibrationActive = true;
            PlayerPrefs.SetInt("Vibration", 1);
            vibrationOff.SetActive(false);
            vibrationOn.SetActive(true);
        }
    }
    public void soundCloses()
    {
        main_char.sound_manager.SoundPlay(4);
        if (PlayerPrefs.GetInt("Voice") == 1)
        {
            soundOff.SetActive(true);
            soundOn.SetActive(false);
            main_char.sound_manager.isSoundActive = false;
            PlayerPrefs.SetInt("Voice", 0);
        }
        else if (PlayerPrefs.GetInt("Voice") == 0)
        {
            PlayerPrefs.SetInt("Voice", 1);
            main_char.sound_manager.isSoundActive = true;
            soundOff.SetActive(false);
            soundOn.SetActive(true);
        }
    }

    public List<Sprite> bikImages = new List<Sprite>();
    public Image bikiniImage;

    public IEnumerator OpenKeepItPanel()
    {
        yield return new WaitForSeconds(1f);
        if (particle_bikinis.isOpenKeepItPanel == true && game_manager.sceneToContinue >= 4)
        {
            if (PlayerPrefs.GetInt("currentBikini") == 1)
            {
                bikiniImage.sprite = bikImages[0];

            }
            else if (PlayerPrefs.GetInt("currentBikini")==2)
            {
                bikiniImage.sprite = bikImages[1];

            }
            else if (PlayerPrefs.GetInt("currentBikini") == 3)
            {
                bikiniImage.sprite = bikImages[2];

            }
            else if (PlayerPrefs.GetInt("currentBikini") == 4)
            {
                bikiniImage.sprite = bikImages[3];
            }
            else if (PlayerPrefs.GetInt("currentBikini") == 5)
            {
                bikiniImage.sprite = bikImages[4];
            }
            else if (PlayerPrefs.GetInt("currentBikini") == 6)
            {
                bikiniImage.sprite = bikImages[5];
            }

            keepitPanel.SetActive(true);
            fantastictext.SetActive(true);
            yield return new WaitForSeconds(2f);
            particle_bikinis.isOpenKeepItPanel = false;
            loseitbutton.SetActive(true);
        }
    }

    

    public DateTime surpriseBoxOpen;
    public List<Sprite> surpriseBoxChar = new List<Sprite>();
    public Image surpriseBoxImage;
    public GameObject surpriseBoxButton;
    public GameObject surpriseBoxContinueButton;
    public GameObject surpriseBoxCharImage;
    public GameObject surpriseBoxAnim;
    public GameObject surpriseBoxPanelContinueButton;
    public void SurpriseBoxContiune()
    {
        main_char.sound_manager.SoundPlay(4);
        count_down.gameObject.SetActive(false);
        surpriseBoxCharImage.SetActive(true);
        //surpriseBoxPanelContinueButton.SetActive(true);
        surpriseBoxAnim.SetActive(false);
    }
    public void surpriseBoxPanelContinue()
    {
        main_char.swerve_InputSystem.touch.phase = TouchPhase.Ended;
        main_char.sound_manager.SoundPlay(4);
        main_char.swerve_InputSystem.finish = true;
        main_char.isStopped = false;
        main_char.swerveSpeed = 0.3f;
        main_char.playerAnim.SetBool("Idle", false);
        main_char.playerAnim.SetBool("Walk", true);
            
        surprisePanel.SetActive(false);
        surpriseBoxContinueButton.SetActive(false);


    }

    public void SurpriseBoxClose()
    {
        main_char.sound_manager.SoundPlay(4);
        surprisePanel.SetActive(false);
    }

    public void bikini1()
    {
        main_char.sound_manager.SoundPlay(4);
        main_char.MainCharBikinis[0].SetActive(false);
        main_char.MainCharBikinis[1].SetActive(true);
        main_char.MainCharBikinis[2].SetActive(false);
        main_char.MainCharBikinis[3].SetActive(false); 
        main_char.MainCharBikinis[4].SetActive(false);
        main_char.MainCharBikinis[5].SetActive(false);
        main_char.MainCharBikinis[6].SetActive(false);
        PlayerPrefs.SetInt("currentBikini", 1);
        main_char.BlueBackGround[5].SetActive(false);
        main_char.BlueBackGround[4].SetActive(false);
        main_char.BlueBackGround[3].SetActive(false);
        main_char.BlueBackGround[2].SetActive(false);
        main_char.BlueBackGround[1].SetActive(false);
        main_char.BlueBackGround[0].SetActive(true);
        main_char.BackGroundBikini[0].SetActive(false);
        main_char.BikiniImage[0].SetActive(true);
    }
    public void bikini2()
    {
        main_char.sound_manager.SoundPlay(4);
        main_char.MainCharBikinis[0].SetActive(false);
        main_char.MainCharBikinis[1].SetActive(false);
        main_char.MainCharBikinis[2].SetActive(true);
        main_char.MainCharBikinis[3].SetActive(false);
        main_char.MainCharBikinis[4].SetActive(false);
        main_char.MainCharBikinis[5].SetActive(false);
        main_char.MainCharBikinis[6].SetActive(false);
        PlayerPrefs.SetInt("currentBikini",2);
        main_char.BlueBackGround[5].SetActive(false);
        main_char.BlueBackGround[4].SetActive(false);
        main_char.BlueBackGround[3].SetActive(false);
        main_char.BlueBackGround[2].SetActive(false);
        main_char.BlueBackGround[1].SetActive(true);    
        main_char.BlueBackGround[0].SetActive(false);
        main_char.BackGroundBikini[1].SetActive(false);
        main_char.BikiniImage[1].SetActive(true);
    }
    public void bikini3()
    {
        main_char.sound_manager.SoundPlay(4);
        main_char.MainCharBikinis[0].SetActive(false);
        main_char.MainCharBikinis[1].SetActive(false);
        main_char.MainCharBikinis[2].SetActive(false);
        main_char.MainCharBikinis[3].SetActive(true);
        main_char.MainCharBikinis[4].SetActive(false);
        main_char.MainCharBikinis[5].SetActive(false);
        main_char.MainCharBikinis[6].SetActive(false);
        PlayerPrefs.SetInt("currentBikini", 3);
        main_char.BlueBackGround[5].SetActive(false);
        main_char.BlueBackGround[4].SetActive(false);
        main_char.BlueBackGround[3].SetActive(false);
        main_char.BlueBackGround[2].SetActive(true);
        main_char.BlueBackGround[1].SetActive(false);
        main_char.BlueBackGround[0].SetActive(false);
        main_char.BackGroundBikini[2].SetActive(false);
        main_char.BikiniImage[2].SetActive(true);
    }
    public void bikini4()
    {
        main_char.sound_manager.SoundPlay(4);
        main_char.MainCharBikinis[0].SetActive(false);
        main_char.MainCharBikinis[1].SetActive(false);
        main_char.MainCharBikinis[2].SetActive(false);
        main_char.MainCharBikinis[3].SetActive(false);
        main_char.MainCharBikinis[4].SetActive(true);
        main_char.MainCharBikinis[5].SetActive(false);
        main_char.MainCharBikinis[6].SetActive(false);
        PlayerPrefs.SetInt("currentBikini", 4);
        main_char.BackGroundBikini[3].SetActive(false);
        main_char.BikiniImage[3].SetActive(true);
        main_char.BlueBackGround[5].SetActive(false);
        main_char.BlueBackGround[4].SetActive(false);
        main_char.BlueBackGround[3].SetActive(true);
        main_char.BlueBackGround[2].SetActive(false);
        main_char.BlueBackGround[1].SetActive(false);
        main_char.BlueBackGround[0].SetActive(false);
    }
    public void bikini5()
    {
        main_char.sound_manager.SoundPlay(4);
        main_char.MainCharBikinis[0].SetActive(false);
        main_char.MainCharBikinis[1].SetActive(false);
        main_char.MainCharBikinis[2].SetActive(false);
        main_char.MainCharBikinis[3].SetActive(false);
        main_char.MainCharBikinis[4].SetActive(false);
        main_char.MainCharBikinis[5].SetActive(true);
        main_char.MainCharBikinis[6].SetActive(false);
        PlayerPrefs.SetInt("currentBikini", 5);
        main_char.BackGroundBikini[4].SetActive(false);
        main_char.BikiniImage[4].SetActive(true);
        main_char.BlueBackGround[5].SetActive(false);
        main_char.BlueBackGround[4].SetActive(true);
        main_char.BlueBackGround[3].SetActive(false);
        main_char.BlueBackGround[2].SetActive(false);
        main_char.BlueBackGround[1].SetActive(false);
        main_char.BlueBackGround[0].SetActive(false);
    }
    public void bikini6()
    {
        main_char.sound_manager.SoundPlay(4);
        main_char.MainCharBikinis[0].SetActive(false);
        main_char.MainCharBikinis[1].SetActive(false);
        main_char.MainCharBikinis[2].SetActive(false);
        main_char.MainCharBikinis[3].SetActive(false);
        main_char.MainCharBikinis[4].SetActive(false);
        main_char.MainCharBikinis[5].SetActive(false);
        main_char.MainCharBikinis[6].SetActive(true);
        PlayerPrefs.SetInt("currentBikini", 6);
        main_char.BackGroundBikini[5].SetActive(false);
        main_char.BikiniImage[5].SetActive(true);
        main_char.BlueBackGround[5].SetActive(true);
        main_char.BlueBackGround[4].SetActive(false);
        main_char.BlueBackGround[3].SetActive(false);
        main_char.BlueBackGround[2].SetActive(false);
        main_char.BlueBackGround[1].SetActive(false);
        main_char.BlueBackGround[0].SetActive(false);
    }

    
    // KARAKTER STORE PENCERESÝNDE TIKLADIÐI BUTONLARA ATADIÐIM FONKSÝYONLAR 
    public void char1()
    {
        main_char.sound_manager.SoundPlay(4);
        main_char.hair8.SetActive(false);
        main_char.hair6.SetActive(false);
        main_char.hair5.SetActive(false);
        main_char.hair4.SetActive(false);
        main_char.hair3.SetActive(false);
        main_char.hair1.SetActive(true);
        main_char.coat.GetComponent<SkinnedMeshRenderer>().material = characters_set_material.Coat[0];
        //main_char.glove_L.GetComponent<SkinnedMeshRenderer>().material = characters_set_material.Gloves[1];
        //main_char.glove_R.GetComponent<SkinnedMeshRenderer>().material = characters_set_material.Gloves[1];
        main_char.top.GetComponent<SkinnedMeshRenderer>().material = characters_set_material.Top[0];
        main_char.skirt.GetComponent<SkinnedMeshRenderer>().material = characters_set_material.Skirt[0];
        main_char.hair1.GetComponent<MeshRenderer>().material = characters_set_material.Hairmat[0];
        //main_char.instantiate_glove.GetComponent<SkinnedMeshRenderer>().material = characters_set_material.Gloves[1];
        main_char.instantiateSkirts.GetComponent<SkinnedMeshRenderer>().material = characters_set_material.Skirt[0];
        main_char.instantiateTop.GetComponent<SkinnedMeshRenderer>().material = characters_set_material.Top[0];
        main_char.instantiateCoat.GetComponent<SkinnedMeshRenderer>().material = characters_set_material.Coat[0];
        main_char.PictureGreen[9].SetActive(false);
        main_char.PictureGreen[8].SetActive(false);
        main_char.PictureGreen[7].SetActive(false);
        main_char.PictureGreen[6].SetActive(false);
        main_char.PictureGreen[5].SetActive(false);
        main_char.PictureGreen[4].SetActive(false);
        main_char.PictureGreen[3].SetActive(false);
        main_char.PictureGreen[2].SetActive(false);
        main_char.PictureGreen[1].SetActive(false);
        main_char.PictureGreen[0].SetActive(true);
        //PlayerPrefs.SetInt("character1", 1);
        //PlayerPrefs.SetInt("character2", 0);
        //PlayerPrefs.SetInt("character3", 0);
        //PlayerPrefs.SetInt("character4", 0);
        //PlayerPrefs.SetInt("character5", 0);
        //PlayerPrefs.SetInt("character6", 0);
        //PlayerPrefs.SetInt("character7", 0);
       
    }
    public void char2()
    {
        main_char.sound_manager.SoundPlay(4);
        main_char.hair8.SetActive(false);
        main_char.hair6.SetActive(false);
        main_char.hair5.SetActive(false);
        main_char.hair4.SetActive(false);
        main_char.hair3.SetActive(false);
        main_char.hair1.SetActive(true);
        main_char.PictureGreen[9].SetActive(false);
        main_char.PictureGreen[8].SetActive(false);
        main_char.PictureGreen[7].SetActive(false);
        main_char.PictureGreen[6].SetActive(false);
        main_char.PictureGreen[5].SetActive(false);
        main_char.PictureGreen[4].SetActive(false);
        main_char.PictureGreen[3].SetActive(false);
        main_char.PictureGreen[2].SetActive(false);
        main_char.PictureGreen[1].SetActive(true);
        main_char.PictureGreen[0].SetActive(false);
        main_char.BackGround[0].SetActive(false);
        main_char.CharImage[0].SetActive(true);

        PlayerPrefs.SetInt("charImage2", 1);
        main_char.coat.GetComponent<SkinnedMeshRenderer>().material = characters_set_material.Coat[1];
        //main_char.glove_L.GetComponent<SkinnedMeshRenderer>().material = characters_set_material.Gloves[1];
        //main_char.glove_R.GetComponent<SkinnedMeshRenderer>().material = characters_set_material.Gloves[1];
        main_char.top.GetComponent<SkinnedMeshRenderer>().material = characters_set_material.Top[1];
        main_char.skirt.GetComponent<SkinnedMeshRenderer>().material = characters_set_material.Skirt[1];
        main_char.hair1.GetComponent<MeshRenderer>().material = characters_set_material.Hairmat[1];
        //main_char.instantiate_glove.GetComponent<SkinnedMeshRenderer>().material = characters_set_material.Gloves[1];
        main_char.instantiateSkirts.GetComponent<SkinnedMeshRenderer>().material = characters_set_material.Skirt[1];
        main_char.instantiateTop.GetComponent<SkinnedMeshRenderer>().material = characters_set_material.Top[1];
        main_char.instantiateCoat.GetComponent<SkinnedMeshRenderer>().material = characters_set_material.Coat[1];
        //PlayerPrefs.SetInt("character1", 0);
        //PlayerPrefs.SetInt("character2", 1);
        //PlayerPrefs.SetInt("character3", 0);
        //PlayerPrefs.SetInt("character4", 0);
        //PlayerPrefs.SetInt("character5", 0);
        //PlayerPrefs.SetInt("character6", 0);
        //PlayerPrefs.SetInt("character7", 0);
    }

    public void char3()
    {
        main_char.sound_manager.SoundPlay(4);
        main_char.hair8.SetActive(false);
        main_char.hair6.SetActive(false);
        main_char.hair5.SetActive(false);
        main_char.hair4.SetActive(false);
        main_char.hair3.SetActive(true);
        main_char.hair1.SetActive(false);
        PlayerPrefs.SetInt("charImage3", 1);
        main_char.PictureGreen[9].SetActive(false);
        main_char.PictureGreen[8].SetActive(false);
        main_char.PictureGreen[7].SetActive(false);
        main_char.PictureGreen[6].SetActive(false);
        main_char.PictureGreen[5].SetActive(false);
        main_char.PictureGreen[4].SetActive(false);
        main_char.PictureGreen[3].SetActive(false);
        main_char.PictureGreen[2].SetActive(true);
        main_char.PictureGreen[1].SetActive(false);
        main_char.PictureGreen[0].SetActive(false);
        main_char.BackGround[1].SetActive(false);
        main_char.CharImage[1].SetActive(true);
        main_char.coat.GetComponent<SkinnedMeshRenderer>().material = characters_set_material.Coat[2];
        //main_char.glove_L.GetComponent<SkinnedMeshRenderer>().material = characters_set_material.Gloves[2];
        //main_char.glove_R.GetComponent<SkinnedMeshRenderer>().material = characters_set_material.Gloves[2];
        main_char.top.GetComponent<SkinnedMeshRenderer>().material = characters_set_material.Top[2];
        main_char.skirt.GetComponent<SkinnedMeshRenderer>().material = characters_set_material.Skirt[2];
        main_char.hair3.GetComponent<MeshRenderer>().material = characters_set_material.Hairmat[2];
        //main_char.instantiate_glove.GetComponent<SkinnedMeshRenderer>().material = characters_set_material.Gloves[2];
        main_char.instantiateSkirts.GetComponent<SkinnedMeshRenderer>().material = characters_set_material.Skirt[2];
        main_char.instantiateTop.GetComponent<SkinnedMeshRenderer>().material = characters_set_material.Top[2];
        main_char.instantiateCoat.GetComponent<SkinnedMeshRenderer>().material = characters_set_material.Coat[2];
        main_char.CharImage[1].SetActive(true);
        main_char.PictureGreen[0].SetActive(false);
        main_char.PictureGreen[1].SetActive(false);
        main_char.PictureGreen[3].SetActive(false);
        main_char.PictureGreen[4].SetActive(false);
        main_char.PictureGreen[5].SetActive(false);
        main_char.PictureGreen[6].SetActive(false);
        //PlayerPrefs.SetInt("character1", 0);
        //PlayerPrefs.SetInt("character2", 0);
        //PlayerPrefs.SetInt("character3", 1);
        //PlayerPrefs.SetInt("character4", 0);
        //PlayerPrefs.SetInt("character5", 0);
        //PlayerPrefs.SetInt("character6", 0);
        //PlayerPrefs.SetInt("character7", 0);
    }
    public void char4()
    {
        main_char.sound_manager.SoundPlay(4);
        main_char.hair8.SetActive(false);
        main_char.hair6.SetActive(false);
        main_char.hair5.SetActive(false);
        main_char.hair4.SetActive(true);
        main_char.hair3.SetActive(false);
        main_char.hair1.SetActive(false);
        PlayerPrefs.SetInt("charImage4", 1);
        main_char.PictureGreen[9].SetActive(false);
        main_char.PictureGreen[8].SetActive(false);
        main_char.PictureGreen[7].SetActive(false);
        main_char.PictureGreen[6].SetActive(false);
        main_char.PictureGreen[5].SetActive(false);
        main_char.PictureGreen[4].SetActive(false);
        main_char.PictureGreen[3].SetActive(true);
        main_char.PictureGreen[2].SetActive(false);
        main_char.PictureGreen[1].SetActive(false);
        main_char.PictureGreen[0].SetActive(false); main_char.BackGround[2].SetActive(false); main_char.CharImage[2].SetActive(true);
        main_char.coat.GetComponent<SkinnedMeshRenderer>().material = characters_set_material.Coat[3];
        //main_char.glove_L.GetComponent<SkinnedMeshRenderer>().material = characters_set_material.Gloves[3];
        //main_char.glove_R.GetComponent<SkinnedMeshRenderer>().material = characters_set_material.Gloves[3];
        main_char.top.GetComponent<SkinnedMeshRenderer>().material = characters_set_material.Top[3];
        main_char.skirt.GetComponent<SkinnedMeshRenderer>().material = characters_set_material.Skirt[3];
        main_char.hair4.GetComponent<MeshRenderer>().material = characters_set_material.Hairmat[3];
        //main_char.instantiate_glove.GetComponent<SkinnedMeshRenderer>().material = characters_set_material.Gloves[3];
        main_char.instantiateSkirts.GetComponent<SkinnedMeshRenderer>().material = characters_set_material.Skirt[3];
        main_char.instantiateTop.GetComponent<SkinnedMeshRenderer>().material = characters_set_material.Top[3];
        main_char.instantiateCoat.GetComponent<SkinnedMeshRenderer>().material = characters_set_material.Coat[3];
        main_char.CharImage[2].SetActive(true);
        main_char.PictureGreen[0].SetActive(false);
        main_char.PictureGreen[1].SetActive(false);
        main_char.PictureGreen[2].SetActive(false);
        main_char.PictureGreen[4].SetActive(false);
        main_char.PictureGreen[5].SetActive(false);
        main_char.PictureGreen[6].SetActive(false);
        //PlayerPrefs.SetInt("character1", 0);
        //PlayerPrefs.SetInt("character2", 0);
        //PlayerPrefs.SetInt("character3", 0);
        //PlayerPrefs.SetInt("character4", 1);
        //PlayerPrefs.SetInt("character5", 0);
        //PlayerPrefs.SetInt("character6", 0);
        //PlayerPrefs.SetInt("character7", 0);
    }
    public void char5()
    {
        main_char.sound_manager.SoundPlay(4);
        main_char.hair8.SetActive(false);
        main_char.hair6.SetActive(false);
        main_char.hair5.SetActive(true);
        main_char.hair4.SetActive(false);
        main_char.hair3.SetActive(false);
        main_char.hair1.SetActive(false);
        PlayerPrefs.SetInt("charImage5", 1);
        main_char.PictureGreen[9].SetActive(false);
        main_char.PictureGreen[8].SetActive(false);
        main_char.PictureGreen[7].SetActive(false);
        main_char.PictureGreen[6].SetActive(false);
        main_char.PictureGreen[5].SetActive(false);
        main_char.PictureGreen[4].SetActive(true);
        main_char.PictureGreen[3].SetActive(false);
        main_char.PictureGreen[2].SetActive(false);
        main_char.PictureGreen[1].SetActive(false);
        main_char.PictureGreen[0].SetActive(false); main_char.BackGround[3].SetActive(false); main_char.CharImage[3].SetActive(true);
        main_char.coat.GetComponent<SkinnedMeshRenderer>().material = characters_set_material.Coat[4];
        //main_char.glove_L.GetComponent<SkinnedMeshRenderer>().material = characters_set_material.Gloves[4];
        //main_char.glove_R.GetComponent<SkinnedMeshRenderer>().material = characters_set_material.Gloves[4];
        main_char.top.GetComponent<SkinnedMeshRenderer>().material = characters_set_material.Top[4];
        main_char.skirt.GetComponent<SkinnedMeshRenderer>().material = characters_set_material.Skirt[4];
        main_char.hair5.GetComponent<MeshRenderer>().material = characters_set_material.Hairmat[4];
        //main_char.instantiate_glove.GetComponent<SkinnedMeshRenderer>().material = characters_set_material.Gloves[4];
        main_char.instantiateSkirts.GetComponent<SkinnedMeshRenderer>().material = characters_set_material.Skirt[4];
        main_char.instantiateTop.GetComponent<SkinnedMeshRenderer>().material = characters_set_material.Top[4];
        main_char.instantiateCoat.GetComponent<SkinnedMeshRenderer>().material = characters_set_material.Coat[4];
        //PlayerPrefs.SetInt("character1", 0);
        //PlayerPrefs.SetInt("character2", 0);
        //PlayerPrefs.SetInt("character3", 0);
        //PlayerPrefs.SetInt("character4", 0);
        //PlayerPrefs.SetInt("character5", 1);
        //PlayerPrefs.SetInt("character6", 0);
        //PlayerPrefs.SetInt("character7", 0);
    }
    public void char6()
    {
        main_char.sound_manager.SoundPlay(4);
        main_char.hair8.SetActive(false);
        main_char.hair6.SetActive(true);
        main_char.hair5.SetActive(false);
        main_char.hair4.SetActive(false);
        main_char.hair3.SetActive(false);
        main_char.hair1.SetActive(false);
        PlayerPrefs.SetInt("charImage6", 1);
        main_char.PictureGreen[9].SetActive(false);
        main_char.PictureGreen[8].SetActive(false);
        main_char.PictureGreen[7].SetActive(false);
        main_char.PictureGreen[6].SetActive(false);
        main_char.PictureGreen[5].SetActive(true);
        main_char.PictureGreen[4].SetActive(false);
        main_char.PictureGreen[3].SetActive(false);
        main_char.PictureGreen[2].SetActive(false);
        main_char.PictureGreen[1].SetActive(false);
        main_char.PictureGreen[0].SetActive(false); main_char.BackGround[4].SetActive(false); main_char.CharImage[4].SetActive(true);
        main_char.coat.GetComponent<SkinnedMeshRenderer>().material = characters_set_material.Coat[5];
        //main_char.glove_L.GetComponent<SkinnedMeshRenderer>().material = characters_set_material.Gloves[5];
        //main_char.glove_R.GetComponent<SkinnedMeshRenderer>().material = characters_set_material.Gloves[5];
        main_char.top.GetComponent<SkinnedMeshRenderer>().material = characters_set_material.Top[5];
        main_char.skirt.GetComponent<SkinnedMeshRenderer>().material = characters_set_material.Skirt[5];
        main_char.hair6.GetComponent<MeshRenderer>().material = characters_set_material.Hairmat[5];
        //main_char.instantiate_glove.GetComponent<SkinnedMeshRenderer>().material = characters_set_material.Gloves[5];
        main_char.instantiateSkirts.GetComponent<SkinnedMeshRenderer>().material = characters_set_material.Skirt[5];
        main_char.instantiateTop.GetComponent<SkinnedMeshRenderer>().material = characters_set_material.Top[5];
        main_char.instantiateCoat.GetComponent<SkinnedMeshRenderer>().material = characters_set_material.Coat[5];
        //PlayerPrefs.SetInt("character1", 0);
        //PlayerPrefs.SetInt("character2", 0);
        //PlayerPrefs.SetInt("character3", 0);
        //PlayerPrefs.SetInt("character4", 0);
        //PlayerPrefs.SetInt("character5", 0);
        //PlayerPrefs.SetInt("character6", 1);
        //PlayerPrefs.SetInt("character7", 0);
    }
    public void char7()
    {
        main_char.sound_manager.SoundPlay(4);
        main_char.hair8.SetActive(false);
        main_char.hair6.SetActive(false);
        main_char.hair5.SetActive(false);
        main_char.hair4.SetActive(false);
        main_char.hair3.SetActive(false);
        main_char.hair1.SetActive(true);
        PlayerPrefs.SetInt("charImage7", 1);
        main_char.PictureGreen[9].SetActive(false);
        main_char.PictureGreen[8].SetActive(false);
        main_char.PictureGreen[7].SetActive(false);
        main_char.PictureGreen[6].SetActive(true);
        main_char.PictureGreen[5].SetActive(false);
        main_char.PictureGreen[4].SetActive(false);
        main_char.PictureGreen[3].SetActive(false);
        main_char.PictureGreen[2].SetActive(false);
        main_char.PictureGreen[1].SetActive(false);
        main_char.PictureGreen[0].SetActive(false); 
        main_char.BackGround[5].SetActive(false); 
        main_char.CharImage[5].SetActive(true);
        main_char.coat.GetComponent<SkinnedMeshRenderer>().material = characters_set_material.Coat[6];
        //main_char.glove_L.GetComponent<SkinnedMeshRenderer>().material = characters_set_material.Gloves[6];
        //main_char.glove_R.GetComponent<SkinnedMeshRenderer>().material = characters_set_material.Gloves[6];
        main_char.top.GetComponent<SkinnedMeshRenderer>().material = characters_set_material.Top[6];
        main_char.skirt.GetComponent<SkinnedMeshRenderer>().material = characters_set_material.Skirt[6];
        main_char.hair1.GetComponent<MeshRenderer>().material = characters_set_material.Hairmat[6];
        //main_char.instantiate_glove.GetComponent<SkinnedMeshRenderer>().material = characters_set_material.Gloves[6];
        main_char.instantiateSkirts.GetComponent<SkinnedMeshRenderer>().material = characters_set_material.Skirt[6];
        main_char.instantiateTop.GetComponent<SkinnedMeshRenderer>().material = characters_set_material.Top[6];
        main_char.instantiateCoat.GetComponent<SkinnedMeshRenderer>().material = characters_set_material.Coat[6];
        //PlayerPrefs.SetInt("character1", 0);
        //PlayerPrefs.SetInt("character2", 0);
        //PlayerPrefs.SetInt("character3", 0);
        //PlayerPrefs.SetInt("character4", 0);
        //PlayerPrefs.SetInt("character5", 0);
        //PlayerPrefs.SetInt("character6", 0);
        //PlayerPrefs.SetInt("character7", 1);
    }
    public void char8()
    {
        main_char.sound_manager.SoundPlay(4);
        main_char.hair8.SetActive(true);
        main_char.hair6.SetActive(false);
        main_char.hair5.SetActive(false);
        main_char.hair4.SetActive(false);
        main_char.hair3.SetActive(false);
        main_char.hair1.SetActive(false);
        PlayerPrefs.SetInt("charImage8", 1);
        main_char.PictureGreen[9].SetActive(false);
        main_char.PictureGreen[8].SetActive(false);
        main_char.PictureGreen[7].SetActive(true);
        main_char.PictureGreen[6].SetActive(false);
        main_char.PictureGreen[5].SetActive(false);
        main_char.PictureGreen[4].SetActive(false);
        main_char.PictureGreen[3].SetActive(false);
        main_char.PictureGreen[2].SetActive(false);
        main_char.PictureGreen[1].SetActive(false);
        main_char.PictureGreen[0].SetActive(false);
        main_char.BackGround[6].SetActive(false);
        main_char.CharImage[6].SetActive(true);
        main_char.coat.GetComponent<SkinnedMeshRenderer>().material = characters_set_material.Coat[7];
        //main_char.glove_L.GetComponent<SkinnedMeshRenderer>().material = characters_set_material.Gloves[7];
        //main_char.glove_R.GetComponent<SkinnedMeshRenderer>().material = characters_set_material.Gloves[7];
        main_char.top.GetComponent<SkinnedMeshRenderer>().material = characters_set_material.Top[7];
        main_char.skirt.GetComponent<SkinnedMeshRenderer>().material = characters_set_material.Skirt[7];
        main_char.hair8.GetComponent<MeshRenderer>().material = characters_set_material.Hairmat[7];
        //main_char.instantiate_glove.GetComponent<SkinnedMeshRenderer>().material = characters_set_material.Gloves[7];
        main_char.instantiateSkirts.GetComponent<SkinnedMeshRenderer>().material = characters_set_material.Skirt[7];
        main_char.instantiateTop.GetComponent<SkinnedMeshRenderer>().material = characters_set_material.Top[7];
        main_char.instantiateCoat.GetComponent<SkinnedMeshRenderer>().material = characters_set_material.Coat[7];
        //PlayerPrefs.SetInt("character2", 0);
        //PlayerPrefs.SetInt("character3", 0);
        //PlayerPrefs.SetInt("character4", 0);
        //PlayerPrefs.SetInt("character5", 0);
        //PlayerPrefs.SetInt("character6", 0);
        //PlayerPrefs.SetInt("character7", 1);
        PlayerPrefs.SetInt("currentCharacter", 8);
    }
    public void char9()
    {
        main_char.sound_manager.SoundPlay(4);
        main_char.hair8.SetActive(true);
        main_char.hair6.SetActive(false);
        main_char.hair5.SetActive(false);
        main_char.hair4.SetActive(false);
        main_char.hair3.SetActive(false);
        main_char.hair1.SetActive(false);
        PlayerPrefs.SetInt("charImage9", 1);
        main_char.PictureGreen[9].SetActive(false);
        main_char.PictureGreen[8].SetActive(true);
        main_char.PictureGreen[7].SetActive(false);
        main_char.PictureGreen[6].SetActive(false);
        main_char.PictureGreen[5].SetActive(false);
        main_char.PictureGreen[4].SetActive(false);
        main_char.PictureGreen[3].SetActive(false);
        main_char.PictureGreen[2].SetActive(false);
        main_char.PictureGreen[1].SetActive(false);
        main_char.PictureGreen[0].SetActive(false);
        main_char.BackGround[7].SetActive(false);
        main_char.CharImage[7].SetActive(true);
        main_char.coat.GetComponent<SkinnedMeshRenderer>().material = characters_set_material.Coat[8];
        //main_char.glove_L.GetComponent<SkinnedMeshRenderer>().material = characters_set_material.Gloves[7];
        //main_char.glove_R.GetComponent<SkinnedMeshRenderer>().material = characters_set_material.Gloves[7];
        main_char.top.GetComponent<SkinnedMeshRenderer>().material = characters_set_material.Top[8];
        main_char.skirt.GetComponent<SkinnedMeshRenderer>().material = characters_set_material.Skirt[8];
        main_char.hair8.GetComponent<MeshRenderer>().material = characters_set_material.Hairmat[8];
        //main_char.instantiate_glove.GetComponent<SkinnedMeshRenderer>().material = characters_set_material.Gloves[7];
        main_char.instantiateSkirts.GetComponent<SkinnedMeshRenderer>().material = characters_set_material.Skirt[8];
        main_char.instantiateTop.GetComponent<SkinnedMeshRenderer>().material = characters_set_material.Top[8];
        main_char.instantiateCoat.GetComponent<SkinnedMeshRenderer>().material = characters_set_material.Coat[8];
        PlayerPrefs.SetInt("currentCharacter", 9);
    }
    public void char10()
    {
        main_char.sound_manager.SoundPlay(4);
        main_char.hair8.SetActive(true);
        main_char.hair6.SetActive(false);
        main_char.hair5.SetActive(false);
        main_char.hair4.SetActive(false);
        main_char.hair3.SetActive(false);
        main_char.hair1.SetActive(false);
        PlayerPrefs.SetInt("charImage9", 1);
        main_char.PictureGreen[9].SetActive(true);
        main_char.PictureGreen[8].SetActive(false);
        main_char.PictureGreen[7].SetActive(false);
        main_char.PictureGreen[6].SetActive(false);
        main_char.PictureGreen[5].SetActive(false);
        main_char.PictureGreen[4].SetActive(false);
        main_char.PictureGreen[3].SetActive(false);
        main_char.PictureGreen[2].SetActive(false);
        main_char.PictureGreen[1].SetActive(false);
        main_char.PictureGreen[0].SetActive(false);
        main_char.BackGround[8].SetActive(false);
        main_char.CharImage[8].SetActive(true);
        main_char.coat.GetComponent<SkinnedMeshRenderer>().material = characters_set_material.Coat[9];
        //main_char.glove_L.GetComponent<SkinnedMeshRenderer>().material = characters_set_material.Gloves[7];
        //main_char.glove_R.GetComponent<SkinnedMeshRenderer>().material = characters_set_material.Gloves[7];
        main_char.top.GetComponent<SkinnedMeshRenderer>().material = characters_set_material.Top[9];
        main_char.skirt.GetComponent<SkinnedMeshRenderer>().material = characters_set_material.Skirt[9];
        main_char.hair8.GetComponent<MeshRenderer>().material = characters_set_material.Hairmat[9];
        //main_char.instantiate_glove.GetComponent<SkinnedMeshRenderer>().material = characters_set_material.Gloves[7];
        main_char.instantiateSkirts.GetComponent<SkinnedMeshRenderer>().material = characters_set_material.Skirt[9];
        main_char.instantiateTop.GetComponent<SkinnedMeshRenderer>().material = characters_set_material.Top[9];
        main_char.instantiateCoat.GetComponent<SkinnedMeshRenderer>().material = characters_set_material.Coat[9];
        PlayerPrefs.SetInt("currentCharacter", 10);
    }


    //public void char3()
    //{
    //    main_char.topBikinis.GetComponent<SkinnedMeshRenderer>().material = particle_bikinis.bikTopMat[2];
    //    main_char.botBikinis.GetComponent<SkinnedMeshRenderer>().material = particle_bikinis.bikBotMat[2];
    //}
    //public void char4()
    //{
    //    main_char.topBikinis.GetComponent<SkinnedMeshRenderer>().material = particle_bikinis.bikTopMat[3];
    //    main_char.botBikinis.GetComponent<SkinnedMeshRenderer>().material = particle_bikinis.bikBotMat[3];
    //}
    //public void char5()
    //{
    //    main_char.topBikinis.GetComponent<SkinnedMeshRenderer>().material = particle_bikinis.bikTopMat[4];
    //    main_char.botBikinis.GetComponent<SkinnedMeshRenderer>().material = particle_bikinis.bikBotMat[4];
    //}
    //public void char6()
    //{
    //    main_char.topBikinis.GetComponent<SkinnedMeshRenderer>().material = particle_bikinis.bikTopMat[5];
    //    main_char.botBikinis.GetComponent<SkinnedMeshRenderer>().material = particle_bikinis.bikBotMat[5];
    //}

    /*public void ChangeChar()
    {
        if (PlayerPrefs.GetInt("character1") == 1 && PlayerPrefs.GetInt("character2") == 0)
        {
            main_char.coat.GetComponent<SkinnedMeshRenderer>().material = characters_set_material.Coat[1];
            //main_char.glove_L.GetComponent<SkinnedMeshRenderer>().material = characters_set_material.Gloves[1];
            //main_char.glove_R.GetComponent<SkinnedMeshRenderer>().material = characters_set_material.Gloves[1];
            main_char.top.GetComponent<SkinnedMeshRenderer>().material = characters_set_material.Top[1];
            main_char.skirt.GetComponent<SkinnedMeshRenderer>().material = characters_set_material.Skirt[1];
            main_char.hair.GetComponent<MeshRenderer>().material = characters_set_material.Hairmat[1];
            PlayerPrefs.SetInt("character2", 1);
        }
        else if (PlayerPrefs.GetInt("character1") == 1 && PlayerPrefs.GetInt("character2") == 1 && PlayerPrefs.GetInt("character3") == 0)
        {
            main_char.coat.GetComponent<SkinnedMeshRenderer>().material = characters_set_material.Coat[2];
            //main_char.glove_L.GetComponent<SkinnedMeshRenderer>().material = characters_set_material.Gloves[2];
            //main_char.glove_R.GetComponent<SkinnedMeshRenderer>().material = characters_set_material.Gloves[2];
            main_char.top.GetComponent<SkinnedMeshRenderer>().material = characters_set_material.Top[2];
            main_char.skirt.GetComponent<SkinnedMeshRenderer>().material = characters_set_material.Skirt[2];
            main_char.hair.GetComponent<MeshRenderer>().material = characters_set_material.Hairmat[2];
            PlayerPrefs.SetInt("character3", 1);
        }
    }*/

}