using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] int hitPoints = 30; 

    private void OnParticleCollision(GameObject other)
    {        
        hitPoints--;
        if (hitPoints <= 0)
        {
            KillEnemy();
        }
    }

    private void KillEnemy()
    {
        // GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
        // fx.transform.parent = parent;
        Destroy(gameObject);
    }
}
