using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellingDis : MonoBehaviour
{
    public Grid Grid;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Player") { 
        Grid.GetComponent<Grid>().enabled = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.transform.tag == "Player")
        {
            Grid.GetComponent<Grid>().enabled = true;
        }
    }
}
