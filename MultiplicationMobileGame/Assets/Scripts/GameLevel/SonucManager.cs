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
    bool ac�ls�nMi;

    GameManager gameManager;
    private void Awake()
    {
        gameManager = Object.FindObjectOfType<GameManager>();
    }
    private void OnEnable()
    {
        sayac = 0;
        ac�ls�nMi = true;
        dogruText.text = "";
        yanlisText.text = "";
        toplamPuan.text = "";
        tekrarOyna.GetComponent<RectTransform>().localScale = Vector3.zero;
        anaMenu.GetComponent<RectTransform>().localScale = Vector3.zero;
        StartCoroutine(ResimAcici());
    }
    

    IEnumerator ResimAcici()
    {
        while (ac�ls�nMi)
        {
            sayac += .155f;
            sonucImg.fillAmount = sayac;
            yield return new WaitForSeconds(.1f);
            if (sayac>=1)
            {
                ac�ls�nMi = false;
                sayac = 1;
                tekrarOyna.GetComponent<RectTransform>().DOScale(1,.5f);
                anaMenu.GetComponent<RectTransform>().DOScale(1, .5f);
                dogruText.text ="Do�ru: "+ gameManager.dogruAdet.ToString()+" Adet";
                yanlisText.text = "Yanl��: "+ gameManager.yanlisAdet.ToString()+" Adet";
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
