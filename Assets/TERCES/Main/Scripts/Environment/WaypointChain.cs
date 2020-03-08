using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointChain : MonoBehaviour
{
    [SerializeField]
    public List<Navigator> AgentsInChain;
    public Transform[] Waypoints;
    public AgentManager AgentMan;
    public float ScannerRadius;
    private float NearDist = Mathf.Infinity;


    private void Start()
    {
        for (int i = 0; i < AgentMan.Agents.Length; i++)
        {
            Debug.Log("Entered Loop");
            
            if (AgentMan.Agents[i].TargetChain == GetComponent<WaypointChain>())
            {
                Debug.Log("Adding " + AgentMan.Agents[i].RefID + " to the list of active agents...");
                AgentsInChain.Add(AgentMan.Agents[i]);
            }
        }
    }

}
