using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieMovement : MonoBehaviour
{
    [HideInInspector] Animator anim;
    [SerializeField] Transform target;
    [HideInInspector] public NavMeshAgent agent;
    [SerializeField] public float turnSpeed;
    [SerializeField] public float damageAmount = 25f;
    float distance;
    public float chaseDistance;
    bool isDead = false;

    public void Start()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    public void Update()
    {
        if (!isDead)
        {
            distance = Vector3.Distance(transform.position, target.position);

            if (distance < chaseDistance)
            {
                AttackPlayer();
            }
            else
            {
                ChasePlayer();
            }

        }
     
    }

    void AttackPlayer()
    {
        anim.SetBool("Attack", true);
        anim.SetBool("Run", false);
        Vector3 direction = target.position - transform.position;//bakýcaðýmýz pozisyonu belirledik
        direction.y = 0;//yukarýya ve aþaðýya bakamýcagý için 0'a eþitledik

        transform.rotation = Quaternion.Slerp(transform.rotation,
        Quaternion.LookRotation(direction), turnSpeed * Time.deltaTime);//yönümüzü player a çevirdik

        agent.updatePosition = false;
        agent.updateRotation = false;

    }

    void ChasePlayer()
    {
        anim.SetBool("Attack", false);
        anim.SetBool("Run", true);
        agent.SetDestination(target.position);
        agent.updateRotation = true;
        agent.updatePosition = true;
    }


    public void ZombieDeath()
    {
        isDead = true;
        agent.enabled = false;
        agent.updatePosition = false;
        agent.updateRotation = false;
        

        anim.SetBool("Attack", false);
        anim.SetBool("Run", false);
        anim.Play("Death");
    }

    void DamageZombie() //AnimationEvent
    {
        if (distance <= chaseDistance)
        {
            CharacterHealth.singleton.DamagePlayer(damageAmount);
        }

    }
}
