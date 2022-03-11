
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
public class CountDown : MonoBehaviour
{

    public SwerveInputSystem swerve_input;
    public UImanager UI_manager;
    public MainChar main_char;
    //public CharactersSetMaterial characters_set_material;
    public ParticleBikinis particle_bikinis;
    public GameObject undressContinuebutton;
    public GameObject storeContinueButton;
    public GameObject gameoverContinueButton;
    public GameObject recieved;
    public GameObject rewardin;
    public GameObject texts;
    public GameObject undress;
    public int countdownTime;
    public TextMeshProUGUI countdownDisplay;
    public Touch touch;
    public GameObject get500;
    public GameObject getTwo500;
    public GameObject KeepItContinueButton;
    public GameObject keepItButton;

    //public GameObject surpriseBoxButton;
    //public GameObject surpriseBoxContinueButton;
    //public GameObject surpriseBoxCharImage;
    //public GameObject surpriseBoxAnim;
    //public GameObject surpriseBoxPanelContinueButton;


    public Material topbikini;
    public Material botbikini;
    public Material coat;
    public Material gloveL;
    public Material gloveR;
    public Material skirt;
    public Material top;
    public Material hair;

    public bool isKeepItOnClick = false;


    public GameManager game_manager;
    
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


    }
    
    //public void Undress()
    //{
    //    if (isUndressOpen == false)
    //    {
    //        main_char.sound_manager.SoundPlay(4);
    //        countdownTime = 10;
    //        countdownDisplay.text = countdownTime.ToString();
    //        //DOTween.Pause("parentween");
    //        this.gameObject.SetActive(true);
    //        StartCoroutine(CountdownsTextUndress());
    //        undress.SetActive(false);
    //        isUndressOpen = true;
    //        main_char.isStopped = true; main_char.swerveAmount = 0;
    //        swerve_input.finish = false;
    //        main_char.swerveAmount = 0;
    //    }

    //}
    public void GameOverAd()
    {

    }
    public void AdButtonAfterGameOver()
    {
        main_char.sound_manager.SoundPlay(4);
        main_char.isStopped = true; main_char.swerveAmount = 0;
        main_char.swerve_InputSystem.finish = false;
        main_char.swerveAmount = 0;
        //countdownTime = 10;
        //countdownDisplay.text = countdownTime.ToString();
        this.gameObject.SetActive(true);
        //StartCoroutine(CountdownsGameOver());
        UI_manager.HeartCircle.gameObject.SetActive(false);
        //UI_manager.gameover.SetActive(true);
        texts.SetActive(true);
        UI_manager.hotImageBarParent.SetActive(true);
        rewardin.SetActive(true);
        recieved.SetActive(false);


    }
    //public void UndressContinue()
    //{
    //    storeContinueButton.SetActive(false);
    //    main_char.sound_manager.SoundPlay(4);
    //    this.gameObject.SetActive(false);
    //    UI_manager.bar.fillAmount = 0.5f;
    //    UI_manager.colorbar.fillAmount = 0.5f;
    //    main_char.hangerValue = 0.5f;
    //    main_char.coat.SetActive(false);
    //    main_char.glove_R.SetActive(false);
    //    main_char.glove_L.SetActive(false);
    //    main_char.playerAnim.SetBool("Idle", false);
    //    main_char.swerve_InputSystem.touch.phase = TouchPhase.Ended;

    //    main_char.isStopped = false;
    //    swerve_input.finish = true;
        



    //}
    public void GamoverContinueButton()
    {
        main_char.sound_manager.SoundPlay(4);
        UI_manager.HeartCircle.fillAmount = 1;
        this.gameObject.SetActive(false);
        main_char.swerve_InputSystem.touch.phase = TouchPhase.Ended;
        main_char.isStopped = false;
        UI_manager.bar.fillAmount = 0.3750f;
        UI_manager.colorbar.fillAmount = 0.6250f;

        main_char.hangerValue = 0.6250f;
        main_char.coat.SetActive(false);
        main_char.glove_R.SetActive(false);
        main_char.glove_L.SetActive(false);
        main_char.boat_L.SetActive(false);
        main_char.boat_R.SetActive(false);
        main_char.beret.SetActive(false);
        main_char.playerAnim.SetBool("fall", false);
        
        main_char.playerAnim.SetBool("Idle", false);
        UI_manager.HeartCircle.fillAmount = 0;
        main_char.playerAnim.speed = 1;
        main_char.swerve_InputSystem.touch.phase = TouchPhase.Ended;
        swerve_input.finish = true;
        main_char.swerveSpeed = 0.3f;
        UI_manager.gameover.SetActive(false);
        gameoverContinueButton.SetActive(false);

    }
    public void storeContinue()
    {
        main_char.sound_manager.SoundPlay(4);
        this.gameObject.SetActive(false);
        storeContinueButton.SetActive(false);
        //main_char.swerve_InputSystem.touch.phase = TouchPhase.Ended;
        //main_char.isStopped = false;
        //swerve_input.finish = true;
    }
    //public void Get500()
    //{
    //    main_char.sound_manager.SoundPlay(4);
    //    undressContinuebutton.SetActive(false);

    //    storeContinueButton.SetActive(false);
    //    countdownTime = 10;
    //    countdownDisplay.text = countdownTime.ToString();
    //    this.gameObject.SetActive(true);
    //    StartCoroutine(CountdownsTextStore());
    //    main_char.coins += 500;
    //    UI_manager.coin.text = "" + main_char.coins;
    //    PlayerPrefs.SetInt("mycoin", main_char.coins);
    //    texts.SetActive(true);
    //    rewardin.SetActive(true);
    //    recieved.SetActive(false);
    //}
    //public void GetTwo500()
    //{
    //    main_char.sound_manager.SoundPlay(4);
    //    undressContinuebutton.SetActive(false);

    //    storeContinueButton.SetActive(false);
    //    countdownTime = 10;
    //    countdownDisplay.text = countdownTime.ToString();
    //    this.gameObject.SetActive(true);
    //    StartCoroutine(CountdownsTextStore());
    //    main_char.coins += 500;
    //    UI_manager.coin.text = "" + main_char.coins;
    //    PlayerPrefs.SetInt("mycoin", main_char.coins);
    //    texts.SetActive(true);
    //    rewardin.SetActive(true);
    //    recieved.SetActive(false);

    //}
    //public void Get3x()
    //{
    //    main_char.sound_manager.SoundPlay(4);
    //    undressContinuebutton.SetActive(false);
    //    storeContinueButton.SetActive(false);
    //    countdownTime = 10;
    //    countdownDisplay.text = countdownTime.ToString();
    //    this.gameObject.SetActive(true);
    //    StartCoroutine(CountdownsTextStore());
    //    main_char.collected›nGame = main_char.collected›nGame * 3;
    //    main_char.coins += main_char.collected›nGame;
    //    PlayerPrefs.SetInt("mycoin", main_char.coins);
    //    UI_manager.coin.text = "" + main_char.coins;
    //    UI_manager.get3x.SetActive(false);
    //    texts.SetActive(true);
    //    rewardin.SetActive(true);
    //    recieved.SetActive(false);

    //}
    //public IEnumerator CountdownsTextUndress()
    //{
    //    main_char.swerveAmount = 0;
    //    main_char.swerve_InputSystem.finish = false;
    //    storeContinueButton.SetActive(false);
    //    main_char.isStopped = true; main_char.swerveAmount = 0;


    //    DOTween.Pause("parentween");
    //    for (int i = 1; i < 10; i++)
    //    {
    //        yield return new WaitForSeconds(1f);
    //        countdownTime--;
    //        countdownDisplay.text = countdownTime.ToString();
    //    }

    //    yield return new WaitForSeconds(1f);
    //    undressContinuebutton.SetActive(true);
    //    recieved.SetActive(true);
    //    rewardin.SetActive(false);
    //    texts.SetActive(false);
    //    undress.SetActive(false);
    //}

    IEnumerator CountdownsTextStore()
    {
        //main_char.isStopped = true; main_char.swerveAmount = 0;
        //main_char.swerve_InputSystem.finish = false;
        //main_char.swerveAmount = 0;
        for (int i = 1; i < 10; i++)
        {
            yield return new WaitForSeconds(1f);
            countdownTime--;
            countdownDisplay.text = countdownTime.ToString();
        }

        yield return new WaitForSeconds(1f);
        storeContinueButton.SetActive(true);
        recieved.SetActive(true);
        rewardin.SetActive(false);
        texts.SetActive(false);

    }
    IEnumerator CountdownsGameOver()
    {
        main_char.isStopped = true; main_char.swerveAmount = 0;
        main_char.swerve_InputSystem.finish = false;
        main_char.swerveAmount = 0;
        for (int i = 1; i < 10; i++)
        {
            yield return new WaitForSeconds(1f);
            countdownTime--;
            countdownDisplay.text = countdownTime.ToString();
        }
        yield return new WaitForSeconds(1f);
        gameoverContinueButton.SetActive(true);
        recieved.SetActive(true);
        rewardin.SetActive(false);
        texts.SetActive(false);
        undress.SetActive(false);
    }

    //public void OpenTheFirstBikini()
    //{
    //    main_char.sound_manager.SoundPlay(4);
    //    //UI_manager.FirstBikini.SetActive(false);
    //    //UI_manager.FirstBikiniOpen.SetActive(true);
    //    countdownTime = 10;
    //    countdownDisplay.text = countdownTime.ToString();
    //    this.gameObject.SetActive(true);
    //    StartCoroutine(CountdownsTextStore());
    //    main_char.collected›nGame = main_char.collected›nGame * 3;
    //    main_char.coins += main_char.collected›nGame;
    //    UI_manager.coin.text = "" + main_char.coins;
    //    UI_manager.get3x.SetActive(false);
    //    texts.SetActive(true);
    //    rewardin.SetActive(true);
    //    recieved.SetActive(false);
    //}
    

    //    public void OpenBikiniKeepIt()
    //    {
    //    main_char.sound_manager.SoundPlay(4);
    //    //UI_manager.FirstBikini.SetActive(false);
    //    //UI_manager.FirstBikiniOpen.SetActive(true);
    //    countdownTime = 10;
    //    countdownDisplay.text = countdownTime.ToString();
    //    this.gameObject.SetActive(true);
    //    StartCoroutine(CountdownsKeepIt());
    //    texts.SetActive(true);
    //    rewardin.SetActive(true);
    //    recieved.SetActive(false);
    //    isKeepItOnClick = true;

    //}
    public IEnumerator CountdownsKeepIt()
    {
        main_char.swerveAmount = 0;
        main_char.swerve_InputSystem.finish = false;
        main_char.isStopped = true; main_char.swerveAmount = 0;
        for (int i = 1; i < 10; i++)
        {
            yield return new WaitForSeconds(1f);
            countdownTime--;
            countdownDisplay.text = countdownTime.ToString();
        }

        yield return new WaitForSeconds(1f);
        KeepItContinueButton.SetActive(true);
        keepItButton.SetActive(false);
        recieved.SetActive(true);
        rewardin.SetActive(false);
        texts.SetActive(false);
        keepItButton.SetActive(false);

    }
    public IEnumerator CountdownsAddOpen()
    {
        //main_char.swerveAmount = 0;
        //main_char.swerve_InputSystem.finish = false;
        //main_char.isStopped = true; main_char.swerveAmount = 0;
        for (int i = 1; i < 10; i++)
        {
            yield return new WaitForSeconds(1f);
            countdownTime--;
            countdownDisplay.text = countdownTime.ToString();
        }

        yield return new WaitForSeconds(1f);
        storeContinueButton.SetActive(true);
        recieved.SetActive(true);
        rewardin.SetActive(false);
        texts.SetActive(false);

    }
    //public void KeepItContinue()
    //{
    //    main_char.sound_manager.SoundPlay(4);
    //    UI_manager.keepitPanel.SetActive(false);
    //    UI_manager.fantastictext.SetActive(false);
    //    UI_manager.loseitbutton.SetActive(false);
    //    particle_bikinis.isOpenKeepItPanel = false;
    //    UI_manager.ShineGetOpenPanel2();
    //    this.gameObject.SetActive(false);

    //}

    public IEnumerator CountdownsSurpriseBox()
    {
        main_char.swerveAmount = 0;
        main_char.swerve_InputSystem.finish = false;
        main_char.isStopped = true; main_char.swerveAmount = 0;
        main_char.playerAnim.SetBool("Idle", true);
        main_char.playerAnim.SetBool("Walk", false);
        for (int i = 1; i < 10; i++)
        {
            yield return new WaitForSeconds(1f);
            countdownTime--;
            countdownDisplay.text = countdownTime.ToString();
        }

        yield return new WaitForSeconds(1f);
        UI_manager.surpriseBoxContinueButton.SetActive(true);
        recieved.SetActive(true);
        rewardin.SetActive(false);
        texts.SetActive(false);
        UI_manager.surpriseBoxAnim.GetComponent<Animator>().speed = 1;

    }

}