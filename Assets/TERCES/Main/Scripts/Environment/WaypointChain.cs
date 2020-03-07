using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointChain : MonoBehaviour
{
    public GameObject[] AgentsInChain;
    public Transform[] Waypoints;
    public AgentManager AgentMan;
    public float ScannerRadius;


    private void Awake()
    {
        for (int i = 0; i < AgentMan.Agents.Length; i++)
        {
            //TODO: Check and decide active agents on this particular chain
        }
    }

}
