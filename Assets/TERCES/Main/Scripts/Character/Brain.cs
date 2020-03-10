using UnityEngine;

public class Brain : MonoBehaviour
{
    public Transform EyeLocation;
    public float AngleH, AngleV;
    public GameObject[] POI_InMemory;
    public GameObject[] CharactersInMemory;
    public string[] OffensiveTags;
    public string[] FriendlyTags;
    RaycastHit hit;

    Vector3 EyeH, EyeV;

    // Start is called before the first frame update
    void Start()
    {
        
    }

}
