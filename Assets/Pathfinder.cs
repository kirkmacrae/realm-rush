﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();

    Queue<Waypoint> queue = new Queue<Waypoint>();

    List<Waypoint> path = new List<Waypoint>();
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
    Waypoint searchCenter;
    public List<Waypoint> GetPath()
    {
        LoadBlocks();
        ColorStartAndEnd();
        BreadthFirstSearch();
        CreatePath();
        return path;
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

    private void BreadthFirstSearch()
    {
        queue.Enqueue(start);
        while (queue.Count > 0 && exploring)
        {
            searchCenter = queue.Dequeue();
            print(" searching from:" + searchCenter);
            HaltIfEndFound();
            ExploreNeighbours();
            searchCenter.isExplored = true;

        }


    }

    private void HaltIfEndFound()
    {
        if(searchCenter == end)
        {
            print("searching from end, stopping.");
            exploring = false;
        }
    }

    
    private void ExploreNeighbours()
    {
        if (!exploring) { return; }
        foreach (Vector2Int direction in directions)
        {
            Vector2Int neighbourPosition = searchCenter.GetGridPosition() + direction;
            if (grid.ContainsKey(neighbourPosition))
            {
                QueueNewNeighbours(neighbourPosition);
            }
        }
    }

    private void QueueNewNeighbours(Vector2Int neighbourPosition)
    {
        Waypoint neighbour = grid[neighbourPosition];
        if (neighbour.isExplored || queue.Contains(neighbour))
        {
        }
        else
        {        
            queue.Enqueue(neighbour);            
            neighbour.exploredFrom = searchCenter;
        }
    }

    private void CreatePath()
    {
        path.Add(end);
        Waypoint previous = end.exploredFrom;
        while(previous !=start)
        {
            path.Add(previous);
            previous.SetTopColour(Color.blue);
            previous = previous.exploredFrom;
        }
        path.Add(start);
        path.Reverse();
    }
}
