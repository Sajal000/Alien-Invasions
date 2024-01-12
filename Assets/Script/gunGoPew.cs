using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class gunGoPew : MonoBehaviour
{
    public Camera playerCamera;
    AudioSource src;
    public AudioClip shootSound;
    public AudioClip reloadSound;
    public AudioClip emptyMagSound;
    private Animator animator;
    public GameObject muzzleEffect;
    public TextMeshProUGUI ammoDisplay;

    public bool isShooting, readyToShoot;
    bool allowReset = true;
    public float shootingDelay = 1f;
    public float spreadIntensity; 

    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float bulletVelocity = 30;
    public float bulletPrefabLifeTime = 2f;
    public float reloadTime;
    public int magSize, bulletsLeft;
    public bool isReloading;

    private void Awake()
    {
        readyToShoot = true;
        animator = GetComponent<Animator>();
        src = GetComponent<AudioSource>();
        bulletsLeft = magSize;
        isShooting = false;
    }

    void Update()
    {       
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (readyToShoot && bulletsLeft > 0)
            {
                FireWeapon(); 
            }
        }

        if (Input.GetKeyDown(KeyCode.R) && bulletsLeft < magSize && isReloading == false && isShooting == false)
        {
            Reload();
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && bulletsLeft == 0)
        {
            src.PlayOneShot(emptyMagSound);
        }

        // if(readyToShoot && isShooting == false && isReloading == false && bulletsLeft <= 0)
        //{
        // Reload();
        // }

        if (ammoDisplay != null)
        {
            ammoDisplay.text = $"{bulletsLeft}/{magSize}";
        }

        if(bulletsLeft == magSize)
        {
            ReloadCompleted();
        }

        
    }

    private void FireWeapon()
    {
        isShooting = true;
        bulletsLeft--; 
        muzzleEffect.GetComponent<ParticleSystem>().Play();
        animator.SetTrigger("RECOIL");
        src.PlayOneShot(shootSound);
        readyToShoot = false;
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody>().AddForce(bulletSpawn.forward.normalized * bulletVelocity, ForceMode.Impulse);
        StartCoroutine(DestroyBulletAfterTime(bullet,bulletPrefabLifeTime));

        if (allowReset)
        {
            Invoke("ResetShot", shootingDelay);
            allowReset = false;
        }
    }

    private void Reload()
    {
        src.PlayOneShot(reloadSound);
        animator.SetTrigger("RELOAD");
        isReloading = true;
        isShooting = false;
        Invoke("ReloadCompleted", reloadTime);
    }

    private void ReloadCompleted()
    {
        bulletsLeft = magSize;
        isReloading = false;
        isShooting = false;
    }

    private void ResetShot()
    {
        readyToShoot = true;
        allowReset = true;
        isShooting = false;
    }

    private IEnumerator DestroyBulletAfterTime(GameObject bullet, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(bullet);
    }
}
