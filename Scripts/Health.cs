using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public GameObject Player;
    public GameObject Healthbar;
    public GameObject Enemy;
    public int health = 200;
    public float damage = 20;

    public void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }
    public void GetShootAt(int damage)
    {
        health = health - damage;
    }
    public void Update()
    {
        if(health <= 0)
        {
            Player.GetComponent<Money>().AddBalance(50);
            Destroy(Enemy);
        }
        Healthbar.transform.GetComponent<Healthbar>().SetHealth(health);
    }

}
