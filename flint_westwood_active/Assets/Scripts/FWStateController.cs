using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FWStateController : MonoBehaviour
{
    public GameObject player;
    public Weapon npcWeapon;
    public Waypoint[] waypoints;

    private FWStateManager _manager;
    

    private void InitializeStateManager()
    { 
        PatrolWaypointState waypointState = new PatrolWaypointState(waypoints);
        waypointState.AddStateTransition(NPCStateTransition.SawPlayer, NPCState.Track);
        TargetPlayerState targetPlayerState = new TargetPlayerState(30f, 5f, npcWeapon);
        targetPlayerState.AddStateTransition(NPCStateTransition.LostPlayer, NPCState.Patrol);
    
        _manager = new FWStateManager();
        _manager.AddNewState(waypointState);
        _manager.AddNewState(targetPlayerState);
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
        if (player && this.gameObject)
        {
            _manager.CurrentState.ShouldStateChange(player, this.gameObject);
            _manager.CurrentState.ExecuteCurrentStateBehavior(player, this.gameObject);
        }
    }
}
