using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBadGirl : MonoBehaviour
{
    public MainChar main_char;
    public float speed = 1;
    public bool isTrigger = false;
    public Animator badgirlWalking;
    public GameObject badgirl;
    void Update()
    {
        if (isTrigger == true)
        {
            FollowMainCharacter();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            isTrigger = true;

        }
    }
    public void FollowMainCharacter()
    {
        badgirlWalking.SetBool("badgirlWalking", true);
        badgirl.transform.position = Vector3.MoveTowards(badgirl.transform.position, main_char.transform.position, speed * Time.deltaTime);
        badgirl.transform.LookAt(main_char.transform);
    }
}
