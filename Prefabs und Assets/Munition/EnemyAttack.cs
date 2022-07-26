using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnemyAttack : MonoBehaviour
{
    public float attackSpeed = 5f;
    float attackTimer;
    public float attackRange = 1;
    public float attackForce = 10f;
    public Enemy enemy;
    public ParticleSystem ps;
    void Start()

    {
        attackTimer = attackSpeed;

    }

    // Update is called once per frame
    void Update()
    {
        if (attackTimer <= 0)
        {
            CheckForPlayer();
        }
        attackTimer -= Time.deltaTime;
    }
    void CheckForPlayer()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, attackRange);
        foreach(Collider2D c in collider)
        {
            Debug.Log(c.tag);
            if (c.gameObject.tag == "Player")
            {
                
                Player.player.SubHealth(10);
                Vector2 attackDir = c.transform.position - transform.position;
                c.GetComponent<Rigidbody2D>().AddForce(attackDir * Time.deltaTime * ( attackRange*4) * attackForce *100, ForceMode2D.Impulse);
                attackTimer = attackSpeed;
                ps.Play();
                return;
            }
        }
       
    }
}

