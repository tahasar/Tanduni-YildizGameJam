using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieHealth : MonoBehaviour
{
    public float zombieHealth = 300f;
    [HideInInspector] ZombieMovement zombieAI;


    public void Start()
    {
        zombieAI = GetComponent<ZombieMovement>();
    }

    public void BulletDamage(float damage)
    {
        zombieHealth -= damage;
        if (zombieHealth <= 0f)
        {
            
            ZombieDeath();
        }

    }

    public void ZombieDeath()
    {
        zombieAI.ZombieDeath();
        zombieAI.agent.speed = 0f;

        Destroy(gameObject, 5);


    }
}
