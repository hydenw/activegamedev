using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FWState : MonoBehaviour
{
    protected Dictionary<FWStateManager.StateTransitions, FWStateManager.NPCStates> StateDict = new Dictionary<FWStateManager.StateTransitions, FWStateManager.NPCStates>();

    protected FWStateManager.NPCStates npcState;

    public FWStateManager.NPCStates NpcState
    {
        get => npcState;
        set => npcState = value;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public abstract void ShouldStateChange(Transform player, Transform npc);
    public abstract void ExecuteCurrentState(Transform player, Transform npc);
}
