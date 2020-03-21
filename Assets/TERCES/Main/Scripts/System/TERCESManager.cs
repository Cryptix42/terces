using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TERCESManager : MonoBehaviour
{
    public List<GameObject> TObjects = new List<GameObject>();
    public List<GameObject> Agents = new List<GameObject>();
    public List<GameObject> Chains = new List<GameObject>();

    private void Awake()
    {
        GameObject Player = GameObject.FindWithTag("Player");
        TObjects.AddRange(GameObject.FindGameObjectsWithTag("TERCES Object"));
        if(Player != null)
        {
            TObjects.Add(Player);
        }
        Chains.AddRange(GameObject.FindGameObjectsWithTag("Waypoint Chain"));
        for(int i = 0; i<TObjects.Count;i++)
        {
            if (TObjects[i].GetComponent<TERCES_Agent>() != null)
            {
                Agents.Add(TObjects[i]);
            }
        }
        if (Player != null)
        {
            Agents.Add(Player);
        }
    }

}
