using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Money : MonoBehaviour
{
    public Text textBox;
    public int Balance { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        textBox.text = Balance + "$";
    }
    public void AddBalance(int amount)
    {
        Balance += amount;
        
    }
}
