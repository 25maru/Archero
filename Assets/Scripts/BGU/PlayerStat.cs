using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : MonoBehaviour
{
    public string Name;             // 플레이어 이름
    public int HP;                  // 체력
    public int MaxHP;               // 최대 체력
    public int Speed;               // 캐릭터 속도
    public int AttackDamage;        // 캐릭터 공격력
    public int AttackSpeed;         // 공격 속도
    public bool IsDead = false;     // 사망조건

    public int Gold;                // 골드
    public int Diamond;             // 다이아몬드

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
        if (IsDead) return; // 죽었으면 회복 불가

        HP += amount;
        if (HP > MaxHP)
        {
            HP = MaxHP;
        }
    }

    public void Die()
    {
        Debug.Log ("캐릭터가 사망했습니다.");
    }
}
