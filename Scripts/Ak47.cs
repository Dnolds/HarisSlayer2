using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ak47 : MonoBehaviour
{
    public AudioSource ReloadSound;
    public AudioSource[] ShotSound;
    public Transform ShootPos;
    public GameObject bulletPrefab;
    public float bulletForce = 300;
    public int minDamage = 3;
    public int maxDamage= 10;

    public float shootTime = 0.1f;
    float shootTimer = 0;

 
    public float currentAmmo = 0;
    public float maxAmmo = 30;

    public float reloadTime = 1;
    public bool isReloading = false;

    public ParticleSystem particleEffect;
    
    private void Start()
    {
        currentAmmo = maxAmmo;
        shootTimer = shootTime;
    }

    void Update()
    {
        //Update UI
        Player.player.currentAmmo = currentAmmo;
        Player.player.maxAmmo = maxAmmo;

        //Timer for Shootingrate
        shootTimer -= Time.deltaTime;
        if (isReloading)
        {
            return;
        }
        
        if (currentAmmo <= 0) 
        {
            StartCoroutine(Reload());
            return;
        }
        else
        {
            if (Input.GetKey(KeyCode.Mouse0) && shootTimer <= 0)
            {
                Shoot();
                shootTimer = shootTime;
            }
         
        }
    }

    IEnumerator Reload()
    {
        ReloadSound.Play();
        isReloading = true;
        Debug.Log("Reloading");

        yield return new WaitForSeconds(reloadTime);
        currentAmmo = maxAmmo;
        

        isReloading = false;

    }
    public void Shoot()
    {
        ShotSound[Random.Range(0, 2)].Play();
        particleEffect.Play();
        currentAmmo--;
        
        //Create Bullet
        GameObject bullet = Instantiate(bulletPrefab, ShootPos.position, Player.player.playerPos.rotation);

        Rigidbody2D rigidbody2D = bullet.GetComponent<Rigidbody2D>();
        System.Random random = new System.Random();

        //Apply Damage in the Range between two point randomly
        bullet.GetComponent<GetShoot>().damage = random.Next(minDamage,maxDamage);

        //Add Force to bullet aka. Shoot Bullet
        rigidbody2D.AddForce(Player.player.playerPos.up * bulletForce, ForceMode2D.Impulse);

        //Destroy after 4sec
        Destroy(bullet, 4f);
        
        
    }
}
