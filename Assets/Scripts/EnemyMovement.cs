using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] ParticleSystem deathFX;
    [SerializeField] float movementPeriod = 1f;
    [SerializeField] int baseDamage = 10; //damage dealt to base
    
    // Start is called before the first frame update
    void Start()
    {
        Pathfinder pathfinder = FindObjectOfType<Pathfinder>();
        var path = pathfinder.GetPath();
        StartCoroutine(FollowPath(path));
    }

    IEnumerator FollowPath(List<Waypoint> path)
    {
        foreach(Waypoint waypoint in path)
        {
            transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(movementPeriod);
        }
        DamageBase();
    }

    void DamageBase()
    {
        var fx = Instantiate(deathFX, transform.position, Quaternion.identity);
        fx.Play();

        Destroy(fx.gameObject, fx.main.duration);

        BaseDamage Base = FindObjectOfType<BaseDamage>();
        Base.DamageBase(baseDamage);
        Destroy(gameObject);        
    }
}
