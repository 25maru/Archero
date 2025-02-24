using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : MonoBehaviour
{
    public PlayerData playerData;

    public string Name = "Test";                                     // �÷��̾� �̸�
    public int HP = 100;                                             // ü��
    public int MaxHP = 100;                                          // �ִ� ü��
    public bool IsDead = false;                                      // �������

    public int Gold = 0;                                             // ���
    public int Diamond = 0;                                          // ���̾Ƹ��

    [Range(1, 20)][SerializeField] public int speed = 10;            // ĳ���� �ӵ�
    public int Speed
    {
        get { return speed; }
        set { speed = Mathf.Clamp(value, 1, 20); }                   // ���� 1~20 ������ ����� �ʵ��� ����
    }

    [Range(1, 5)][SerializeField] public int attackDamage = 3;       // ĳ���� ���ݷ�
    public int AttackDamage
    {
        get { return attackDamage; }
        set { attackDamage = Mathf.Clamp(value, 1, 5); }             // ���� 1~5 ������ ����� �ʵ��� ����
    }
    [Range(1, 5)][SerializeField] public int attackSpeed = 3;        // ���� �ӵ�
    public int AttackSpeed
    {
        get { return attackSpeed; }
        set { attackSpeed = Mathf.Clamp(value, 1, 5); }              // ���� 1~5 ������ ����� �ʵ��� ����
    }

    void Start()
    {
        HP = MaxHP;
    }

    public void TakeDamage(int damage)
    {
        HP -= damage;

        if (HP < 0)
        {
            HP = 0;
            IsDead = true;
            Die();
        }
    }

    public void Heal(int amount)
    {
        if (IsDead) return; // �׾����� ȸ�� �Ұ�

        HP += amount;
        if (HP > MaxHP)
        {
            HP = MaxHP;
        }
    }

    public void Die()
    {
        Debug.Log("ĳ���Ͱ� ����߽��ϴ�.");
    }
}
