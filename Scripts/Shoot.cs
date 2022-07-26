using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public int damage = 10;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shooting();
        }
    }

    void Shooting()
    {
        Vector2 mousedir = Camera.main.ScreenToWorldPoint(Input.mousePosition)- transform.position;
        RaycastHit2D ray = Physics2D.Raycast(transform.position, mousedir);
        if(ray.transform.tag == "Enemy")
        {
            ray.collider.GetComponent<Enemy>().SubHealth(damage);
            ParticleSystem particles = new ParticleSystem();
            Instantiate(particles, transform.position, Quaternion.identity);
        }
    }
   
}
