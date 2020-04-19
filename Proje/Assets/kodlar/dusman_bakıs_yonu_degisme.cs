using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dusman_bakıs_yonu_degisme : MonoBehaviour
{

    float horizontal;
    public GameObject dusman_yonu;
    float pozisyon;
    float sayı = 20f;
    void Start()
    {
        pozisyon = dusman_yonu.transform.position.x;
    }

    // duzgun calısmadı
    void Update()
    {
        
        if (dusman_yonu.transform.position.x < pozisyon+sayı)
        {
            transform.localScale = new Vector3(1, 1, 1);
           

        }
        else if (dusman_yonu.transform.position.x > pozisyon)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            if (dusman_yonu.transform.position.x == pozisyon)
            {
                return;
            }
        }
    }
}
