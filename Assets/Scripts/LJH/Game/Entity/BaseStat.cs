using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BaseStat : MonoBehaviour
{
    [SerializeField] protected PlayerData BaseData;

    // 초기화되야 하는 스탯변수
    protected int health;
    protected bool dead;
    
    protected virtual void Start()
    {
        health = BaseData.MaxHP;
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
        if (health > BaseData.MaxHP)
        {
            health = BaseData.MaxHP;
        }
    }

    public void Die()
    {
        Debug.Log("캐릭터가 사망했습니다.");
    }

    public bool IsDead()
    {
        return dead;
    }

    #region Get Stat Func

    public virtual float GetAttackDamage()
    {
        return BaseData.AttackDamage;
    }

    public virtual int GetCurrentHealth()
    {
        return health;
    }

    public virtual int GetMaxHealth()
    {
        return BaseData.MaxHP;
    }

    public virtual float GetSpeed()
    {
        return BaseData.Speed;
    }

    public virtual float GetAttackSpeed()
    {
        return BaseData.AttackSpeed;
    }

    public virtual int GetProjectileNum()
    {
        return BaseData.projectileNum;
    }

    public virtual int GetProjectilePierce()
    {
        return BaseData.projectilePierce;
    }

    public virtual int GetMaxProjectileReflection() 
    {
        return BaseData.projectileReflection;
    }

    #endregion
}