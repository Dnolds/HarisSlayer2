using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Text AmmoText;
    public Image weaponImage;
    public Slider healthSlider;
    public GameObject reloadImage;
    
   
    
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Player.player.currentAmmo <= 0)
        {
            reloadImage.SetActive(true);
        }
        else
        {
            reloadImage.SetActive(false) ;
        }
        AmmoText.text = $"{Player.player.currentAmmo} / {Player.player.maxAmmo}";
        
        healthSlider.value = Player.player.health;
    }
}
