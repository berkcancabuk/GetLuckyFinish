using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class RampClimb : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(ClimbingRamp());
    }
    public GameObject rampPosDown, rampPosUp;
    public MainChar main_char;
    IEnumerator ClimbingRamp()
    {
        main_char.transform.DOMove(rampPosDown.transform.position, 0.1f);
        main_char.playerAnim.SetBool("Walk", true);
        main_char.playerAnim.SetBool("Idle", false);
        yield return new WaitForSeconds(0.1f);
        main_char.transform.DOMove(rampPosUp.transform.position, 0.7f);
        yield return new WaitForSeconds(0.3f);
        main_char.playerAnim.SetBool("Walk", false);
        main_char.playerAnim.SetBool("Idle", true);
    }
}
