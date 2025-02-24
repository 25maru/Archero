using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStatUI : MonoBehaviour
{
    public PlayerStat playerStat;               // �÷��̾� ���� ����
    public TextMeshProUGUI playerNameText;          // �÷��̾� �̸�
    public TextMeshProUGUI playerAttackText;     // �÷��̾� ���� ����
    public TextMeshProUGUI playerMaxHPText;            // �÷��̾� ü�� ����
    public TextMeshProUGUI goldText;            // �÷��̾ ������ ���
    public TextMeshProUGUI diamondText;         // �÷��̾ ������ ���̾Ƹ��

    void Start()
    {
        UpdateUI();
    }

    public void UpdateUI()
    {
        if (playerStat != null)
        {
            playerNameText.text = $"�̸�: {playerStat.Name}";
            playerMaxHPText.text = $"ü��: {playerStat.MaxHP}";
            playerAttackText.text = $"���ݷ�: {playerStat.AttackDamage}";
            goldText.text = $"���: {playerStat.Gold}";
            diamondText.text = $"���̾�: {playerStat.Diamond}";
        }
    }
}
