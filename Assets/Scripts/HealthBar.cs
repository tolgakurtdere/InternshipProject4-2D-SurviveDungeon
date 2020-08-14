using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider bar;
    private int maxValue = 100;
    private int currentValue;
    void Start()
    {
        currentValue = maxValue;
        bar.maxValue = maxValue;
        bar.value = maxValue;
    }

    public void LoseHP(int amount)
    {
        if (currentValue - amount >= 0)
        {
            currentValue -= amount;
            bar.value = currentValue;
        }
        else
        {
            currentValue = 0;
            bar.value = currentValue;
        }
    }

    public void GainHP(int amount)
    {
        if (currentValue + amount <= maxValue)
        {
            currentValue += amount;
            bar.value = currentValue;
        }
        else
        {
            currentValue = maxValue;
            bar.value = currentValue;
        }
    }

    public int GetCurrentValue()
    {
        return currentValue;
    }
}
