using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eye : MonoBehaviour
{

    public float maxRadius;
    public int i = 0;
    public float stepValue;
    RaycastHit hit;
    private float curRad = 0.0f;
    void FixedUpdate()
    {
        if(curRad<maxRadius)
        {
            if (Physics.SphereCast(transform.position, curRad, transform.localRotation.eulerAngles, out hit))
            {
                print("Hit!");
            }
        }
        curRad += stepValue;
        if(curRad>maxRadius)
        {
            curRad = 0.0f;
        }
        i++;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, curRad);
    }
    //
}
