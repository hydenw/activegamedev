using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FWRangedNPCState : FWStateMachine
{
    private FWStateManager.RangedStates currentState;

    public GameObject[] _waypoints = new GameObject[25];
    public Transform waypointHolder;

    public Vector3 velocity = Vector3.zero;


    public float moveSpeed;

    protected override void InitializeState()
    {
        moveSpeed = 2f;
        this.currentState = FWStateManager.RangedStates.PATROL;
//        for (int i = 0; i < _waypoints.Length; i++)
//        {
//            _waypoints[i] = new GameObject();
//            _waypoints[i].transform.parent = waypointHolder;
//            _waypoints[i].AddComponent<Waypoint>();
//            _waypoints[i].GetComponent<Waypoint>()._waypoint = new Vector2(Random.Range(-5, 5), Random.Range(-5, 5));
//            _waypoints[i].transform.position = _waypoints[i].GetComponent<Waypoint>()._waypoint;
//            _waypoints[i].name = "Waypoint" + i;
//        }

        StartCoroutine(LinearMoveWaypoints());
    }

    private void HandleState()
    {
        switch (currentState)
        {
            case FWStateManager.RangedStates.PATROL:
                UpdatePatrol();
                break;
            default:
                Debug.Log("nothing");
                break;
        }
    }

    protected override void StateUpdate()
    {
        base.StateUpdate();
        HandleState();
    }

    protected override void StateFixedUpdate()
    {
        base.StateFixedUpdate();
    }

    private void DetectPlayer()
    {
        RaycastHit2D hit;
        if (Physics2D.OverlapCircle(transform.position, 10f))
        {
            
        }

    }

    private void UpdatePatrol()
    {
        Debug.Log("patroling");
    }

    IEnumerator LinearMoveWaypoints()
    {
        var waypoint = _waypoints[Random.Range(0, 4)].transform;
        while (true)
        {
            if (waypoint.transform.position == this.transform.position)
            {
                waypoint = _waypoints[Random.Range(0, 4)].transform;
            }


//            Vector3.SmoothDamp(this.transform.position, waypoint.transform.position,
//                ref velocity, moveSpeed);
            this.transform.position = Vector3.MoveTowards(this.transform.position, waypoint.transform.position,
                Time.deltaTime * moveSpeed);
            
            yield return null;
        }
    }


    public override void Start()
    {
        base.Start();
    }

    public override void Update()
    {
        base.Update();
    }
}