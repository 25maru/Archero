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

    public bool Use(int much) //사용 또는 획득, 사용 가능 유무
    {
        if(playerData.Gold < much) return false; //골드가 부족할 시

        playerData.Gold -= much;
        Show();
        return true;
    }

    void Show()
    {
        Gold.text = playerData.Gold.ToString();
    }
}
