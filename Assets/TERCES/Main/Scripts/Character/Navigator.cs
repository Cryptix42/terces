/*TERCES NAVIGATOR v. 0.1 Alpha
 * This program contains all the necessary methods for pathfinding across an environment. There are four ways an AI
 * agent can navigate:
 * 1. Patrol: The agent traverses between a set of pre-determined points in a pre determined order.
 * 2. Chase: The agent chases a target till it catches up with the target. If the target hides, the agent
 * looks around the general area of the target's last seen location.
 * 3. Locate: The agent uses its memory to navigate to a certain spot previously visited by it
 * 4. Explore: Fully automated, the agent relies on visual stimuli to look for interesting spots, and explore
 * the area available to it.
 */

#region Dependencies
using UnityEngine;
using UnityEngine.AI;
#endregion

public class Navigator : MonoBehaviour
{
    #region Reference Variables
    [HideInInspector]
    public GameObject Me; //The agent's own gameobject.
    [HideInInspector]
    public NavMeshAgent Agent;//The pathfinder Agent (UnityEngine.AI)
    public ChainManager ChainMan; //Reference to the Chain Manager object.
    #endregion

    #region Main Variables
    public enum Modes {Patrol, Chase, Locate, Explore}; //Four modes of the agent, refer documentation.
    public Modes NavMode; //Shows a nifty drop down in the Editor.
    public string RefID; //ID of the agent. Debug only.
    #endregion

    #region Patrol Behavior Variables
    public WaypointChain TargetChain;
    public enum PatMode {BackToStart, FindNext};
    public PatMode PatrolMode;
    #endregion

    #region Main Methods
    private void Awake()
    {
        Me = gameObject;
        Agent = Me.GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        OnModeChanged();
    }

    public void OnModeChanged()
    {
        if (NavMode == Modes.Patrol)
        {
            if (TargetChain == null)
            {
                TargetChain = FindNearestWaypoint();
            }
            TargetChain.PopulateAgentsList();
            PatrolWaypoints(TargetChain);
        }
    }
    #endregion

    #region Patrol
    void PatrolWaypoints(WaypointChain wChain)
    {
        Agent.SetDestination(wChain.ChainStart.position);
    }

    WaypointChain FindNearestWaypoint()
    {
        int NearestChainIndex = 0;
        float NearestChainDistance = Mathf.Infinity;
        for(int i = 0; i < ChainMan.Chains.Count; i++)
        {
            Vector3 wPos = ChainMan.Chains[i].GetComponent<WaypointChain>().ChainStart.position;
            float CurrentChainDistance = Vector3.Distance(Me.transform.position, wPos);
            if (CurrentChainDistance < NearestChainDistance)
            {
                NearestChainIndex = i;
                NearestChainDistance = CurrentChainDistance;
            }
        }
        return ChainMan.Chains[NearestChainIndex].GetComponent<WaypointChain>();
    }
    #endregion
}
