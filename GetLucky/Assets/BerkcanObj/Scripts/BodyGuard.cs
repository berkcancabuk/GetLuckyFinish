using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyGuard : MonoBehaviour
{ public UImanager UI_manager;
    public Animator anim;
    private void OnTriggerEnter(Collider other)
    {
        if (this.gameObject.tag == "goldenBody")
        {
            anim.SetBool("Body", true);
        }
        if (this.gameObject.tag == "poolBody" && UI_manager.bar.fillAmount >= 0.8750f)
        {
            anim.SetBool("PoolBody", true);
        }
    }
}
