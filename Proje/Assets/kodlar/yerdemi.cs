using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class yerdemi : MonoBehaviour
{
    public LayerMask layer,layer2,layer3,layer4;
    
    public bool yerdemiyiz;
    public Rigidbody2D rigidbo;
    public float zıplamagücü;
    public GameObject karakterim_animsyon_erisim;
    public Animator animasyoncum;

    public GameObject standingon;
    private Vector3 aktifglobalppoint;
    private Vector3 aktitlokalppoint;
    public GameObject karakter_takip;

    public float tahtaziplatmagücü=30f;
    public bool tahtayadegior=false;
   public bool dusen_zeminde=false;

    
    void Update()
    {
        

        alttaplatformvarmı();


        RaycastHit2D carptı = Physics2D.Raycast(transform.position, Vector2.down, 0.5f, layer);
        if (carptı.collider != null)
        {
            yerdemiyiz = true;

        }
        else
        {
            yerdemiyiz = false;
            carptı = Physics2D.Raycast(transform.position, Vector2.down, 0.5f, layer2);
            if(carptı.collider != null)
            {
                yerdemiyiz = true;
            }

        }
        if (Input.GetKeyDown(KeyCode.Space))
        {

            zipla();


        }
        if (yerdemiyiz == true)
        {
            karakterim_animsyon_erisim.GetComponent<karakterkontrol>().animasyoncum.SetBool("zemindemi", true);
           
        }
        if (yerdemiyiz == false)
        {
            karakterim_animsyon_erisim.GetComponent<karakterkontrol>().animasyoncum.SetBool("zemindemi", false);
            if (tahtayadegior == true)
            {
                
                rigidbo.velocity += new Vector2(0, tahtaziplatmagücü);
                karakterim_animsyon_erisim.GetComponent<karakterkontrol>().animasyoncum.SetBool("zemindemi", false);
             
            }
            else if (tahtayadegior == false)
            {
                karakterim_animsyon_erisim.GetComponent<karakterkontrol>().animasyoncum.SetBool("zemindemi", true);
            }

        }
        RaycastHit2D carptıgı_obje = Physics2D.Raycast(transform.position, Vector2.down, 0.5f, layer);
        if (carptıgı_obje.collider != null)
        {
            standingon = carptıgı_obje.collider.gameObject;
            

        }
        if(standingon!=null)
        {
            aktifglobalppoint = karakter_takip.transform.position;

            aktitlokalppoint = standingon.transform.InverseTransformPoint(karakter_takip.transform.position);
            
        }
        RaycastHit2D ziplama_tahtam = Physics2D.Raycast(transform.position, Vector2.down, 0.5f, layer3);
        if (ziplama_tahtam.collider != null)
        {
            yerdemiyiz = false;
            tahtayadegior = true;
        }
        else
        {
            yerdemiyiz = true;
            tahtayadegior = false;


        }
        RaycastHit2D dusen_zemin = Physics2D.Raycast(transform.position, Vector2.down, 0.5f, layer4);
        if (dusen_zemin.collider != null)
        {
            dusen_zeminde = true;
            yerdemiyiz = true;
        }
        else
        yerdemiyiz = false;


    }

            public void alttaplatformvarmı()
    {
        if(standingon!=null)
        {
            var newglobalpoint = standingon.transform.TransformPoint(aktitlokalppoint);
            var moveDistance = newglobalpoint - aktifglobalppoint;
            if(moveDistance!=Vector3.zero)
            {
                karakter_takip.transform.Translate(moveDistance, Space.World);
            }
            standingon = null;
        }
    }

        public void zipla()
        {
            if (yerdemiyiz == true||karakterkontrol.duvarziplamasi == true)
                rigidbo.velocity += new Vector2(0, zıplamagücü);



        }
}
    



