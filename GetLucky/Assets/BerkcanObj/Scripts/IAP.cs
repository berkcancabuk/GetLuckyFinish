using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Purchasing;

public class IAP : MonoBehaviour, IStoreListener
{
    private static IStoreController m_StoreController;          // Unity'nin sat�n alma sistemini tan�ml�yoruz
    private static IExtensionProvider m_StoreExtensionProvider; // Alt sat�n alma i�levini tan�ml�yoruz.
    public MainChar main_char;
    public static string ReklamKapat = "ReklamKapatildi";
    public GameObject butonum;

    void Start()
    {
        // E�er Store Verilerimiz bo� ise olu�turuyoruz
        if (m_StoreController == null)
        {
            // �r�nlerimizi �r�n katalogumuza ekliyoruz.
            InitializePurchasing();
        }
    }

    public void InitializePurchasing()
    {
        // Ba�lant� kurdukmu onu kontrol ediyoruz
        if (IsInitialized())
        {
            return;
        }

        // Ma�az�ma �r�n eklemen �nce ne yapmam�z laz�m ? Ma�aza a�mam�z gerekiyor de�il mi ?
        // ��te bunu yapmak i�in builder kullnarak bir ma�aza olu�turuyoruz.
        var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());
        builder.AddProduct(ReklamKapat, ProductType.NonConsumable);
        // Burada olu�turudu�umuz ma�azam�za �r�nler olu�turuyoruz. �r�nlerin 3 �e�iti vard�r.

        // Consumable =Kullan�c�lar �r�n� tekrar tekrar sat�n alabilirler. 
        /* *Sanal para birimleri
         *Sa�l�k iksirleri
         * Ge�ici g�� - up.
        */

        // Non - Consumable  =Kullan�c�lar �r�n� yaln�zca bir kez sat�n alabilir.
        /*
          * Silah veya z�rh
          * Ekstra i�eri�e eri�im
        */

        // Subscription  =Kullan�c�lar, �r�ne s�n�rl� bir s�re i�in eri�ebilirler.
        /*Bir online oyuna ayl�k eri�im
        *G�nl�k bonuslar
        *�cretsiz deneme
        */


        //      builder.AddProduct(Urununyukaridabelirledi�imadi, ProductType.Consumable);
        // �r�n�n t�r�

