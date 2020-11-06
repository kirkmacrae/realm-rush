using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float secondsBetweenSpawns = 5f;
    [SerializeField] EnemyMovement enemyPrefab;
    [SerializeField] Transform enemySpawnLocation;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }   

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            yield return new WaitForSeconds(secondsBetweenSpawns);
            Instantiate(enemyPrefab, enemySpawnLocation.position, Quaternion.identity);
        }
    }
}
