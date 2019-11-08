using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public Vector2 _waypoint;

    public Waypoint(float x, float y)
    {
        _waypoint = new Vector2(x, y);
    }

    private void Start()
    {
        this._waypoint = transform.position;
    }
}