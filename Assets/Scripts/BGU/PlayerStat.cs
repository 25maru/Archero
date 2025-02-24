using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : MonoBehaviour
{
    public PlayerData playerData;

    void Start()
    {
        playerData.HP = playerData.MaxHP;
    }

    public void TakeDamage(int damage)
    {
        playerData.HP -= damage;

        if (playerData.HP < 0)
        {
            playerData.HP = 0;
            playerData.IsDead = true;
            Die();
        }
    }

    public void Heal(int amount)
    {
        if (playerData.IsDead) return; // 죽었으면 회복 불가

        playerData.HP += amount;
        if (playerData.HP > playerData.MaxHP)
        {
            playerData.HP = playerData.MaxHP;
        }
    }

    public void Die()
    {
        Debug.Log("캐릭터가 사망했습니다.");
    }
}
