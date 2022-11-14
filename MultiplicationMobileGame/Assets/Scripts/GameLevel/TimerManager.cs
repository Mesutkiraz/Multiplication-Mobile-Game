using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{
    [SerializeField]
    private Text sureText;
    [SerializeField]
    private GameObject sonucPanel,sureSayac,puanPanel,dogruYanlýs,player,sonuc;
    int kalanSure;
    bool saysinMi;
    void Start()
    {
        kalanSure = 5;
        sonucPanel.SetActive(false);
        sureSayac.SetActive(true);
        puanPanel.SetActive(true);
        dogruYanlýs.SetActive(true);
        player.SetActive(true);
        sonuc.SetActive(true);
        saysinMi = true;
        StartCoroutine(sureyiSaysinmi());
    }
    IEnumerator sureyiSaysinmi()
    {
        
        while (saysinMi)
        {
            yield return new WaitForSeconds(1f);
            if (kalanSure<10)
            {
                sureText.text = "0" + kalanSure.ToString();
            }
            else
            {
                sureText.text = kalanSure.ToString();
            }
            if (kalanSure<=0)
            {
                saysinMi = false;
                sonucPanel.SetActive(true);
                sureSayac.SetActive(false);
                puanPanel.SetActive(false);
                dogruYanlýs.SetActive(false);
                player.SetActive(false);
                sonuc.SetActive(false);
                sureText.text = "";
            }
            kalanSure--;

        }
    }


}
