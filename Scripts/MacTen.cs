using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MacTen : MonoBehaviour
{
    public AudioSource ReloadSound;
    public Text Ammo;
    public GameObject ReloadingIco;
    public List<AudioSource> Shotsounds;
    public Transform Player;
    public GameObject prefab;
    public int i = 300;
    public float Times = 4;
    private float count = 0;
    public float currentAmmo = 0;
    public float maxAmmo = 32;
    public float reloadTime = 2;
    public bool isReloading = false;

    private void Start()
    {
        
        currentAmmo = maxAmmo;
    }
    void Update()
    {
        if (isReloading)
        {
            return;
        }
        Ammo.text = $"{currentAmmo} / {maxAmmo}";
        if (currentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }
        if (Input.GetKeyDown("r") && currentAmmo != maxAmmo)
        {
            StartCoroutine(Reload());
            count = -1000;
            return;
            
        }
        else
        {
            if (Input.GetKey(KeyCode.Mouse0) && count >= 0.1f)
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
        ReloadingIco.SetActive(true);
        yield return new WaitForSeconds(reloadTime);
        currentAmmo = maxAmmo;
        count = 20;
        ReloadingIco.SetActive(false);
        isReloading = false;

    }
    public void Shoot()
    {
        currentAmmo--;
        GetRandShotSound().Play();
        GameObject bullet = Instantiate(prefab, transform.position, Player.rotation);
        Rigidbody2D rigidbody2D = bullet.GetComponent<Rigidbody2D>();
        System.Random random = new System.Random();
        bullet.GetComponent<GetShoot>().damage = random.Next(25, 60);
        rigidbody2D.AddForce(Player.up * i, ForceMode2D.Impulse);
        Destroy(bullet, 4f);
        count = 0;
        Ammo.text = $"{currentAmmo} / {maxAmmo}";
    }
    public AudioSource GetRandShotSound()
    {
        var random = new System.Random();
        return Shotsounds[random.Next(0, 3)];
    }
}
