using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] List<Waypoint> path;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PrintAllWaypoints());        
    }

    IEnumerator PrintAllWaypoints()
    {        
        foreach (Waypoint waypoint in path)
        {
            //transform.position = waypoint.transform.position;            
            yield return new WaitForSeconds(1f);
        }       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
