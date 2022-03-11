using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class CharactersSetMaterial : MonoBehaviour
{
    public MainChar main_char;


    public Material[] Boot;
    public Material[] Coat;
    public Material[] Gloves;
    public Material[] Skirt;
    public Material[] Top;
    public Material[] Hairmat;
    public Renderer rend;
    public GameObject second;
    public GameObject third;
    public GameObject fourth;
    public GameObject fifth;
    public GameObject sixth;
    public GameObject seventh;
    public GameObject eighth;
    public GameObject nineth;
    public GameObject tenth;

    public GameObject skirt;
    public GameObject gloves_R;
    public GameObject gloves_L;
    public GameObject coat;
    public GameObject top;
    public GameObject boot_R;
    public GameObject boot_L;

    public GameObject NotEnoughCoins;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OpenCharacter()
    {




        if (PlayerPrefs.GetInt("mycoin") >= 1500)
        {
            var unlockNumber = ReturnCharacterNumberToUnlock();
            print(unlockNumber);
            PlayerPrefs.SetInt("character" + unlockNumber, 1);
            main_char.coins -= 1500;
            main_char.UI_manager.coin.text = "" + main_char.coins;
            PlayerPrefs.SetInt("mycoin", main_char.coins);
            main_char.isStopped = true;
            main_char.swerveAmount = 0;
            main_char.swerve_InputSystem.finish = false;
            main_char.swerveAmount = 0;
            if (unlockNumber == 1)
            {


                //PlayerPrefs.SetInt("currentCharacter", unlockNumber);
            }
            else if (unlockNumber == 2)
            {
                PlayerPrefs.SetInt("charImage2", 1);
                main_char.PictureGreen[9].SetActive(false);
                main_char.PictureGreen[8].SetActive(false);
                main_char.PictureGreen[7].SetActive(false);
                main_char.PictureGreen[6].SetActive(false);
                main_char.PictureGreen[5].SetActive(false);
                main_char.PictureGreen[4].SetActive(false);
                main_char.PictureGreen[3].SetActive(false);
                main_char.PictureGreen[2].SetActive(false);
                main_char.PictureGreen[1].SetActive(true);
                main_char.PictureGreen[0].SetActive(false);
                main_char.BackGround[0].SetActive(false);
                main_char.CharImage[0].SetActive(true);
                coat.GetComponent<SkinnedMeshRenderer>().material = Coat[1];
                //glove_L.GetComponent<SkinnedMeshRenderer>().material = char_set_mat.Gloves[1];
                //glove_R.GetComponent<SkinnedMeshRenderer>().material = char_set_mat.Gloves[1];
                top.GetComponent<SkinnedMeshRenderer>().material = Top[1];
                skirt.GetComponent<SkinnedMeshRenderer>().material = Skirt[1];
                main_char.hair1.GetComponent<MeshRenderer>().material = Hairmat[1];
                //instantiate_glove.GetComponent<SkinnedMeshRenderer>().material = char_set_mat.Gloves[1];
                main_char.instantiateSkirts.GetComponent<SkinnedMeshRenderer>().material = Skirt[1];
                main_char.instantiateTop.GetComponent<SkinnedMeshRenderer>().material = Top[1];
                main_char.instantiateCoat.GetComponent<SkinnedMeshRenderer>().material = Coat[1];

                PlayerPrefs.SetInt("currentCharacter", unlockNumber);
            }
            else if (unlockNumber == 3)
            {
                PlayerPrefs.SetInt("charImage3", 1);
                main_char.PictureGreen[9].SetActive(false);
                main_char.PictureGreen[8].SetActive(false);
                main_char.PictureGreen[7].SetActive(false);
                main_char.PictureGreen[6].SetActive(false);
                main_char.PictureGreen[5].SetActive(false);
                main_char.PictureGreen[4].SetActive(false);
                main_char.PictureGreen[3].SetActive(false);
                main_char.PictureGreen[2].SetActive(true);
                main_char.PictureGreen[1].SetActive(false);
                main_char.PictureGreen[0].SetActive(false);
                main_char.BackGround[1].SetActive(false);
                main_char.CharImage[1].SetActive(true);

                coat.GetComponent<SkinnedMeshRenderer>().material = Coat[2];
                //glove_L.GetComponent<SkinnedMeshRenderer>().material = char_set_mat.Gloves[2];
                //glove_R.GetComponent<SkinnedMeshRenderer>().material = char_set_mat.Gloves[2];
                top.GetComponent<SkinnedMeshRenderer>().material = Top[2];
                skirt.GetComponent<SkinnedMeshRenderer>().material = Skirt[2];
                main_char.hair1.GetComponent<MeshRenderer>().material = Hairmat[2];
                //instantiate_glove.GetComponent<SkinnedMeshRenderer>().material = char_set_mat.Gloves[2];
                main_char.instantiateSkirts.GetComponent<SkinnedMeshRenderer>().material = Skirt[2];
                main_char.instantiateTop.GetComponent<SkinnedMeshRenderer>().material = Top[2];
                main_char.instantiateCoat.GetComponent<SkinnedMeshRenderer>().material = Coat[2];
                PlayerPrefs.SetInt("currentCharacter", unlockNumber);
            }
            else if (unlockNumber == 4)
            {
                PlayerPrefs.SetInt("charImage4", 1);
                main_char.PictureGreen[9].SetActive(false);
                main_char.PictureGreen[8].SetActive(false);
                main_char.PictureGreen[7].SetActive(false);
                main_char.PictureGreen[6].SetActive(false);
                main_char.PictureGreen[5].SetActive(false);
                main_char.PictureGreen[4].SetActive(false);
                main_char.PictureGreen[3].SetActive(true);
                main_char.PictureGreen[2].SetActive(false);
                main_char.PictureGreen[1].SetActive(false);
                main_char.PictureGreen[0].SetActive(false); main_char.BackGround[2].SetActive(false); main_char.CharImage[2].SetActive(true);
                coat.GetComponent<SkinnedMeshRenderer>().material = Coat[3];
                //glove_L.GetComponent<SkinnedMeshRenderer>().material = char_set_mat.Gloves[3];
                //glove_R.GetComponent<SkinnedMeshRenderer>().material = char_set_mat.Gloves[3];
                top.GetComponent<SkinnedMeshRenderer>().material = Top[3];
                skirt.GetComponent<SkinnedMeshRenderer>().material = Skirt[3];
                main_char.hair1.GetComponent<MeshRenderer>().material = Hairmat[3];
                //instantiate_glove.GetComponent<SkinnedMeshRenderer>().material = char_set_mat.Gloves[3];
                main_char.instantiateSkirts.GetComponent<SkinnedMeshRenderer>().material = Skirt[3];
                main_char.instantiateTop.GetComponent<SkinnedMeshRenderer>().material = Top[3];
                main_char.instantiateCoat.GetComponent<SkinnedMeshRenderer>().material = Coat[3];
                PlayerPrefs.SetInt("currentCharacter", unlockNumber);
            }
            else if (unlockNumber == 5)
            {
                PlayerPrefs.SetInt("charImage5", 1);
                main_char.PictureGreen[9].SetActive(false);
                main_char.PictureGreen[8].SetActive(false);
                main_char.PictureGreen[7].SetActive(false);
                main_char.PictureGreen[6].SetActive(false);
                main_char.PictureGreen[5].SetActive(false);
                main_char.PictureGreen[4].SetActive(true);
                main_char.PictureGreen[3].SetActive(false);
                main_char.PictureGreen[2].SetActive(false);
                main_char.PictureGreen[1].SetActive(false);
                main_char.PictureGreen[0].SetActive(false); main_char.BackGround[3].SetActive(false); main_char.CharImage[3].SetActive(true);
                coat.GetComponent<SkinnedMeshRenderer>().material = Coat[4];
                //glove_L.GetComponent<SkinnedMeshRenderer>().material = char_set_mat.Gloves[4];
                //glove_R.GetComponent<SkinnedMeshRenderer>().material = char_set_mat.Gloves[4];
                top.GetComponent<SkinnedMeshRenderer>().material = Top[4];
                skirt.GetComponent<SkinnedMeshRenderer>().material = Skirt[4];
                main_char.hair1.GetComponent<MeshRenderer>().material = Hairmat[4];
                //instantiate_glove.GetComponent<SkinnedMeshRenderer>().material = char_set_mat.Gloves[4];
                main_char.instantiateSkirts.GetComponent<SkinnedMeshRenderer>().material = Skirt[4];
                main_char.instantiateTop.GetComponent<SkinnedMeshRenderer>().material = Top[4];
                main_char.instantiateCoat.GetComponent<SkinnedMeshRenderer>().material = Coat[4];
                PlayerPrefs.SetInt("currentCharacter", unlockNumber);
            }
            else if (unlockNumber == 6)
            {
                PlayerPrefs.SetInt("charImage6", 1);
                main_char.PictureGreen[9].SetActive(false);
                main_char.PictureGreen[8].SetActive(false);
                main_char.PictureGreen[7].SetActive(false);
                main_char.PictureGreen[6].SetActive(false);
                main_char.PictureGreen[5].SetActive(true);
                main_char.PictureGreen[4].SetActive(false);
                main_char.PictureGreen[3].SetActive(false);
                main_char.PictureGreen[2].SetActive(false);
                main_char.PictureGreen[1].SetActive(false);
                main_char.PictureGreen[0].SetActive(false); main_char.BackGround[4].SetActive(false); main_char.CharImage[4].SetActive(true);
                coat.GetComponent<SkinnedMeshRenderer>().material = Coat[5];
                //glove_L.GetComponent<SkinnedMeshRenderer>().material = char_set_mat.Gloves[5];
                //glove_R.GetComponent<SkinnedMeshRenderer>().material = char_set_mat.Gloves[5];
                top.GetComponent<SkinnedMeshRenderer>().material = Top[5];
                skirt.GetComponent<SkinnedMeshRenderer>().material = Skirt[5];
                main_char.hair1.GetComponent<MeshRenderer>().material = Hairmat[5];
                //instantiate_glove.GetComponent<SkinnedMeshRenderer>().material = char_set_mat.Gloves[5];
                main_char.instantiateSkirts.GetComponent<SkinnedMeshRenderer>().material = Skirt[5];
                main_char.instantiateTop.GetComponent<SkinnedMeshRenderer>().material = Top[5];
                main_char.instantiateCoat.GetComponent<SkinnedMeshRenderer>().material = Coat[5];
                PlayerPrefs.SetInt("currentCharacter", unlockNumber);
            }
            else if (unlockNumber == 7)
            {
                PlayerPrefs.SetInt("charImage7", 1);
                main_char.PictureGreen[9].SetActive(false);
                main_char.PictureGreen[8].SetActive(false);
                main_char.PictureGreen[7].SetActive(false);
                main_char.PictureGreen[6].SetActive(true);
                main_char.PictureGreen[5].SetActive(false);
                main_char.PictureGreen[4].SetActive(false);
                main_char.PictureGreen[3].SetActive(false);
                main_char.PictureGreen[2].SetActive(false);
                main_char.PictureGreen[1].SetActive(false);
                main_char.PictureGreen[0].SetActive(false); main_char.BackGround[5].SetActive(false); main_char.CharImage[5].SetActive(true);
                coat.GetComponent<SkinnedMeshRenderer>().material = Coat[6];
                //glove_L.GetComponent<SkinnedMeshRenderer>().material = char_set_mat.Gloves[6];
                //glove_R.GetComponent<SkinnedMeshRenderer>().material = char_set_mat.Gloves[6];
                top.GetComponent<SkinnedMeshRenderer>().material = Top[6];
                skirt.GetComponent<SkinnedMeshRenderer>().material = Skirt[6];
                main_char.hair1.GetComponent<MeshRenderer>().material = Hairmat[6];
                //instantiate_glove.GetComponent<SkinnedMeshRenderer>().material = char_set_mat.Gloves[6];
                main_char.instantiateSkirts.GetComponent<SkinnedMeshRenderer>().material = Skirt[6];
                main_char.instantiateTop.GetComponent<SkinnedMeshRenderer>().material = Top[6];
                main_char.instantiateCoat.GetComponent<SkinnedMeshRenderer>().material = Coat[6];
                PlayerPrefs.SetInt("currentCharacter", unlockNumber);
            }
            else if (unlockNumber == 8)

            {
                PlayerPrefs.SetInt("charImage8", 1);
                main_char.PictureGreen[9].SetActive(false);
                main_char.PictureGreen[8].SetActive(false);
                main_char.PictureGreen[7].SetActive(true);
                main_char.PictureGreen[6].SetActive(false);
                main_char.PictureGreen[5].SetActive(false);
                main_char.PictureGreen[4].SetActive(false);
                main_char.PictureGreen[3].SetActive(false);
                main_char.PictureGreen[2].SetActive(false);
                main_char.PictureGreen[1].SetActive(false);
                main_char.PictureGreen[0].SetActive(false); main_char.BackGround[6].SetActive(false); main_char.CharImage[6].SetActive(true);
                main_char.coat.GetComponent<SkinnedMeshRenderer>().material = Coat[7];
                //glove_L.GetComponent<SkinnedMeshRenderer>().material = char_set_mat.Gloves[6];
                //glove_R.GetComponent<SkinnedMeshRenderer>().material = char_set_mat.Gloves[6];
                top.GetComponent<SkinnedMeshRenderer>().material = Top[7];
                skirt.GetComponent<SkinnedMeshRenderer>().material = Skirt[7];
                main_char.hair1.GetComponent<MeshRenderer>().material = Hairmat[7];
                //instantiate_glove.GetComponent<SkinnedMeshRenderer>().material = char_set_mat.Gloves[6];
                main_char.instantiateSkirts.GetComponent<SkinnedMeshRenderer>().material = Skirt[7];
                main_char.instantiateTop.GetComponent<SkinnedMeshRenderer>().material = Top[7];
                main_char.instantiateCoat.GetComponent<SkinnedMeshRenderer>().material = Coat[7];
                PlayerPrefs.SetInt("currentCharacter", unlockNumber);
            }
        }
        else if (PlayerPrefs.GetInt("mycoin") < 1500)
        { print("NOTENOUGH");
          NotEnoughCoins.SetActive(true);
          StartCoroutine(NotEnoughCoin());
        }
        print("NOTENOUGH2");

    }
    public void OpenBikini()
    {
        if (PlayerPrefs.GetInt("charImage8") == 1 && PlayerPrefs.GetInt("charImage7") == 1 && PlayerPrefs.GetInt("charImage6") == 1
            && PlayerPrefs.GetInt("charImage5") == 1 && PlayerPrefs.GetInt("charImage4") == 1 && PlayerPrefs.GetInt("charImage3") == 1
            && PlayerPrefs.GetInt("charImage2") == 1 && PlayerPrefs.GetInt("charImage9") == 1 && PlayerPrefs.GetInt("charImage10") == 1)
        {
            main_char.UI_manager.InstantiateBikiniScene();
            var unlockNumber2 = ReturnBikiniNumberToUnlockSurpriseBox();
            print("Girdi");
            PlayerPrefs.SetInt("Bikini" + unlockNumber2, 1);
            main_char.UI_manager.count_down.gameObject.SetActive(true);
            if (unlockNumber2 == 1)
            {
                main_char.UI_manager.surpriseBoxImage.sprite = main_char.UI_manager.surpriseBoxChar[7];
                main_char.BackGroundBikini[0].SetActive(false);
                main_char.BlueBackGround[5].SetActive(false);
                main_char.BlueBackGround[4].SetActive(false);
                main_char.BlueBackGround[3].SetActive(false);
                main_char.BlueBackGround[2].SetActive(false);
                main_char.BlueBackGround[1].SetActive(false);
                main_char.BlueBackGround[0].SetActive(true);
                main_char.MainCharBikinis[1].SetActive(true);
                main_char.MainCharBikinis[2].SetActive(false);
                main_char.MainCharBikinis[3].SetActive(false);
                main_char.MainCharBikinis[4].SetActive(false);
                main_char.MainCharBikinis[5].SetActive(false);
                main_char.MainCharBikinis[6].SetActive(false);
                main_char.MainCharBikinis[0].SetActive(false);
                PlayerPrefs.SetInt("currentBikini", unlockNumber2);
            }
            else if (unlockNumber2 == 2)
            {
                main_char.UI_manager.surpriseBoxImage.sprite = main_char.UI_manager.surpriseBoxChar[8];
                main_char.BackGroundBikini[1].SetActive(false);
                main_char.BlueBackGround[5].SetActive(false);
                main_char.BlueBackGround[4].SetActive(false);
                main_char.BlueBackGround[3].SetActive(false);
                main_char.BlueBackGround[2].SetActive(false);
                main_char.BlueBackGround[1].SetActive(true);
                main_char.BlueBackGround[0].SetActive(false);
                main_char.MainCharBikinis[1].SetActive(false);
                main_char.MainCharBikinis[2].SetActive(true);
                main_char.MainCharBikinis[3].SetActive(false);
                main_char.MainCharBikinis[4].SetActive(false);
                main_char.MainCharBikinis[5].SetActive(false);
                main_char.MainCharBikinis[6].SetActive(false);
                main_char.MainCharBikinis[0].SetActive(false);
                PlayerPrefs.SetInt("currentBikini", unlockNumber2);
            }
            else if (unlockNumber2 == 3)
            {
                main_char.UI_manager.surpriseBoxImage.sprite = main_char.UI_manager.surpriseBoxChar[9];
                main_char.BackGroundBikini[2].SetActive(false);
                main_char.BlueBackGround[5].SetActive(false);
                main_char.BlueBackGround[4].SetActive(false);
                main_char.BlueBackGround[3].SetActive(false);
                main_char.BlueBackGround[2].SetActive(true);
                main_char.BlueBackGround[1].SetActive(false);
                main_char.BlueBackGround[0].SetActive(false);
                main_char.MainCharBikinis[1].SetActive(false);
                main_char.MainCharBikinis[2].SetActive(true);
                main_char.MainCharBikinis[3].SetActive(false);
                main_char.MainCharBikinis[4].SetActive(false);
                main_char.MainCharBikinis[5].SetActive(false);
                main_char.MainCharBikinis[6].SetActive(false);
                main_char.MainCharBikinis[0].SetActive(false);
                PlayerPrefs.SetInt("currentBikini", unlockNumber2);
            }
            else if (unlockNumber2 == 4)
            {
                main_char.UI_manager.surpriseBoxImage.sprite = main_char.UI_manager.surpriseBoxChar[10];
                main_char.BackGroundBikini[3].SetActive(false);
                main_char.BlueBackGround[5].SetActive(false);
                main_char.BlueBackGround[4].SetActive(false);
                main_char.BlueBackGround[3].SetActive(true);
                main_char.BlueBackGround[2].SetActive(false);
                main_char.BlueBackGround[1].SetActive(false);
                main_char.BlueBackGround[0].SetActive(false);
                main_char.MainCharBikinis[1].SetActive(false);
                main_char.MainCharBikinis[2].SetActive(true);
                main_char.MainCharBikinis[3].SetActive(false);
                main_char.MainCharBikinis[4].SetActive(false);
                main_char.MainCharBikinis[5].SetActive(false);
                main_char.MainCharBikinis[6].SetActive(false);
                main_char.MainCharBikinis[0].SetActive(false);
                PlayerPrefs.SetInt("currentBikini", unlockNumber2);
            }
            else if (unlockNumber2 == 5)
            {
                main_char.UI_manager.surpriseBoxImage.sprite = main_char.UI_manager.surpriseBoxChar[11];
                main_char.BackGroundBikini[4].SetActive(false);
                main_char.BlueBackGround[5].SetActive(false);
                main_char.BlueBackGround[4].SetActive(true);
                main_char.BlueBackGround[3].SetActive(false);
                main_char.BlueBackGround[2].SetActive(false);
                main_char.BlueBackGround[1].SetActive(false);
                main_char.BlueBackGround[0].SetActive(false);
                main_char.MainCharBikinis[1].SetActive(false);
                main_char.MainCharBikinis[2].SetActive(true);
                main_char.MainCharBikinis[3].SetActive(false);
                main_char.MainCharBikinis[4].SetActive(false);
                main_char.MainCharBikinis[5].SetActive(false);
                main_char.MainCharBikinis[6].SetActive(false);
                main_char.MainCharBikinis[0].SetActive(false);
                PlayerPrefs.SetInt("currentBikini", unlockNumber2);
            }
            else if (unlockNumber2 == 6)
            {
                main_char.UI_manager.surpriseBoxImage.sprite = main_char.UI_manager.surpriseBoxChar[12];
                main_char.BackGroundBikini[5].SetActive(false);
                main_char.BlueBackGround[5].SetActive(true);
                main_char.BlueBackGround[4].SetActive(false);
                main_char.BlueBackGround[3].SetActive(false);
                main_char.BlueBackGround[2].SetActive(false);
                main_char.BlueBackGround[1].SetActive(false);
                main_char.BlueBackGround[0].SetActive(false);
                main_char.MainCharBikinis[1].SetActive(false);
                main_char.MainCharBikinis[2].SetActive(true);
                main_char.MainCharBikinis[3].SetActive(false);
                main_char.MainCharBikinis[4].SetActive(false);
                main_char.MainCharBikinis[5].SetActive(false);
                main_char.MainCharBikinis[6].SetActive(false);
                main_char.MainCharBikinis[0].SetActive(false);
                PlayerPrefs.SetInt("currentBikini", unlockNumber2);
            }
        }
    }
    public void OpenVipChar()
    {


        main_char.isStopped = true;
        main_char.swerveAmount = 0;
        main_char.swerve_InputSystem.finish = false;
        main_char.swerveAmount = 0;
        if (main_char.coins >= 5000)
        {
            var unlockNumber = ReturnVipCharacterNumberToUnlock();
            print(unlockNumber);
            PlayerPrefs.SetInt("character" + unlockNumber, 1);

            main_char.coins -= 5000;
            main_char.UI_manager.coin.text = "" + main_char.coins;
            PlayerPrefs.SetInt("mycoin", main_char.coins);
            if (unlockNumber == 9)
            {
                PlayerPrefs.SetInt("charImage9", 1);
                main_char.PictureGreen[9].SetActive(false);
                main_char.PictureGreen[8].SetActive(true);
                main_char.PictureGreen[7].SetActive(false);
                main_char.PictureGreen[6].SetActive(false);
                main_char.PictureGreen[5].SetActive(false);
                main_char.PictureGreen[4].SetActive(false);
                main_char.PictureGreen[3].SetActive(false);
                main_char.PictureGreen[2].SetActive(false);
                main_char.PictureGreen[1].SetActive(false);
                main_char.PictureGreen[0].SetActive(false); main_char.BackGround[7].SetActive(false); main_char.CharImage[7].SetActive(true);
                main_char.coat.GetComponent<SkinnedMeshRenderer>().material = Coat[8];
                top.GetComponent<SkinnedMeshRenderer>().material = Top[8];
                skirt.GetComponent<SkinnedMeshRenderer>().material = Skirt[8];
                main_char.hair1.GetComponent<MeshRenderer>().material = Hairmat[8];
                main_char.instantiateSkirts.GetComponent<SkinnedMeshRenderer>().material = Skirt[8];
                main_char.instantiateTop.GetComponent<SkinnedMeshRenderer>().material = Top[8];
                main_char.instantiateCoat.GetComponent<SkinnedMeshRenderer>().material = Coat[8];
                PlayerPrefs.SetInt("currentCharacter", unlockNumber);
            }
            else if (unlockNumber == 10)
            {
                PlayerPrefs.SetInt("charImage10", 1);
                main_char.PictureGreen[9].SetActive(true);
                main_char.PictureGreen[8].SetActive(false);
                main_char.PictureGreen[7].SetActive(false);
                main_char.PictureGreen[6].SetActive(false);
                main_char.PictureGreen[5].SetActive(false);
                main_char.PictureGreen[4].SetActive(false);
                main_char.PictureGreen[3].SetActive(false);
                main_char.PictureGreen[2].SetActive(false);
                main_char.PictureGreen[1].SetActive(false);
                main_char.PictureGreen[0].SetActive(false); main_char.BackGround[8].SetActive(false); main_char.CharImage[8].SetActive(true);
                main_char.coat.GetComponent<SkinnedMeshRenderer>().material = Coat[9];
                top.GetComponent<SkinnedMeshRenderer>().material = Top[9];
                skirt.GetComponent<SkinnedMeshRenderer>().material = Skirt[9];
                main_char.hair1.GetComponent<MeshRenderer>().material = Hairmat[9];
                main_char.instantiateSkirts.GetComponent<SkinnedMeshRenderer>().material = Skirt[9];
                main_char.instantiateTop.GetComponent<SkinnedMeshRenderer>().material = Top[9];
                main_char.instantiateCoat.GetComponent<SkinnedMeshRenderer>().material = Coat[9];
                PlayerPrefs.SetInt("currentCharacter", unlockNumber);
            }
        }
        else if (main_char.coins < 5000)
        {
            NotEnoughCoins.SetActive(true);
            StartCoroutine(NotEnoughCoin());
        }
    }
    public int ReturnCharacterNumberToUnlock()
    {
        var tempClosedCharacterList = new List<int>();
        for (int i = 1; i < 9; i++)
        {
            if (PlayerPrefs.GetInt("character" + i) == 0)
            {
                tempClosedCharacterList.Add(i);
            }
        }

        return tempClosedCharacterList[UnityEngine.Random.Range(0, tempClosedCharacterList.Count)];
    }



    public void OpenSurpriseBoxCharacter()
    {
        main_char.sound_manager.SoundPlay(4);
        if (PlayerPrefs.GetInt("character1") == 0 || PlayerPrefs.GetInt("character2") == 0 || PlayerPrefs.GetInt("character3") == 0 || PlayerPrefs.GetInt("character5") == 0 || PlayerPrefs.GetInt("character5") == 0 || PlayerPrefs.GetInt("character4") == 0 || PlayerPrefs.GetInt("character6") == 0 || PlayerPrefs.GetInt("character7") == 0 || PlayerPrefs.GetInt("character8") == 0 || PlayerPrefs.GetInt("character9") == 0 || PlayerPrefs.GetInt("character10") == 0)
        {
            var unlockNumber = ReturnCharacterNumberToUnlockSurprsieBox();
            PlayerPrefs.SetInt("character" + unlockNumber, 1);
            //main_char.UI_manager.count_down.gameObject.SetActive(true);


            print(unlockNumber + "unlocknumber");


            if (unlockNumber == 2)
            {
                main_char.hair8.SetActive(false);
                main_char.hair3.SetActive(false);
                main_char.hair4.SetActive(false);
                main_char.hair5.SetActive(false);
                main_char.hair6.SetActive(false);
                main_char.hair1.SetActive(true);
                main_char.UI_manager.surpriseBoxImage.sprite = main_char.UI_manager.surpriseBoxChar[0];
                PlayerPrefs.SetInt("Second", 1);
                main_char.coat.GetComponent<SkinnedMeshRenderer>().material = Coat[1];
                //main_char.glove_L.GetComponent<SkinnedMeshRenderer>().material = characters_set_material.Gloves[1];
                //main_char.glove_R.GetComponent<SkinnedMeshRenderer>().material = characters_set_material.Gloves[1];
                main_char.top.GetComponent<SkinnedMeshRenderer>().material = Top[1];
                main_char.skirt.GetComponent<SkinnedMeshRenderer>().material = Skirt[1];
                main_char.hair1.GetComponent<MeshRenderer>().material = Hairmat[1];
                PlayerPrefs.SetInt("charImage2", 1);
                main_char.PictureGreen[7].SetActive(false);
                main_char.PictureGreen[6].SetActive(false);
                main_char.PictureGreen[5].SetActive(false);
                main_char.PictureGreen[4].SetActive(false);
                main_char.PictureGreen[3].SetActive(false);
                main_char.PictureGreen[2].SetActive(false);
                main_char.PictureGreen[1].SetActive(true);
                main_char.PictureGreen[0].SetActive(false);
                main_char.BackGround[1].SetActive(false);
                main_char.CharImage[1].SetActive(true);
                //coat.GetComponent<SkinnedMeshRenderer>().material = Coat[1];
                ////glove_L.GetComponent<SkinnedMeshRenderer>().material = char_set_mat.Gloves[1];
                ////glove_R.GetComponent<SkinnedMeshRenderer>().material = char_set_mat.Gloves[1];
                //top.GetComponent<SkinnedMeshRenderer>().material = Top[1];
                //skirt.GetComponent<SkinnedMeshRenderer>().material = Skirt[1];
                //main_char.hair.GetComponent<MeshRenderer>().material = Hairmat[1];
                ////instantiate_glove.GetComponent<SkinnedMeshRenderer>().material = char_set_mat.Gloves[1];
                main_char.instantiateSkirts.GetComponent<SkinnedMeshRenderer>().material = Skirt[0];
                main_char.instantiateTop.GetComponent<SkinnedMeshRenderer>().material = Top[0];
                main_char.instantiateCoat.GetComponent<SkinnedMeshRenderer>().material = Coat[0];

                //main_char.coins -= 1500;
                PlayerPrefs.SetInt("currentCharacter", unlockNumber);
            }
            else if (unlockNumber == 3)
            {
                main_char.hair8.SetActive(false);
                main_char.hair3.SetActive(true);
                main_char.hair4.SetActive(false);
                main_char.hair5.SetActive(false);
                main_char.hair6.SetActive(false);
                main_char.hair1.SetActive(false);
                main_char.UI_manager.surpriseBoxImage.sprite = main_char.UI_manager.surpriseBoxChar[1];
                main_char.coat.GetComponent<SkinnedMeshRenderer>().material = Coat[2];
                //main_char.glove_L.GetComponent<SkinnedMeshRenderer>().material = characters_set_material.Gloves[1];
                //main_char.glove_R.GetComponent<SkinnedMeshRenderer>().material = characters_set_material.Gloves[1];
                main_char.top.GetComponent<SkinnedMeshRenderer>().material = Top[2];
                main_char.skirt.GetComponent<SkinnedMeshRenderer>().material = Skirt[2];
                main_char.hair3.GetComponent<MeshRenderer>().material = Hairmat[2];
                main_char.instantiateSkirts.GetComponent<SkinnedMeshRenderer>().material = Skirt[1];
                main_char.instantiateTop.GetComponent<SkinnedMeshRenderer>().material = Top[1];
                main_char.instantiateCoat.GetComponent<SkinnedMeshRenderer>().material = Coat[1];

                PlayerPrefs.SetInt("charImage3", 1);
                main_char.PictureGreen[7].SetActive(false);
                main_char.PictureGreen[6].SetActive(false);
                main_char.PictureGreen[5].SetActive(false);
                main_char.PictureGreen[4].SetActive(false);
                main_char.PictureGreen[3].SetActive(false);
                main_char.PictureGreen[2].SetActive(true);
                main_char.PictureGreen[1].SetActive(false);
                main_char.PictureGreen[0].SetActive(false);
                main_char.BackGround[1].SetActive(false);
                main_char.CharImage[1].SetActive(true);
                PlayerPrefs.SetInt("currentCharacter", unlockNumber);
            }
            else if (unlockNumber == 4)
            {
                main_char.hair8.SetActive(false);
                main_char.hair3.SetActive(false);
                main_char.hair4.SetActive(true);
                main_char.hair5.SetActive(false);
                main_char.hair6.SetActive(false);
                main_char.hair1.SetActive(false);
                main_char.UI_manager.surpriseBoxImage.sprite = main_char.UI_manager.surpriseBoxChar[2];
                main_char.coat.GetComponent<SkinnedMeshRenderer>().material = Coat[3];
                main_char.instantiateSkirts.GetComponent<SkinnedMeshRenderer>().material = Skirt[2];
                main_char.instantiateTop.GetComponent<SkinnedMeshRenderer>().material = Top[2];
                main_char.instantiateCoat.GetComponent<SkinnedMeshRenderer>().material = Coat[2];
                main_char.top.GetComponent<SkinnedMeshRenderer>().material = Top[3];
                main_char.skirt.GetComponent<SkinnedMeshRenderer>().material = Skirt[3];
                main_char.hair4.GetComponent<MeshRenderer>().material = Hairmat[3];
                PlayerPrefs.SetInt("charImage4", 1);
                main_char.PictureGreen[7].SetActive(false);
                main_char.PictureGreen[6].SetActive(false);
                main_char.PictureGreen[5].SetActive(false);
                main_char.PictureGreen[4].SetActive(false);
                main_char.PictureGreen[3].SetActive(true);
                main_char.PictureGreen[2].SetActive(false);
                main_char.PictureGreen[1].SetActive(false);
                main_char.PictureGreen[0].SetActive(false);
                main_char.BackGround[2].SetActive(false);
                main_char.CharImage[2].SetActive(true);
                PlayerPrefs.SetInt("currentCharacter", unlockNumber);
            }
            else if (unlockNumber == 5)
            {
                main_char.hair8.SetActive(false);
                main_char.hair3.SetActive(false);
                main_char.hair4.SetActive(false);
                main_char.hair5.SetActive(true);
                main_char.hair6.SetActive(false);
                main_char.hair1.SetActive(false);
                main_char.UI_manager.surpriseBoxImage.sprite = main_char.UI_manager.surpriseBoxChar[3];
                main_char.coat.GetComponent<SkinnedMeshRenderer>().material = Coat[4];
                main_char.instantiateSkirts.GetComponent<SkinnedMeshRenderer>().material = Skirt[3];
                main_char.instantiateTop.GetComponent<SkinnedMeshRenderer>().material = Top[3];
                main_char.instantiateCoat.GetComponent<SkinnedMeshRenderer>().material = Coat[3];
                main_char.top.GetComponent<SkinnedMeshRenderer>().material = Top[4];
                main_char.skirt.GetComponent<SkinnedMeshRenderer>().material = Skirt[4];
                main_char.hair5.GetComponent<MeshRenderer>().material = Hairmat[4];
                PlayerPrefs.SetInt("charImage5", 1);
                main_char.PictureGreen[7].SetActive(false);
                main_char.PictureGreen[6].SetActive(false);
                main_char.PictureGreen[5].SetActive(false);
                main_char.PictureGreen[4].SetActive(true);
                main_char.PictureGreen[3].SetActive(false);
                main_char.PictureGreen[2].SetActive(false);
                main_char.PictureGreen[1].SetActive(false);
                main_char.PictureGreen[0].SetActive(false);
                main_char.BackGround[3].SetActive(false);
                main_char.CharImage[3].SetActive(true);
                PlayerPrefs.SetInt("currentCharacter", unlockNumber);
            }
            else if (unlockNumber == 6)
            {
                main_char.hair8.SetActive(false);
                main_char.hair3.SetActive(false);
                main_char.hair4.SetActive(false);
                main_char.hair5.SetActive(false);
                main_char.hair6.SetActive(true);
                main_char.hair1.SetActive(false);
                main_char.UI_manager.surpriseBoxImage.sprite = main_char.UI_manager.surpriseBoxChar[4];
                main_char.coat.GetComponent<SkinnedMeshRenderer>().material = Coat[5];
                main_char.instantiateSkirts.GetComponent<SkinnedMeshRenderer>().material = Skirt[4];
                main_char.instantiateTop.GetComponent<SkinnedMeshRenderer>().material = Top[4];
                main_char.instantiateCoat.GetComponent<SkinnedMeshRenderer>().material = Coat[4];
                main_char.top.GetComponent<SkinnedMeshRenderer>().material = Top[5];
                main_char.skirt.GetComponent<SkinnedMeshRenderer>().material = Skirt[5];
                main_char.hair6.GetComponent<MeshRenderer>().material = Hairmat[5];
                PlayerPrefs.SetInt("charImage6", 1);
                main_char.PictureGreen[7].SetActive(false);
                main_char.PictureGreen[6].SetActive(false);
                main_char.PictureGreen[5].SetActive(true);
                main_char.PictureGreen[4].SetActive(false);
                main_char.PictureGreen[3].SetActive(false);
                main_char.PictureGreen[2].SetActive(false);
                main_char.PictureGreen[1].SetActive(false);
                main_char.PictureGreen[0].SetActive(false);
                main_char.BackGround[4].SetActive(false);
                main_char.CharImage[4].SetActive(true);
                PlayerPrefs.SetInt("currentCharacter", unlockNumber);
            }
            else if (unlockNumber == 7)
            {
                main_char.hair8.SetActive(false);
                main_char.hair3.SetActive(false);
                main_char.hair4.SetActive(false);
                main_char.hair5.SetActive(false);
                main_char.hair6.SetActive(false);
                main_char.hair1.SetActive(true);
                main_char.UI_manager.surpriseBoxImage.sprite = main_char.UI_manager.surpriseBoxChar[5];
                main_char.coat.GetComponent<SkinnedMeshRenderer>().material = Coat[6];
                main_char.instantiateSkirts.GetComponent<SkinnedMeshRenderer>().material = Skirt[5];
                main_char.instantiateTop.GetComponent<SkinnedMeshRenderer>().material = Top[5];
                main_char.instantiateCoat.GetComponent<SkinnedMeshRenderer>().material = Coat[5];
                main_char.top.GetComponent<SkinnedMeshRenderer>().material = Top[6];
                main_char.skirt.GetComponent<SkinnedMeshRenderer>().material = Skirt[6];
                main_char.hair1.GetComponent<MeshRenderer>().material = Hairmat[6];
                PlayerPrefs.SetInt("charImage7", 1);
                main_char.PictureGreen[7].SetActive(false);
                main_char.PictureGreen[6].SetActive(true);
                main_char.PictureGreen[5].SetActive(false);
                main_char.PictureGreen[4].SetActive(false);
                main_char.PictureGreen[3].SetActive(false);
                main_char.PictureGreen[2].SetActive(false);
                main_char.PictureGreen[1].SetActive(false);
                main_char.PictureGreen[0].SetActive(false);
                main_char.BackGround[5].SetActive(false);
                main_char.CharImage[5].SetActive(true);
                PlayerPrefs.SetInt("currentCharacter", unlockNumber);
            }
            else if (unlockNumber == 8)
            {
                main_char.hair8.SetActive(true);
                main_char.hair3.SetActive(false);
                main_char.hair4.SetActive(false);
                main_char.hair5.SetActive(false);
                main_char.hair6.SetActive(false);
                main_char.hair1.SetActive(false);
                main_char.UI_manager.surpriseBoxImage.sprite = main_char.UI_manager.surpriseBoxChar[6];
                main_char.coat.GetComponent<SkinnedMeshRenderer>().material = Coat[7];
                main_char.instantiateSkirts.GetComponent<SkinnedMeshRenderer>().material = Skirt[6];
                main_char.instantiateTop.GetComponent<SkinnedMeshRenderer>().material = Top[6];
                main_char.instantiateCoat.GetComponent<SkinnedMeshRenderer>().material = Coat[6];
                main_char.top.GetComponent<SkinnedMeshRenderer>().material = Top[7];
                main_char.skirt.GetComponent<SkinnedMeshRenderer>().material = Skirt[7];
                main_char.hair8.GetComponent<MeshRenderer>().material = Hairmat[7];
                PlayerPrefs.SetInt("charImage8", 1);
                main_char.PictureGreen[7].SetActive(true);
                main_char.PictureGreen[6].SetActive(false);
                main_char.PictureGreen[5].SetActive(false);
                main_char.PictureGreen[4].SetActive(false);
                main_char.PictureGreen[3].SetActive(false);
                main_char.PictureGreen[2].SetActive(false);
                main_char.PictureGreen[1].SetActive(false);
                main_char.PictureGreen[0].SetActive(false);
                main_char.BackGround[6].SetActive(false);
                main_char.CharImage[6].SetActive(true);
                PlayerPrefs.SetInt("currentCharacter", unlockNumber);
            }
            else if (unlockNumber == 9)
            {
                PlayerPrefs.SetInt("charImage9", 1);
                main_char.hair8.SetActive(true);
                main_char.hair3.SetActive(false);
                main_char.hair4.SetActive(false);
                main_char.hair5.SetActive(false);
                main_char.hair6.SetActive(false);
                main_char.hair1.SetActive(false);
                main_char.PictureGreen[9].SetActive(false);
                main_char.PictureGreen[8].SetActive(true);
                main_char.PictureGreen[7].SetActive(false);
                main_char.PictureGreen[6].SetActive(false);
                main_char.PictureGreen[5].SetActive(false);
                main_char.PictureGreen[4].SetActive(false);
                main_char.PictureGreen[3].SetActive(false);
                main_char.PictureGreen[2].SetActive(false);
                main_char.PictureGreen[1].SetActive(false);
                main_char.PictureGreen[0].SetActive(false); main_char.BackGround[7].SetActive(false); main_char.CharImage[7].SetActive(true);
                main_char.coat.GetComponent<SkinnedMeshRenderer>().material = Coat[8];
                top.GetComponent<SkinnedMeshRenderer>().material = Top[8];
                skirt.GetComponent<SkinnedMeshRenderer>().material = Skirt[8];
                main_char.hair1.GetComponent<MeshRenderer>().material = Hairmat[8];
                main_char.instantiateSkirts.GetComponent<SkinnedMeshRenderer>().material = Skirt[8];
                main_char.instantiateTop.GetComponent<SkinnedMeshRenderer>().material = Top[8];
                main_char.instantiateCoat.GetComponent<SkinnedMeshRenderer>().material = Coat[8];
                PlayerPrefs.SetInt("currentCharacter", unlockNumber);
            }
            else if (unlockNumber == 10)
            {
                PlayerPrefs.SetInt("charImage10", 1);
                main_char.PictureGreen[9].SetActive(true);
                main_char.PictureGreen[8].SetActive(false);
                main_char.PictureGreen[7].SetActive(false);
                main_char.PictureGreen[6].SetActive(false);
                main_char.PictureGreen[5].SetActive(false);
                main_char.PictureGreen[4].SetActive(false);
                main_char.PictureGreen[3].SetActive(false);
                main_char.PictureGreen[2].SetActive(false);
                main_char.PictureGreen[1].SetActive(false);
                main_char.PictureGreen[0].SetActive(false); main_char.BackGround[8].SetActive(false); main_char.CharImage[8].SetActive(true);
                main_char.coat.GetComponent<SkinnedMeshRenderer>().material = Coat[9];
                top.GetComponent<SkinnedMeshRenderer>().material = Top[9];
                skirt.GetComponent<SkinnedMeshRenderer>().material = Skirt[9];
                main_char.hair1.GetComponent<MeshRenderer>().material = Hairmat[9];
                main_char.instantiateSkirts.GetComponent<SkinnedMeshRenderer>().material = Skirt[9];
                main_char.instantiateTop.GetComponent<SkinnedMeshRenderer>().material = Top[9];
                main_char.instantiateCoat.GetComponent<SkinnedMeshRenderer>().material = Coat[9];
                PlayerPrefs.SetInt("currentCharacter", unlockNumber);
            }
        }
        else
        {
            var unlockNumber2 = ReturnBikiniNumberToUnlockSurpriseBox();
            PlayerPrefs.SetInt("Bikini" + unlockNumber2, 1);
            //main_char.UI_manager.count_down.gameObject.SetActive(true);
            if (unlockNumber2 == 1)
            {
                PlayerPrefs.SetInt("Bikini1", 1);
                main_char.UI_manager.surpriseBoxImage.sprite = main_char.UI_manager.surpriseBoxChar[7];
                main_char.MainCharBikinis[0].SetActive(false);
                main_char.MainCharBikinis[1].SetActive(true);
                main_char.MainCharBikinis[2].SetActive(false);
                main_char.MainCharBikinis[3].SetActive(false);
                main_char.MainCharBikinis[4].SetActive(false);
                main_char.MainCharBikinis[5].SetActive(false);
                main_char.MainCharBikinis[6].SetActive(false);
                PlayerPrefs.SetInt("currentBikini", 1);
                main_char.BlueBackGround[5].SetActive(false);
                main_char.BlueBackGround[4].SetActive(false);
                main_char.BlueBackGround[3].SetActive(false);
                main_char.BlueBackGround[2].SetActive(false);
                main_char.BlueBackGround[1].SetActive(false);
                main_char.BlueBackGround[0].SetActive(true);
                main_char.BackGroundBikini[0].SetActive(false);
                main_char.BikiniImage[0].SetActive(true);

            }
            else if (unlockNumber2 == 2)
            {
                PlayerPrefs.SetInt("Bikini2", 1);
                main_char.UI_manager.surpriseBoxImage.sprite = main_char.UI_manager.surpriseBoxChar[8];
                main_char.MainCharBikinis[0].SetActive(false);
                main_char.MainCharBikinis[1].SetActive(false);
                main_char.MainCharBikinis[2].SetActive(true);
                main_char.MainCharBikinis[3].SetActive(false);
                main_char.MainCharBikinis[4].SetActive(false);
                main_char.MainCharBikinis[5].SetActive(false);
                main_char.MainCharBikinis[6].SetActive(false);
                PlayerPrefs.SetInt("currentBikini", 2);
                main_char.BlueBackGround[5].SetActive(false);
                main_char.BlueBackGround[4].SetActive(false);
                main_char.BlueBackGround[3].SetActive(false);
                main_char.BlueBackGround[2].SetActive(false);
                main_char.BlueBackGround[1].SetActive(true);
                main_char.BlueBackGround[0].SetActive(false);
                main_char.BackGroundBikini[1].SetActive(false);
                main_char.BikiniImage[1].SetActive(true);
            }
            else if (unlockNumber2 == 3)
            {
                PlayerPrefs.SetInt("Bikini3", 1);
                main_char.UI_manager.surpriseBoxImage.sprite = main_char.UI_manager.surpriseBoxChar[9];
                main_char.MainCharBikinis[0].SetActive(false);
                main_char.MainCharBikinis[1].SetActive(false);
                main_char.MainCharBikinis[2].SetActive(false);
                main_char.MainCharBikinis[3].SetActive(true);
                main_char.MainCharBikinis[4].SetActive(false);
                main_char.MainCharBikinis[5].SetActive(false);
                main_char.MainCharBikinis[6].SetActive(false);
                PlayerPrefs.SetInt("currentBikini", 3);
                main_char.BlueBackGround[5].SetActive(false);
                main_char.BlueBackGround[4].SetActive(false);
                main_char.BlueBackGround[3].SetActive(false);
                main_char.BlueBackGround[2].SetActive(true);
                main_char.BlueBackGround[1].SetActive(false);
                main_char.BlueBackGround[0].SetActive(false);
                main_char.BackGroundBikini[2].SetActive(false);
                main_char.BikiniImage[2].SetActive(true);

            }
            else if (unlockNumber2 == 4)
            {
                PlayerPrefs.SetInt("Bikini4", 1);
                main_char.UI_manager.surpriseBoxImage.sprite = main_char.UI_manager.surpriseBoxChar[10];
                main_char.MainCharBikinis[0].SetActive(false);
                main_char.MainCharBikinis[1].SetActive(false);
                main_char.MainCharBikinis[2].SetActive(false);
                main_char.MainCharBikinis[3].SetActive(false);
                main_char.MainCharBikinis[4].SetActive(true);
                main_char.MainCharBikinis[5].SetActive(false);
                main_char.MainCharBikinis[6].SetActive(false);
                PlayerPrefs.SetInt("currentBikini", 4);
                main_char.BackGroundBikini[3].SetActive(false);
                main_char.BikiniImage[3].SetActive(true);
                main_char.BlueBackGround[5].SetActive(false);
                main_char.BlueBackGround[4].SetActive(false);
                main_char.BlueBackGround[3].SetActive(true);
                main_char.BlueBackGround[2].SetActive(false);
                main_char.BlueBackGround[1].SetActive(false);
                main_char.BlueBackGround[0].SetActive(false);
            }
            else if (unlockNumber2 == 5)
            {
                PlayerPrefs.SetInt("Bikini5", 1);
                main_char.UI_manager.surpriseBoxImage.sprite = main_char.UI_manager.surpriseBoxChar[11];
                main_char.MainCharBikinis[0].SetActive(false);
                main_char.MainCharBikinis[1].SetActive(false);
                main_char.MainCharBikinis[2].SetActive(false);
                main_char.MainCharBikinis[3].SetActive(false);
                main_char.MainCharBikinis[4].SetActive(false);
                main_char.MainCharBikinis[5].SetActive(true);
                main_char.MainCharBikinis[6].SetActive(false);
                PlayerPrefs.SetInt("currentBikini", 5);
                main_char.BackGroundBikini[4].SetActive(false);
                main_char.BikiniImage[4].SetActive(true);
                main_char.BlueBackGround[5].SetActive(false);
                main_char.BlueBackGround[4].SetActive(true);
                main_char.BlueBackGround[3].SetActive(false);
                main_char.BlueBackGround[2].SetActive(false);
                main_char.BlueBackGround[1].SetActive(false);
                main_char.BlueBackGround[0].SetActive(false);
            }
            else if (unlockNumber2 == 6)
            {
                main_char.UI_manager.surpriseBoxImage.sprite = main_char.UI_manager.surpriseBoxChar[12];
                main_char.MainCharBikinis[0].SetActive(false);
                main_char.MainCharBikinis[1].SetActive(false);
                main_char.MainCharBikinis[2].SetActive(false);
                main_char.MainCharBikinis[3].SetActive(false);
                main_char.MainCharBikinis[4].SetActive(false);
                main_char.MainCharBikinis[5].SetActive(false);
                main_char.MainCharBikinis[6].SetActive(true);
                PlayerPrefs.SetInt("currentBikini", 6);
                main_char.BackGroundBikini[5].SetActive(false);
                main_char.BikiniImage[5].SetActive(true);
                main_char.BlueBackGround[5].SetActive(true);
                main_char.BlueBackGround[4].SetActive(false);
                main_char.BlueBackGround[3].SetActive(false);
                main_char.BlueBackGround[2].SetActive(false);
                main_char.BlueBackGround[1].SetActive(false);
                main_char.BlueBackGround[0].SetActive(false);
                PlayerPrefs.SetInt("Bikini6", 1);
            }
            main_char.UI_manager.InstantiateBikiniScene();
        }

        PlayerPrefs.SetInt("surpriseBox", 1);
        //main_char.UI_manager.count_down.countdownTime = 10;
        //print(main_char.UI_manager.count_down.countdownTime);
        //main_char.UI_manager.count_down.countdownDisplay.text = main_char.UI_manager.count_down.countdownTime.ToString();
        //StartCoroutine(main_char.UI_manager.count_down.CountdownsSurpriseBox());
        main_char.UI_manager.surpriseBoxOpen = DateTime.Now;
        PlayerPrefs.SetString("SurpriseBoxOpen", main_char.UI_manager.surpriseBoxOpen.ToString());
        main_char.UI_manager.game_manager.surpriseBoxClaimTrue = true;

        main_char.UI_manager.surpriseBoxOpen = System.DateTime.Parse(PlayerPrefs.GetString("SurpriseBoxOpen"));

        main_char.UI_manager.surpriseBoxButton.SetActive(false);
        main_char.UI_manager.game_manager.countDown24Hours();
        main_char.UI_manager.countdownSurpriseBoxImage.SetActive(true);
    }
    public int ReturnCharacterNumberToUnlockSurprsieBox()
    {
        var tempClosedCharacterList = new List<int>();
        for (int i = 1; i < 11; i++)
        {
            if (PlayerPrefs.GetInt("character" + i) == 0)
            {
                tempClosedCharacterList.Add(i);
            }
        }

        return tempClosedCharacterList[UnityEngine.Random.Range(0, tempClosedCharacterList.Count)];


    }
    public int ReturnBikiniNumberToUnlockSurpriseBox()
    {
        var tempClosedBikiniList = new List<int>();
        for (int i = 1; i < 7; i++)
        {
            if (PlayerPrefs.GetInt("Bikini" + i) == 0)
            {
                tempClosedBikiniList.Add(i);
            }
        }

        return tempClosedBikiniList[UnityEngine.Random.Range(0, tempClosedBikiniList.Count)];
    }
    public int ReturnVipCharacterNumberToUnlock()
    {
        var tempClosedVipList = new List<int>();
        for (int i = 9; i < 11; i++)
        {
            if (PlayerPrefs.GetInt("character" + i) == 0)
            {
                tempClosedVipList.Add(i);
            }
        }

        return tempClosedVipList[UnityEngine.Random.Range(0, tempClosedVipList.Count)];
    }
    IEnumerator NotEnoughCoin()
    {
        yield return new WaitForSeconds(2f);
        NotEnoughCoins.SetActive(false);
    }
}
