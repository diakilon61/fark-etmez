using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class swich_buton : MonoBehaviour
{
    public static swich_buton s_bton_kodu;
    public Animator animasyonum;
    bool swichacik = false, degiyormu;
    public GameObject tahta_kapi;
    public Button elTutma;
    kapi_swich kapiS;
    

    void Start()
    {
        elTutma = FindInActiveObjectByName("el_tutma").GetComponent<Button>();
        animasyonum = GetComponent<Animator>();
        animasyonum.SetBool("swichon", swichacik);
        tahta_kapi.GetComponent<kapi_swich>().kapi_bool = false;
        kapiS = tahta_kapi.GetComponent<kapi_swich>();
    }
    void Update()
    {
       
    }
    //tmm butonu hallettik kalanı kolay

    public void eylem()
    {
        if (!kapiS.kapi_surecte && degiyormu) {
            print("kapi açılıyor");
            if (!kapiS.kapi_bool)
            {
                kapiS.kapiyi_ac();
                animasyonum.SetBool("swichon", true);
            }
            else
            {
                kapiS.kapiyi_kapa();
                animasyonum.SetBool("swichon", false);
            }
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("karakter")) elTutma.onClick.AddListener(eylem);
    }
    void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("karakter")) degiyormu = true;
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("karakter")) degiyormu = false;
    }
    GameObject FindInActiveObjectByName(string name)
    {
        Transform[] objs = Resources.FindObjectsOfTypeAll<Transform>() as Transform[];
        for (int i = 0; i < objs.Length; i++)
        {
            if (objs[i].hideFlags == HideFlags.None)
            {
                if (objs[i].name == name)
                {
                    return objs[i].gameObject;
                }
            }
        }
        return null;
    }
}//

