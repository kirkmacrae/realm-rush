using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] int hitPoints = 20;
    [SerializeField] ParticleSystem hitParticlePrefab;
    [SerializeField] ParticleSystem deathFX;

    private void OnParticleCollision(GameObject other)
    {        
        hitPoints--;
        hitParticlePrefab.Play();
        if (hitPoints <= 0)
        {
            KillEnemy();
        }
    }

    private void KillEnemy()
    {
        var fx = Instantiate(deathFX, transform.position, Quaternion.identity);
        fx.Play();
        Destroy(gameObject);        
    }
}
