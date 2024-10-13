using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public TextMeshProUGUI healthText;
    public Image fillBar;

    //public void UpdateHealth(int health, int maxHealth)
    //{
    //    healthText.text = health.ToString() + " / " + maxHealth.ToString();
    //    bar.fillAmount = (float)health / (float)maxHealth;
    //}

    public void UpdateBar(int currentValue, int maxValue)
    {
        fillBar.fillAmount = (float)currentValue / (float)maxValue;
        healthText.text = currentValue.ToString() + " / " + maxValue.ToString();
    }
}
