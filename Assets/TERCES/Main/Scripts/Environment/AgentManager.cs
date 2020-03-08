using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentManager : MonoBehaviour
{
    public List<GameObject> Agents = new List<GameObject>();

    void Awake()

    {
        Agents.AddRange(GameObject.FindGameObjectsWithTag("TERCES Agent"));
    }
}
