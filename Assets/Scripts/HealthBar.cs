using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;  // Reference to the UI slider

    public void SetMaxHealth(int maxHealth)
    {
        slider.maxValue = maxHealth;
        slider.value = maxHealth;  // Set the bar to full at the start
    }

    public void SetHealth(int health)
    {
        slider.value = health; // Update the slider value
    }
}

