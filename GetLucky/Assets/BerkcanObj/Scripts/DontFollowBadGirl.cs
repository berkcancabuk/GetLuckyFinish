using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontFollowBadGirl : MonoBehaviour
{
    public FollowBadGirl follow_Bad_Girl;
    private void Start()
    {
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {

            follow_Bad_Girl.badgirlWalking.SetBool("badgirlWalking", false);
            follow_Bad_Girl.isTrigger = false;
            print("false");
        }
    }
}
