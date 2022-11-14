using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject baslaImage, dogruImage, yanlisImage;
    [SerializeField]
    public Text soruText,sonuc1,sonuc2,sonuc3,dogruAdetText,yanlisAdetText,puanText;

    string hangiOyun;
    public int birinciCarpan,ikinciCarpan,dogruSonuc,birinciYanlis,ikinciYanlis,dogruAdet,yanlisAdet,toplamPuan;

    PlayerManager playerManager;
    private void Awake()
    {
        playerManager = Object.FindObjectOfType<PlayerManager>();
    }
    void Start()
    {
        dogruImage.GetComponent<RectTransform>().DOScale(0,0);
        yanlisImage.GetComponent<RectTransform>().DOScale(0, 0);
        dogruAdet = 0;
        yanlisAdet = 0;
        toplamPuan = 0;
        if (PlayerPrefs.HasKey("hangiOyun"))
        {
            hangiOyun = PlayerPrefs.GetString("hangiOyun");
        }
        StartCoroutine(baslaYaziRoutine());
    }

    IEnumerator baslaYaziRoutine()
    {
        baslaImage.GetComponent<RectTransform>().DOScale(1.5f, .5f);
        yield return new WaitForSeconds(.5f);
        baslaImage.GetComponent<RectTransform>().DOScale(0, .5f).SetEase(Ease.InBack);
        baslaImage.GetComponent<CanvasGroup>().DOFade(0, .5f);
        yield return new WaitForSeconds(.5f);
        oyunaBasla();
    }
    void oyunaBasla()
    {
        playerManager.donsunMu = true;
        IkinciCarpan();
    }
  void BirinciCarpan()
    {
        switch (hangiOyun)
        {
            case "iki":
                birinciCarpan = 2;
                break;

            case "uc":
                birinciCarpan = 3;
                break;

            case "dort":
                birinciCarpan = 4;
                break;

            case "bes":
                birinciCarpan = 5;
                break;

            case "alti":
                birinciCarpan = 6;
                break;

            case "yedi":
                birinciCarpan = 7;
                break;

            case "sekiz":
                birinciCarpan = 8;
                break;

            case "dokuz":
                birinciCarpan = 9;
                break;

            case "on":
                birinciCarpan = 10;
                break;

            case "karisik":
                birinciCarpan = Random.Range(2,11);
                break;
        }
        Debug.Log(birinciCarpan);
    }
  void IkinciCarpan()
    {
        BirinciCarpan();
        ikinciCarpan = Random.Range(2, 11);
        int rastgeleDeger = Random.Range(1, 100);
        if (rastgeleDeger<=50)
        {
            soruText.text = birinciCarpan.ToString() + " x " + ikinciCarpan.ToString();
        }
        else
        {
            soruText.text = ikinciCarpan.ToString() + " x " + birinciCarpan.ToString();
        }
        dogruSonuc = birinciCarpan * ikinciCarpan;
        SonuclariYazdir();
    }
    void SonuclariYazdir()
    {
        birinciYanlis = dogruSonuc + Random.Range(2, 10);
        if (dogruSonuc>10)
        {
            ikinciYanlis = dogruSonuc - Random.Range(1, 8);
        }
        else
        {
            ikinciYanlis =  Mathf.Abs(dogruSonuc - Random.Range(1, 5));
        }
        int rastgeleDeger = Random.Range(1, 100);
        if (rastgeleDeger<=33)
        {
            sonuc1.text = dogruSonuc.ToString();
            sonuc2.text = birinciYanlis.ToString();
            sonuc3.text = ikinciYanlis.ToString();
        }
        else if (rastgeleDeger<=66)
        {
            sonuc2.text = dogruSonuc.ToString();
            sonuc1.text = birinciYanlis.ToString();
            sonuc3.text = ikinciYanlis.ToString();
        }
        else
        {
            sonuc3.text = dogruSonuc.ToString();
            sonuc1.text = birinciYanlis.ToString();
            sonuc2.text = ikinciYanlis.ToString();
        }
    }

    public void SonucuKontrolEt(int sonucText)
    {
        dogruImage.GetComponent<RectTransform>().DOScale(0, 0f);
        yanlisImage.GetComponent<RectTransform>().DOScale(0,0f);

        if (sonucText==dogruSonuc)
        {
            dogruAdet++;
            toplamPuan += 20;
            dogruImage.GetComponent<RectTransform>().DOScale(1,.1f);
           
        }
        else
        {
            yanlisAdet++;
            yanlisImage.GetComponent<RectTransform>().DOScale(1, .1f);
        }
        IkinciCarpan();
        dogruAdetText.text = dogruAdet.ToString() + " DOÐRU";
        yanlisAdetText.text = yanlisAdet.ToString() + " YANLIÞ";
        puanText.text = toplamPuan.ToString() + " PUAN";
    }
}
