using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();

    Queue<Waypoint> queue = new Queue<Waypoint>();
    List<Waypoint> unexplored = new List<Waypoint>();
    List<Waypoint> nextToExplore = new List<Waypoint>();

    Dictionary<Vector2Int, Waypoint> gridExplored = new Dictionary<Vector2Int, Waypoint>();
    Vector2Int[] directions =
    {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };

    [SerializeField] Waypoint start;
    [SerializeField] Waypoint end;

    bool exploring = true;

    // Start is called before the first frame update
    void Start()
    {
        LoadBlocks();
        ColorStartAndEnd();
        Pathfind();

        gridExplored.Add(start.GetGridPosition(),start);
        unexplored.Add(start);

        ExploreNeighbours(start);
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

    private void Pathfind()
    {
        queue.Enqueue(start);
        while (queue.Count > 0 && exploring)
        {
            var searchCenter = queue.Dequeue();
            print(" searching from:" + searchCenter);
            HalfIfEndFound(searchCenter);
            //ExploreNeighbours(searchCenter);

        }
    }

    private void HalfIfEndFound(Waypoint searchCenter)
    {
        if(searchCenter == end)
        {
            print("searching from end, stopping.");
            exploring = false;
        }
    }

    
    private void ExploreNeighbours(Waypoint start)
    {
        if (!exploring) { return; }
        Vector2Int neighbourPosition;


        while (exploring)        
        {
            foreach (Waypoint waypoint in unexplored)
            {
               
                foreach (Vector2Int direction in directions)
                {
                    neighbourPosition = waypoint.GetGridPosition() + direction;
                    if (grid.ContainsKey(neighbourPosition) && !gridExplored.ContainsKey(neighbourPosition))
                    {
                        print("Exploring " + neighbourPosition);
                        grid[neighbourPosition].SetTopColour(Color.blue);
                        

                        if (grid[neighbourPosition] == end)
                        {
                            print("End search ");
                            exploring = false;
                            return;
                        }
                        gridExplored.Add(grid[neighbourPosition].GetGridPosition(), grid[neighbourPosition]);
                        nextToExplore.Add(grid[neighbourPosition]);
                    }                    
                }
            }
            unexplored.Clear();
            foreach(Waypoint thing in nextToExplore)
            {
                unexplored.Add(thing);
            }            
            nextToExplore.Clear();            
        }
    }

}
