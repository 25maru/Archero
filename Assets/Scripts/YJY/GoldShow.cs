using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GoldShow : MonoBehaviour
{
    public TextMeshProUGUI Gold;
    public StatData playerData;

    private void Start()
    {
        Show();
    }

    public bool Use(int much) //��� �Ǵ� ȹ��, ��� ���� ����
    {
        if(playerData.Gold < much) return false; //��尡 ������ ��

        playerData.Gold -= much;
        Show();
        return true;
    }

    void Show()
    {
        Gold.text = playerData.Gold.ToString();
    }
}
