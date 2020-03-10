using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brain : MonoBehaviour
{
    public Transform EyeLocation;
    public float AngleH, AngleV;
    public List<GameObject> POI_InMemory;
    public List<GameObject> CharactersInMemory;
    public string[] OffensiveTags;
    public string[] FriendlyTags;
    RaycastHit hit;

    Vector3 EyeH, EyeV;

    // Start is called before the first frame update
    void Start()
    {
        
    }

}
