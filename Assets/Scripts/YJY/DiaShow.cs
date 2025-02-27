using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DiaShow : MonoBehaviour
{
    public TextMeshProUGUI Dia;
    public StatData playerData;

    private void Start()
    {
        Show();
    }

    public bool Use(int much) //사용 또는 획득, 사용 가능 유무
    {
        if (playerData.Diamond < much) return false; //골드가 부족할 시

        playerData.Diamond -= much;
        Show();
        return true;
    }

    void Show()
    {
        Dia.text = playerData.Diamond.ToString();
    }
}
