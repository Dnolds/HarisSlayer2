using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MP : MonoBehaviour
{
    public AudioSource ReloadSound;

    public GameObject ReloadingIco;
    public AudioSource ShotSound;
    
    public GameObject prefab;
    public int i = 300;

    public float shootTime = 0.1f;
    float shootTimer = 0;

    private float count = 0;
    public float currentAmmo = 0;
    public float maxAmmo = 30;
    public float reloadTime = 1;
    public bool isReloading = false;
    public ParticleSystem ps;
    private void Start()
    {
        currentAmmo = maxAmmo;
        shootTimer = shootTime;
    }
    void Update()
    {
        
        Player.player.currentAmmo = currentAmmo;
        Player.player.maxAmmo = maxAmmo;
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
            count += Time.deltaTime;
        }
    }

    IEnumerator Reload()
    {

        isReloading = true;
        Debug.Log("Reloading");

        yield return new WaitForSeconds(reloadTime);
        currentAmmo = maxAmmo;


        isReloading = false;

    }
    public void Shoot()
    {
        ps.Play();
        currentAmmo--;

        GameObject bullet = Instantiate(prefab, transform.position, Player.player.playerPos.rotation);

        Rigidbody2D rigidbody2D = bullet.GetComponent<Rigidbody2D>();
        System.Random random = new System.Random();
        bullet.GetComponent<GetShoot>().damage = random.Next(10, 30);
        rigidbody2D.AddForce(Player.player.playerPos.up * i, ForceMode2D.Impulse);
        Destroy(bullet, 4f);


    }
}
