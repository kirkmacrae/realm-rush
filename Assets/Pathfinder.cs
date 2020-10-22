using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    // Start is called before the first frame update
    void Start()
    {
        LoadBlocks();
        
    }

    private void LoadBlocks()
    {
        var waypoints = FindObjectsOfType<Waypoint>();
        foreach (Waypoint waypoint in waypoints)
        {            
            if (grid.ContainsKey(waypoint.GetGridPosition()))
            {
                Debug.LogWarning("overlapping waypoint at " + waypoint.GetGridPosition());
            }
            else
            {
                grid.Add(waypoint.GetGridPosition(), waypoint);
            }
            
        }
    }   
}
