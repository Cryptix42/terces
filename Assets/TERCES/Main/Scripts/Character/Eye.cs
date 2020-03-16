using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eye : MonoBehaviour
{

    public TERCESManager Manager;
    public float maxRadius;
    public float stepValue;
    public float pulsespeed;
    public Brain MyBrain;
    public GameObject Me;
    RaycastHit hit;
    [Range(0, 1)]private float curRad = 0.1f;
    public bool flag = false;
    void Update()
    {
       /*if(transform.rotation.x>0)
        {
            transform.Rotate(transform.rotation.x - transform.rotation.x, 0, 0);
        }*/
        if(transform.localRotation.x < 0)
        {
            transform.Rotate(2,0,0);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, curRad);
        //Gizmos.DrawLine(transform.localPosition, MyBrain.CharactersInMemory[0].transform.position);
    }
    //
}
