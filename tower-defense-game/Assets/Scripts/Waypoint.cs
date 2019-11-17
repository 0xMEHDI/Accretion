using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public const int gridSize = 10;

    Vector2Int waypointPosition;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public Vector2 GetWaypointPosition()
    {
        waypointPosition = new Vector2Int(
            Mathf.RoundToInt(transform.position.x / gridSize) * gridSize,
            Mathf.RoundToInt(transform.position.z / gridSize) * gridSize
            );
        return waypointPosition;
    }
}
