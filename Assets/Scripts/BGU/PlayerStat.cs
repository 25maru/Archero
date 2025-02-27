using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStat : BaseStat
{
    public PlayerData GameData;
    InventoryHandler invenHandler;

    protected override void Start()
    {
        invenHandler = GetComponent<InventoryHandler>();
    }

    public void FullHealth()
    {
        GameData.HP = GetMaxHealth();
    }

    public void GetExp(int exp)
    {
        GameData.exp += exp;

        if (GameData.exp < GameData.maxExp) 
        {
            GameData.level++;
            GameData.exp = 0;

            // 레벨업시 필요 경험치 증가
            GameData.maxExp = (int)Mathf.Ceil(GameData.maxExp * 1.2f);
        }
    }

    public override void TakeDamage(int damage)
    {
        GameData.HP -= damage;

        if (GameData.HP < 0)
        {
            GameData.HP = 0;
            dead = true;
            Die();
        }
    }

    public override void Heal(int amount)
    {
        if (GameData.IsDead) return; // 죽었으면 회복 불가

        BaseData.HP += amount;
        if (GameData.HP > GetMaxHealth())
        {
            GameData.HP = GetMaxHealth();
        }
    }

    #region Get Stat Func

    public override float GetAttackDamage()
    {
        float equipDamage = invenHandler.GetEquipAvility_Attack();

        return BaseData.AttackDamage + GameData.AttackDamage + equipDamage;
    }

    public override int GetCurrentHealth()
    {
        return GameData.HP;
    }

    public override int GetMaxHealth()
    {
        int equipHealth = (int)invenHandler.GetEquipAvility_Health();

        return BaseData.MaxHP + GameData.MaxHP + equipHealth;
    }

    public override float GetSpeed()
    {
        return BaseData.Speed * GameData.Speed;
    }

    public override float GetAttackSpeed()
    {
        return BaseData.AttackSpeed * GameData.AttackSpeed;
    }

    public override int GetProjectileNum()
    {
        return BaseData.projectileNum + GameData.projectileNum;
    }

    public override int GetProjectilePierce()
    {
        return BaseData.projectilePierce + GameData.projectilePierce;
    }

    public override int GetMaxProjectileReflection()
    {
        return BaseData.projectileReflection + GameData.projectileReflection;
    }
    #endregion
}
