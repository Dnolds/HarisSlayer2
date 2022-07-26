using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public static Player player;
    public Transform playerPos;
    public int maxHealth = 200;
    public int health;
    public float currentAmmo;
    public float maxAmmo;
    public Sprite weaponImage;

    // Start is called before the first frame update
    private void Start()
    {
        health = maxHealth;
    }
    public void SubHealth(int amount)
    {
        if(health - amount <= 0)
        {
            Destroy(gameObject);
        }
        health -= amount;
    }
    public void AddHealth(int amount)
    {
        if(health < maxHealth) { 
        health += amount;
        }
    }
    void Awake()
    {
        if (player != null)
            GameObject.Destroy(player);
        else
            player = this;

        DontDestroyOnLoad(this);
    }
}
