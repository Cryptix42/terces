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




    
}
