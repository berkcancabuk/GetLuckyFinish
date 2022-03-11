using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public MainChar main_char;
    public AudioClip[] mysounds;
    public AudioSource audiosource;
    public bool isSoundActive = true;
    public bool isVibrationActive = true;
    void Start()
    {
        
        audiosource = GetComponent<AudioSource>();

    }
    public IEnumerator addSoundScript()
    {
        GameObject mainchar = GameObject.Find("alldressT-Pose_1");
        GameObject audio = GameObject.Find("Main Camera");
        if (mainchar != null)
        {
            yield return new WaitForSeconds(.2f);
            main_char = mainchar.GetComponent<MainChar>();
            audiosource = audio.GetComponent<AudioSource>();

        }
    }
    public void VibrationPlay()
    {
        if (isVibrationActive)
        {
            Handheld.Vibrate();
        }
        
    }
    public void SoundPlay(int sound)
    {
        if (isSoundActive)
        {
            audiosource.PlayOneShot(mysounds[sound]);
        }
        
    }
    
}
