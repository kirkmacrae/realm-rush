using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public bool isExplored = false;
    public Waypoint exploredFrom;
    public Color exploredColor;
    public bool isPlaceable;
    
    const int gridSize = 10;

    public void Awake()
    {
        isPlaceable = true;
    }

    public int GetGridSize()
    {
        return gridSize;
    }

    public Vector2Int GetGridPosition()
    {
        return new Vector2Int(
           Mathf.RoundToInt(transform.position.x / gridSize),
           Mathf.RoundToInt(transform.position.z / gridSize)
           );
    }    

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && isPlaceable)
        {
            FindObjectOfType<TowerFactory>().AddTower(this);         
        }
    }
}
