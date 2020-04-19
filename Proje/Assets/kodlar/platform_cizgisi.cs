using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform_cizgisi : MonoBehaviour

{
    public Transform[] points;
    public void OnDrawGizmos()
    {
        if (points == null || points.Length < 2)
            return;
        for (var i = 1; i < points.Length; i++)
        {
            Gizmos.DrawLine(points[i - 1].position, points[i].position);
        }


    }
    public IEnumerator<Transform> Platform_cizgisi()
    {
        var index = 0;
        var drection = 1;

        while (true)
        {
            yield return points[index];
            if (index <= 0)
                drection = 1;
            else if (index >= points.Length - 1)
                drection = -1;

            index += drection;


        }

    }
}




