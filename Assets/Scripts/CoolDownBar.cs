using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoolDownBar : MonoBehaviour
{
    public Slider bar;
    private int maxValue = 1000;
    private int currentValue;
    void Start()
    {
        currentValue = maxValue;
        bar.maxValue = maxValue;
        bar.value = maxValue;
    }

    public void UseMana(int amount)
    {
        if(currentValue - amount >= 0)
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

    public void GainMana(int amount)
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
