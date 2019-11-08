using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolWaypointState : FWState
{
    private Waypoint[] _waypoints;
    private int _currentWaypointIndex;
    private float _patrolNPCRange = 10f;
    private float _patrolNPCSpeed = 1f;
    
    public PatrolWaypointState(Waypoint[] waypoints)
    {
        this._waypoints = waypoints;
        _currentWaypointIndex = 0;
        this.npcState = NPCState.Patrol;
    }
    
    public void SetSpeed(float patrolSpeed)
    {
        this._patrolNPCSpeed = patrolSpeed;
    }

    public override void ShouldStateChange(GameObject player, GameObject currentNpc)
    {
        Debug.Log("Patrolling");
        RaycastHit2D hit =
            Physics2D.Raycast(currentNpc.transform.position, currentNpc.transform.up, _patrolNPCRange);
        if (hit.collider != null)
        {
            if (hit.transform.gameObject.CompareTag("Player"))
            {
                Debug.Log("SAW PLAYER");
                currentNpc.GetComponent<FWStateController>().SwitchState(NPCStateTransition.SawPlayer);
            }
        }

    }

    public override void ExecuteCurrentStateBehavior(GameObject player, GameObject currentNpc)
    {
        var position = currentNpc.transform.position;
        Vector2 npcPos = new Vector2(position.x, position.y);
        Vector2 waypointPos = _waypoints[_currentWaypointIndex]._waypoint;
//        Debug.Log("NPC Position" + npcPos);
        if (Vector2.Distance(npcPos, waypointPos) < 0.1f)
        {
            _currentWaypointIndex++;
            if (_currentWaypointIndex >= _waypoints.Length) _currentWaypointIndex = 0;
        }
        else
        {
            float step =  _patrolNPCSpeed * Time.deltaTime; // calculate distance to move
            var npcPosition = currentNpc.transform.position;
            npcPosition = Vector3.MoveTowards(npcPosition, waypointPos, step);
            currentNpc.transform.position = npcPosition;
        }
    }
}
