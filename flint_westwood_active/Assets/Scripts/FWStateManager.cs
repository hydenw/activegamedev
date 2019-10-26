using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FWStateManager : MonoBehaviour
{
    private NPCStates _currentNpcState;
    private FWStateMachine activeStateMachine;

    public FWStateMachine ActiveStateMachine
    {
        get => activeStateMachine;
    }


    public NPCStates CurrentNpcState
    {
        get => _currentNpcState; 
    }

    public enum NPCStates
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
