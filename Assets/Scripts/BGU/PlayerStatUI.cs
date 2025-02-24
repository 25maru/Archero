using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStatUI : MonoBehaviour
{
    public PlayerStat playerStat;               // 플레이어 스탯 정보
    public TextMeshProUGUI playerNameText;          // 플레이어 이름
    public TextMeshProUGUI playerAttackText;     // 플레이어 공격 스텟
    public TextMeshProUGUI playerMaxHPText;            // 플레이어 체력 스텟
    public TextMeshProUGUI goldText;            // 플레이어가 소지한 골드
    public TextMeshProUGUI diamondText;         // 플레이어가 소지한 다이아몬드

    void Start()
    {
        UpdateUI();
    }

    public void UpdateUI()
    {
        if (playerStat != null)
        {
            playerNameText.text = $"이름: {playerStat.Name}";
            playerMaxHPText.text = $"체력: {playerStat.MaxHP}";
            playerAttackText.text = $"공격력: {playerStat.AttackDamage}";
            goldText.text = $"골드: {playerStat.Gold}";
            diamondText.text = $"다이아: {playerStat.Diamond}";
        }
    }
}
