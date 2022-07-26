using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kommentar : MonoBehaviour
{
    public AudioSource audio1;
    public AudioSource audio2;
    

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            playSound();   
        }
    }

    private void playSound()
    {
    if(random())
        {
            audio1.Play();
        }
    if(!random())
        {
            audio2.Play();
        }
    
    
    
    }
    public bool random()
    {
        System.Random random = new System.Random();
        int i = random.Next();

        if((i%2) == 0) {
            return true;
        }
        else { return false; 
        }
    }
    
}
