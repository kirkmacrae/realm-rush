using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public bool isExplored = false;
    public Waypoint exploredFrom;
    public Color exploredColor;

    Vector2Int gridPos;
    const int gridSize = 10;
   
    public int GetGridSize()
    {
        return gridSize;
    }

    private void Update()
    {
        if (isExplored)
        {
           // SetTopColour(exploredColor);
        }
    }
    public Vector2Int GetGridPosition()
    {
        return new Vector2Int(
           Mathf.RoundToInt(transform.position.x / gridSize),
           Mathf.RoundToInt(transform.position.z / gridSize)
           );
    }
    public void SetTopColour(Color color)
    {        
        MeshRenderer topMeshRenderer = transform.Find("Top").GetComponent<MeshRenderer>();
        topMeshRenderer.material.color = color;
    }
}
