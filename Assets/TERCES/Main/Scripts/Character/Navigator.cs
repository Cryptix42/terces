using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Navigator : MonoBehaviour
{
    [HideInInspector]
    public GameObject Me;
    [HideInInspector]
    public NavMeshAgent Agent;
    public enum Modes {Explorer, Patrol, Chase, Locate};
    public Modes NavMode;
    public ChainManager ChainMan;
    public WaypointChain TargetChain;
    // Start is called before the first frame update
    void Start()
    {
        if(NavMode==Modes.Patrol)
        {
            if(TargetChain == null)
            {
                TargetChain = FindNearestWaypoint();
            }
            PatrolWaypoints(TargetChain);
        }
    }


    void PatrolWaypoints(WaypointChain wChain)
    {
        Agent.SetDestination(wChain.Waypoints[0].position);
    }

    WaypointChain FindNearestWaypoint()
    {
        int NearestChainIndex = 0;
        float NearestChainDistance = Mathf.Infinity;
        for(int i = 0; i < ChainMan.Chains.Length; i++)
        {
            Vector3 wPos = ChainMan.Chains[i].Waypoints[0].position;
            float CurrentChainDistance = Vector3.Distance(Me.transform.position, wPos);
            if (CurrentChainDistance < NearestChainDistance)
            {
                NearestChainIndex = i;
                NearestChainDistance = CurrentChainDistance;
            }
        }
        return ChainMan.Chains[NearestChainIndex];
    }
}
