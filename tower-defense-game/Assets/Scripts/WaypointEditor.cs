using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
[RequireComponent(typeof(Waypoint))]
public class WaypointEditor : MonoBehaviour
{   
    Waypoint waypoint;    

    private void Awake()
    {
        waypoint = GetComponent<Waypoint>();
        
    }

    void Update()
    {
        SnapToGrid();
        UpdateLabel();
    }

    private void SnapToGrid()
    {
        transform.position = new Vector3(
            waypoint.GetWaypointPosition().x, 0f, 
            waypoint.GetWaypointPosition().y
            );
    }

    private void UpdateLabel()
    {
        int gridSize = Waypoint.gridSize;
        TextMesh label = GetComponentInChildren<TextMesh>();

        string labelText = 
            waypoint.GetWaypointPosition().x / gridSize + "," + 
            waypoint.GetWaypointPosition().y / gridSize;

        label.text = labelText;
        gameObject.name = labelText;
    }
}
