using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dusen_zemin : MonoBehaviour
{
    [SerializeField] float  speed;
    private float maxHeight;
    public bool ustundemi, yerdemi=false;
    public LayerMask layer;//durcagı zemının layer ı
    
       

    void Start()
    {
        maxHeight = transform.position.y;        
    }
    void Update()
    {
        RaycastHit2D degiyomu = Physics2D.Raycast(transform.position, Vector2.down, 0.5f, layer);
       if (degiyomu.collider != null)
        {
            yerdemi = true;
            
        }

    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Player" && other.transform.position.y > transform.position.y)
        {
            ustundemi = true;
            StartCoroutine(AsagiIn());
        }
    }
    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.name == "Player")
        {
            ustundemi = false;
                      
            if (yerdemi==true)
            {
                StartCoroutine(YukariCik());
            }
        }          
    }

    IEnumerator YukariCik()
    {
        yield return new WaitForSeconds(1);
        while (transform.position.y < maxHeight&&yerdemi)
        {
            if (!ustundemi)
                transform.position += new Vector3(0, speed * Time.deltaTime, 0);          
            yield return null;
        }
        yerdemi = false;
    }
    IEnumerator AsagiIn()
    {
        yield return new WaitForSeconds(2);
        while (!yerdemi)
        {
            transform.position += new Vector3(0, -speed * Time.deltaTime, 0);
            yield return null;
            
        }
    }
    
}
