using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Reflection;
using System;
using GoogleMobileAds.Api;
public class MainChar : MonoBehaviour
{
    public CharactersSetMaterial char_set_mat;
    public DirectPathCreator direct_path;
    public SwerveInputSystem swerve_InputSystem;
    public UImanager UI_manager;
    public PoolJumAndBonusCoin multip;
    public ParentScript speed;
    public CameraFollows cam;
    public SoundManager sound_manager;

    //KARAKTER KIYAFET
    public GameObject glove_L;
    public GameObject glove_R;
    public GameObject instantiate_glove;
    public GameObject coat;
    public GameObject instantiateCoat;
    public GameObject boat_R;
    public GameObject boat_L;
    public GameObject instantiateBoat;
    public GameObject top;
    public GameObject instantiateTop;
    public GameObject beret;
    public GameObject skirt;
    public GameObject instantiateSkirts;
    public GameObject towel;
    public GameObject topBikinis;
    public GameObject botBikinis;
    public GameObject hair1;
    public GameObject hair3;
    public GameObject hair4;
    public GameObject hair5;
    public GameObject hair6;
    public GameObject hair8;
    public GameObject hair9;
    public GameObject hair10;


    public GameObject bikini1top;
    public GameObject bikini1bot;
    public GameObject bikini4;


    //KAYDIRMA 
    public float swerveSpeed = 0.3f;
    public float hangerValue = 0.25f;
    public float _lastFrameFingerPositionX;
    public float _moveFactorX;


    //AN›MATORLER
    public Animator playerAnim; //player animasyonu 
    public Animator cabinTrue; //kabin animator¸
    public Animator cabinTrueImageAnim;
    public Animator cabinFalse;



    public int coins = 0;
    public int collected›nGame = 0;
    //public int characters1;
    //public int characters2;
    //public int characters3;
    //public int characters4;
    //public int characters5;
    //public int characters6;
    //public int characters7;
    //public int characters8;
    //public int characters9;
    //public int characters10;

    public Vector3 rot;

    public ParticleSystem flare;
    public ParticleSystem endGameConfettiEffect;
    public ParticleSystem smoke;








    public int MyScoreRanks = 0;

    public GameObject maincamera;
    public GameObject camera2;
    public GameObject CMcamera3xToTurn;
    public GameObject CMcamera4xToTurn;
    public GameObject CMcamera5xToTurn;
    public GameObject CMmainFollowCam;




    public GameObject bonusCoin;

    public float maxSwerveAmount = 2f;
    public float minSwerveAmount = -2f;
    public bool isStopped = false;

    // KARAKTER DE–›ﬁ›KL›–› ›«›N KULLANDI–IM L›STELER
    public List<GameObject> PictureGreen = new List<GameObject>();
    public List<GameObject> BackGround = new List<GameObject>();
    public List<GameObject> CharImage = new List<GameObject>();

    // B›K›N› ›«›N KULLANDI–IM L›STELER

    public List<GameObject> BackGroundBikini = new List<GameObject>();
    public List<GameObject> BikiniImage = new List<GameObject>();
    public List<GameObject> BlueBackGround = new List<GameObject>();

    public List<GameObject> MainCharBikinis = new List<GameObject>();
    public Touch touch;

    public void Start()
    {
        GameObject soundmanager = GameObject.Find("Sound Manager");
        sound_manager = soundmanager.GetComponent<SoundManager>();
        sound_manager.GetComponent<SoundManager>();
        StartCoroutine(sound_manager.addSoundScript());
        MyScoreRanks = 0;
        charOpen();
        CharBikiniOpen();
        CharImageOpen();
        BikiniOpen();
        AddBikiniOpenToBikini();

        hangerValue = 0.25f;
        print("startAfterErrorMesage");
        //characters1 = PlayerPrefs.GetInt("char1",0);
        //characters2 = PlayerPrefs.GetInt("char2",0);
        //characters3 = PlayerPrefs.GetInt("char3",0);
        //characters4 = PlayerPrefs.GetInt("char4",0);
        //characters5 = PlayerPrefs.GetInt("char5",0);
        //characters6 = PlayerPrefs.GetInt("char6",0);
        //characters7 = PlayerPrefs.GetInt("char7",0);
        //characters8 = PlayerPrefs.GetInt("char8",0);
        //characters9 = PlayerPrefs.GetInt("char9", 0);
        //characters10 = PlayerPrefs.GetInt("char10", 0);
        UI_manager.coin.text = PlayerPrefs.GetInt("mycoin").ToString();
        coins = PlayerPrefs.GetInt("mycoin");
        DOTween.Pause("parentween");
        AdRequest request = new AdRequest.Builder().Build();
        swerve_InputSystem = GetComponent<SwerveInputSystem>();
        UI_manager.game_manager.RequestGecis();
        RequestGecisVideo();
        if (PlayerPrefs.GetInt("restartValue") >= 3 && (PlayerPrefs.GetInt("ReklamlarKapali") == 0))
        {
            RestartOnOpen();
            //rewardedAd.LoadAd(request);
        }
        UI_manager.game_manager.timer.gameObject.SetActive(true);
    }
    public float swerveAmount;

