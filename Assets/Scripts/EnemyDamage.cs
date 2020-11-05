using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] int hitPoints = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    private void OnParticleCollision(GameObject other)
    {
        print("enemy hit");
        hitPoints--;
        if (hitPoints <= 0)
        {
            KillEnemy();
        }
    }

    private void KillEnemy()
    {
        print("dead");
        // GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
        // fx.transform.parent = parent;
        Destroy(gameObject);
    }
}
