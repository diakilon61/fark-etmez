using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kapi_swich : MonoBehaviour
{
    public static kapi_swich Instance;
    public Animator animasyonkapi;
    public bool kapi_bool = false, kapi_surecte;

    void Start()
    {
        animasyonkapi  = GetComponent<Animator>();
        animasyonkapi.SetBool("kapi_bton_acik", kapi_bool);
        kapi_bool = false;
    }


    public void kapiyi_kapa()
    {
        animasyonkapi.SetBool("kapi_bton_acik", false);
        kapi_bool = false;
        kapi_surecte = true;
        Invoke("booluAyarla", 1f);
    }
    public void kapiyi_ac()
    {
        animasyonkapi.SetBool("kapi_bton_acik", true);
        kapi_bool = true;
        kapi_surecte = true;
        Invoke("booluAyarla", 1f);
    }
   void booluAyarla()
    {
        kapi_surecte = false;
    }
}
