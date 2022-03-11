using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class grannyHit : MonoBehaviour
{
    public MainChar main_char;
    public UImanager UI_manager;
    public WalkGranny walk_granny;
    public Touch touch;
    public Animator grannyAnim;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            main_char.sound_manager.VibrationPlay();
            main_char.sound_manager.SoundPlay(9);
            grannyAnim.SetBool("grannyhit", true);
            DOTween.Pause("parentween");
            WhenYouHitTheGranny();
            gameObject.GetComponent<BoxCollider>().enabled = false;
            main_char.sound_manager.SoundPlay(0);
        }
    }
    public void WhenYouHitTheGranny()
    {
        //transform.LookAt(main_char.transform.position);
        main_char.hangerValue -= 0.125f;
        main_char.isStopped = true;
        main_char.swerve_InputSystem.touch.phase = TouchPhase.Ended;
        main_char.swerveAmount = 0;
        main_char.swerve_InputSystem.finish = false;
        main_char.swerveAmount = 0;
        main_char.swerveSpeed = 0;
        UI_manager.bar.DOFillAmount(UI_manager.bar.fillAmount + 0.125f, 0.2f);
        main_char.playerAnim.SetBool("Idle", true);
        main_char.playerAnim.SetBool("Walk", false);
        if (main_char.hangerValue >= 0 && main_char.hangerValue < 0.12f)
        {
            print("kadýna çarptýk2");
            StartCoroutine(WhenHitToGrannyLater());
        }
        else if (main_char.hangerValue >= 0.12f && main_char.hangerValue < 0.25f)
        {
            print("kadýna çarptýk1");
            StartCoroutine(WhenHitToGrannyLater());
            main_char.beret.SetActive(true);
        }
        else if (main_char.hangerValue >= 0.25f && main_char.hangerValue < 0.375)
        {
            StartCoroutine(WhenHitToGrannyLater());
            main_char.glove_R.SetActive(true);
            main_char.glove_L.SetActive(true);
        }
        else if (main_char.hangerValue >= 0.375f && main_char.hangerValue < 0.50f)
        {
            StartCoroutine(WhenHitToGrannyLater());
            main_char.coat.SetActive(true);

        }
        else if (main_char.hangerValue >= 0.50f && main_char.hangerValue < 0.625f)
        {
            StartCoroutine(WhenHitToGrannyLater());
            main_char.boat_R.SetActive(true);
            main_char.boat_L.SetActive(true);
        }
        else if (main_char.hangerValue >= 0.625f && main_char.hangerValue < 0.75f)
        {
            StartCoroutine(WhenHitToGrannyLater());
            main_char.top.SetActive(true);
        }
        else if (main_char.hangerValue >= 0.750f && main_char.hangerValue < 0.8750f)
        {
            StartCoroutine(WhenHitToGrannyLater());
            main_char.skirt.SetActive(true);
        }
        
    }
    IEnumerator WhenHitToGrannyLater()
    {
        
        UI_manager.textAngry.SetActive(true);
        yield return new WaitForSeconds(1f);
        main_char.isStopped = false;
        main_char.playerAnim.SetBool("Idle", false);
        UI_manager.textAngry.SetActive(false);
        UI_manager.GameOver();
        yield return new WaitForSeconds(0.2f);
        main_char.swerve_InputSystem.finish = true;
        main_char.swerveSpeed = 0.3f;
        
    }
}
