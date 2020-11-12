using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] int hitPoints = 20;
    [SerializeField] ParticleSystem hitParticlePrefab;
    [SerializeField] ParticleSystem deathFX;
    [SerializeField] AudioClip enemyDamagedSFX;
    [SerializeField] AudioClip enemyDeathSFX;

    private void OnParticleCollision(GameObject other)
    {        
        hitPoints--;
        GetComponent<AudioSource>().PlayOneShot(enemyDamagedSFX);
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
        GetComponent<AudioSource>().PlayOneShot(enemyDeathSFX);
        Destroy(fx.gameObject, fx.main.duration);
        Destroy(gameObject);        
    }
}
