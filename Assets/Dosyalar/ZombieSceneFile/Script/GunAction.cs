using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunAction : MonoBehaviour
{

    Animator anim;
    [Header("SHOOT")]
    [SerializeField] float damageZombie = 25f;
    [SerializeField] Transform ShootPoint;
    [SerializeField] float range;
    [SerializeField] float rateOffire;
    float nextFire = 0f;
    public bool isAim = false;
    GameObject bloodClone;
    bool isShoot = true;

    [Header("Ammo")]
    // public Text currentAmmotext;
    //public Text carriedAmmotext;
    public int currentAmmo = 12;
    public int maxAmmo = 12;
    public int carriedAmmo = 60;


    [Header("Effect")]
    public TrailRenderer bulletTrail;
    public GameObject TrailBulletPos;
    [SerializeField] GameObject bloodEffect;
    [SerializeField] GameObject MuzzleFlash;
    [SerializeField] GameObject bulletImpact;

    [Header("Audio")]
    [SerializeField] AudioClip gunAc;
    [SerializeField] AudioSource gunAs;
    [SerializeField] AudioClip reloadAc;

    [HideInInspector] GunRecoil recoil;
    private bool isReloading;
    private bool shootRay;

    public void Start()
    {
        anim = GetComponent<Animator>();

        recoil = GameObject.Find("RecoilCam").GetComponentInParent<GunRecoil>();
    }

    public void Update()
    {
        if (Input.GetButtonDown("Fire1") && currentAmmo > 0 && isShoot)
        {
            Shoot();
        }

        if (Input.GetButtonDown("Fire1") && currentAmmo <= 0)
        {
            DryFire();

        }

        if (Input.GetKeyDown(KeyCode.R) && carriedAmmo != 0 || currentAmmo == 0 && carriedAmmo != 0)
        {

            Reload();
        }
    }

    void Shoot()
    {
        if (Time.time > nextFire)
        {
            if (isShoot)
            {
                nextFire = 0;

                nextFire = Time.time + rateOffire;

                currentAmmo--;
                MuzzleFlash.SetActive(true);
                ShootRay();
                recoil.Recoil();

                //UpdateAmmoUI();

                if (shootRay)
                {
                    anim.Play("Shoot");

                }
            }
        }

    }

    /* private void UpdateAmmoUI()
     {
         currentAmmotext.text = currentAmmo.ToString();
         carriedAmmotext.text = carriedAmmo.ToString();
     }*/

    private void ShootRay()
    {

        StartCoroutine(GunSoundAndMuzzleflash());
        RaycastHit raycastHit;
        if (Physics.Raycast(ShootPoint.position, ShootPoint.forward, out raycastHit, range))
        {

            TrailRenderer trail = Instantiate(bulletTrail, TrailBulletPos.transform.position, Quaternion.identity);
            StartCoroutine(SpawnTrail(trail, raycastHit));
            shootRay = true;
            if (raycastHit.transform.CompareTag("Zombie"))
            {
                GameObject bloodClone = Instantiate(bloodEffect, raycastHit.point, transform.rotation);
                damageZombie = 100f;
                ZombieHealth zombieHealthScript = raycastHit.transform.GetComponentInParent<ZombieHealth>();
                zombieHealthScript.BulletDamage(damageZombie);
            }
            else
            {
                GameObject bulletImpactClone = Instantiate(bulletImpact, raycastHit.point, transform.rotation);
                Destroy(bulletImpactClone, 2f);
            }
        }
        Destroy(bloodClone, 1f);
    }

    private void DryFire()
    {
        if (Time.time > nextFire)
        {
            isShoot = false;
            nextFire = 0;
            nextFire = Time.time + rateOffire;
        }
    }

    void Reload()
    {
        if (!isReloading && currentAmmo != maxAmmo)
        {
            isShoot = false;
            anim.Play("Reload");

            if (carriedAmmo <= 0) return;

            gunAs.PlayOneShot(reloadAc);
            StartCoroutine(ReloadCountdown(2.30f));
        }

    }

    IEnumerator GunSoundAndMuzzleflash()
    {

        gunAs.volume = 0.5f;
        gunAs.PlayOneShot(gunAc);
        yield return new WaitForSeconds(0.25f);
        MuzzleFlash.SetActive(false);
    }

    IEnumerator ReloadCountdown(float timer)
    {
        while (timer > 0f)
        {
            isReloading = true;
            timer -= Time.deltaTime;
            yield return null;

        }
        if (timer <= 0f)
        {
            int bulletsNeededToFillMag = maxAmmo - currentAmmo;
            int bulletsToDeduct = (carriedAmmo >= bulletsNeededToFillMag) ? bulletsNeededToFillMag : carriedAmmo;

            carriedAmmo -= bulletsToDeduct;
            currentAmmo += bulletsToDeduct;

            isReloading = false;
            // UpdateAmmoUI();
            isShoot = true;

        }
    }

    private IEnumerator SpawnTrail(TrailRenderer Trail, RaycastHit Hit)
    {
        float time = 0f;

        Vector3 startPosition = Trail.transform.position;

        while (time < 1)
        {
            Trail.transform.position = Vector3.Lerp(startPosition, Hit.point, time);

            time += Time.deltaTime / Trail.time;

            yield return null;
        }

        Trail.transform.position = Hit.point;


    }
}

