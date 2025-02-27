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

    public bool Use(int much) //��� �Ǵ� ȹ��, ��� ���� ����
    {
        if (playerData.Diamond < much) return false; //��尡 ������ ��

        playerData.Diamond -= much;
        Show();
        return true;
    }

    void Show()
    {
        Dia.text = playerData.Diamond.ToString();
    }
}
