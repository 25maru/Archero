using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : MonoBehaviour
{
    public PlayerData playerData;

    public int HP;
    public int MaxHP;
    public bool IsDead = false;

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
