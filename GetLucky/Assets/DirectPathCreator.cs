using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;
using DG.Tweening;
public class DirectPathCreator : MonoBehaviour
{
    public MainChar main_char;
    public GameObject cmDirectCam;
    public Animator turncylinder;
    public bool isRot = true;
    public Transform parent;

    public GameObject upperRamp;
    public GameObject upperPlatform;
    public Material upperRamp1;
    Touch touch;
    public void SlideToDirect()
    {
        StartCoroutine(SlideDirect());
    }
   void Start()
    {
        upperRamp1.color = new Color(0.9921569f, 0.7568628f, 0.9921569f, 1f);
    }
    public void Update()
    {
        
    }
    public GameObject directPos1, directPos2;
    IEnumerator SlideDirect()
    {
        if (isRot == false)
        {
            main_char.transform.parent = transform.transform;
        }
        cmDirectCam.SetActive(true);
        cmDirectCam.gameObject.transform.DOMoveY(2.3f, 1.3f);
        yield return new WaitForSeconds(0.5f);
        main_char.playerAnim.SetBool("getoffthepole", true);
        yield return new WaitForSeconds(0.2f);
        main_char.transform.DOMove(directPos1.transform.position, 0.3f);

        yield return new WaitForSeconds(0.3f);
        
        turncylinder.SetBool("turn", true);
        main_char.transform.DOMove(directPos2.transform.position, 3f);
        
        yield return new WaitForSeconds(2f);
        cmDirectCam.SetActive(false);
        main_char.transform.parent = parent;
        isRot = true;
        yield return new WaitForSeconds(1f);
        main_char.playerAnim.SetBool("getoffthepole", false);
        main_char.playerAnim.SetBool("Idle", true);
        main_char.swerve_InputSystem.touch.phase = TouchPhase.Ended;
        main_char.isStopped = false;
        main_char.swerve_InputSystem.finish = true;
        main_char.swerveSpeed = 0.25f;
        main_char.playerAnim.SetBool("Idle", false);
      
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {

            upperPlatform.GetComponent<MeshRenderer>().enabled = false;
            upperRamp1.color = new Color(253/255, 193/255, 253/255, 0.1f);

            upperRamp.GetComponent<Material>().color = upperRamp1.color;
        }
    }

}
