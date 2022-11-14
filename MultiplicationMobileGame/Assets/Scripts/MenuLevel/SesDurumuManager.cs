using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SesDurumuManager : MonoBehaviour
{
    
    void Start()
    {
        sesAcik();
    }

    public void sesAcik()
    {
        PlayerPrefs.SetInt("sesDurum", 1);
    }
    public void sesKapalý()
    {
        PlayerPrefs.SetInt("sesDurum", 0);
    }
}
