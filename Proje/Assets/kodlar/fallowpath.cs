using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class fallowpath : MonoBehaviour
{
    public platform_cizgisi path;
    public float hareket_hizi=5f;
    public float varmak_üzere = 0.1f;
    private IEnumerator<Transform> correntpoints;


    public void Start()
    {
        correntpoints = path.Platform_cizgisi();
        correntpoints.MoveNext();
        transform.position = correntpoints.Current.position;
    }
   public void Update()

    {
        if (correntpoints == null || correntpoints.Current == null)
            return;
        
        transform.position = Vector3.MoveTowards(transform.position, correntpoints.Current.position, Time.deltaTime * hareket_hizi);
        var distanceSquared = (transform.position - correntpoints.Current.position).sqrMagnitude;
        if (distanceSquared < varmak_üzere * varmak_üzere)
        {
            correntpoints.MoveNext();
        }
        
        


    }
   
}
