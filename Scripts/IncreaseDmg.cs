using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class IncreaseDmg : MonoBehaviour
{
    public int amount;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D player = Physics2D.OverlapCircleAll(transform.position, 0.5f).FirstOrDefault(e => e.transform.gameObject.tag == "Player");
        if (player != null)
        {
            player.GetComponentInChildren<Ak47>().maxDamage += amount;
            player.GetComponentInChildren<Ak47>().minDamage += amount;
            Destroy(gameObject);
        }
    }
}
