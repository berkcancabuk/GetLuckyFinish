using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefInitializer : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        if (!PlayerPrefs.HasKey("ReklamlarKapali"))
        {
            PlayerPrefs.SetInt("ReklamlarKapali", 0);
        }
        if (!PlayerPrefs.HasKey("mycoin"))
        {
            PlayerPrefs.SetInt("mycoin", 50000);
        }
        if (!PlayerPrefs.HasKey("restartValue"))
        {
            PlayerPrefs.SetInt("restartValue", 0);
        }
        if (!PlayerPrefs.HasKey("howmuchBikini"))
        {
            PlayerPrefs.SetInt("howmuchBikini", 0);
        }
        if (!PlayerPrefs.HasKey("character1"))
        {
            PlayerPrefs.SetInt("character1", 1);
        }
        if (!PlayerPrefs.HasKey("character2"))
        {
            PlayerPrefs.SetInt("character2", 0);
        }
        if (!PlayerPrefs.HasKey("character3"))
        {
            PlayerPrefs.SetInt("character3", 0);
        }
        if (!PlayerPrefs.HasKey("character4"))
        {
            PlayerPrefs.SetInt("character4", 0);
        }
        if (!PlayerPrefs.HasKey("character5"))
        {
            PlayerPrefs.SetInt("character5", 0);
        }
        if (!PlayerPrefs.HasKey("character6"))
        {
            PlayerPrefs.SetInt("character6", 0);
        }
        if (!PlayerPrefs.HasKey("character7"))
        {
            PlayerPrefs.SetInt("character7", 0);
        }
        if (!PlayerPrefs.HasKey("character8"))
        {
            PlayerPrefs.SetInt("character8", 0);
        }
        if (!PlayerPrefs.HasKey("character9"))
        {
            PlayerPrefs.SetInt("character9", 0);
        }
        if (!PlayerPrefs.HasKey("character10"))
        {
            PlayerPrefs.SetInt("character10", 0);
        }
        if (!PlayerPrefs.HasKey("currentCharacter"))
        {
            PlayerPrefs.SetInt("currentCharacter", 1);
        }
        if (!PlayerPrefs.HasKey("currentBikini"))
        {
            PlayerPrefs.SetInt("currentBikini", 0);
        }
        if (!PlayerPrefs.HasKey("currentAddBikini1"))
        {
            PlayerPrefs.SetInt("currentAddBikini1", 0);
        }
        if (!PlayerPrefs.HasKey("currentAddBikini2"))
        {
            PlayerPrefs.SetInt("currentAddBikini2", 0);
        }
        if (!PlayerPrefs.HasKey("currentAddBikini3"))
        {
            PlayerPrefs.SetInt("currentAddBikini3", 0);
        }
        if (!PlayerPrefs.HasKey("currentAddBikini4"))
        {
            PlayerPrefs.SetInt("currentAddBikini4", 0);
        }
        if (!PlayerPrefs.HasKey("currentAddBikini5"))
        {
            PlayerPrefs.SetInt("currentAddBikini5", 0);
        }
        if (!PlayerPrefs.HasKey("currentAddBikini6"))
        {
            PlayerPrefs.SetInt("currentAddBikini6", 0);
        }
        if (!PlayerPrefs.HasKey("collectedBikini"))
        {
            PlayerPrefs.SetInt("collectedBikini", 0);
        }
        if (!PlayerPrefs.HasKey("Bikini1"))
        {
            PlayerPrefs.SetInt("Bikini1", 0);
        }
        if (!PlayerPrefs.HasKey("Bikini2"))
        {
            PlayerPrefs.SetInt("Bikini2", 0);
        }
        if (!PlayerPrefs.HasKey("Bikini3"))
        {
            PlayerPrefs.SetInt("Bikini3", 0);
        }
        if (!PlayerPrefs.HasKey("Bikini4"))
        {
            PlayerPrefs.SetInt("Bikini4", 0);
        }
        if (!PlayerPrefs.HasKey("Bikini5"))
        {
            PlayerPrefs.SetInt("Bikini5", 0);
        }
        if (!PlayerPrefs.HasKey("Bikini6"))
        {
            PlayerPrefs.SetInt("Bikini6", 0);
        }
        if (!PlayerPrefs.HasKey("BikiniImage1"))
        {
            PlayerPrefs.SetInt("BikiniImage1", 0);
        }
        if (!PlayerPrefs.HasKey("BikiniImage2"))
        {
            PlayerPrefs.SetInt("BikiniImage2", 0);
        }
        if (!PlayerPrefs.HasKey("BikiniImage3"))
        {
            PlayerPrefs.SetInt("BikiniImage3", 0);
        }
        if (!PlayerPrefs.HasKey("BikiniImage4"))
        {
            PlayerPrefs.SetInt("BikiniImage4", 0);
        }
        if (!PlayerPrefs.HasKey("BikiniImage5"))
        {
            PlayerPrefs.SetInt("BikiniImage5", 0);
        }
        if (!PlayerPrefs.HasKey("BikiniImage6"))
        {
            PlayerPrefs.SetInt("BikiniImage6", 0);
        }



        if (!PlayerPrefs.HasKey("surpriseBox"))
        {
            PlayerPrefs.SetInt("surpriseBox", 0);
        }

        if (!PlayerPrefs.HasKey("surpriseBoxImageFirst"))
        {
            PlayerPrefs.SetInt("surpriseBoxImageFirst", 1);
        }
        if (!PlayerPrefs.HasKey("surpriseBoxImageSecond"))
        {
            PlayerPrefs.SetInt("surpriseBoxImageSecond", 0);
        }
        if (!PlayerPrefs.HasKey("surpriseBoxImageThird"))
        {
            PlayerPrefs.SetInt("surpriseBoxImageThird", 0);
        }
        if (!PlayerPrefs.HasKey("surpriseBoxImageFourth"))
        {
            PlayerPrefs.SetInt("surpriseBoxImageFourth", 0);
        }
        if (!PlayerPrefs.HasKey("surpriseBoxImageFifth"))
        {
            PlayerPrefs.SetInt("surpriseBoxImageFifth", 0);
        }
        if (!PlayerPrefs.HasKey("surpriseBoxImageSixth"))
        {
            PlayerPrefs.SetInt("surpriseBoxImageSixth", 0);
        }
        if (!PlayerPrefs.HasKey("surpriseBoxImageSeventh"))
        {
            PlayerPrefs.SetInt("surpriseBoxImageSeventh", 0);
        }
        if (!PlayerPrefs.HasKey("surpriseBoxImageEighth"))
        {
            PlayerPrefs.SetInt("surpriseBoxImageEighth", 0);
        }
        if (!PlayerPrefs.HasKey("surpriseBoxImageNineth"))
        {
            PlayerPrefs.SetInt("surpriseBoxImageNineth", 0);
        }

        if (!PlayerPrefs.HasKey("SavedScene"))
        {
            PlayerPrefs.SetInt("SavedScene", 1);

        }
        if (!PlayerPrefs.HasKey("isOutOfTheGame"))
        {
            PlayerPrefs.SetInt("isOutOfTheGame", 0);
        }

        //setting panel
        if (!PlayerPrefs.HasKey("Voice"))
        {
            PlayerPrefs.SetInt("Voice", 1);
        }
        if (!PlayerPrefs.HasKey("Vibration"))
        {
            PlayerPrefs.SetInt("Vibration", 1);
        }

        // karakterlerin resimleri açýldý mý ? 


        if (!PlayerPrefs.HasKey("charImage2"))
        {
            PlayerPrefs.SetInt("charImage2", 0);
        }
        if (!PlayerPrefs.HasKey("charImage3"))
        {
            PlayerPrefs.SetInt("charImage3", 0);
        }
        if (!PlayerPrefs.HasKey("charImage4"))
        {
            PlayerPrefs.SetInt("charImage4", 0);
        }
        if (!PlayerPrefs.HasKey("charImage5"))
        {
            PlayerPrefs.SetInt("charImage5", 0);
        }
        if (!PlayerPrefs.HasKey("charImage6"))
        {
            PlayerPrefs.SetInt("charImage6", 0);
        }
        if (!PlayerPrefs.HasKey("charImage7"))
        {
            PlayerPrefs.SetInt("charImage7", 0);
        }
        if (!PlayerPrefs.HasKey("charImage8"))
        {
            PlayerPrefs.SetInt("charImage8", 0);
        }
        if (!PlayerPrefs.HasKey("charImage9"))
        {
            PlayerPrefs.SetInt("charImage9", 0);
        }
        if (!PlayerPrefs.HasKey("charImage10"))
        {
            PlayerPrefs.SetInt("charImage10", 0);
        }

        // karakterin bikinileri açýldý mý = 
        if (!PlayerPrefs.HasKey("bikiniImage1"))
        {
            PlayerPrefs.SetInt("bikiniImage1", 0);
        }
        if (!PlayerPrefs.HasKey("bikiniImage2"))
        {
            PlayerPrefs.SetInt("bikiniImage2", 0);
        }
        if (!PlayerPrefs.HasKey("bikiniImage3"))
        {
            PlayerPrefs.SetInt("bikiniImage3", 0);
        }
        if (!PlayerPrefs.HasKey("bikiniImage4"))
        {
            PlayerPrefs.SetInt("bikiniImage4", 0);
        }
        if (!PlayerPrefs.HasKey("bikiniImage5"))
        {
            PlayerPrefs.SetInt("bikiniImage5", 0);
        }
        if (!PlayerPrefs.HasKey("bikiniImage6"))
        {
            PlayerPrefs.SetInt("bikiniImage6", 0);
        }
       

        if (!PlayerPrefs.HasKey("IhaveScore"))
        {
            PlayerPrefs.SetInt("IhaveScore", 0);
        }
    }


}
