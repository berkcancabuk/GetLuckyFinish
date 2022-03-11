using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class goldenGate : MonoBehaviour
{
    
    public UImanager UI_manager;
    public MainChar main_char;
    public Animator anim;
    public ParticleBikinis particle_bikinis;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            UI_manager.hotBarParent.SetActive(false);
            UI_manager.undressImage.SetActive(false);
            UI_manager.bikinisPanel.SetActive(false);
            UI_manager.storeGamePanel.SetActive(false);
            UI_manager.undressImage.SetActive(false);
            if (UI_manager.colorbar.fillAmount == 1)
            {
                PlayerPrefs.SetInt("IhaveScore", PlayerPrefs.GetInt("IhaveScore") + 1); ;
                main_char.MyScoreRanks++;
            }
            main_char.sound_manager.SoundPlay(7);
            main_char.swerveSpeed = 0.25f;
            main_char.MyScoreRanks++;
            PlayerPrefs.SetInt("IhaveScore", PlayerPrefs.GetInt("IhaveScore") +1);
            if (UI_manager.game_manager.sceneToContinue >= 4 && UI_manager.colorbar.fillAmount >= 1 && PlayerPrefs.GetInt("howmuchBikini") < 2)
            {
                anim.SetBool("goldenGate", true);
                particle_bikinis.gameObject.SetActive(true);
                particle_bikinis.gameObject.GetComponent<BoxCollider>().isTrigger = true;
            }
            else if (main_char.hangerValue <= 0.250f)
            {
                main_char.swerve_InputSystem.touch.phase = TouchPhase.Ended;
                main_char.playerAnim.SetBool("Hit", true);
                UI_manager.loseImage.SetActive(true);
                UI_manager.continueLose.SetActive(true);
                UI_manager.main_char.sound_manager.SoundPlay(8);
                main_char.swerveSpeed = 0;
                main_char.playerAnim.SetBool("Idle", true);
                main_char.playerAnim.SetBool("Walk", false);
                main_char.swerveAmount = 0;
                main_char.swerve_InputSystem.finish = false;
                main_char.swerveAmount = 0;
                DOTween.Pause("parentween");
                StartCoroutine(main_char.Coaton());
            }
            else
            {
                
                anim.SetBool("goldenGate", true);
            }

        }



    }
}
