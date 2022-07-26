using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ChristianAttack : MonoBehaviour
{
    
    public float attackSpeed = 5f;
    float attackTimer;
    public float attackRange = 1;
    public float attackForce = 10f;
    public Enemy enemy;
    public GameObject bullet;
    public ParticleSystem ps;
    public Transform shootPoint;
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
        Collider2D collider = Physics2D.OverlapCircleAll(transform.position, attackRange).FirstOrDefault(e => e.tag == "Player");
        if(collider != null)
        {
            Shoot(collider.transform.position);
        }

    }
    private void Shoot(Vector2 playerPos)
    {
       GameObject b = Instantiate(bullet, shootPoint.position, transform.rotation);
        Vector2 shootDir = playerPos- (Vector2)b.transform.position;
        
        b.GetComponent<Rigidbody2D>().AddForce(shootDir * Time.deltaTime *5000,ForceMode2D.Impulse);
        attackTimer = attackSpeed;
    }
}
