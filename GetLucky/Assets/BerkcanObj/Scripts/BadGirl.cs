using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadGirl : MonoBehaviour
{
    public UImanager UI_manager;
    public FollowBadGirl follow_Bad_Girl;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            this.gameObject.GetComponent<BoxCollider>().isTrigger = false;
            UI_manager.main_char.sound_manager.VibrationPlay();
            follow_Bad_Girl.badgirlWalking.SetBool("badgirlWalking", false);
            follow_Bad_Girl.isTrigger = false;
            UI_manager.hotImageBarParent.SetActive(false);
            UI_manager.fireAnim.SetActive(false);
            UI_manager.bar.fillAmount = 1;
            UI_manager.main_char.sound_manager.SoundPlay(8);
            UI_manager.GameOver();
            print("asd");
            UI_manager.HowMuchHitGirl++;
            this.gameObject.SetActive(false);
        }
    }

}
