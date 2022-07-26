using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPGHead : MonoBehaviour
{
    public float range = 2f;
    public float damage;
    public float strength = 10f;
    public GameObject explosionParticle;
    bool brightnessTool = true;
    float brightness = 0;
    public GameObject light;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Explode();
    }
    void Explode()
    {

        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position,range);
        GameObject a = Instantiate(explosionParticle,transform.position,Quaternion.identity);
        foreach(Collider2D c in collider)
        {
            if(c.GetComponent<Rigidbody2D>() != null && c.tag != "Player")
            {
                Vector2 forceDir = c.transform.position - transform.position;
                Destroy(c.gameObject);
                
            }
        }
        
        
        Destroy(a, 2);
        light = a.transform.GetChild(0).gameObject;
        Destroy(light,1.2f);
        brightnessTool = false;
    }
    private void Update()
    {
        if (brightnessTool)
        {
            brightness += Time.deltaTime * 10;
        }
        else
        {
            brightness -= Time.deltaTime * 10;
        }
       

    }
}
