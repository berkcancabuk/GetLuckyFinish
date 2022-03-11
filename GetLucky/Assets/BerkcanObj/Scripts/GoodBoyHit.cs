using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GoodBoyHit : MonoBehaviour
{
    public MainChar main_char;
    public UImanager UI_manager;
    public Touch touch;
    public Animator goodBoyAnim;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            main_char.sound_manager.VibrationPlay();
            UI_manager.main_char.sound_manager.SoundPlay(3);
            gameObject.transform.GetComponent<BoxCollider>().isTrigger = false;
            goodBoyAnim.SetBool("takephoto", true);
            transform.LookAt(main_char.transform);
            WhenYouHitTheGoodBoy();
        }
    }
    public void WhenYouHitTheGoodBoy()
    {
        main_char.hangerValue += 0.250f;
        main_char.isStopped = true;
        main_char.swerveAmount = 0;
        main_char.swerve_InputSystem.finish = false;
        main_char.swerveAmount = 0;
        main_char.swerveSpeed = 0;
        main_char.swerve_InputSystem.touch.phase = TouchPhase.Ended;
        UI_manager.layer.SetActive(true);
        UI_manager.layer.transform.DOLocalMoveY(787f, 1f);
        StartCoroutine(main_char.layerObjectTurnOff());
        UI_manager.colorbar.DOFillAmount(UI_manager.colorbar.fillAmount + 0.250f, 0.2f);
        UI_manager.bar.DOFillAmount(UI_manager.bar.fillAmount - 0.250f, 0.2f);
        main_char.playerAnim.SetBool("Idle", true);
        main_char.playerAnim.SetBool("Walk", false);
        StartCoroutine(WhenHitToGoodBoyLater());

        if (main_char.hangerValue >= 1.0f)
        {
            UI_manager.fireAnim.SetActive(true);
            main_char.towel.SetActive(true);
            for (int i = 0; i < 7; i++)
            {
                main_char.MainCharBikinis[i].SetActive(false);
            }
            main_char.topBikinis.SetActive(false);
            UI_manager.hotImageBarParent.SetActive(true);
            UI_manager.hotText.SetActive(true);
            StartCoroutine(main_char.CoatOff());
            UI_manager.redHotCanvas.SetActive(true);
            main_char.skirt.SetActive(false);
            Instantiate(main_char.instantiateSkirts, new Vector3(main_char.gameObject.transform.localPosition.x - 0.3f, main_char.gameObject.transform.localPosition.y+ 0.705f, main_char.gameObject.transform.localPosition.z), Quaternion.identity);
            StartCoroutine(main_char.GoodBoy());
            
        }
        else if (main_char.hangerValue >= 0.8750f)
        {
            main_char.skirt.SetActive(false);
            UI_manager.SpicyImage.SetActive(true);
            StartCoroutine(main_char.CoatOff());
            main_char.flare.Play();
            main_char.top.SetActive(false);
            Instantiate(main_char.instantiateTop, new Vector3(main_char.gameObject.transform.localPosition.x, main_char.gameObject.transform.localPosition.y, main_char.gameObject.transform.localPosition.z - 0.3f), Quaternion.identity);
            Instantiate(main_char.instantiateSkirts, new Vector3(main_char.gameObject.transform.localPosition.x, main_char.gameObject.transform.localPosition.y, main_char.gameObject.transform.localPosition.z - 0.3f), Quaternion.identity);
            StartCoroutine(main_char.GoodBoy());
        }
        else if (main_char.hangerValue >= 0.75f)
        {
            UI_manager.sexyImage.SetActive(true);
            main_char.playerAnim.SetBool("CoatOn", true);
            main_char.top.SetActive(false);
            main_char.boat_L.SetActive(false);
            main_char.boat_R.SetActive(false);
            main_char.flare.Play();
            Instantiate(main_char.instantiateTop, new Vector3(main_char.gameObject.transform.localPosition.x, transform.localPosition.y, this.transform.localPosition.z - 0.3f), Quaternion.identity);
            Instantiate(main_char.instantiateBoat, new Vector3(main_char.gameObject.transform.localPosition.x - 0.696f, main_char.gameObject.transform.localPosition.y, main_char.gameObject.transform.localPosition.z), Quaternion.identity);
            StartCoroutine(main_char.GoodBoy());
        }
        else if (main_char.hangerValue >= 0.625f)
        {
            main_char.boat_L.SetActive(false);
            main_char.boat_R.SetActive(false);
            main_char.coat.SetActive(false);
            UI_manager.textBubbly.SetActive(true);
            main_char.flare.Play();
            Instantiate(main_char.instantiateCoat, main_char.gameObject.transform.localPosition, Quaternion.identity);
            Instantiate(main_char.instantiateBoat, new Vector3(main_char.gameObject.transform.localPosition.x - 0.696f, main_char.gameObject.transform.localPosition.y, main_char.gameObject.transform.localPosition.z), Quaternion.identity);
            StartCoroutine(main_char.GoodBoy());
        }
        else if (main_char.hangerValue >= 0.50f)
        {
            main_char.playerAnim.SetBool("CoatOn", true);
            main_char.coat.SetActive(false);
            main_char.glove_L.SetActive(false);
            main_char.glove_R.SetActive(false);
            main_char.flare.Play();
            UI_manager.textConfident.SetActive(true);
            Instantiate(main_char.instantiateCoat, main_char.gameObject.transform.localPosition, Quaternion.identity);
            Instantiate(main_char.instantiate_glove, new Vector3(main_char.gameObject.transform.localPosition.x, main_char.gameObject.transform.localPosition.y, main_char.gameObject.transform.localPosition.z - 1f), Quaternion.identity);
            StartCoroutine(main_char.GoodBoy());
        }
        else if (main_char.hangerValue >= 0.375f)
        {
            main_char.playerAnim.SetBool("GloveOn", true);
            main_char.glove_L.SetActive(false);
            main_char.glove_R.SetActive(false);
            main_char.beret.SetActive(false);
            main_char.flare.Play();
            Instantiate(main_char.instantiate_glove, new Vector3(main_char.gameObject.transform.localPosition.x, main_char.gameObject.transform.localPosition.y, main_char.gameObject.transform.localPosition.z - 1f), Quaternion.identity);
            Instantiate(main_char.beret, this.transform.localPosition, Quaternion.identity);
            StartCoroutine(main_char.GoodBoy());
        }
        else if (main_char.hangerValue >= 0.25f)
        {
            main_char.beret.SetActive(false);
            main_char.flare.Play(); 
            Instantiate(main_char.beret, main_char.gameObject.transform.localPosition, Quaternion.identity);
            StartCoroutine(main_char.GoodBoy());
        }
        else if (main_char.hangerValue >= 0)
        {
            main_char.beret.SetActive(false);
            main_char.flare.Play();
            Instantiate(main_char.beret, main_char.gameObject.transform.localPosition, Quaternion.identity);
            StartCoroutine(main_char.GoodBoy());
        }
    }
    IEnumerator WhenHitToGoodBoyLater()
    {
        yield return new WaitForSeconds(1f);
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        main_char.playerAnim.SetBool("Idle", false);
        goodBoyAnim.SetBool("takephoto", false);
        main_char.isStopped = false;
        yield return new WaitForSeconds(0.2f);
        main_char.swerve_InputSystem.finish = true;
        main_char.swerveSpeed = 0.25f;

    }
}
