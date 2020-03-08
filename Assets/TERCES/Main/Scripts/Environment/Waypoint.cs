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
    private bool isEndpoint;

    private void Awake()
    {
        ParentChain = transform.parent.GetComponent<WaypointChain>();
        if(NextWaypoint == null)
        {
            isEndpoint = true;
        }
    }

    private void Update()
    {
        for (int i = 0; i < ParentChain.AgentsInChain.Count; i++)
        {
            if (Vector3.Distance(ParentChain.AgentsInChain[i].transform.position, transform.position) < AreaOfInfluence)
            {
                if (isEndpoint)
                {
                    ParentChain.AgentsInChain[i].Agent.SetDestination(ParentChain.ChainStart.position);
                }

                else
                {
                    ParentChain.AgentsInChain[i].Agent.SetDestination(NextWaypoint.position);
                }

            }
        }
    }




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
