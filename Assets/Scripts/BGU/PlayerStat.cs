using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : MonoBehaviour
{
    public PlayerData playerData;

    public string Name = "Test";                                     // 플레이어 이름
    public int HP = 100;                                             // 체력
    public int MaxHP = 100;                                          // 최대 체력
    public bool IsDead = false;                                      // 사망조건

    public int Gold = 0;                                             // 골드
    public int Diamond = 0;                                          // 다이아몬드

    [Range(1, 20)][SerializeField] public int speed = 10;            // 캐릭터 속도
    public int Speed
    {
        get { return speed; }
        set { speed = Mathf.Clamp(value, 1, 20); }                   // 값이 1~20 범위를 벗어나지 않도록 제한
    }

    [Range(1, 5)][SerializeField] public int attackDamage = 3;       // 캐릭터 공격력
    public int AttackDamage
    {
        get { return attackDamage; }
        set { attackDamage = Mathf.Clamp(value, 1, 5); }             // 값이 1~5 범위를 벗어나지 않도록 제한
    }
    [Range(1, 5)][SerializeField] public int attackSpeed = 3;        // 공격 속도
    public int AttackSpeed
    {
        get { return attackSpeed; }
        set { attackSpeed = Mathf.Clamp(value, 1, 5); }              // 값이 1~5 범위를 벗어나지 않도록 제한
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
        if (IsDead) return; // 죽었으면 회복 불가

        HP += amount;
        if (HP > MaxHP)
        {
            HP = MaxHP;
        }
    }

    public void Die()
    {
        Debug.Log("캐릭터가 사망했습니다.");
    }
}
