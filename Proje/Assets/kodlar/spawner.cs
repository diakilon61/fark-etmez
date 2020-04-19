using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public Transform son;
    public hareketli_testere_atilan Projectile;
    public float speed = 6f;
    public float FireRate = 2f;
    private float nextShotInseconds;


    void Start()
    {
        nextShotInseconds = FireRate;
    }

    // Update is called once per frame
    void Update()
    {
        if ((nextShotInseconds -= Time.deltaTime) > 0)
        {
            return;
        }
        nextShotInseconds = FireRate;
        var projectile = (hareketli_testere_atilan)Instantiate(Projectile, transform.position, transform.rotation);
        projectile.Initialize(son, speed);
    }
    public void OnDrawGizmos()
    {
        if (son == null)
        {
            return;

        }
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, son.position);

    }
}
