using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    Slider slider;

    private void Start()
    {
        slider = GetComponentInChildren<Slider>();
    }

    public void UpdateHealth(float hp, float maxHp)
    {
        slider.value = hp / maxHp;
    }
}
