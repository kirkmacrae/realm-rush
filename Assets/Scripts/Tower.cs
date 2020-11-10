using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

public class Tower : MonoBehaviour    
{
    [SerializeField] Transform objectToPan;    
    [SerializeField] float attackRange = 50f;
    [SerializeField] ParticleSystem projectileParticle;

    public Waypoint towerLocation;

    Transform targetEnemy;

    private void Awake()
    {        
        
    }

    // Update is called once per frame
    void Update()
    {
        SetTargetEnemy();

        if (targetEnemy)
        {
            objectToPan.LookAt(targetEnemy);
            ShootEnemy();
        }
        else
        {
            Shoot(false);
        }
    }

    private void SetTargetEnemy()
    {
        var sceneEnemies = FindObjectsOfType<EnemyDamage>();
        if(sceneEnemies.Length == 0) { return; }

        Transform closestEnemy = sceneEnemies[0].transform;        
        
        foreach(EnemyDamage enemy in sceneEnemies)
        {
            closestEnemy = GetClosest(closestEnemy, enemy.transform);            
        }

        targetEnemy = closestEnemy;
    }

    private Transform GetClosest(Transform a, Transform b)
    {
        float distanceToA = Vector3.Distance(a.position, objectToPan.transform.position);
        float distanceToB = Vector3.Distance(b.position, objectToPan.transform.position);

        if (distanceToA <= distanceToB)
        {
            return a;
        }
        else
        {
            return b;
        }
    }

    void ShootEnemy()
    {

        float distanceToEnemy = Vector3.Distance(targetEnemy.transform.position, objectToPan.transform.position);
        
        if(distanceToEnemy <= attackRange)
        {            
            Shoot(true);
        }
        else
        {
            Shoot(false);
        }
    }

    private void Shoot(bool isActive)
    {
        var emissionModule = projectileParticle.emission;
        emissionModule.enabled = isActive;
     
    }

    private float getDistanceToEnemy(Transform enemy)
    {
        float distanceToEnemy = Vector3.Distance(enemy.position, objectToPan.transform.position);

        return distanceToEnemy;
    }
}
