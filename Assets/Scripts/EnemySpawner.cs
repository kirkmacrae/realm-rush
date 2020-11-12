using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float secondsBetweenSpawns = 5f;
    [SerializeField] EnemyMovement enemyPrefab;    
    [SerializeField] Transform enemyParentTransform;
    [SerializeField] AudioClip spawnedEnemySFX;

    [SerializeField] Text scoreText;
    int scoreCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = scoreCount.ToString();
        StartCoroutine(SpawnEnemies());
    }   

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            GetComponent<AudioSource>().PlayOneShot(spawnedEnemySFX);
            var enemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            enemy.transform.parent = enemyParentTransform;

            scoreCount++;
            scoreText.text = scoreCount.ToString();
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }
}
