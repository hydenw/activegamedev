using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : FWState
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void ShouldStateChange(GameObject player, GameObject currentNpc)
    {
        if (Vector3.Distance(currentNpc.transform.position, player.transform.position) <= 50.0f)
        {
            
        }
    }

    public override void ExecuteCurrentStateBehavior(GameObject player, GameObject currentNpc)
    {
        throw new System.NotImplementedException();
    }
}
