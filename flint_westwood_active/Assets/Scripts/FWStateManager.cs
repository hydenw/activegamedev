using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FWStateManager : MonoBehaviour
{
    private RangedStates currentRangedState;
    private FWStateMachine activeStateMachine;

    public FWStateMachine ActiveStateMachine
    {
        get => activeStateMachine;
    }


    public RangedStates CurrentRangedState
    {
        get => currentRangedState; 
    }

    public enum RangedStates
    {
        Patrol, Track, Interact, Attack, Flee
    }

    public enum StateTransitions
    {
        None = 0,
        SawPlayer,
        TargetedPlayer,
        LostPlayer,
        Dead
    }
    
    
    
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
