using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThisGameManager : MonoBehaviour
{
    public PlayerData BasicData;
    public PlayerData ThisGameData;

    public Slider PlayerHpBar;

    private void Start()
    {
        HpShow();
    }

    void HpShow()
    {
        PlayerHpBar.value = (BasicData.HP + ThisGameData.HP) / (BasicData.MaxHP + ThisGameData.MaxHP);
    }

    public void EndGame()
    {
        ThisGameData.HP = 0;
        ThisGameData.MaxHP = 0;
        ThisGameData.IsDead = false;
        BasicData.Gold += ThisGameData.Gold;
        BasicData.Diamond += ThisGameData.Diamond;
    }
}
