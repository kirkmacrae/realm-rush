using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{

    [SerializeField] int maxTowers = 3;
    [SerializeField] Tower towerPrefab;

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
        tempTower.towerLocation = waypoint;
        towerQueue.Enqueue(tempTower);
        waypoint.isPlaceable = false;        
    }

    private void MoveExistingTower(Waypoint waypoint)
    {
        Tower movingTower = towerQueue.Dequeue();
        movingTower.towerLocation.isPlaceable = true;


        movingTower.transform.position = waypoint.transform.position;
        waypoint.isPlaceable = false;
        towerQueue.Enqueue(movingTower);        
    }
}
