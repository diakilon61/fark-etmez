using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bton : MonoBehaviour
{
    public GameObject pembe_bton_rengi;
    public GameObject kapi;
    public bool kalkıkmı = false;
    List<GameObject> deyenler = new List<GameObject>();
    bool kontrol;
    void Start()
    {
        pembe_bton_rengi.SetActive(false);
        kapi.GetComponent<Collider2D>().isTrigger = false;
    }

    void FixedUpdate()
    {
        kapi.GetComponent<Collider2D>().isTrigger = false;
        if (kalkıkmı == false)
        {
            
            kapi.GetComponent<Rigidbody2D>().simulated = true;
            kapi.GetComponent<Collider2D>().isTrigger = false;
        }
      

    }

    void OnTriggerEnter2D(Collider2D carpilan_nesne)
    {
        GameObject carpilan = carpilan_nesne.gameObject;
        if (carpilan_nesne.tag == "karakter")
        {
            deyenler.Add(carpilan);
        }
        if (carpilan_nesne.tag == "kutu")
        {
            deyenler.Add(carpilan);
        }
        if(deyenler.Count > 0 && !kalkıkmı)
        {
            pembe_bton_rengi.SetActive(true);
            kapi.GetComponent<Rigidbody2D>().velocity = (new Vector2(0, 20));
            Invoke("SimuleyiKapa", 1f);
         
            kalkıkmı = true;
        }
    }
    void OnTriggerExit2D(Collider2D carpilan_nesne)
    {

        GameObject carpilan = carpilan_nesne.gameObject;
        if (carpilan_nesne.tag == "karakter")
        {
            deyenler.Remove(carpilan);
        }
        if (carpilan_nesne.tag == "kutu")
        {
            deyenler.Remove(carpilan);
        }
        if (deyenler.Count < 1 && kalkıkmı)
        {
            pembe_bton_rengi.SetActive(false);
            kapi.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -20);
            kapi.GetComponent<Rigidbody2D>().simulated = true;
            kalkıkmı = false;
        }
    }
    void SimuleyiKapa()
    {
        kapi.GetComponent<Rigidbody2D>().simulated = false;
    }
}
