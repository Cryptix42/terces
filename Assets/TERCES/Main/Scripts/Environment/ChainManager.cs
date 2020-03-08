using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainManager : MonoBehaviour
{
    public List<GameObject> Chains = new List<GameObject>();
    
    private int c;

    void Awake()

    {

        Chains.AddRange(GameObject.FindGameObjectsWithTag("Waypoint Chain"));

    }



}
