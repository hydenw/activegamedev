using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    [SerializeField] private Transform player;
    [SerializeField] private float cameraSmoothSpeed;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void LateUpdate()
    {
        Vector3 newPosition = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, newPosition, cameraSmoothSpeed);
    }
}
