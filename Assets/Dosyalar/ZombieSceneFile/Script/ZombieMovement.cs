using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

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
    bool isChase;
    [HideInInspector] public bool isPlayAnim;

    [HideInInspector] ScoreManager coinAmount;

    CharacterHealth characterHealth;


    public void Start()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        characterHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterHealth>();

        if (SceneManager.GetActiveScene().name == "PixelScene")
        coinAmount = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>();
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
            else if (!gameObject.CompareTag("Boss") || isChase)
            {
                ChasePlayer();
            }
        }

        if (SceneManager.GetActiveScene().name == "PixelScene")
            if (coinAmount.score >6 && gameObject.CompareTag("EnemyAxeMap"))
            {
                anim.SetBool("PlayAnimation", true);
                isPlayAnim = true;
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

        if (!gameObject.CompareTag("EnemyAxeMap"))
        Invoke("DamageZombie", 1.5f);

    }
    public void Craw()
    {
        if (gameObject.CompareTag("Boss"))
        {
            Invoke("ChasePlayer", 4f);
            anim.SetBool("Saw", true);
            agent.updatePosition = false;
            agent.updateRotation = false;
        }
    }

    void ChasePlayer()
    {
        isChase = true;
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

    void DamageZombie() 
    {
        characterHealth.DamagePlayer(damageAmount);
    }
}
