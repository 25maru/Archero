using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerStatUI : MonoBehaviour
{
    public PlayerStat playerstat;               // 플레이어 스탯 정보
    public TextMeshProUGUI playername;          // 플레이어 이름
    public TextMeshProUGUI playerAttDamage;     // 플레이어 공격 스텟
    public TextMeshProUGUI playerMaxHP;            // 플레이어 체력 스텟

    void Update()
    {
        if (playerstat != null)
        {
            playername.text = playerstat.Name;
            playerAttDamage.text = $"공격력: {playerstat.AttackDamage}";
            playerMaxHP.text = $"체력: {playerstat.MaxHP}";
        }
    }
}