    public void Update()
    {
        if (UI_manager.bar.fillAmount == 1)
        {
            UI_manager.GameOver();
        }
        swerveAmount = Time.deltaTime * swerveSpeed * swerve_InputSystem._moveFactorX;
        swerveAmount = Mathf.Clamp(swerveAmount, minSwerveAmount, maxSwerveAmount);
        this.transform.localPosition = new Vector3(Mathf.Clamp(transform.localPosition.x, -2, 2), transform.localPosition.y, transform.localPosition.z);
        transform.Translate(swerveAmount, 0, 0);

        //if ((swerve_InputSystem.touch.phase == TouchPhase.Moved ||swerve_InputSystem.touch.phase == TouchPhase.Stationary )&&isStopped)
        //{
        //    print("mainchartouch");
        //    DOTween.Play("parentween");
        //    isStopped = false;

        //}

        //else if (/*Input.GetMouseButtonUp(0)*/ swerve_InputSystem.touch.phase == TouchPhase.Ended && !isStopped) 
        //{
        //    print("isStopFalse");
        //    DOTween.Pause("parentween");
        //    isStopped = true;
        //}
        if (isStopped == true)
        {
            DOTween.Pause("parentween");

        }
        else if (isStopped == false && (swerve_InputSystem.touch.phase == TouchPhase.Moved || swerve_InputSystem.touch.phase == TouchPhase.Stationary))
        {
            DOTween.Play("parentween");
            playerAnim.SetBool("Walk", true);
            playerAnim.SetBool("Idle", false);


        }


    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "obstacle")
        {
            swerve_InputSystem.touch.phase = TouchPhase.Ended;
            // DOTween.Play("parentween");
            isStopped = false;

            swerveSpeed = 0.3f;

            print("obstacleExit");
        }
    }
    public void charOpen()
    {
        if (PlayerPrefs.GetInt("currentCharacter") == 1)
        {
            hair8.SetActive(false);
            hair6.SetActive(false);
            hair5.SetActive(false);
            hair4.SetActive(false);
            hair3.SetActive(false);
            hair1.SetActive(true);
            PictureGreen[9].SetActive(false);
            PictureGreen[8].SetActive(false);
            PictureGreen[7].SetActive(false);
            PictureGreen[6].SetActive(false);
            PictureGreen[5].SetActive(false);
            PictureGreen[4].SetActive(false);
            PictureGreen[3].SetActive(false);
            PictureGreen[2].SetActive(false);
            PictureGreen[1].SetActive(false);
            PictureGreen[0].SetActive(true);
            coat.GetComponent<SkinnedMeshRenderer>().material = char_set_mat.Coat[0];
            top.GetComponent<SkinnedMeshRenderer>().material = char_set_mat.Top[0];
            skirt.GetComponent<SkinnedMeshRenderer>().material = char_set_mat.Skirt[0];
            hair1.GetComponent<MeshRenderer>().material = char_set_mat.Hairmat[0];
            instantiateSkirts.GetComponent<SkinnedMeshRenderer>().material = char_set_mat.Skirt[0];
            instantiateTop.GetComponent<SkinnedMeshRenderer>().material = char_set_mat.Top[0];
            instantiateCoat.GetComponent<SkinnedMeshRenderer>().material = char_set_mat.Coat[0];

        }
        else if (PlayerPrefs.GetInt("currentCharacter") == 2)
        {
            hair8.SetActive(false);
            hair6.SetActive(false);
            hair5.SetActive(false);
            hair4.SetActive(false);
            hair3.SetActive(false);
            hair1.SetActive(true);
            PictureGreen[9].SetActive(false);
            PictureGreen[8].SetActive(false);
            PictureGreen[7].SetActive(false);
            PictureGreen[6].SetActive(false);
            PictureGreen[5].SetActive(false);
            PictureGreen[4].SetActive(false);
            PictureGreen[3].SetActive(false);
            PictureGreen[2].SetActive(false);
            PictureGreen[1].SetActive(true);
            PictureGreen[0].SetActive(false);
            BackGround[0].SetActive(false);
            CharImage[0].SetActive(true);
            coat.GetComponent<SkinnedMeshRenderer>().material = char_set_mat.Coat[1];
            top.GetComponent<SkinnedMeshRenderer>().material = char_set_mat.Top[1];
            skirt.GetComponent<SkinnedMeshRenderer>().material = char_set_mat.Skirt[1];
            hair1.GetComponent<MeshRenderer>().material = char_set_mat.Hairmat[1];
            instantiateSkirts.GetComponent<SkinnedMeshRenderer>().material = char_set_mat.Skirt[1];
            instantiateTop.GetComponent<SkinnedMeshRenderer>().material = char_set_mat.Top[1];
            instantiateCoat.GetComponent<SkinnedMeshRenderer>().material = char_set_mat.Coat[1];

        }
        else if (PlayerPrefs.GetInt("currentCharacter") == 3)
        {
            hair8.SetActive(false);
            hair6.SetActive(false);
            hair5.SetActive(false);
            hair4.SetActive(false);
            hair3.SetActive(true);
            hair1.SetActive(false);
            PictureGreen[9].SetActive(false);
            PictureGreen[8].SetActive(false);
            PictureGreen[7].SetActive(false);
            PictureGreen[6].SetActive(false);
            PictureGreen[5].SetActive(false);
            PictureGreen[4].SetActive(false);
            PictureGreen[3].SetActive(false);
            PictureGreen[2].SetActive(true);
            PictureGreen[1].SetActive(false);
            PictureGreen[0].SetActive(false);
            BackGround[1].SetActive(false);
            CharImage[1].SetActive(true);

            coat.GetComponent<SkinnedMeshRenderer>().material = char_set_mat.Coat[2];
            top.GetComponent<SkinnedMeshRenderer>().material = char_set_mat.Top[2];
            skirt.GetComponent<SkinnedMeshRenderer>().material = char_set_mat.Skirt[2];
            hair3.GetComponent<MeshRenderer>().material = char_set_mat.Hairmat[2];
            instantiateSkirts.GetComponent<SkinnedMeshRenderer>().material = char_set_mat.Skirt[2];
            instantiateTop.GetComponent<SkinnedMeshRenderer>().material = char_set_mat.Top[2];
            instantiateCoat.GetComponent<SkinnedMeshRenderer>().material = char_set_mat.Coat[2];
        }
        else if (PlayerPrefs.GetInt("currentCharacter") == 4)
        {
            hair8.SetActive(false);
            hair6.SetActive(false);
            hair5.SetActive(false);
            hair4.SetActive(true);
            hair3.SetActive(false);
            hair1.SetActive(false);
            PictureGreen[9].SetActive(false);
            PictureGreen[8].SetActive(false);
            PictureGreen[7].SetActive(false);
            PictureGreen[6].SetActive(false);
            PictureGreen[5].SetActive(false);
            PictureGreen[4].SetActive(false);
            PictureGreen[3].SetActive(true);
            PictureGreen[2].SetActive(false);
            PictureGreen[1].SetActive(false);
            PictureGreen[0].SetActive(false); BackGround[2].SetActive(false); CharImage[2].SetActive(true);
            coat.GetComponent<SkinnedMeshRenderer>().material = char_set_mat.Coat[3];
            top.GetComponent<SkinnedMeshRenderer>().material = char_set_mat.Top[3];
            skirt.GetComponent<SkinnedMeshRenderer>().material = char_set_mat.Skirt[3];
            hair4.GetComponent<MeshRenderer>().material = char_set_mat.Hairmat[3];
            instantiateSkirts.GetComponent<SkinnedMeshRenderer>().material = char_set_mat.Skirt[3];
            instantiateTop.GetComponent<SkinnedMeshRenderer>().material = char_set_mat.Top[3];
            instantiateCoat.GetComponent<SkinnedMeshRenderer>().material = char_set_mat.Coat[3];
        }
        else if (PlayerPrefs.GetInt("currentCharacter") == 5)
        {
            hair8.SetActive(false);
            hair6.SetActive(false);
            hair5.SetActive(true);
            hair4.SetActive(false);
            hair3.SetActive(false);
            hair1.SetActive(false);
            PictureGreen[9].SetActive(false);
            PictureGreen[8].SetActive(false);
            PictureGreen[7].SetActive(false);
            PictureGreen[6].SetActive(false);
            PictureGreen[5].SetActive(false);
            PictureGreen[4].SetActive(true);
            PictureGreen[3].SetActive(false);
            PictureGreen[2].SetActive(false);
            PictureGreen[1].SetActive(false);
            PictureGreen[0].SetActive(false); BackGround[3].SetActive(false); CharImage[3].SetActive(true);
            coat.GetComponent<SkinnedMeshRenderer>().material = char_set_mat.Coat[4];
            top.GetComponent<SkinnedMeshRenderer>().material = char_set_mat.Top[4];
            skirt.GetComponent<SkinnedMeshRenderer>().material = char_set_mat.Skirt[4];
            hair5.GetComponent<MeshRenderer>().material = char_set_mat.Hairmat[4];
            instantiateSkirts.GetComponent<SkinnedMeshRenderer>().material = char_set_mat.Skirt[4];
            instantiateTop.GetComponent<SkinnedMeshRenderer>().material = char_set_mat.Top[4];
            instantiateCoat.GetComponent<SkinnedMeshRenderer>().material = char_set_mat.Coat[4];
        }
        else if (PlayerPrefs.GetInt("currentCharacter") == 6)
        {
            hair8.SetActive(false);
            hair6.SetActive(true);
            hair5.SetActive(false);
            hair4.SetActive(false);
            hair3.SetActive(false);
            hair1.SetActive(false);
            PictureGreen[9].SetActive(false);
            PictureGreen[8].SetActive(false);
            PictureGreen[7].SetActive(false);
            PictureGreen[6].SetActive(false);
            PictureGreen[5].SetActive(true);
            PictureGreen[4].SetActive(false);
            PictureGreen[3].SetActive(false);
            PictureGreen[2].SetActive(false);
            PictureGreen[1].SetActive(false);
            PictureGreen[0].SetActive(false); BackGround[4].SetActive(false); CharImage[4].SetActive(true);
            coat.GetComponent<SkinnedMeshRenderer>().material = char_set_mat.Coat[5];
            top.GetComponent<SkinnedMeshRenderer>().material = char_set_mat.Top[5];
            skirt.GetComponent<SkinnedMeshRenderer>().material = char_set_mat.Skirt[5];
            hair6.GetComponent<MeshRenderer>().material = char_set_mat.Hairmat[5];
            instantiateSkirts.GetComponent<SkinnedMeshRenderer>().material = char_set_mat.Skirt[5];
            instantiateTop.GetComponent<SkinnedMeshRenderer>().material = char_set_mat.Top[5];
            instantiateCoat.GetComponent<SkinnedMeshRenderer>().material = char_set_mat.Coat[5];
        }
        else if (PlayerPrefs.GetInt("currentCharacter") == 7)
        {
            hair8.SetActive(false);
            hair6.SetActive(false);
            hair5.SetActive(false);
            hair4.SetActive(false);
            hair3.SetActive(false);
            hair1.SetActive(true);
            PictureGreen[9].SetActive(false);
            PictureGreen[8].SetActive(false);
            PictureGreen[7].SetActive(false);
            PictureGreen[6].SetActive(true);
            PictureGreen[5].SetActive(false);
            PictureGreen[4].SetActive(false);
            PictureGreen[3].SetActive(false);
            PictureGreen[2].SetActive(false);
            PictureGreen[1].SetActive(false);
            PictureGreen[0].SetActive(false); BackGround[5].SetActive(false); CharImage[5].SetActive(true);
            coat.GetComponent<SkinnedMeshRenderer>().material = char_set_mat.Coat[6];
            top.GetComponent<SkinnedMeshRenderer>().material = char_set_mat.Top[6];
            skirt.GetComponent<SkinnedMeshRenderer>().material = char_set_mat.Skirt[6];
            hair1.GetComponent<MeshRenderer>().material = char_set_mat.Hairmat[6];
            instantiateSkirts.GetComponent<SkinnedMeshRenderer>().material = char_set_mat.Skirt[6];
            instantiateTop.GetComponent<SkinnedMeshRenderer>().material = char_set_mat.Top[6];
            instantiateCoat.GetComponent<SkinnedMeshRenderer>().material = char_set_mat.Coat[6];
        }
        else if (PlayerPrefs.GetInt("currentCharacter") == 8)
        {
            hair8.SetActive(true);
            hair6.SetActive(false);
            hair5.SetActive(false);
            hair4.SetActive(false);
            hair3.SetActive(false);
            hair1.SetActive(false);
            PictureGreen[9].SetActive(false);
            PictureGreen[8].SetActive(false);
            PictureGreen[7].SetActive(true);
            PictureGreen[6].SetActive(false);
            PictureGreen[5].SetActive(false);
            PictureGreen[4].SetActive(false);
            PictureGreen[3].SetActive(false);
            PictureGreen[2].SetActive(false);
            PictureGreen[1].SetActive(false);
            PictureGreen[0].SetActive(false); BackGround[6].SetActive(false); CharImage[6].SetActive(true);
            coat.GetComponent<SkinnedMeshRenderer>().material = char_set_mat.Coat[7];
            top.GetComponent<SkinnedMeshRenderer>().material = char_set_mat.Top[7];
            skirt.GetComponent<SkinnedMeshRenderer>().material = char_set_mat.Skirt[7];
            hair8.GetComponent<MeshRenderer>().material = char_set_mat.Hairmat[7];
            instantiateSkirts.GetComponent<SkinnedMeshRenderer>().material = char_set_mat.Skirt[7];
            instantiateTop.GetComponent<SkinnedMeshRenderer>().material = char_set_mat.Top[7];
            instantiateCoat.GetComponent<SkinnedMeshRenderer>().material = char_set_mat.Coat[7];
        }
        else if (PlayerPrefs.GetInt("currentCharacter") == 9)
        {
            hair8.SetActive(true);
            hair6.SetActive(false);
            hair5.SetActive(false);
            hair4.SetActive(false);
            hair3.SetActive(false);
            hair1.SetActive(false);
            PictureGreen[9].SetActive(false);
            PictureGreen[8].SetActive(true);
            PictureGreen[7].SetActive(false);
            PictureGreen[6].SetActive(false);
            PictureGreen[5].SetActive(false);
            PictureGreen[4].SetActive(false);
            PictureGreen[3].SetActive(false);
            PictureGreen[2].SetActive(false);
            PictureGreen[1].SetActive(false);
            PictureGreen[0].SetActive(false); BackGround[7].SetActive(false); CharImage[7].SetActive(true);
            coat.GetComponent<SkinnedMeshRenderer>().material = char_set_mat.Coat[8];
            top.GetComponent<SkinnedMeshRenderer>().material = char_set_mat.Top[8];
            skirt.GetComponent<SkinnedMeshRenderer>().material = char_set_mat.Skirt[8];
            hair8.GetComponent<MeshRenderer>().material = char_set_mat.Hairmat[8];
            instantiateSkirts.GetComponent<SkinnedMeshRenderer>().material = char_set_mat.Skirt[8];
            instantiateTop.GetComponent<SkinnedMeshRenderer>().material = char_set_mat.Top[8];
            instantiateCoat.GetComponent<SkinnedMeshRenderer>().material = char_set_mat.Coat[8];
        }
        else if (PlayerPrefs.GetInt("currentCharacter") == 10)
        {
            hair8.SetActive(true);
            hair6.SetActive(false);
            hair5.SetActive(false);
            hair4.SetActive(false);
            hair3.SetActive(false);
            hair1.SetActive(false);
            PictureGreen[9].SetActive(true);
            PictureGreen[8].SetActive(false);
            PictureGreen[7].SetActive(false);
            PictureGreen[6].SetActive(false);
            PictureGreen[5].SetActive(false);
            PictureGreen[4].SetActive(false);
            PictureGreen[3].SetActive(false);
            PictureGreen[2].SetActive(false);
            PictureGreen[1].SetActive(false);
            PictureGreen[0].SetActive(false); BackGround[8].SetActive(false); CharImage[8].SetActive(true);
            coat.GetComponent<SkinnedMeshRenderer>().material = char_set_mat.Coat[9];
            top.GetComponent<SkinnedMeshRenderer>().material = char_set_mat.Top[9];
            skirt.GetComponent<SkinnedMeshRenderer>().material = char_set_mat.Skirt[9];
            hair8.GetComponent<MeshRenderer>().material = char_set_mat.Hairmat[9];
            instantiateSkirts.GetComponent<SkinnedMeshRenderer>().material = char_set_mat.Skirt[9];
            instantiateTop.GetComponent<SkinnedMeshRenderer>().material = char_set_mat.Top[9];
            instantiateCoat.GetComponent<SkinnedMeshRenderer>().material = char_set_mat.Coat[9];
        }
    }
    public void CharImageOpen()
    {
        if (PlayerPrefs.GetInt("charImage2") == 1)
        {
            print("char2");
            CharImage[0].SetActive(true);
        }
        if (PlayerPrefs.GetInt("charImage3") == 1)
        {
            print("char3");
            CharImage[1].SetActive(true);
        }
        if (PlayerPrefs.GetInt("charImage4") == 1)
        {
            print("char4");
            CharImage[2].SetActive(true);
        }
        if (PlayerPrefs.GetInt("charImage5") == 1)
        {
            print("char5");
            CharImage[3].SetActive(true);
        }
        if (PlayerPrefs.GetInt("charImage6") == 1)
        {
            print("char6");
            CharImage[4].SetActive(true);
        }
        if (PlayerPrefs.GetInt("charImage7") == 1)
        {
            print("char7");
            CharImage[5].SetActive(true);
        }
        if (PlayerPrefs.GetInt("charImage8") == 1)
        {
            print("char8");
            CharImage[6].SetActive(true);
        }
        if (PlayerPrefs.GetInt("charImage9") == 1)
        {
            CharImage[7].SetActive(true);
        }
        if (PlayerPrefs.GetInt("charImage10") == 1)
        {
            CharImage[8].SetActive(true);
        }

    }
    public void CharBikiniOpen()
    {
        if (PlayerPrefs.GetInt("currentBikini") == 1)
        {
            MainCharBikinis[1].SetActive(true);
            MainCharBikinis[2].SetActive(false);
            MainCharBikinis[3].SetActive(false);
            MainCharBikinis[4].SetActive(false);
            MainCharBikinis[5].SetActive(false);
            MainCharBikinis[6].SetActive(false);
            BlueBackGround[5].SetActive(false);
            BlueBackGround[4].SetActive(false);
            BlueBackGround[3].SetActive(false);
            BlueBackGround[2].SetActive(false);
            BlueBackGround[1].SetActive(false);
            BlueBackGround[0].SetActive(true);
            BackGroundBikini[0].SetActive(false);
            BikiniImage[0].SetActive(true);

        }
        else if (PlayerPrefs.GetInt("currentBikini") == 2)
        {
            MainCharBikinis[1].SetActive(false);
            MainCharBikinis[2].SetActive(true);
            MainCharBikinis[3].SetActive(false);
            MainCharBikinis[4].SetActive(false);
            MainCharBikinis[5].SetActive(false);
            MainCharBikinis[6].SetActive(false);
            BlueBackGround[5].SetActive(false);
            BlueBackGround[4].SetActive(false);
            BlueBackGround[3].SetActive(false);
            BlueBackGround[2].SetActive(false);
            BlueBackGround[1].SetActive(true);
            BlueBackGround[0].SetActive(false);
            BackGroundBikini[1].SetActive(false);
            BikiniImage[1].SetActive(true);

        }
        else if (PlayerPrefs.GetInt("currentBikini") == 3)
        {
            MainCharBikinis[1].SetActive(false);
            MainCharBikinis[2].SetActive(false);
            MainCharBikinis[3].SetActive(true);
            MainCharBikinis[4].SetActive(false);
            MainCharBikinis[5].SetActive(false);
            MainCharBikinis[6].SetActive(false);
            BlueBackGround[5].SetActive(false);
            BlueBackGround[4].SetActive(false);
            BlueBackGround[3].SetActive(false);
            BlueBackGround[2].SetActive(true);
            BlueBackGround[1].SetActive(false);
            BlueBackGround[0].SetActive(false);
            BackGroundBikini[2].SetActive(false);
            BikiniImage[2].SetActive(true);
        }
        else if (PlayerPrefs.GetInt("currentBikini") == 4)
        {
            MainCharBikinis[1].SetActive(false);
            MainCharBikinis[2].SetActive(false);
            MainCharBikinis[3].SetActive(false);
            MainCharBikinis[4].SetActive(true);
            MainCharBikinis[5].SetActive(false);
            MainCharBikinis[6].SetActive(false);
            BlueBackGround[5].SetActive(false);
            BlueBackGround[4].SetActive(false);
            BlueBackGround[3].SetActive(true);
            BlueBackGround[2].SetActive(false);
            BlueBackGround[1].SetActive(false);
            BlueBackGround[0].SetActive(false);
            BackGroundBikini[3].SetActive(false);
            BikiniImage[3].SetActive(true);
        }
        else if (PlayerPrefs.GetInt("currentBikini") == 5)
        {
            MainCharBikinis[1].SetActive(false);
            MainCharBikinis[2].SetActive(false);
            MainCharBikinis[3].SetActive(false);
            MainCharBikinis[4].SetActive(false);
            MainCharBikinis[5].SetActive(true);
            MainCharBikinis[6].SetActive(false);
            BlueBackGround[5].SetActive(false);
            BlueBackGround[4].SetActive(true);
            BlueBackGround[3].SetActive(false);
            BlueBackGround[2].SetActive(false);
            BlueBackGround[1].SetActive(false);
            BlueBackGround[0].SetActive(false);
            BackGroundBikini[4].SetActive(false);
            BikiniImage[4].SetActive(true);
        }
        else if (PlayerPrefs.GetInt("currentBikini") == 6)
        {
            MainCharBikinis[1].SetActive(false);
            MainCharBikinis[2].SetActive(false);
            MainCharBikinis[3].SetActive(false);
            MainCharBikinis[4].SetActive(false);
            MainCharBikinis[5].SetActive(false);
            MainCharBikinis[6].SetActive(true);
            BlueBackGround[5].SetActive(true);
            BlueBackGround[4].SetActive(false);
            BlueBackGround[3].SetActive(false);
            BlueBackGround[2].SetActive(false);
            BlueBackGround[1].SetActive(false);
            BlueBackGround[0].SetActive(false);
            BackGroundBikini[5].SetActive(false);
            BikiniImage[5].SetActive(true);
        }
    }
    public void AddBikiniOpenToBikini()
    {
        if (PlayerPrefs.GetInt("Bikini1") == 1)
        {
            BackGroundBikini[0].SetActive(false);
            BikiniImage[0].SetActive(true);

        }
        if (PlayerPrefs.GetInt("Bikini2") == 1)
        {
            BackGroundBikini[1].SetActive(false);
            BikiniImage[1].SetActive(true);

        }
        if (PlayerPrefs.GetInt("Bikini3") == 1)
        {
            BackGroundBikini[2].SetActive(false);
            BikiniImage[2].SetActive(true);
        }
        if (PlayerPrefs.GetInt("Bikini4") == 1)
        {
            BackGroundBikini[3].SetActive(false);
            BikiniImage[3].SetActive(true);
        }
        if (PlayerPrefs.GetInt("Bikini5") == 1)
        {
            BackGroundBikini[4].SetActive(false);
            BikiniImage[4].SetActive(true);
        }
        if (PlayerPrefs.GetInt("Bikini6") == 1)
        {
            BackGroundBikini[5].SetActive(false);
            BikiniImage[5].SetActive(true);
        }
    }
    public void BikiniOpen()
    {
        if (PlayerPrefs.GetInt("currentBikini") == 1)
        {
            MainCharBikinis[0].SetActive(false);
            MainCharBikinis[1].SetActive(true);
            MainCharBikinis[2].SetActive(false);
            MainCharBikinis[3].SetActive(false);
            MainCharBikinis[4].SetActive(false);
            MainCharBikinis[5].SetActive(false);
            MainCharBikinis[6].SetActive(false);
            BlueBackGround[5].SetActive(false);
            BlueBackGround[4].SetActive(false);
            BlueBackGround[3].SetActive(false);
            BlueBackGround[2].SetActive(false);
            BlueBackGround[1].SetActive(false);
            BlueBackGround[0].SetActive(true);
            BackGroundBikini[0].SetActive(false);
            BikiniImage[0].SetActive(true);
        }
        else if (PlayerPrefs.GetInt("currentBikini") == 2)
        {
            MainCharBikinis[0].SetActive(false);
            MainCharBikinis[1].SetActive(false);
            MainCharBikinis[2].SetActive(true);
            MainCharBikinis[3].SetActive(false);
            MainCharBikinis[4].SetActive(false);
            MainCharBikinis[5].SetActive(false);
            MainCharBikinis[6].SetActive(false);
            BlueBackGround[5].SetActive(false);
            BlueBackGround[4].SetActive(false);
            BlueBackGround[3].SetActive(false);
            BlueBackGround[2].SetActive(false);
            BlueBackGround[1].SetActive(true);
            BlueBackGround[0].SetActive(false);
            BackGroundBikini[1].SetActive(false);
            BikiniImage[1].SetActive(true);
        }
        else if (PlayerPrefs.GetInt("currentBikini") == 3)
        {
            MainCharBikinis[0].SetActive(false);
            MainCharBikinis[1].SetActive(false);
            MainCharBikinis[2].SetActive(false);
            MainCharBikinis[3].SetActive(true);
            MainCharBikinis[4].SetActive(false);
            MainCharBikinis[5].SetActive(false);
            MainCharBikinis[6].SetActive(false);
            BlueBackGround[5].SetActive(false);
            BlueBackGround[4].SetActive(false);
            BlueBackGround[3].SetActive(false);
            BlueBackGround[2].SetActive(true);
            BlueBackGround[1].SetActive(false);
            BlueBackGround[0].SetActive(false);
            BackGroundBikini[2].SetActive(false);
            BikiniImage[2].SetActive(true);
        }
        else if (PlayerPrefs.GetInt("currentBikini") == 4)
        {
            MainCharBikinis[0].SetActive(false);
            MainCharBikinis[1].SetActive(false);
            MainCharBikinis[2].SetActive(false);
            MainCharBikinis[3].SetActive(false);
            MainCharBikinis[4].SetActive(true);
            MainCharBikinis[5].SetActive(false);
            MainCharBikinis[6].SetActive(false);
            BlueBackGround[5].SetActive(false);
            BlueBackGround[4].SetActive(false);
            BlueBackGround[3].SetActive(true);
            BlueBackGround[2].SetActive(false);
            BlueBackGround[1].SetActive(false);
            BlueBackGround[0].SetActive(false);
            BackGroundBikini[3].SetActive(false);
            BikiniImage[3].SetActive(true);
        }
        else if (PlayerPrefs.GetInt("currentBikini") == 5)
        {
            MainCharBikinis[0].SetActive(false);
            MainCharBikinis[1].SetActive(false);
            MainCharBikinis[2].SetActive(false);
            MainCharBikinis[3].SetActive(false);
            MainCharBikinis[4].SetActive(false);
            MainCharBikinis[5].SetActive(true);
            MainCharBikinis[6].SetActive(false);
            BlueBackGround[5].SetActive(false);
            BlueBackGround[4].SetActive(true);
            BlueBackGround[3].SetActive(false);
            BlueBackGround[2].SetActive(false);
            BlueBackGround[1].SetActive(false);
            BlueBackGround[0].SetActive(false);
            BackGroundBikini[4].SetActive(false);
            BikiniImage[4].SetActive(true);
        }
        else if (PlayerPrefs.GetInt("currentBikini") == 6)
        {
            MainCharBikinis[0].SetActive(false);
            MainCharBikinis[1].SetActive(false);
            MainCharBikinis[2].SetActive(false);
            MainCharBikinis[3].SetActive(false);
            MainCharBikinis[4].SetActive(false);
            MainCharBikinis[5].SetActive(false);
            MainCharBikinis[6].SetActive(true);
            BlueBackGround[5].SetActive(true);
            BlueBackGround[4].SetActive(false);
            BlueBackGround[3].SetActive(false);
            BlueBackGround[2].SetActive(false);
            BlueBackGround[1].SetActive(false);
            BlueBackGround[0].SetActive(false);
            BackGroundBikini[5].SetActive(false);
            BikiniImage[5].SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "directPathCreator")
        {
            isStopped = true;
            playerAnim.SetBool("Walk", false);
            swerveSpeed = 0;
            direct_path.isRot = false;
            direct_path.SlideToDirect();
        }

        if (other.tag == "wall")
        {
            print("wall");
            swerveSpeed = 0;
        }

        if (other.tag == "exit")
        {
            swerveSpeed = 0.3f;
        }

        //ENGEL KONTROL‹
        if (other.tag == "obstacle")
        {
            //DOTween.Pause("parentween");
            isStopped = true;
            print("obstacleEntry");
        }



        //CO›N TOPLAMA
        if (other.tag == "coin")
        {
            sound_manager.VibrationPlay();
            sound_manager.SoundPlay(6);
            collected›nGame++;
            coins++;
            UI_manager.coin.text = "" + coins;
            //PlayerPrefs.SetInt("mycoin",coins);
        }

        //B›T›ﬁTE YAZI MI «IKACAK YOKSA MERD›VEN M› «IKACAK
        if (other.tag == "stairs" && hangerValue < 0.8750f)
        {
            other.gameObject.GetComponent<BoxCollider>().enabled = false;
            print("girdi");
            DOTween.Kill("parentween");
            UI_manager.complated.SetActive(true);
            StartCoroutine(UI_manager.printText());
            if (UI_manager.game_manager.sceneToContinue == 1)
            {
                UI_manager.textNoInPool.SetActive(true);
            }

            endGameConfettiEffect.Play();
            cam.cameraKapatVeB¸y¸t();
            isStopped = true;
            swerveAmount = 0;
            swerve_InputSystem.finish = false;
            swerveAmount = 0;
            swerveSpeed = 0;
            transform.DOLocalRotate(rot, 2f, RotateMode.Fast).SetLoops(1);
            playerAnim.SetLayerWeight(1, 0f);
            StartCoroutine(UI_manager.ShineGetOpenPanel());
            sound_manager.SoundPlay(13);
            playerAnim.SetBool("dance", true);
        }
        else if (other.tag == "stairs" && hangerValue >= 0.875f)
        {
            isStopped = true;
            swerveAmount = 0;
            swerve_InputSystem.finish = false;
            swerveAmount = 0;
            swerveSpeed = 0;
            StartCoroutine(ClimbingStairs());
        }



        //ASKI TOPLADI–INDA OLACAKLAR
        if (other.tag == "hanger")
        {
            sound_manager.VibrationPlay();
            sound_manager.SoundPlay(10);
            other.gameObject.SetActive(false);
            UI_manager.layer.transform.DOLocalMoveY(-470, 0.0001f);
            UI_manager.layer.SetActive(false);
            UI_manager.colorbar.DOFillAmount(UI_manager.colorbar.fillAmount + 0.03125f, 0.20f);
            hangerValue += 0.03125f;
            UI_manager.layer.SetActive(true);
            UI_manager.layer.transform.DOLocalMoveY(787f, 1f);
            StartCoroutine(layerObjectTurnOff());
            sound_manager.SoundPlay(1);

            UI_manager.bar.DOFillAmount(UI_manager.bar.fillAmount - 0.03125f, 0.20f);
            if (hangerValue == 0.250f)
            {
                beret.SetActive(false);
                flare.Play();
                Instantiate(beret, this.transform.position, Quaternion.identity);
            }
            if (hangerValue == 0.3750f)
            {
                playerAnim.SetBool("GloveOn", true);
                glove_R.SetActive(false);
                glove_L.SetActive(false);
                var glove›nstantiate = Instantiate(instantiate_glove, new Vector3(this.transform.position.x, transform.position.y, this.transform.position.z - 0.5f), Quaternion.Euler(0, 0, 0));
                glove›nstantiate.transform.parent = this.gameObject.transform;
                glove›nstantiate.transform.rotation = this.gameObject.transform.rotation;
                glove›nstantiate.transform.parent = null;

                flare.Play();
                StartCoroutine(GloveOff());
            }
            if (hangerValue == 0.50f)
            {
                playerAnim.SetBool("CoatOn", true);
                coat.SetActive(false);
                UI_manager.textConfident.SetActive(true);
                var glove›nstantiate = Instantiate(instantiateCoat, new Vector3(this.transform.position.x, transform.position.y, this.transform.position.z - 0.5f), Quaternion.identity);
                glove›nstantiate.transform.parent = this.gameObject.transform;
                glove›nstantiate.transform.rotation = this.gameObject.transform.rotation;
                glove›nstantiate.transform.parent = null;
                flare.Play();
                StartCoroutine(CoatOff());
            }
            if (hangerValue == 0.625f)
            {
                boat_R.SetActive(false);
                boat_L.SetActive(false);
                UI_manager.textBubbly.SetActive(true);
                StartCoroutine(CoatOff());
                flare.Play();
                var glove›nstantiate = Instantiate(instantiateBoat, new Vector3(this.transform.position.x - 0.596f, this.transform.position.y, this.transform.position.z - 0.5f), Quaternion.identity);
                glove›nstantiate.transform.parent = this.gameObject.transform;
                glove›nstantiate.transform.rotation = this.gameObject.transform.rotation;
                glove›nstantiate.transform.parent = null;
            }
            if (hangerValue == 0.75f)
            {
                playerAnim.SetBool("CoatOn", true);
                top.SetActive(false);
                UI_manager.sexyImage.SetActive(true);
                StartCoroutine(CoatOff());
                flare.Play();
                var glove›nstantiate = Instantiate(instantiateTop, new Vector3(this.transform.position.x, transform.position.y, this.transform.position.z - 0.3f), Quaternion.identity);
                glove›nstantiate.transform.parent = this.gameObject.transform;
                glove›nstantiate.transform.rotation = this.gameObject.transform.rotation;
                glove›nstantiate.transform.parent = null;
            }
            if (hangerValue == 0.8750f)
            {
                playerAnim.SetBool("CoatOn", true);
                skirt.SetActive(false);
                UI_manager.SpicyImage.SetActive(true);
                StartCoroutine(CoatOff());
                flare.Play();
                var glove›nstantiate = Instantiate(instantiateSkirts, new Vector3(this.transform.position.x, transform.position.y, this.transform.position.z - 0.3f), Quaternion.identity);
                glove›nstantiate.transform.parent = this.gameObject.transform;
                glove›nstantiate.transform.rotation = this.gameObject.transform.rotation;
                glove›nstantiate.transform.parent = null;
            }
            if (hangerValue >= 1.0f)
            {
                //MyScoreRanks++;
                //PlayerPrefs.SetInt("IhaveScore",PlayerPrefs.GetInt("IhaveScore")+1);
                towel.SetActive(true);
                for (int i = 0; i < 6; i++)
                {
                    MainCharBikinis[i].SetActive(false);
                }
                UI_manager.fireAnim.SetActive(true);
                UI_manager.hotImageBarParent.SetActive(true);
                UI_manager.hotText.SetActive(true);
                StartCoroutine(CoatOff());
                UI_manager.redHotCanvas.SetActive(true);
                UI_manager.layer.SetActive(false);

            }
        }


        //HALIYA «ARPINCA OLACAKLAR 
        if (other.tag == "cloth")
        {
            sound_manager.VibrationPlay();
            sound_manager.SoundPlay(5);
            hangerValue -= 0.1250f;
            UI_manager.bar.DOFillAmount(UI_manager.bar.fillAmount + 0.1250f, 0.30f);
            UI_manager.colorbar.DOFillAmount(UI_manager.colorbar.fillAmount - 0.1250f, 0.30f);
            sound_manager.SoundPlay(0);
            playerAnim.SetBool("Hit", true);
            StartCoroutine(Coaton());
            if (hangerValue >= 0.125f && hangerValue < 0.25f)
            {
                UI_manager.textAngry.SetActive(true);
                beret.SetActive(true);
            }
            if (hangerValue >= 0.250f && hangerValue < 0.3750f)
            {
                UI_manager.textAngry.SetActive(true);
                glove_L.SetActive(true);
                glove_R.SetActive(true);

            }
            if (hangerValue >= 0.3750f && hangerValue < 0.490f)
            {
                UI_manager.textAngry.SetActive(true);
                coat.SetActive(true);

            }
            if (hangerValue >= 0.50f && hangerValue < 0.6250f)
            {
                UI_manager.textAngry.SetActive(true);

                boat_L.SetActive(true);
                boat_R.SetActive(true);
            }
            if (hangerValue >= 0.6250f && hangerValue < 0.75)
            {
                UI_manager.textAngry.SetActive(true);
                top.SetActive(true);
            }

        }


        //KAB›NE G›R›NCE OLACAKLAR
        if (other.tag == "cabin")
        {
            other.gameObject.GetComponent<BoxCollider>().enabled = false;
            swerveAmount = 0;
            UI_manager.layer.transform.DOLocalMoveY(-470, 0.0001f);
            UI_manager.layer.SetActive(false);
            hangerValue += 0.1250f;
            UI_manager.layer.SetActive(true);
            UI_manager.layer.transform.DOLocalMoveY(787f, 1f);
            sound_manager.SoundPlay(1);
            StartCoroutine(layerObjectTurnOff());
            UI_manager.colorbar.DOFillAmount(UI_manager.colorbar.fillAmount + 0.125f, 0.2f);
            UI_manager.bar.DOFillAmount(UI_manager.bar.fillAmount - 0.125f, 0.2f);
            playerAnim.SetBool("Idle", true);
            playerAnim.SetBool("Walk", false);
            cabinTrueImageAnim.SetBool("TrueTik", true);
            if (hangerValue >= 1.0f)
            {
                MyScoreRanks++;
                //PlayerPrefs.SetInt("IhaveScore", PlayerPrefs.GetInt("IhaveScore") +1);
                UI_manager.fireAnim.SetActive(true);
                towel.SetActive(true);
                //for (int i = 0; i < 6; i++)
                //{
                //    MainCharBikinis[i].SetActive(false);
                //}
                topBikinis.SetActive(false);
                cabinTrue.SetBool("cabins", true);
                UI_manager.hotImageBarParent.SetActive(true);
                UI_manager.hotText.SetActive(true);
                StartCoroutine(CoatOff());
                UI_manager.redHotCanvas.SetActive(true);
                StartCoroutine(GreenCabin());

            }
            else if (hangerValue >= 0.8750f)
            {
                cabinTrue.SetBool("cabins", true);
                skirt.SetActive(false);
                UI_manager.SpicyImage.SetActive(true);
                StartCoroutine(CoatOff());
                flare.Play();
                var glove›nstantiate = Instantiate(instantiateSkirts, new Vector3(this.transform.position.x, transform.position.y, this.transform.position.z - 0.3f), Quaternion.identity);
                glove›nstantiate.transform.parent = this.gameObject.transform;
                glove›nstantiate.transform.rotation = this.gameObject.transform.rotation;
                glove›nstantiate.transform.parent = null;
                StartCoroutine(GreenCabin());
            }
            else if (hangerValue >= 0.75f)
            {
                cabinTrue.SetBool("cabins", true);
                UI_manager.sexyImage.SetActive(true);
                playerAnim.SetBool("CoatOn", true);
                top.SetActive(false);
                flare.Play();
                var glove›nstantiate = Instantiate(instantiateTop, new Vector3(this.transform.position.x, transform.position.y, this.transform.position.z - 0.3f), Quaternion.identity);
                glove›nstantiate.transform.parent = this.gameObject.transform;
                glove›nstantiate.transform.rotation = this.gameObject.transform.rotation;
                glove›nstantiate.transform.parent = null;
                StartCoroutine(GreenCabin());
            }
            else if (hangerValue >= 0.625f)
            {
                cabinTrue.SetBool("cabins", true);
                boat_L.SetActive(false);
                boat_R.SetActive(false);
                UI_manager.textBubbly.SetActive(true);
                flare.Play();
                var glove›nstantiate = Instantiate(instantiateBoat, new Vector3(this.transform.position.x - 0.696f, this.transform.position.y, this.transform.position.z), Quaternion.identity);
                glove›nstantiate.transform.parent = this.gameObject.transform;
                glove›nstantiate.transform.rotation = this.gameObject.transform.rotation;
                glove›nstantiate.transform.parent = null;
                StartCoroutine(GreenCabin());
            }
            else if (hangerValue >= 0.50f)
            {
                cabinTrue.SetBool("cabins", true);
                playerAnim.SetBool("CoatOn", true);
                coat.SetActive(false);
                flare.Play();
                UI_manager.textConfident.SetActive(true);
                var glove›nstantiate = Instantiate(instantiateCoat, this.transform.position, Quaternion.identity);
                glove›nstantiate.transform.parent = this.gameObject.transform;
                glove›nstantiate.transform.rotation = this.gameObject.transform.rotation;
                glove›nstantiate.transform.parent = null;
                StartCoroutine(GreenCabin());
            }
            else if (hangerValue >= 0.375f)
            {
                cabinTrue.SetBool("cabins", true);
                playerAnim.SetBool("GloveOn", true);
                glove_L.SetActive(false);
                glove_R.SetActive(false);
                flare.Play();
                var glove›nstantiate = Instantiate(instantiate_glove, this.transform.position, Quaternion.identity);
                glove›nstantiate.transform.parent = this.gameObject.transform;
                glove›nstantiate.transform.rotation = this.gameObject.transform.rotation;
                glove›nstantiate.transform.parent = null;
                StartCoroutine(GreenCabin());
            }
            else if (hangerValue >= 0.25f)
            {
                cabinTrue.SetBool("cabins", true);
                beret.SetActive(false);
                flare.Play();
                var glove›nstantiate = Instantiate(beret, this.transform.position, Quaternion.identity);
                glove›nstantiate.transform.parent = this.gameObject.transform;
                glove›nstantiate.transform.rotation = this.gameObject.transform.rotation;
                glove›nstantiate.transform.parent = null;
                StartCoroutine(GreenCabin());
            }
            else if (hangerValue >= 0)
            {
                beret.SetActive(false);
                flare.Play();
                var glove›nstantiate = Instantiate(beret, this.transform.position, Quaternion.identity);
                glove›nstantiate.transform.parent = this.gameObject.transform;
                glove›nstantiate.transform.rotation = this.gameObject.transform.rotation;
                glove›nstantiate.transform.parent = null;
            }
        }

        //YANLIﬁ KAB›NE G›R›NCE OLACAKLAR
        if (other.tag == "cabinLose")
        {
            swerveAmount = 0;
            sound_manager.SoundPlay(0);
            hangerValue -= 0.125f;
            UI_manager.bar.DOFillAmount(UI_manager.bar.fillAmount + 0.125f, 0.2f);
            playerAnim.SetBool("Idle", true);
            playerAnim.SetBool("Walk", false);
            other.gameObject.GetComponent<BoxCollider>().enabled = false;
            if (hangerValue == 0f && hangerValue < 0.12f)
            {
                StartCoroutine(RedCabin());
                cabinFalse.SetBool("redCabin", true);
            }
            else if (hangerValue >= 0.12f && hangerValue < 0.25f)
            {
                StartCoroutine(RedCabin());
                cabinFalse.SetBool("redCabin", true);
                beret.SetActive(true);
            }
            else if (hangerValue >= 0.25f && hangerValue < 0.375)
            {
                StartCoroutine(RedCabin());
                cabinFalse.SetBool("redCabin", true);
                glove_R.SetActive(true);
                glove_L.SetActive(true);
            }
            else if (hangerValue >= 0.375f && hangerValue < 0.50f)
            {
                StartCoroutine(RedCabin());
                cabinFalse.SetBool("redCabin", true);
                coat.SetActive(true);

            }
            else if (hangerValue >= 0.50f && hangerValue < 0.625f)
            {
                StartCoroutine(RedCabin());
                cabinFalse.SetBool("redCabin", true);
                boat_R.SetActive(true);
                boat_L.SetActive(true);
            }
            else if (hangerValue >= 0.625f && hangerValue < 0.75f)
            {
                StartCoroutine(RedCabin());
                cabinFalse.SetBool("redCabin", true);
                top.SetActive(true);
            }
            else if (hangerValue >= 0.750f && hangerValue < 0.8750f)
            {
                StartCoroutine(RedCabin());
                cabinFalse.SetBool("redCabin", true);
                skirt.SetActive(true);
            }

        }
    }
    public IEnumerator layerObjectTurnOff()
    {
        yield return new WaitForSeconds(1f);
        UI_manager.layer.SetActive(false);
    }
    IEnumerator GloveOff()
    {
        yield return new WaitForSeconds(0.2f);
        playerAnim.SetBool("GloveOn", false);
    }
    public IEnumerator CoatOff()
    {
        yield return new WaitForSeconds(0.5f);
        playerAnim.SetBool("CoatOn", false);
        UI_manager.textBubbly.SetActive(false);
        UI_manager.textConfident.SetActive(false);
        UI_manager.hotText.SetActive(false);
        UI_manager.SpicyImage.SetActive(false);
        UI_manager.sexyImage.SetActive(false);
    }
    public IEnumerator Coaton()
    {
        yield return new WaitForSeconds(0.2f);
        playerAnim.SetBool("Hit", false);
        UI_manager.textAngry.SetActive(false);
    }
    public IEnumerator GreenCabin()
    {
        isStopped = true;
        swerveAmount = 0;
        swerve_InputSystem.finish = false;
        swerveAmount = 0;
        swerveSpeed = 0;
        swerve_InputSystem.touch.phase = TouchPhase.Ended;
        yield return new WaitForSeconds(0.5f);
        playerAnim.SetBool("CoatOn", false);
        playerAnim.SetBool("GloveOn", false);
        yield return new WaitForSeconds(0.2f);
        Instantiate(smoke, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z - 0.3f), Quaternion.identity);
        UI_manager.textBubbly.SetActive(false);
        UI_manager.textConfident.SetActive(false);
        playerAnim.SetBool("Idle", true);
        playerAnim.SetBool("Walk", false);
        cabinTrue.SetBool("cabins", false);
        yield return new WaitForSeconds(1.3f);
        isStopped = false;
        playerAnim.SetBool("Idle", false);
        UI_manager.sexyImage.SetActive(false);
        yield return new WaitForSeconds(0.2f);
        swerve_InputSystem.finish = true;
        if (swerve_InputSystem.touch.phase == TouchPhase.Moved || swerve_InputSystem.touch.phase == TouchPhase.Stationary)
        {
            //DOTween.Play("parentween");
            yield return new WaitForSeconds(0.2f);
            //DOTween.Pause("parentween");
            swerveSpeed = 0.3f;
        }
    }
    public IEnumerator GoodBoy()
    {
        yield return new WaitForSeconds(0.5f);
        playerAnim.SetBool("CoatOn", false);
        playerAnim.SetBool("GloveOn", false);
        yield return new WaitForSeconds(0.2f);
        Instantiate(smoke, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z - 0.3f), Quaternion.identity);
        UI_manager.textBubbly.SetActive(false);
        UI_manager.textConfident.SetActive(false);
        yield return new WaitForSeconds(1f);
        UI_manager.sexyImage.SetActive(false);

    }
    public IEnumerator RedCabin()
    {
        isStopped = true;
        swerveAmount = 0;
        swerve_InputSystem.finish = false;
        swerveAmount = 0;
        swerveSpeed = 0;
        swerve_InputSystem.touch.phase = TouchPhase.Ended;
        UI_manager.textAngry.SetActive(true);
        yield return new WaitForSeconds(1f);
        cabinFalse.SetBool("redCabin", false);
        yield return new WaitForSeconds(1.3f);
        isStopped = false;
        playerAnim.SetBool("Idle", false);
        yield return new WaitForSeconds(0.2f);
        swerve_InputSystem.finish = true;
        if (swerve_InputSystem.touch.phase == TouchPhase.Moved || swerve_InputSystem.touch.phase == TouchPhase.Stationary)
        {
            //DOTween.Play("parentween");
            yield return new WaitForSeconds(0.2f);
            //DOTween.Pause("parentween");
            swerveSpeed = 0.3f;
        }
    }
    public GameObject stairPosDown, stairPosUp1, stairPosUp2;
    IEnumerator ClimbingStairs()
    {
        transform.DOMove(stairPosDown.transform.position, 0.1f);
        yield return new WaitForSeconds(0.1f);
        transform.DOMove(stairPosUp1.transform.position, 1f);
        yield return new WaitForSeconds(0.5f);
        transform.DOMove(stairPosUp2.transform.position, 0.5f);
        yield return new WaitForSeconds(0.5f);
        playerAnim.SetBool("dance", true);
        bonusCoin.SetActive(true);
        multip.isJumped = true;
    }




    private InterstitialAd InterGecisReklami;
    private InterstitialAd InterGecisVideoReklami;
    public string AndroidBannerReklamKimligi;
    public string ›osBannerReklamKimligi;
    public string VideoAndroidBannerReklamKimligi;
    public string Video›osBannerReklamKimligi; string reklamId;

    string reklamId2;
    private RewardedAd rewardedAd;
    void RequestRewerdedVideos()
    {
        if (PlayerPrefs.GetInt("ReklamlarKapali") == 0)
        {


            string adUnitId;
#if UNITY_ANDROID
            adUnitId = "ca-app-pub-3940256099942544/5224354917";
#elif UNITY_IPHONE
            adUnitId = "ca-app-pub-3940256099942544/1712485313";
#else
            adUnitId = "unexpected_platform";
#endif

            this.rewardedAd = new RewardedAd(adUnitId);
            AdRequest request = new AdRequest.Builder().Build();
            this.rewardedAd.LoadAd(request);
            this.rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
        }
    }
    public void HandleUserEarnedReward(object sender, Reward args)
    {
        if (isGameOverContButton == false)
        {
            UI_manager.HeartCircle.gameObject.SetActive(false);
            InterGecisVideoReklami.Show();
            UI_manager.main_char.swerve_InputSystem.touch.phase = TouchPhase.Ended;
            UI_manager.main_char.isStopped = false;
            UI_manager.bar.fillAmount = 0.3750f;
            UI_manager.colorbar.fillAmount = 0.6250f;
            UI_manager.main_char.hangerValue = 0.6250f;
            UI_manager.main_char.coat.SetActive(false);
            UI_manager.main_char.glove_R.SetActive(false);
            UI_manager.main_char.glove_L.SetActive(false);
            UI_manager.main_char.boat_L.SetActive(false);
            UI_manager.main_char.boat_R.SetActive(false);
            UI_manager.main_char.beret.SetActive(false);
            UI_manager.main_char.playerAnim.SetBool("fall", false);

            UI_manager.main_char.playerAnim.SetBool("Idle", false);
            UI_manager.HeartCircle.fillAmount = 0;
            UI_manager.main_char.playerAnim.speed = 1;
            UI_manager.main_char.swerve_InputSystem.touch.phase = TouchPhase.Ended;
            UI_manager.swerve_input.finish = true;
            UI_manager.main_char.swerveSpeed = 0.3f;
            UI_manager.gameover.SetActive(false);
            isGameOverContButton = true;
        }
        if (isPressGet500 == true)
        {
            coins += 500;
            UI_manager.coin.text = "" + coins;
            PlayerPrefs.SetInt("mycoin", coins);
            isPressGet500 = false;
        }
        if (isPressGetSecond500 == true)
        {
            coins += 500;
            UI_manager.coin.text = "" + coins;
            PlayerPrefs.SetInt("mycoin", coins);
            isPressGetSecond500 = false;
        }
        if (isPressGet3x == true)
        {
            collected›nGame = collected›nGame * 3;
            coins += collected›nGame;
            PlayerPrefs.SetInt("mycoin", coins);
            UI_manager.coin.text = "" + coins;
            UI_manager.get3x.SetActive(false);
            isPressGet3x = false;
        }
        if (isBikiniKeepIt == true)
        {
            UI_manager.particle_bikinis.isOpenKeepItPanel = false;
            UI_manager.keepitPanel.SetActive(false);
            UI_manager.fantastictext.SetActive(false);
            UI_manager.loseitbutton.SetActive(false);
            UI_manager.ShineGetOpenPanel2();
            swerveAmount = 0;
            swerve_InputSystem.finish = false;
            isStopped = true; swerveAmount = 0;
            UI_manager.count_down.keepItButton.SetActive(false);
            isBikiniKeepIt = false;
        }
        if (isUndressOpenButton == true)
        {

            UI_manager.bar.fillAmount = 0.5f;
            UI_manager.colorbar.fillAmount = 0.5f;
            hangerValue = 0.5f;
            isUndressOpenButton = false;
            coat.SetActive(false);
            glove_R.SetActive(false);
            glove_L.SetActive(false);
            playerAnim.SetBool("Idle", false);
            swerve_InputSystem.touch.phase = TouchPhase.Ended;

            isStopped = false;
            swerve_InputSystem.finish = true;
        }
        if (isSurpriseboxpanelOpen == true)
        {
            swerveAmount = 0;
            swerve_InputSystem.finish = false;
            isStopped = true; swerveAmount = 0;
            //UI_manager.surpriseBoxContinueButton.SetActive(true);
            isSurpriseboxpanelOpen = true;
            playerAnim.SetBool("Idle", true);
            playerAnim.SetBool("Walk", false);
            char_set_mat.OpenSurpriseBoxCharacter();
            UI_manager.surpriseBoxCharImage.SetActive(true);
            //UI_manager.surpriseBoxPanelContinueButton.SetActive(true);
            UI_manager.surpriseBoxAnim.SetActive(false);
            isSurpriseboxpanelOpen = false;
        }
        if (isWatchVideoFromBikinisPanel == true)
        {
            UI_manager.addBikinisPanelOpenBikini(bikininumber2);
            swerveAmount = 0;
            swerve_InputSystem.finish = false;
            isStopped = true; swerveAmount = 0;
            isWatchVideoFromBikinisPanel = false;
        }
        RequestGecisVideo();
        if (InterGecisVideoReklami.IsLoaded())
        {
            InterGecisVideoReklami.Show();
            PlayerPrefs.SetInt("restartValue", 0);
        }

    }

    void RequestGecisVideo()
    {
#if UNITY_ANDROID
        reklamId2 = VideoAndroidBannerReklamKimligi;
#elif UNITY_IPHONE
              Reklamid2=Video›osBannerReklamKimligi;
#else
              Reklamid2 = "Tan˝ms˝z Platform";
#endif

        InterGecisVideoReklami = new InterstitialAd(reklamId2);
        AdRequest request = new AdRequest.Builder().Build();
        InterGecisVideoReklami.LoadAd(request);


    }
    public bool isGameOverContButton = true;
    public bool isPressGet500 = false;
    public bool isPressGetSecond500 = false;
    public bool isPressGet3x = false;
    public bool isBikiniKeepIt = false;
    public bool isUndressOpenButton = false;
    public bool isSurpriseboxpanelOpen = false;
    public bool isWatchVideoFromBikinisPanel = false;
    public void GameOverVideo()
    {
        sound_manager.SoundPlay(4);
        if (PlayerPrefs.GetInt("ReklamlarKapali") == 1)
        {
            UI_manager.HeartCircle.gameObject.SetActive(false);
            InterGecisVideoReklami.Show();
            UI_manager.main_char.swerve_InputSystem.touch.phase = TouchPhase.Ended;
            UI_manager.main_char.isStopped = false;
            UI_manager.bar.fillAmount = 0.3750f;
            UI_manager.colorbar.fillAmount = 0.6250f;
            UI_manager.main_char.hangerValue = 0.6250f;
            UI_manager.main_char.coat.SetActive(false);
            UI_manager.main_char.glove_R.SetActive(false);
            UI_manager.main_char.glove_L.SetActive(false);
            UI_manager.main_char.boat_L.SetActive(false);
            UI_manager.main_char.boat_R.SetActive(false);
            UI_manager.main_char.beret.SetActive(false);
            UI_manager.main_char.playerAnim.SetBool("fall", false);

            UI_manager.main_char.playerAnim.SetBool("Idle", false);
            UI_manager.HeartCircle.fillAmount = 0;
            UI_manager.main_char.playerAnim.speed = 1;
            UI_manager.main_char.swerve_InputSystem.touch.phase = TouchPhase.Ended;
            UI_manager.swerve_input.finish = true;
            UI_manager.main_char.swerveSpeed = 0.3f;
            UI_manager.gameover.SetActive(false);
        }
            isGameOverContButton = false;
        RequestRewerdedVideos();
        if (this.rewardedAd.IsLoaded())
        {
            this.rewardedAd.Show();
        }
        else
        {
            RequestGecisVideo();
        }
    }
    public void RestartOnOpen()
    {
        
            RequestRewerdedVideos();
        if (this.rewardedAd.IsLoaded())
        {
            this.rewardedAd.Show();
        }
        else
        {
            RequestGecisVideo();
        }
    }



    public void TakeTheMyCoinGet500()
    {
        sound_manager.SoundPlay(4);
        if (PlayerPrefs.GetInt("ReklamlarKapali") == 1)
        {
            coins += 500;
            UI_manager.coin.text = "" + coins;
            PlayerPrefs.SetInt("mycoin", coins);
        }
        isPressGet500 = true;
        RequestRewerdedVideos();
        if (this.rewardedAd.IsLoaded())
        {
            this.rewardedAd.Show();

        }
        else
        {
            RequestGecisVideo();
        }
    }

    public void TakeTheMyCoinGetTwo500()
    {
        sound_manager.SoundPlay(4);
        if (PlayerPrefs.GetInt("ReklamlarKapali") == 1)
        {
            coins += 500;
            UI_manager.coin.text = "" + coins;
            PlayerPrefs.SetInt("mycoin", coins);
        }
        isPressGetSecond500 = true;
        RequestRewerdedVideos();
        if (this.rewardedAd.IsLoaded())
        {
            this.rewardedAd.Show();

        }
        else
        {
            RequestGecisVideo();
        }
    }

    public void TakeTheMyCoinGet3x()
    {
        sound_manager.SoundPlay(4);
        if (PlayerPrefs.GetInt("ReklamlarKapali") == 1)
        {
            collected›nGame = collected›nGame * 3;
            coins += collected›nGame;
            PlayerPrefs.SetInt("mycoin", coins);
            UI_manager.coin.text = "" + coins;
            UI_manager.get3x.SetActive(false);
        }
            
        
        isPressGet3x = true;
        RequestRewerdedVideos();
        if (this.rewardedAd.IsLoaded())
        {
            this.rewardedAd.Show();

        }
        else
        {
            RequestGecisVideo();
        }
    }
    public void BikiniKeepIt()
    {
        sound_manager.SoundPlay(4);
        if (PlayerPrefs.GetInt("ReklamlarKapali") == 1)
        {

            UI_manager.particle_bikinis.isOpenKeepItPanel = false;
            UI_manager.keepitPanel.SetActive(false);
            UI_manager.fantastictext.SetActive(false);
            UI_manager.loseitbutton.SetActive(false);
            UI_manager.ShineGetOpenPanel2();
            swerveAmount = 0;
            swerve_InputSystem.finish = false;
            isStopped = true; swerveAmount = 0;
            UI_manager.count_down.keepItButton.SetActive(false);
        }
            isBikiniKeepIt = true;
            RequestRewerdedVideos();
            if (this.rewardedAd.IsLoaded())
            {
                this.rewardedAd.Show();

            }
            else
            {
                RequestGecisVideo();
            }
        
    }
    public void UndressOpen()
    {
        sound_manager.SoundPlay(4);
        if (UI_manager.isUndressOpen == false)
        {
            sound_manager.SoundPlay(4);
            UI_manager.count_down.undress.SetActive(false);
            UI_manager.isUndressOpen = true;
            isStopped = true; swerveAmount = 0;
            swerve_InputSystem.finish = false;
            swerveAmount = 0;
        }
        
        if (PlayerPrefs.GetInt("ReklamlarKapali") == 1)
        {
            UI_manager.bar.fillAmount = 0.5f;
            UI_manager.colorbar.fillAmount = 0.5f;
            hangerValue = 0.5f;
            coat.SetActive(false);
            glove_R.SetActive(false);
            glove_L.SetActive(false);
            playerAnim.SetBool("Idle", false);
            swerve_InputSystem.touch.phase = TouchPhase.Ended;

            isStopped = false;
            swerve_InputSystem.finish = true;
        }
            
        isUndressOpenButton = true;
        RequestRewerdedVideos();
        if (this.rewardedAd.IsLoaded())
        {
            this.rewardedAd.Show();

        }
        else
        {
            RequestGecisVideo();
        }


    }
    public void OpenSurprisePanel()
    {
        //swerveAmount = 0;
        //swerve_InputSystem.finish = false;
        //isStopped = true; swerveAmount = 0;
        ////UI_manager.surpriseBoxContinueButton.SetActive(true);
        //isSurpriseboxpanelOpen = true;
        //playerAnim.SetBool("Idle", true);
        //playerAnim.SetBool("Walk", false);
        sound_manager.SoundPlay(4);
        if (PlayerPrefs.GetInt("ReklamlarKapali") == 1)
        {
            swerveAmount = 0;
            swerve_InputSystem.finish = false;
            isStopped = true; swerveAmount = 0;
            //UI_manager.surpriseBoxContinueButton.SetActive(true);
            isSurpriseboxpanelOpen = true;
            playerAnim.SetBool("Idle", true);
            playerAnim.SetBool("Walk", false);
            char_set_mat.OpenSurpriseBoxCharacter();
            UI_manager.surpriseBoxCharImage.SetActive(true);
            //UI_manager.surpriseBoxPanelContinueButton.SetActive(true);
            UI_manager.surpriseBoxAnim.SetActive(false);
        }
            RequestRewerdedVideos();
        if (this.rewardedAd.IsLoaded())
        {
            this.rewardedAd.Show();

        }
        else
        {
            RequestGecisVideo();
        }
    }
    public int bikininumber2;
    public void WatchAndOpenVideoFromBikiniPanel(int bikininumber)
    {
        bikininumber2 = bikininumber;
        sound_manager.SoundPlay(4);
        if (PlayerPrefs.GetInt("ReklamlarKapali") == 1)
        {
            UI_manager.addBikinisPanelOpenBikini(bikininumber2);
            swerveAmount = 0;
            swerve_InputSystem.finish = false;
            isStopped = true; swerveAmount = 0;
        }
            isWatchVideoFromBikinisPanel = true;
        RequestRewerdedVideos();
        if (this.rewardedAd.IsLoaded())
        {
            this.rewardedAd.Show();

        }
        else
        {
            RequestGecisVideo();
        }
    }

    public GameObject ReklamKapatmaPaneli;
    public void ClosedAllAdds()
    {
        ReklamKapatmaPaneli.SetActive(true);
    }
    //public void yuklendimi(object sender, EventArgs args)
    //{
    //    print("y¸klendi");

    //}
    //public void yuklemedesorunvar(object sender, AdFailedToLoadEventArgs args)
    //{
    //    RequestGecisVideo();

    //}
    //    public void acildi(object sender, EventArgs args)
    //{

    //}
    //public void kapatildi(object sender, EventArgs args)
    //{
    //    print("kapatt˝m");
    //    RequestGecisVideo();
    //}


}
