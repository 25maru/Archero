using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerStatUI : MonoBehaviour
{
    public PlayerStat playerstat;               // �÷��̾� ���� ����
    public TextMeshProUGUI playername;          // �÷��̾� �̸�
    public TextMeshProUGUI playerAttDamage;     // �÷��̾� ���� ����
    public TextMeshProUGUI playerMaxHP;            // �÷��̾� ü�� ����

    void Update()
    {
        if (playerstat != null)
        {
            playername.text = playerstat.Name;
            playerAttDamage.text = $"���ݷ�: {playerstat.AttackDamage}";
            playerMaxHP.text = $"ü��: {playerstat.MaxHP}";
        }
    }
}
