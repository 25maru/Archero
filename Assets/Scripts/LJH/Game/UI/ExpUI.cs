using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ExpUI : MonoBehaviour
{
    Slider slider;
    TextMeshProUGUI textLevel;

    private void Start()
    {
        slider = GetComponentInChildren<Slider>();
        textLevel = GetComponentInChildren<TextMeshProUGUI>();

        slider.value = 0;
        textLevel.text = "Lv. 1";
    }

    public void UpdatExp(float exp, float maxExp, int level)
    {
        slider.value = exp / maxExp;
        textLevel.text = $"Lv. {level}";
    }
}
