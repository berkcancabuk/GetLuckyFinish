using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;
using System;
public class SwerveInputSystem : MonoBehaviour
{
    public float _lastFrameFingerPositionX;
    public float _moveFactorX;
    public MainChar main;
    public GameObject slide;
    public GameObject barObje;
    public bool finish = true;
    public Touch touch;
    public bool isHotBarParentOpen = true;

    // Start is called before the first frame update
    void Start()
    {
        main = GetComponent<MainChar>();
    }
    void Update()
    {
        if (finish)
        {
            //#if UNITY_EDITOR
            //if (Input.GetMouseButtonDown(0))
            //{

            //    barObje.SetActive(true);
            //    slide.SetActive(false);

            //    main.playerAnim.SetBool("Idle", false);
            //    main.playerAnim.SetBool("Walk", true);
            //    _lastFrameFingerPositionX = Input.mousePosition.x;
            //}

            //else if (Input.GetMouseButton(0))
            //{

            //    _moveFactorX = Input.mousePosition.x - _lastFrameFingerPositionX;

            //    _lastFrameFingerPositionX = Input.mousePosition.x;

            //}
            //else if (Input.GetMouseButtonUp(0))
            //{
            //    main.playerAnim.SetBool("Idle", true);
            //    main.playerAnim.SetBool("Walk", false);

            //    _moveFactorX = 0f;
            //}
            if (Input.touchCount > 0)
            {
                
                touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began)
                {

                    DOTween.Pause("parentween");
                    main.playerAnim.SetBool("Idle", true);
                    main.playerAnim.SetBool("Walk", false);
                    //print((EventSystem.current.currentSelectedGameObject.gameObject.name) + "  haraket ettirdiðimde began" +
                    //      "");
                    if (!IsPointerOverUIObject(Input.GetTouch(0)))
                    {    if (main.UI_manager.isStopGame == true)
                           {
                            main.UI_manager.settingObjectClose.SetActive(true);
                            main.UI_manager.settingobjectOpen.SetActive(false);
                            main.UI_manager.settinAnim.SetBool("TouchOff", true);
                            StartCoroutine(main.UI_manager.settingobjeFalse());
                            //Time.timeScale = 1f;
                            main.swerve_InputSystem.touch.phase = TouchPhase.Ended;
                            //main_char.swerve_InputSystem.finish = true;

                            //main_char.isStopped = false;
                            main.UI_manager.isStopGame = false;

                           }
                        main.playerAnim.SetBool("Idle", false);
                        main.playerAnim.SetBool("Walk", true);
                        main.UI_manager.bikinisPanel.SetActive(false);
                        main.UI_manager.storeGamePanel.SetActive(false);
                        main.UI_manager.undressImage.SetActive(false);
                        main.UI_manager.game_manager.timer.gameObject.SetActive(false);
                        main.UI_manager.countdownSurpriseBoxImage.SetActive(false);
                        print("began");
                        if (isHotBarParentOpen)
                        {
                            print("play oldu");
                            DOTween.Play("parentween");
                            main.UI_manager.hotBarParent.SetActive(true);
                            barObje.SetActive(true);
                            isHotBarParentOpen = false;
                        }

                        slide.SetActive(false);

                        main.playerAnim.SetBool("Idle", false);
                        main.playerAnim.SetBool("Walk", true);
                        
                    }
                    _lastFrameFingerPositionX = Input.mousePosition.x;


                    //_lastFrameFingerPositionX = Input.mousePosition.x;
                    //print(_moveFactorX + " swerve input system.cs began");
                }
                else if ((touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary))
                {
                    main.playerAnim.SetBool("Idle", true);
                    main.playerAnim.SetBool("Walk", false);
                    print("moved týklamadý");
                    if (isHotBarParentOpen)
                    {
                        DOTween.Pause("parentween");
                    }
                    //print((EventSystem.current.currentSelectedGameObject.gameObject.name) + "  haraket ettirdiðimde stationary" +
                    //      "");
                    if (!IsPointerOverUIObject(Input.GetTouch(0)))
                    {
                        if (main.UI_manager.isStopGame == true)
                        {
                            main.UI_manager.settingObjectClose.SetActive(true);
                            main.UI_manager.settingobjectOpen.SetActive(false);
                            main.UI_manager.settinAnim.SetBool("TouchOff", true);
                            StartCoroutine(main.UI_manager.settingobjeFalse());
                            //Time.timeScale = 1f;
                            main.swerve_InputSystem.touch.phase = TouchPhase.Ended;
                            //main_char.swerve_InputSystem.finish = true;

                            //main_char.isStopped = false;
                            main.UI_manager.isStopGame = false;

                        }
                        main.playerAnim.SetBool("Idle", false);
                        main.playerAnim.SetBool("Walk", true);
                        main.UI_manager.bikinisPanel.SetActive(false);
                        main.UI_manager.storeGamePanel.SetActive(false);
                        main.UI_manager.undressImage.SetActive(false);
                        main.UI_manager.game_manager.timer.gameObject.SetActive(false);
                        main.UI_manager.countdownSurpriseBoxImage.SetActive(false);
                        print("began");
                        if (isHotBarParentOpen)
                        {
                            print("play oldu");
                            DOTween.Play("parentween");
                            main.UI_manager.hotBarParent.SetActive(true);
                            barObje.SetActive(true);
                            isHotBarParentOpen = false;
                        }

                        slide.SetActive(false);

                        main.playerAnim.SetBool("Idle", false);
                        main.playerAnim.SetBool("Walk", true);

                    }
                    //if (!IsPointerOverUIObject(Input.GetTouch(0)))
                    //{
                    //    main.playerAnim.SetBool("Idle", false);
                    //    main.playerAnim.SetBool("Walk", true);
                    //    print("moved týkladý");
                    //    //main.isStopped = false;

                    //    //_moveFactorX = Input.mousePosition.x - _lastFrameFingerPositionX;

                    //    //_lastFrameFingerPositionX = Input.mousePosition.x;
                    //}
                    _moveFactorX = Input.mousePosition.x - _lastFrameFingerPositionX;

                    _lastFrameFingerPositionX = Input.mousePosition.x;

                    // //if (!IsPointerOverUIObject(Input.GetTouch(0)))
                    // //{
                    //     barObje.SetActive(true);
                    //     slide.SetActive(false);
                    //     DOTween.Play("parentween");
                    //     main.playerAnim.SetBool("Idle", false);
                    //     main.playerAnim.SetBool("Walk", true);

                    //     _moveFactorX = Input.mousePosition.x - _lastFrameFingerPositionX;
                    // _lastFrameFingerPositionX = Input.mousePosition.x;
                    // print(_moveFactorX+" swerve input system.cs move or stationary");

                    //// }
                }
                else if (touch.phase == TouchPhase.Ended)
                {
                    DOTween.Pause("parentween");
                    main.playerAnim.SetBool("Idle", true);
                    main.playerAnim.SetBool("Walk", false);
                    _moveFactorX = 0f;
                    print(_moveFactorX + " swerve input system.cs else ended");
                }
            }

        }

    }


    bool IsPointerOverUIObject(Touch touch)
    {

        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(touch.position.x, touch.position.y);

        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;

    }
    
    //#if UNITY_ANDROID
    //public bool IsPointerOverUIObject(Touch touch)
    //{


    //    touch = Input.GetTouch(0);
    //    if ((touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary))
    //    {
    //        if (!IsPointerOverUIObject(Input.GetTouch(0)))
    //        {
    //            barObje.SetActive(true);
    //            slide.SetActive(false);
    //            DOTween.Play("parentween");
    //            main.playerAnim.SetBool("Idle", false);
    //            main.playerAnim.SetBool("Walk", true);
    //            _lastFrameFingerPositionX = Input.mousePosition.x;
    //            _moveFactorX = Input.mousePosition.x - _lastFrameFingerPositionX;
    //            _lastFrameFingerPositionX = Input.mousePosition.x;
    //            return true;
    //        }
    //    }
    //    else if (touch.phase == TouchPhase.Ended)
    //    {
    //        main.playerAnim.SetBool("Idle", true);
    //        main.playerAnim.SetBool("Walk", false);
    //        DOTween.Pause("parentween");
    //        _moveFactorX = 0f;
    //    }




    //    return false;

    //}
}
//#endif

