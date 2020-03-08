using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointChain : MonoBehaviour
{
    public List<Navigator> AgentsInChain;
    public Transform ChainStart;
    public AgentManager AgentMan;
    public float ScannerRadius;
    private float NearDist = Mathf.Infinity;


    private void Start()
    {
        
    }

    public void PopulateAgentsList()
    {
        for (int i = 0; i < AgentMan.Agents.Count; i++)
        {
            if (AgentMan.Agents[i].GetComponent<Navigator>().TargetChain == GetComponent<WaypointChain>())
            {
                bool flag = false;
                for(int j = 0; j < AgentsInChain.Count; j++)
                {
                    if(AgentsInChain[j] == AgentMan.Agents[i].GetComponent<Navigator>())
                    {
                        flag = true;
                    }
                }
                if(!flag)
                {
                    Debug.Log("Adding " + AgentMan.Agents[i].GetComponent<Navigator>().RefID + " to the list of active agents of chain " + gameObject.name +".....");
                    AgentsInChain.Add(AgentMan.Agents[i].GetComponent<Navigator>());
                }
            }
        }
    }

}
