using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BaseStat : MonoBehaviour
{
    [SerializeField] protected StatData baseData;
    [SerializeField] private GameObject DeathPanel;         // 사망 시 패널 출력

    // 초기화되야 하는 스탯변수
    protected int health;
    public bool dead;
    
    protected virtual void Start()
    {
        health = baseData.MaxHP;
        dead = false;

        if(DeathPanel != null)
        {
            DeathPanel.SetActive(false);                    // 패널 비활성화
        }
    }

    public virtual void TakeDamage(int damage)
    {
        health -= damage;

        if (health < 0)
        {
            health = 0;
            dead = true;
            Die();
        }
    }

    public virtual void Heal(int amount)
    {
        if (dead) return; // 죽었으면 회복 불가

        health += amount;
        if (health > baseData.MaxHP)
        {
            health = baseData.MaxHP;
        }
    }

    public void Die()
    {
        Debug.Log("캐릭터가 사망했습니다.");

        if (CompareTag("Player"))
        {
            DeathPanel.SetActive(true);         // 플레이어 사망 시 출력
            Time.timeScale = 0;                 // 패널 출력 시 시간 멈춤
        }
    }

    public bool IsDead()
    {
        return dead;
    }

    #region Get Stat Func

    public virtual float GetAttackDamage()
    {
        return baseData.AttackDamage;
    }

    public virtual int GetCurrentHealth()
    {
        return health;
    }

    public virtual int GetMaxHealth()
    {
        return baseData.MaxHP;
    }

    public virtual float GetSpeed()
    {
        return baseData.Speed;
    }

    public virtual float GetAttackSpeed()
    {
        return baseData.AttackSpeed;
    }

    public virtual int GetProjectileNum()
    {
        return baseData.projectileNum;
    }

    public virtual int GetProjectilePierce()
    {
        return baseData.projectilePierce;
    }

    public virtual int GetMaxProjectileReflection() 
    {
        return baseData.projectileReflection;
    }

    #endregion
}