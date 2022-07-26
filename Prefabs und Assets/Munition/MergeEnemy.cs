using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class MergeEnemy : MonoBehaviour
{
    public GameObject nextTierEnemy;
    public RoundManager rm;
    void Start()
    {
        rm = GameObject.FindGameObjectWithTag("GameController").GetComponent<RoundManager>();
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Enemy")
        {
            if (collision.collider.GetComponent<Enemy>().tier == GetComponent<Enemy>().tier)
            {
                StartCoroutine(Merge(collision.gameObject));
                
            }
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Enemy")
        {
            if (collision.collider.GetComponent<Enemy>().tier == GetComponent<Enemy>().tier)
            {
                StopCoroutine(Merge(collision.gameObject));

            }
        }
    }

    IEnumerator Merge(GameObject g)
    {
        
        Debug.Log("Start Evo");
        yield return new WaitForSecondsRealtime(15); //Wait 1 second
        if(g.GetComponent<Enemy>().id > GetComponent<Enemy>().id)
        {
            
            Mergee(nextTierEnemy, gameObject);
            
        }
        Destroy(g);
        Destroy(gameObject);


        Debug.Log("End Evo");
    }
    public void Mergee(GameObject nextTierEnemy, GameObject enemy)
    {
       
            Vector2 enemyPos = enemy.transform.position;
            
            GameObject a = Instantiate(nextTierEnemy, enemyPos, Quaternion.identity);
            a.GetComponent<Enemy>().tier = GetComponent<Enemy>().tier++;
            a.GetComponent<Enemy>().id = 1 + rm.highestId();
        
        return;
        
        
    }


}
