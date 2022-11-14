using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class altMenuManager : MonoBehaviour
{
    [SerializeField]
    private GameObject ikinciMenuPaneli;
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip audioClip;
    void Start()
    {
        if (ikinciMenuPaneli!=null)
        {
            ikinciMenuPaneli.GetComponent<RectTransform>().DOScale(1, 1f).SetEase(Ease.OutBack);
            ikinciMenuPaneli.GetComponent<CanvasGroup>().DOFade(1, 1f);
        }
       
    }

    public void HangiOyunAcilsin(string hangiOyun)
    {
        if (PlayerPrefs.GetInt("sesDurum") == 1)
        {
            audioSource.PlayOneShot(audioClip);
        }
        PlayerPrefs.SetString("hangiOyun", hangiOyun);
        SceneManager.LoadScene("GameLevel");
        
    }
    public void GeriGit()
    {
        if (PlayerPrefs.GetInt("sesDurum") == 1)
        {
            audioSource.PlayOneShot(audioClip);
        }
        SceneManager.LoadScene("MenuLevel");
    }

}
