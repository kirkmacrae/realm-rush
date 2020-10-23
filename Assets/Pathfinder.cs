using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    Vector2Int[] directions =
    {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };

    [SerializeField] Waypoint start;
    [SerializeField] Waypoint end;    

    // Start is called before the first frame update
    void Start()
    {
        LoadBlocks();
        ColorStartAndEnd();
        ExploreNeighbours();
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

    private void ColorStartAndEnd()
    {
        start.SetTopColour(Color.green);
        end.SetTopColour(Color.red);        
    }

    private void ExploreNeighbours()
    {     
        foreach (Vector2Int direction in directions)
        {
            Vector2Int neighbourPosition = start.GetGridPosition() + direction;
            if (grid.ContainsKey(neighbourPosition))
            {
                print("Exploring " + neighbourPosition);
                grid[neighbourPosition].SetTopColour(Color.blue);
            }
        }
    }

}
