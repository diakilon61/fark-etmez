using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hareketli_testere_atilan : MonoBehaviour
{
    private Transform _destination;
    private float _speed;
   // public GameObject Destroy_effecter;
    public void Initialize (Transform son,float speed)
    {
        _destination =son;
        _speed = speed;
    }
    
    void Start()
    {
        
    }

    // Update is called once per frame
   public void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _destination.position, Time.deltaTime * _speed);
        var distanceSquared = (_destination.transform.position - transform.position).sqrMagnitude;
        if(distanceSquared>0.1f*0.1f)
        {
            return;
        }
       // if(Destroy_effecter!=null)
        //{
        //    Instantiate(Destroy_effecter, transform.position, transform.rotation);
        //}
        Destroy(gameObject);
    }
}
