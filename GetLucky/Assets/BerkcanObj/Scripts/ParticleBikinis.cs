using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleBikinis : MonoBehaviour
{
    public ParticleBikinis particle_bikinis;
    public CountDown count_down;
    public GameObject poolScene;
    public UImanager UI_manager;
    public MainChar main_char;
    public bool isOpenKeepItPanel = false;
    public bool isEnabledBikini = true;
    public List<GameObject> Bikinis = new List<GameObject>();
    
    void Start()
    {
       
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter(Collider other)
    {


        for (int i = 1; i < 7; i++)
        {
           
            if (other.tag == "Player" && UI_manager.game_manager.sceneToContinue >= 4 && PlayerPrefs.GetInt("Bikini"+(i)) == 0 && PlayerPrefs.GetInt("howmuchBikini") <2)
            {
                print("biknii1 aldýk");
                this.gameObject.GetComponent<BoxCollider>().enabled = false;
                isOpenKeepItPanel = true;
                this.gameObject.SetActive(false);
                main_char.towel.SetActive(false);

                main_char.MainCharBikinis[i].SetActive(true);
                
                UI_manager.bikiniImage.sprite = UI_manager.bikImages[i-1];
                PlayerPrefs.SetInt("howmuchBikini", PlayerPrefs.GetInt("howmuchBikini")+1);
                break;
            }
           /* else if (other.tag == "Player" && UI_manager.game_manager.sceneToContinue >= 4 && PlayerPrefs.GetInt("Bikini"+(i)) == 1 && PlayerPrefs.GetInt("howmuchBikini") < 2)
            {
                print("bikini2 yi aldýk mý");
                this.gameObject.GetComponent<BoxCollider>().enabled = false;
                isOpenKeepItPanel = true;
                this.gameObject.SetActive(false);
                main_char.towel.SetActive(false);
                main_char.MainCharBikinis[2].SetActive(true);
                main_char.MainCharBikinis[1].SetActive(false);
                main_char.MainCharBikinis[0].SetActive(false);
                main_char.MainCharBikinis[3].SetActive(false);
                main_char.MainCharBikinis[4].SetActive(false);
                main_char.MainCharBikinis[5].SetActive(false);
                UI_manager.bikiniImage.sprite = UI_manager.bikImages[1];
                PlayerPrefs.SetInt("howmuchBikini", PlayerPrefs.GetInt("howmuchBikini") + 1);
                break;
            }*/
        }
        





    }


}

