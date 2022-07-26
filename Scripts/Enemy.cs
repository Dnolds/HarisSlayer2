using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int id;
    public float speed = 4f;
    public float seeRange = 10f;
    public int health = 100;
    public float damage = 10f;
    public int tier = 0;

    private void Start()
    {
        Destroy(gameObject, 500);
    }
    public void SubHealth(int a)
    {
       
        if(health <= a)
        {
            RoundManager.roundManager.score += 10;
            GetComponent<Drop>().DropItems();
            Destroy(gameObject);
        }
        health -= a;
    }
    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, seeRange);
    }
}
