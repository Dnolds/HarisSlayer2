using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Pathfinding;

public class BotController : MonoBehaviour
{
    float speed;
    float searchradius;
    public AIDestinationSetter des;

    void Start()
    {
        speed = GetComponent<Enemy>().speed;
        searchradius = GetComponent<Enemy>().seeRange;
    }

    // Update is called once per frame
    void Update()
    {
        CheckForPlayerInRadius();
    }

    void CheckForPlayerInRadius()
    {
        List<Collider2D> a = Physics2D.OverlapCircleAll(transform.position, searchradius).ToList();
   
        foreach (Collider2D c in a)
        {
            if (c.tag == "Player")
            {
                SetPlayerTarget(c.transform);
                return;
            }
        }
        SetPlayerTarget(null);
    }
    void SetPlayerTarget(Transform playerPos)
    {
        des.target = playerPos;
    }
}
