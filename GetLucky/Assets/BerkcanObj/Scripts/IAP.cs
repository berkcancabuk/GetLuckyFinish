using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Purchasing;

public class IAP : MonoBehaviour, IStoreListener
{
    private static IStoreController m_StoreController;          // Unity'nin satýn alma sistemini tanýmlýyoruz
    private static IExtensionProvider m_StoreExtensionProvider; // Alt satýn alma iþlevini tanýmlýyoruz.
    public MainChar main_char;
    public static string ReklamKapat = "ReklamKapatildi";
    public GameObject butonum;

    void Start()
    {
        // Eðer Store Verilerimiz boþ ise oluþturuyoruz
        if (m_StoreController == null)
        {
            // ürünlerimizi ürün katalogumuza ekliyoruz.
            InitializePurchasing();
        }
    }

    public void InitializePurchasing()
    {
        // Baðlantý kurdukmu onu kontrol ediyoruz
        if (IsInitialized())
        {
            return;
        }

        // Maðazýma ürün eklemen önce ne yapmamýz lazým ? Maðaza açmamýz gerekiyor deðil mi ?
        // Ýþte bunu yapmak için builder kullnarak bir maðaza oluþturuyoruz.
        var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());
        builder.AddProduct(ReklamKapat, ProductType.NonConsumable);
        // Burada oluþturuduðumuz maðazamýza ürünler oluþturuyoruz. Ürünlerin 3 Çeþiti vardýr.

        // Consumable =Kullanýcýlar Ürünü tekrar tekrar satýn alabilirler. 
        /* *Sanal para birimleri
         *Saðlýk iksirleri
         * Geçici güç - up.
        */

        // Non - Consumable  =Kullanýcýlar Ürünü yalnýzca bir kez satýn alabilir.
        /*
          * Silah veya zýrh
          * Ekstra içeriðe eriþim
        */

        // Subscription  =Kullanýcýlar, Ürüne sýnýrlý bir süre için eriþebilirler.
        /*Bir online oyuna aylýk eriþim
        *Günlük bonuslar
        *Ücretsiz deneme
        */


        //      builder.AddProduct(Urununyukaridabelirlediðimadi, ProductType.Consumable);
        // ürünün türü

        // Tüm ürünlerimizi belirledikten sonra artýk maðazanýn tamamen ürünler ile birlikte oluþturulmasýný
        // saðlýyoruz.
        UnityPurchasing.Initialize(this, builder);
        print("Ýnitialized etti mi purchasing?");
    }

    private bool IsInitialized()
    {
        // Yukarýda  tanýmladýðýmýz tanýmlamarý kontrol ediyor. satýn alma sistemi ile sorun varmý yok mu kontrol
        //ediyor. Duruma göre bize cevap döndürüyor.
        print("Ýnitialized etti mi");
        return m_StoreController != null && m_StoreExtensionProvider != null;
    }

    // Örnek ürün alma fonksiyonu, oyunumuzdaki butona týklanýldýðýnda bu fonksiyon çalýþacak
    // bu fonksiyon ürün adýný yani tanýmlamasýný satýn alma fonksiyonuna taþýyacaktýr.

    public void urunalmafonksiyonu()
    {

        BuyProductID(ReklamKapat);
        print("ürünü aldý");
    }




    // Butonlara týklanýldýðýnda tetiklenen satýn alma fonksiyonudur.
    void BuyProductID(string productId)
    {
        // Baðlantýda sorun varmý yok mu diye kontrol ediyoruz.
        if (IsInitialized())
        {

            // burada dikkat etmen gereken konu, bu fonksiyon string türünde veri alýyorya
            // iþte biz onu burada controllerimiza aktarýyoruz ve sistem o id'ye göre
            // ilgili ürünü çekebiliyor.
            Product product = m_StoreController.products.WithID(productId);
            print("ürünü çekti mi ");

            // eðer ürün varsa ve ürün satýn alýnabilir bir durumdaysa
            if (product != null && product.availableToPurchase)
            {
                print("satýn alýnabilir bir durum ");
                // ürünün id deðerini lazým olursa böyle alabilirsin.
                // product.definition.id

                // satýn alýnma için hareketi baþlatýyoruz ve InitiatePurchase fonksiyonu satýn almayý baþlatýr.
                m_StoreController.InitiatePurchase(product);
            }

            else
            {
                Debug.Log("Satýn alýrken hata oluþtu, Ürün bulunamýyor, ürün yok");
            }
        }

        else
        {

            Debug.Log("Ürün kod tanýmsýz veya ürün çaðýrýlamýyor.");
        }
    }


    /*public void RestorePurchases()
    {
        // Satýn alma henüz kurulmadýysa
        if (!IsInitialized())
        {
            Debug.Log("Geri Alým baþarýsýz");
            return;
        }

        // Bir apple cihazýnda çalýþýyorsak, satýn alýnan bir üründe hata olursa onu kurtarabiliyoruz.
        // bu þuanlýk sadece apple tarafýndan desteklenmektedir. Burada cihazý sorguluyoruz.
        if (Application.platform == RuntimePlatform.IPhonePlayer ||
            Application.platform == RuntimePlatform.OSXPlayer)
        {
            // ... begin restoring purchases
            Debug.Log("Onarma, kurtarma Baþladý");

            // Apple store özgü alt sistemi çaðýrýyoruz.
            var apple = m_StoreExtensionProvider.GetExtension<IAppleExtensions>();

            apple.RestoreTransactions((result) => {
                // Geri yüklemeyi baþlattý. Geri yükleme iþleminin sonucunu döndürür.
                Debug.Log("Geri yükleme devam ediyor. Durum = : " + result);
            });
        }

        else
        {
            // Eðer cihazýmýn apple ürünü deðilse burasý dönecektir ve kullanýlan platformu bize yazacaktýr.
            Debug.Log("Geri yükleme baþarýsýz, bu platform desteklenmiyor. Kullanýlan Platfrom = " + Application.platform);
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

    // Burada satýn alma iþleminin, sürecini kontol ederiz.
    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args)
    {
        // Eðer gelen ürün id'si bizim sistemde tanýmladýðýmýz id'mize eþitse, satýn alýnan ürünü oyuncuya
        // verme yeri burasýdýr. Burada ki amaç hangi ürünü satýn aldýðýný anlamaktýr.
        if (String.Equals(args.purchasedProduct.definition.id, ReklamKapat, StringComparison.Ordinal))
        {
            print("reklamý kapattý mý");
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
            Debug.Log(string.Format("Baþarýsýz, Tanýnmayan bir ürün"));
        }


        return PurchaseProcessingResult.Complete;
    }


    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
    {

        Debug.Log(string.Format("Satýn alma baþarýsýz"));
    }


}
