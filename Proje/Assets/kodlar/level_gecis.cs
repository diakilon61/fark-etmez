﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class level_gecis : MonoBehaviour
{
  
    public void level_ac(string level_ismi)
    {
        SceneManager.LoadScene(level_ismi);
    }
    public void level_ac_siradaki()
    {
        string level_ismi = (PlayerPrefs.GetInt("level") + 1).ToString();
        SceneManager.LoadScene(level_ismi);
    }
    
    public void tetrar_oyna()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void oyunu_kapat()
    {
        Application.Quit();
    }
    public void bolumler()
    {
        SceneManager.LoadScene("levelkilit");
    }






}
