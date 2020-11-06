using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public bool isExplored = false;
    public Waypoint exploredFrom;
    public Color exploredColor;
    public bool isPlaceable;

    [SerializeField] Tower towerPrefab;
    [SerializeField] GameObject towerParent;
    
    const int gridSize = 10;

    public void Awake()
    {
        isPlaceable = true;
    }

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

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && isPlaceable)
        {
            Instantiate(towerPrefab, gameObject.transform.position, Quaternion.identity, towerParent.transform);
            isPlaceable = false;
        }
    }
}
