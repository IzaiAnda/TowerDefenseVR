using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Image fill;

    private void Start()
    {
        slider = GetComponent<Slider>();
    }

    public void setHealth(int currentHealth)
    {
        slider.value= currentHealth;
    }

    public void setMaxHealth(int maxHealth)
    {
        slider.maxValue= maxHealth;
        slider.value = maxHealth;
    }

    public void setPoisoned()
    {
        fill.color = Color.magenta;
    }

    public void setBurn()
    {
        fill.color = Color.red;
    }

    public void setFreeze()
    {
        fill.color = Color.cyan;
    }

}
