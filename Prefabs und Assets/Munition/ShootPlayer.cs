using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ShootPlayer : MonoBehaviour
{
    public int damage = 20;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Player")
        {
            collision.collider.GetComponent<Player>().SubHealth(damage);
            Destroy(gameObject);
        }
    }
}
