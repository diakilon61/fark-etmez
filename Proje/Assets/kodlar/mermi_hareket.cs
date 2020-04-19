using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mermi_hareket : MonoBehaviour
{
    public float mermi_hiz= 5f;
    void Start()
    {
        Destroy(gameObject,5f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += new Vector3(mermi_hiz * Time.deltaTime, 0, 0);
    }
    public void mermi_sola_git()
    {
        mermi_hiz *= -1;
        transform.localScale = new Vector3(-1, 1, 1);
    }
}
