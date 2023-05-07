using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WandAction : MonoBehaviour
{

    Animator anim;

    [Header("Attack")]
    [SerializeField] GameObject attackParticle;
    [SerializeField] GameObject explosionParticle;
    [SerializeField] GameObject bloodEffect;
    public float range;
    public float damageBoss = 100f;
    float nextFire;
    public float rateOffire;
    RaycastHit hit;
    [SerializeField] GameObject shootPoint;
    


    public void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if (Time.time > nextFire)
        {
            nextFire = 0;
            nextFire = Time.time + rateOffire;

            anim.Play("AttackWand");
            AttackRay();
        }
    }

    void AttackRay()
    {
        if (Physics.Raycast(shootPoint.transform.position, shootPoint.transform.forward, out hit, range))
        {
            GameObject trailRocket = Instantiate(attackParticle, shootPoint.transform.position, shootPoint.transform.rotation);
            GameObject expParticle = Instantiate(explosionParticle, hit.point, Quaternion.identity);
            GameObject bloodClone = Instantiate(bloodEffect, hit.point, transform.rotation);
            if (hit.transform.CompareTag("Boss"))
            {
                ZombieHealth zombieHealthScript = hit.transform.GetComponentInParent<ZombieHealth>();
                zombieHealthScript.BulletDamage(damageBoss);
                Destroy(trailRocket,0.5f);
            }
            else
            {
                Destroy(trailRocket,2f); Destroy(expParticle, 1f);
            }
        }
    }


}
