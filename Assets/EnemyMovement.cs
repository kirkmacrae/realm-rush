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
        print("starting patrol...");
        foreach (Waypoint waypoint in path)
        {
            transform.position = waypoint.transform.position;
            print("Visiting block: " + waypoint);
            yield return new WaitForSeconds(1f);
        }
        print("ending patrol.");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
