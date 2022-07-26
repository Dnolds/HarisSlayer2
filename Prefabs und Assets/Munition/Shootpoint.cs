using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shootpoint : MonoBehaviour
{
    public float destroyTime = 0.3f;
    void Start()
    {
        Destroy(gameObject, destroyTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
