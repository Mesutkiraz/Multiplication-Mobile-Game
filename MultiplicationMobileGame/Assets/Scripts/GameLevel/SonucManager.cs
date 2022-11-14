using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class SonucManager : MonoBehaviour
{
    [SerializeField]
    private Image sonucImg;
    [SerializeField]
    private Text dogruText, yanlisText, toplamPuan;
    [SerializeField]
    private GameObject tekrarOyna, anaMenu;

    float sayac;
    bool acýlsýnMi;

    GameManager gameManager;
    private void Awake()
    {
        gameManager = Object.FindObjectOfType<GameManager>();
    }
    private void OnEnable()
    {
        sayac = 0;
        acýlsýnMi = true;
        dogruText.text = "";
        yanlisText.text = "";
        toplamPuan.text = "";
        tekrarOyna.GetComponent<RectTransform>().localScale = Vector3.zero;
        anaMenu.GetComponent<RectTransform>().localScale = Vector3.zero;
        StartCoroutine(ResimAcici());
    }
    

    IEnumerator ResimAcici()
    {
        while (acýlsýnMi)
        {
            sayac += .155f;
            sonucImg.fillAmount = sayac;
            yield return new WaitForSeconds(.1f);
            if (sayac>=1)
            {
                acýlsýnMi = false;
                sayac = 1;
                tekrarOyna.GetComponent<RectTransform>().DOScale(1,.5f);
                anaMenu.GetComponent<RectTransform>().DOScale(1, .5f);
                dogruText.text ="Doðru: "+ gameManager.dogruAdet.ToString()+" Adet";
                yanlisText.text = "Yanlýþ: "+ gameManager.yanlisAdet.ToString()+" Adet";
                toplamPuan.text ="Puan: " +gameManager.toplamPuan.ToString()+" Puan";

            }
        }
    }
    public void TekrarOyna()
    {
        SceneManager.LoadScene("GameLevel");       
    }
    public void AnaMenu()
    {
        SceneManager.LoadScene("MenuLevel");
    }
}
