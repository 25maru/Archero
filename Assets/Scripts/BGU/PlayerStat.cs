using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStat : BaseStat
{
    public StatData GameData;
    InventoryHandler invenHandler;

    protected override void Start()
    {
        invenHandler = GetComponent<InventoryHandler>();
    }

    public void InitGameData()
    {
        GameData.level = 1;
        GameData.MaxHP = 0;
        GameData.HP = GetMaxHealth();
        GameData.Speed = 1;
        GameData.AttackDamage = 1;
        GameData.AttackSpeed = 1;
        GameData.exp = 0;
        GameData.maxExp = 5;

        GameData.Gold = 0;
        GameData.Diamond = 0;

        GameData.projectileNum = 0;
        GameData.projectilePierce = 0;
        GameData.projectileReflection = 0;
    }

    public void GetExp(int exp)
    {
        GameData.exp += exp;

        if (GameData.maxExp <= GameData.exp) 
        {
            PlaySceneManager.Instance.player.ShowLevelUpUI();

            GameData.level++;
            GameData.exp = 0;

            // 레벨업시 필요 경험치 증가
            GameData.maxExp = (int)Mathf.Ceil(GameData.maxExp * 1.2f);
        }

        PlaySceneManager.Instance.player.ChangeExpUI();
    }

    public void GetGold(int gold)
    {
        baseData.Gold += gold;
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

        PlaySceneManager.Instance.player.ChangeHealthUI();
    }

    public override void Heal(int amount)
    {
        if (GameData.IsDead) return; // 죽었으면 회복 불가

        baseData.HP += amount;
        if (GameData.HP > GetMaxHealth())
        {
            GameData.HP = GetMaxHealth();
        }
    }

    #region Get Stat Func

    public override float GetAttackDamage()
    {
        float equipDamage = invenHandler.GetEquipAbility_Attack();

        return (baseData.AttackDamage + equipDamage) * GameData.AttackDamage;
    }

    public override int GetCurrentHealth()
    {
        return GameData.HP;
    }

    public override int GetMaxHealth()
    {
        int equipHealth = (int)invenHandler.GetEquipAbility_Health();

        return (baseData.MaxHP + +equipHealth) + GameData.MaxHP ;
    }

    public override int GetCurrentExp()
    {
        return GameData.exp;
    }

    public int GetMaxExp()
    {
        return GameData.maxExp;
    }

    public int GetLevel()
    {
        return GameData.level;
    }

    public override float GetSpeed()
    {
        return baseData.Speed * GameData.Speed;
    }

    public override float GetAttackSpeed()
    {
        return baseData.AttackSpeed * GameData.AttackSpeed;
    }

    public override int GetProjectileNum()
    {
        return baseData.projectileNum + GameData.projectileNum;
    }

    public override int GetProjectilePierce()
    {
        return baseData.projectilePierce + GameData.projectilePierce;
    }

    public override int GetMaxProjectileReflection()
    {
        return baseData.projectileReflection + GameData.projectileReflection;
    }
    #endregion

    #region Set Stat Func
    public void SetAttackDamage(float damage)
    {
        GameData.AttackDamage += damage;
    }

    public void SetAttackSpeed(float speed)
    {
        GameData.AttackSpeed += speed;
    }

    public void SetSpeed(float speed)
    {
        GameData.Speed += speed;
    }

    public void SetMaxHealth(int health)
    {
        GameData.MaxHP += health;
        GameData.HP += health;
    }

    public void SetProjectileNum(int num)
    {
        GameData.projectileNum += num;
    }

    public void SetProjectilePierce(int num)
    {
        GameData.projectilePierce += num;
    }

    public void SetProjectileReflection(int num)
    {
        GameData.projectileReflection += num;
    }
    #endregion
}
