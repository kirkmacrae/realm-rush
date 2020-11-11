using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseDamage : MonoBehaviour
{
    [SerializeField] int baseHealth = 100;
    [SerializeField] ParticleSystem destroyFX;
    [SerializeField] Text healthText;


    private void Start()
    {
        healthText.text = baseHealth.ToString();
    }
    public void DamageBase(int damage)
    {
        baseHealth -= damage;
        healthText.text = baseHealth.ToString();
        if(baseHealth <= 0)
        {
            BaseDestroyed();
        }
    }

    public void BaseDestroyed()
    {
        var fx = Instantiate(destroyFX, transform.position, Quaternion.identity);
        fx.Play();

        Destroy(fx.gameObject, fx.main.duration);
        Destroy(gameObject);
    }
}
