using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class PoolJumAndBonusCoin : MonoBehaviour
{
    public UImanager UI_manager;
    public MainChar main_char;
    public GameObject bagliObje;
    
    public bool isJumped = false;
    public bool x3 = false;
    public bool x4 = false;
    public bool x5 = false;

    public bool isClickMouse = true;
    //pool positions
    public GameObject poolPosUpX3, poolPosDiveX3, poolPosDownX3;
    public GameObject poolPosUpX4, poolPosDiveX4, poolPosDownX4;
    public GameObject poolPosUpX5, poolPosDiveX5, poolPosDownX5;

    // Start is called before the first frame update
    void Start()
    {
        isClickMouse = true;
            this.gameObject.transform.DOLocalRotate(new Vector3(0, 0, 178.89f), 0.8f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutCirc);
    }

    // Update is called once per frame
    void Update()
    {
        if (isJumped == true)
        {
            if (Input.GetMouseButtonDown(0) && isClickMouse == true)
            {
                isClickMouse = false;
                StartCoroutine(PoolCamChange());
                this.transform.DOKill();
                if ((this.transform.rotation.eulerAngles.z >= 34.4f && this.transform.rotation.eulerAngles.z <= 53.6f) || (this.transform.rotation.eulerAngles.z <= 178.89f && this.transform.rotation.eulerAngles.z >= 155f))
                {
                    main_char.sound_manager.SoundPlay(2);
                    PlayerPrefs.SetInt("IhaveScore", PlayerPrefs.GetInt("IhaveScore") + main_char.MyScoreRanks*3);
                    StartCoroutine(DivePool(poolPosUpX3.transform.position, poolPosDiveX3.transform.position, poolPosDownX3.transform.position));

                    StartCoroutine(pooldownOpenTurnOnCamera(main_char.CMcamera3xToTurn));
                    x3 = true;
                    
                    main_char.coins += main_char.collectedÝnGame * 3;
                    UI_manager.coin.text = "" + main_char.coins;
                    StartCoroutine(UI_manager.ShineGetOpenPanel());
                }
                else if ((this.transform.rotation.eulerAngles.z >= 53.7f && this.transform.rotation.eulerAngles.z <= 84) || (this.transform.rotation.eulerAngles.z >= 127.6f && this.transform.rotation.eulerAngles.z < 155f))
                {
                    main_char.sound_manager.SoundPlay(2);
                    PlayerPrefs.SetInt("IhaveScore", PlayerPrefs.GetInt("IhaveScore")+ main_char.MyScoreRanks * 4);
                    StartCoroutine(DivePool(poolPosUpX4.transform.position, poolPosDiveX4.transform.position, poolPosDownX4.transform.position));
                    StartCoroutine(pooldownOpenTurnOnCamera(main_char.CMcamera4xToTurn));
                    x4 = true;
                    main_char.coins += main_char.collectedÝnGame * 4;
                    print(main_char.coins+"4x");
                    UI_manager.coin.text = "" + main_char.coins;
                    
                    StartCoroutine(UI_manager.ShineGetOpenPanel());
                }
                else if (this.transform.rotation.eulerAngles.z <= 127.5f && this.transform.rotation.eulerAngles.z >= 84.001f)
                {
                    main_char.sound_manager.SoundPlay(2);
                    PlayerPrefs.SetInt("IhaveScore", PlayerPrefs.GetInt("IhaveScore")+ main_char.MyScoreRanks * 5);
                    StartCoroutine(DivePool(poolPosUpX5.transform.position, poolPosDiveX5.transform.position, poolPosDownX5.transform.position));
                    StartCoroutine(pooldownOpenTurnOnCamera(main_char.CMcamera5xToTurn));
                    x5 = true;
                    main_char.coins += main_char.collectedÝnGame * 5;
                    UI_manager.coin.text = "" + main_char.coins;
                    
                    StartCoroutine(UI_manager.ShineGetOpenPanel());
                }
                else
                {
                    main_char.sound_manager.SoundPlay(2);
                    PlayerPrefs.SetInt("IhaveScore", PlayerPrefs.GetInt("IhaveScore") +main_char.MyScoreRanks * 3);
                    StartCoroutine(pooldownOpenTurnOnCamera(main_char.CMcamera3xToTurn));
                    x3 = true;
                    StartCoroutine(DivePool(poolPosUpX3.transform.position, poolPosDiveX3.transform.position, poolPosDownX3.transform.position));
                    main_char.coins += main_char.collectedÝnGame * 3;
                    StartCoroutine(UI_manager.ShineGetOpenPanel());
                }
                //PlayerPrefs.SetInt("mycoin", main_char.coins);
            }
        }
    }
    IEnumerator PoolCamChange()
    {
        yield return new WaitForSeconds(1f);

        UI_manager.ShineGetOpenPanel();
        
        yield return new WaitForSeconds(1.26f);
        bagliObje.SetActive(false);
        main_char.CMmainFollowCam.SetActive(false);
    }
    
    IEnumerator DivePool(Vector3 posUp, Vector3 posDive, Vector3 posDown)
    {
        main_char.playerAnim.SetBool("RunToDive", true);
        main_char.transform.DOMove(posUp, 1f);
        yield return new WaitForSeconds(1f);
        main_char.transform.DOMove(posDive, 1f);
        print("geçti dive a ");
        main_char.sound_manager.SoundPlay(12);
        yield return new WaitForSeconds(1f);
        print("geçti mi");
        main_char.transform.DOMove(posDown, 0.25f);
        main_char.playerAnim.SetBool("treading", true);
        main_char.swerveSpeed = 0;
        main_char.isStopped = true;
        main_char.swerveAmount = 0;
        main_char.swerve_InputSystem.finish = false;
        main_char.swerveAmount = 0;
        print("geçti");

    }
    IEnumerator pooldownOpenTurnOnCamera(GameObject CMcamera)
    {  
       yield return new WaitForSeconds(0.5f);
       CMcamera.SetActive(true);
        main_char.endGameConfettiEffect.Play();
    }
}
