using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LoadingScene : MonoBehaviour
{
    public GameManager game_manager;
    public Image loadingImage;
    // Start is called before the first frame update
    void Start()
    {
        game_manager.sceneToContinue = PlayerPrefs.GetInt("SavedScene");
        loadingImage.DOFillAmount(1, 3f);

    }

    // Update is called once per frame
    void Update()
    {
        if (loadingImage.fillAmount == 1)
        {
            SceneManager.LoadScene(game_manager.sceneToContinue);
            print(game_manager.sceneToContinue);
            //game_manager.surpriseboxOpenString = PlayerPrefs.GetString("SurpriseBoxOpen");
            //game_manager.UI_manager.surpriseBoxOpen = System.DateTime.Parse(PlayerPrefs.GetString("SurpriseBoxOpen"));
        }
    }
}
