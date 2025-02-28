using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum AbilityType { 
    Damage, Speed, AttackSpeed, HpRecovery, MaxHp, ProjectileCount, ProjectilePierce, ProjectileReflection }

public class AbilityHandler : MonoBehaviour
{
    [SerializeField] AbilityType type;
    Button button;
    PlayerStat playerStat;
    LevelUpUI uiLevelUp;

    private void Start()
    {
        playerStat = PlaySceneManager.Instance.player.GetComponent<PlayerStat>();
        button = GetComponent<Button>();

        button.onClick.AddListener(OnClickAbility);
    }

    public void Init(LevelUpUI uiLevelUp)
    {
        this.uiLevelUp = uiLevelUp;
    }


    private void OnClickAbility()
    {
        // ´É·ÂÄ¡ »ó½Â
        switch (type)
        {
            case AbilityType.Damage:
                playerStat.SetAttackDamage(0.1f);
                break;

            case AbilityType.Speed:
                playerStat.SetSpeed(0.1f);
                break;

            case AbilityType.AttackSpeed:
                playerStat.SetAttackSpeed(-0.1f);
                break;

            case AbilityType.HpRecovery:
                playerStat.Heal(100);
                PlaySceneManager.Instance.player.ChangeHealthUI();
                break;

            case AbilityType.MaxHp:
                playerStat.SetMaxHealth(100);
                PlaySceneManager.Instance.player.ChangeHealthUI();
                break;

            case AbilityType.ProjectileCount:
                playerStat.SetProjectileNum(1);
                break;

            case AbilityType.ProjectilePierce:
                playerStat.SetProjectilePierce(1);
                break;

            case AbilityType.ProjectileReflection:
                break;
        }

        // ·¹º§¾÷ ÆÐ³Î ¼û±è
        uiLevelUp.Hide();
    }
}
