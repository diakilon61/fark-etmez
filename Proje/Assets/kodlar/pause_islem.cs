using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class pause_islem : MonoBehaviour
{

    public static bool oyun_devam_ediyormu = true;
    public GameObject pnlı_pause;

    public void oyun_durdur_devam_et()
    {
        if (oyun_devam_ediyormu)
        {
            //oyun durdugunda yapılacaklar
            
            Time.timeScale = 0;
            pnlı_pause.SetActive(true);
            oyun_devam_ediyormu = false;
        }
        else if(oyun_devam_ediyormu==false)
        {
            //oyun devam ettıgınde
            oyun_devam_ediyormu = true;
            Time.timeScale = 1;
            pnlı_pause.SetActive(false);
        }
    }
    public void devam_ettir()
    {
        Time.timeScale = 1;
        pnlı_pause.SetActive(false);
    }
    public void ana_menü_dön()
    {
        oyun_devam_ediyormu = true;
        SceneManager.LoadScene("ana_menü");

    }
    public void bolum_tekrar_oyna()
    {
        oyun_devam_ediyormu = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale=1;
    }
    public void oyunu_kapat()
    {
        Application.Quit();
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
