using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetShoot : MonoBehaviour
{
    private float speed;
     Transform lastPosition;
    public GameObject Ahh;
    public int damage = 66;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Instantiate(Ahh,transform.position,Quaternion.identity);
        if (collision.transform.tag == "Enemy")
        {
            collision.collider.GetComponent<Enemy>().SubHealth(damage);

          
          
            Destroy(gameObject);
            
        }

        if(collision.transform.tag == "Finish")
        {
            return;
        }
       
            Destroy(gameObject);
        
    }
   
}
