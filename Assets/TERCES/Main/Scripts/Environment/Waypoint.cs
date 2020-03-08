using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [HideInInspector]
    public Transform MyLocation;
    

    public WaypointChain ParentChain;
    public float AreaOfInfluence = 1.0f;
    public Transform NextWaypoint;
    public bool FirstWp;

    void OnDrawGizmos()
    {
        if(FirstWp)
        {
            Gizmos.DrawIcon(transform.position, "Waypoint1.tif", true);
        }
        else
        {
            Gizmos.DrawIcon(transform.position, "Waypoint.tif", true);
        }
        if (NextWaypoint == null)
        {
            Gizmos.DrawIcon(transform.position, "WaypointEnd.tif", true);
        }
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(transform.position, 0.15f);
        Gizmos.DrawWireSphere(transform.position, AreaOfInfluence);
        if (NextWaypoint!=null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, NextWaypoint.position);
        }
        
    }



}
