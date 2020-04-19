using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balta_firlatma : MonoBehaviour
{
    [SerializeField] private float dönmehizi;
    [SerializeField] private bool döndür;
    [SerializeField] private float gitme_hizi;


    void Start()
    {
        döndür = true;
        Destroy(gameObject, 1f);
    }

    void Update()
    {
    



//if(Vector2.Distance(transform.position,varis_yeri)<=0.01f)//vardı say kendı pozısyonu varısyerıne 0.01fkadr yakınsa
      //  {
      //      döndür = false;
       // }
    }
 
    void FixedUpdate()
    {
        transform.position += new Vector3(gitme_hizi * Time.deltaTime, 0, 0);
        if(döndür == true)
        {
            transform.Rotate(0, 0, dönmehizi * Time.deltaTime);
        }
        else
        {
            transform.Rotate(0, 0, 0);
        }
    }
    public void balta_sola_git()
    {
        gitme_hizi *= -1;
        transform.localScale = new Vector3(-1, 1, 1);
    }

}
