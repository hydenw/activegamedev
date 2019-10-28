using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FWStateController : MonoBehaviour
{
    public GameObject player;

    public Waypoint[] waypoints;

    private FWStateManager _manager;

    private void InitializeStateManager()
    {
        PatrolWaypointState waypointState = new PatrolWaypointState(waypoints);
        waypointState.AddStateTransition(NPCStateTransition.SawPlayer, NPCState.Track);
        
        _manager = new FWStateManager();
        _manager.AddNewState(waypointState);
    }
    
    public void SwitchState(NPCStateTransition transition)
    {
        _manager.HandleTransition(transition);
    }
    void Start()
    {
        InitializeStateManager();   
    }

    void Update()
    {
        _manager.CurrentState.ShouldStateChange(player, this.gameObject);
        _manager.CurrentState.ExecuteCurrentStateBehavior(player, this.gameObject);
    }
}
