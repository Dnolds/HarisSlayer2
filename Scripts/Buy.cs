using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buy : MonoBehaviour
{
    public int cost = 50;
    public GameObject Canvas;
    GameObject Player;
    public float distance;
    bool Baught = false;
    // Start is called before the first frame update
    void Start()
    {
        Canvas.SetActive(true);
        Canvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        distance = Vector2.Distance(transform.position, Player.transform.position);

        if(distance <= 2)
        {
            Canvas.SetActive(true);
            if (Input.GetKeyDown("e") && !Baught && Player.GetComponent<Money>().Balance > cost)
            {
                Player.GetComponent<Money>().Balance -= cost;
                Baught = true;
            }
        }
        
        else if(distance > 2)
        {
            Canvas.SetActive(false);

        }
    }
}
