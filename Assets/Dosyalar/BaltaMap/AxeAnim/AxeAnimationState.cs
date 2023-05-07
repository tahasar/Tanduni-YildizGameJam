using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeAnimationState : MonoBehaviour
{
    Animator anim;
    public float attackRadius;
    public float damageAxe;
    ZombieMovement enemyControl;
    float nextFire;
    public float rateOffire;

    public void Start()
    {
        enemyControl = GameObject.FindGameObjectWithTag("EnemyAxeMap").GetComponent<ZombieMovement>();
        anim = GetComponent<Animator>();
    }

    public void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            anim.Play("Attack");
        }

    }
    public void Attack()
    {
        if (Time.time > nextFire)
        {
            nextFire = 0;

            nextFire = Time.time + rateOffire;
            AttackTime();
        }

    }
    private void AttackTime()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position + transform.forward + transform.up, attackRadius);

        foreach (Collider hit in hits)
        {
            if (hit.gameObject.CompareTag("EnemyAxeMap") && enemyControl.isPlayAnim)
            {
                ZombieHealth zombieHealth = hit.transform.GetComponentInParent<ZombieHealth>();
                zombieHealth.BulletDamage(damageAxe);
            }
        }
    }
}
