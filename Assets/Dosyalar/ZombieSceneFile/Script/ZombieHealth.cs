using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ZombieHealth : MonoBehaviour
{
    public float zombieHealth = 300f;
    [HideInInspector] ZombieMovement zombieAI;
    
    CharacterMovement characterss;


    public void Start()
    {
        zombieAI = GetComponent<ZombieMovement>();
        
        characterss = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterMovement>();
    }

    private void Update()
    {
        if(SceneManager.GetActiveScene().name == "SherlockMapFinish" && zombieHealth <= 0f)
        {
            characterss.OyundanCik1();
        }
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
