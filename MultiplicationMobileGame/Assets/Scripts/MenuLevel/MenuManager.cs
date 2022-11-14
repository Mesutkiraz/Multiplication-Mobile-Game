using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private GameObject menuPanel,sesDurumImg;
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip audioClip;

    bool sesPanel;

    // Start is called before the first frame update
    void Start()
    {
        sesPanel = false;
        menuAcilis();
    }

    void menuAcilis()
    {
        menuPanel.GetComponent<CanvasGroup>().DOFade(1, 1f);
        menuPanel.GetComponent<RectTransform>().DOScale(1, 1f).SetEase(Ease.OutBack);
    }
    public void ikinciLevelagec()
    {
        if (PlayerPrefs.GetInt("sesDurum") == 1)
        {
            audioSource.PlayOneShot(audioClip);
        }
        SceneManager.LoadScene("ikinciMenuLevel");
    }
    public void ayarlariAc()
    {
        if (!sesPanel)
        {
            sesDurumImg.GetComponent<RectTransform>().DOLocalMoveY(-111, .1f);
            sesPanel = true;
        }
        else
        {
            sesDurumImg.GetComponent<RectTransform>().DOLocalMoveY(-56, .1f);
            sesPanel = false;
        }
        if (PlayerPrefs.GetInt("sesDurum")==1)
        {
            audioSource.PlayOneShot(audioClip);
        }
        
    }

    public void oyunuKapa()
    {
        if (PlayerPrefs.GetInt("sesDurum") == 1)
        {
            audioSource.PlayOneShot(audioClip);
        }
        Application.Quit();
    }
    void Update()
    {
        
    }
}
