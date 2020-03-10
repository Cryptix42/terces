using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eye : MonoBehaviour
{

    public TERCESManager Manager;
    public float maxRadius;
    public float stepValue;
    public float pulsespeed;
    public Brain MyBrain;
    public GameObject Me;
    RaycastHit hit;
    private float curRad = 0.0f;
    public bool flag = false;
    void Update()
    {
        

        #region Sphere Pulse
        if (curRad<maxRadius)
        {
            for (int i = 0; i < Manager.Agents.Count; i++)
            {
                if (Physics.SphereCast(transform.position, curRad, transform.localRotation.eulerAngles, out hit))
                {
                    flag = false;
                    for (int j = 0; j < MyBrain.CharactersInMemory.Count; j++)
                    {
                        if (MyBrain.CharactersInMemory[j] == Manager.Agents[i])
                        {
                            flag = true;
                        }
                    }
                    if (!flag)
                    {
                        if (Manager.Agents[i] != Me)
                        {
                            //ADD TO MEMORY

                            MyBrain.CharactersInMemory.Add(Manager.Agents[i]);
                        }
                    }
                    flag = false;

                    for (int j = 0; j < MyBrain.POI_InMemory.Count; j++)
                    {
                        if (MyBrain.POI_InMemory[j] == Manager.TObjects[i])
                        {
                            flag = true;
                        }
                        for (int k = 0; k < Manager.Agents.Count; k++)
                        {
                            if (Manager.TObjects[i] == Manager.Agents[k])
                            {
                                flag = true;
                            }
                        }
                    }
                    if (!flag)
                    {
                        //ADD TO MEMORY
                        MyBrain.POI_InMemory.Add(Manager.TObjects[i]);
                    }
                }
            }
        }
        curRad += stepValue;
        if(curRad>maxRadius)
        {
            curRad = 0.0f;
        }
        #endregion
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, curRad);
    }
    //
}
