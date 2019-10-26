using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FWStateMachine : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private Transform playerLocation;

    protected virtual void InitializeState()
    {
        playerLocation = player.transform;
    }
    protected virtual void StateUpdate() {}
    
    protected virtual void StateFixedUpdate() {}
    void Start()
    {
        
    }

    void Update()
    {
        StateUpdate();
    }

    private void FixedUpdate()
    {
        StateFixedUpdate();
    }
}
