using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : MonoBehaviour
{
    public string Name;             // �÷��̾� �̸�
    public int HP;                  // ü��
    public int MaxHP;               // �ִ� ü��
    public int Speed;               // ĳ���� �ӵ�
    public int AttackDamage;        // ĳ���� ���ݷ�
    public int AttackSpeed;         // ���� �ӵ�
    public bool IsDead = false;     // �������

    public int Gold;                // ���
    public int Diamond;             // ���̾Ƹ��

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
        Debug.Log ("ĳ���Ͱ� ����߽��ϴ�.");
    }
}
