using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{

    [SerializeField] int maxTowers = 3;
    [SerializeField] Tower towerPrefab;
    [SerializeField] Transform towerParentTransform;


    Queue<Tower> towerQueue = new Queue<Tower>();
    
    public void AddTower(Waypoint waypoint)
    {        
        int towerCount = towerQueue.Count;
        if (towerCount < maxTowers)
        {
            InstantiateNewTower(waypoint);            
        }
        else
        {
            MoveExistingTower(waypoint);
        }

    }

    private void InstantiateNewTower(Waypoint waypoint)
    {
        Tower tempTower = Instantiate(towerPrefab, waypoint.transform.position, Quaternion.identity);
        tempTower.transform.parent = towerParentTransform.transform;
        tempTower.towerWaypoint = waypoint;
        towerQueue.Enqueue(tempTower);
        waypoint.isPlaceable = false;        
    }

    private void MoveExistingTower(Waypoint waypoint)
    {
        Tower movingTower = towerQueue.Dequeue();
        movingTower.towerWaypoint.isPlaceable = true;
        


        movingTower.transform.position = waypoint.transform.position;
        movingTower.towerWaypoint = waypoint;
        waypoint.isPlaceable = false;
        towerQueue.Enqueue(movingTower);        
    }
}