        // T�m �r�nlerimizi belirledikten sonra art�k ma�azan�n tamamen �r�nler ile birlikte olu�turulmas�n�
        // sa�l�yoruz.
        UnityPurchasing.Initialize(this, builder);
        print("�nitialized etti mi purchasing?");
    }

    private bool IsInitialized()
    {
        // Yukar�da  tan�mlad���m�z tan�mlamar� kontrol ediyor. sat�n alma sistemi ile sorun varm� yok mu kontrol
        //ediyor. Duruma g�re bize cevap d�nd�r�yor.
        print("�nitialized etti mi");
        return m_StoreController != null && m_StoreExtensionProvider != null;
    }

    // �rnek �r�n alma fonksiyonu, oyunumuzdaki butona t�klan�ld���nda bu fonksiyon �al��acak
    // bu fonksiyon �r�n ad�n� yani tan�mlamas�n� sat�n alma fonksiyonuna ta��yacakt�r.

    public void urunalmafonksiyonu()
    {

        BuyProductID(ReklamKapat);
        print("�r�n� ald�");
    }




    // Butonlara t�klan�ld���nda tetiklenen sat�n alma fonksiyonudur.
    void BuyProductID(string productId)
    {
        // Ba�lant�da sorun varm� yok mu diye kontrol ediyoruz.
        if (IsInitialized())
        {

            // burada dikkat etmen gereken konu, bu fonksiyon string t�r�nde veri al�yorya
            // i�te biz onu burada controllerimiza aktar�yoruz ve sistem o id'ye g�re
            // ilgili �r�n� �ekebiliyor.
            Product product = m_StoreController.products.WithID(productId);
            print("�r�n� �ekti mi ");

            // e�er �r�n varsa ve �r�n sat�n al�nabilir bir durumdaysa
            if (product != null && product.availableToPurchase)
            {
                print("sat�n al�nabilir bir durum ");
                // �r�n�n id de�erini laz�m olursa b�yle alabilirsin.
                // product.definition.id

                // sat�n al�nma i�in hareketi ba�lat�yoruz ve InitiatePurchase fonksiyonu sat�n almay� ba�lat�r.
                m_StoreController.InitiatePurchase(product);
            }

            else
            {
                Debug.Log("Sat�n al�rken hata olu�tu, �r�n bulunam�yor, �r�n yok");
            }
        }

        else
        {

            Debug.Log("�r�n kod tan�ms�z veya �r�n �a��r�lam�yor.");
        }
    }


    /*public void RestorePurchases()
    {
        // Sat�n alma hen�z kurulmad�ysa
        if (!IsInitialized())
        {
            Debug.Log("Geri Al�m ba�ar�s�z");
            return;
        }

        // Bir apple cihaz�nda �al���yorsak, sat�n al�nan bir �r�nde hata olursa onu kurtarabiliyoruz.
        // bu �uanl�k sadece apple taraf�ndan desteklenmektedir. Burada cihaz� sorguluyoruz.
        if (Application.platform == RuntimePlatform.IPhonePlayer ||
            Application.platform == RuntimePlatform.OSXPlayer)
        {
            // ... begin restoring purchases
            Debug.Log("Onarma, kurtarma Ba�lad�");

            // Apple store �zg� alt sistemi �a��r�yoruz.
            var apple = m_StoreExtensionProvider.GetExtension<IAppleExtensions>();

            apple.RestoreTransactions((result) => {
                // Geri y�klemeyi ba�latt�. Geri y�kleme i�leminin sonucunu d�nd�r�r.
                Debug.Log("Geri y�kleme devam ediyor. Durum = : " + result);
            });
        }

        else
        {
            // E�er cihaz�m�n apple �r�n� de�ilse buras� d�necektir ve kullan�lan platformu bize yazacakt�r.
            Debug.Log("Geri y�kleme ba�ar�s�z, bu platform desteklenmiyor. Kullan�lan Platfrom = " + Application.platform);
        }
    }*/

    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {

        Debug.Log("OnInitialized: PASS");
        m_StoreController = controller;
        m_StoreExtensionProvider = extensions;
    }


    public void OnInitializeFailed(InitializationFailureReason error)
    {

        Debug.Log("OnInitializeFailed InitializationFailureReason:" + error);
    }

    // Burada sat�n alma i�leminin, s�recini kontol ederiz.
    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args)
    {
        // E�er gelen �r�n id'si bizim sistemde tan�mlad���m�z id'mize e�itse, sat�n al�nan �r�n� oyuncuya
        // verme yeri buras�d�r. Burada ki ama� hangi �r�n� sat�n ald���n� anlamakt�r.
        if (String.Equals(args.purchasedProduct.definition.id, ReklamKapat, StringComparison.Ordinal))
        {
            print("reklam� kapatt� m�");
            butonum.SetActive(false);
            main_char.ReklamKapatmaPaneli.SetActive(false);

            PlayerPrefs.SetInt("ReklamlarKapali", 1);
            //PlayerPrefs.Save();
        }


        /* gibi devam edebiliriz. 
         else if (String.Equals(args.purchasedProduct.definition.id, Elmas_10, StringComparison.Ordinal))
     {

         PlayerPrefs.SetInt("ElmasSayisi", PlayerPrefs.GetInt("ElmasSayisi") + 10);
         PlayerPrefs.Save();
     }

         */
        else
        {
            Debug.Log(string.Format("Ba�ar�s�z, Tan�nmayan bir �r�n"));
        }


        return PurchaseProcessingResult.Complete;
    }


    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
    {

        Debug.Log(string.Format("Sat�n alma ba�ar�s�z"));
    }


}
