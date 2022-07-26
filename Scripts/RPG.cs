using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPG : MonoBehaviour
{
    public AudioSource ReloadSound;

    public GameObject ReloadingIco;
    public AudioSource ShotSound;
   
    public GameObject prefab;
    public int i = 300;

    

    private float count = 0;
    public float currentAmmo = 0;
    public float maxAmmo = 1;
    public float reloadTime = 5;
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
            if (Input.GetKey(KeyCode.Mouse0))
            {
                Shoot();
               
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
       
        
        rigidbody2D.AddForce(Player.player.playerPos.up * i * Time.deltaTime*50, ForceMode2D.Impulse );
        Destroy(bullet, 4f);
        


    }
}
