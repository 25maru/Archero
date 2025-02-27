using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BaseStat : MonoBehaviour
{
    [SerializeField] protected StatData baseData;
    [SerializeField] private GameObject DeathPanel;         // ��� �� �г� ���

    // �ʱ�ȭ�Ǿ� �ϴ� ���Ⱥ���
    protected int health;
    public bool dead;
    
    protected virtual void Start()
    {
        health = baseData.MaxHP;
        dead = false;

        if(DeathPanel != null)
        {
            DeathPanel.SetActive(false);                    // �г� ��Ȱ��ȭ
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
        if (dead) return; // �׾����� ȸ�� �Ұ�

        health += amount;
        if (health > baseData.MaxHP)
        {
            health = baseData.MaxHP;
        }
    }

    public void Die()
    {
        Debug.Log("ĳ���Ͱ� ����߽��ϴ�.");

        if (CompareTag("Player"))
        {
            DeathPanel.SetActive(true);         // �÷��̾� ��� �� ���
            Time.timeScale = 0;                 // �г� ��� �� �ð� ����
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