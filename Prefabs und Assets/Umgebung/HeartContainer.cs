using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class HeartContainer : MonoBehaviour
{
    public int healAmount;
    void Start()
    {
        healAmount = Random.Range(20, 100);
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D player = Physics2D.OverlapCircleAll(transform.position, 0.5f).FirstOrDefault(e => e.transform.gameObject.tag == "Player");
        if(player != null)
        {
            player.GetComponent<Player>().AddHealth(healAmount);
            Destroy(gameObject);
        }
    }
}
