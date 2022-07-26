using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    public Slider Slider;
   public void SetStamina(float Stamina)
    {
        Slider.value = Stamina;
    }
}
