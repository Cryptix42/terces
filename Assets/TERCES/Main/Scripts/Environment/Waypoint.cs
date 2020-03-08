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
    private bool WaypointPassed;

    private void Awake()
    {
        ParentChain = transform.parent.GetComponent<WaypointChain>();
    }

    /*private void Update()
    {
        if(!WaypointPassed)
        {}
    }*/




    #region Gizmos
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
        // Draw a sphere at the transform's position and to show the area of influence
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(transform.position, 0.15f);
        Gizmos.DrawWireSphere(transform.position, AreaOfInfluence);
        if (NextWaypoint!=null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, NextWaypoint.position);
        }
        
    }
    #endregion


}
