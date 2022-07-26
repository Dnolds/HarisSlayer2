using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shotgun : MonoBehaviour
{
    public AudioSource ReloadSound;
    public Text Ammo;
    public GameObject ReloadingIco;
    public AudioSource ShotSound;
    
    public GameObject prefab;
    public int i = 300;
    public float Times = 4;
    private float count = 0;
    public float currentAmmo = 0;
    public float maxAmmo = 2;
    public float reloadTime = 1;
    public bool isReloading = false;
    public ParticleSystem ps;
    private void Start()
    {
        currentAmmo = maxAmmo;
    }
    void Update()
    {
        
        Player.player.currentAmmo = currentAmmo;
        Player.player.maxAmmo = maxAmmo;
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
            if (Input.GetKeyDown(KeyCode.Mouse0) )
            {
                Shoot();

            }
            count += Time.deltaTime;
        }
    }

    IEnumerator Reload()
    {
        ReloadSound.Play();
        isReloading = true;
        Debug.Log("Reloading");
        
        yield return new WaitForSeconds(reloadTime);
        currentAmmo = maxAmmo;
         count = 20;
        
        isReloading = false;

    }
    public void Shoot()
    {
        currentAmmo--;
        ShotSound.Play();
        GameObject bullet = Instantiate(prefab, transform.position, Player.player.playerPos.rotation);
        Rigidbody2D rigidbody2D = bullet.GetComponent<Rigidbody2D>();
        System.Random random = new System.Random();
        bullet.GetComponent<GetShoot>().damage = random.Next(90, 250);
        rigidbody2D.AddForce(Player.player.playerPos.up * i, ForceMode2D.Impulse);
        Destroy(bullet, 4f);
        count = 0;
        ps.Play();
      
    }
}
