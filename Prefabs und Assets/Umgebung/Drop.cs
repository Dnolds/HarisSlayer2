using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{
    public GameObject[] dropList;
    public float[] dropChance;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DropItems()
    {
        for(int i = 0; i < dropList.Length; i++)
        {
            if(dropChance[i] > Random.Range(0, 100))
            {
                Instantiate(dropList[i],transform.position,Quaternion.identity);
            }
        }
    }
}
