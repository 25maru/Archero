using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AvilityHandler : MonoBehaviour
{
    enum AbilityType { Damage, Speed, ProjectileCount }

    [SerializeField] AbilityType type;
    Button button;
    PlayerStat playerStat;

    private void Start()
    {
        playerStat = PlaySceneManager.Instance.player.GetComponent<PlayerStat>();
        button = GetComponent<Button>();

        button.onClick.AddListener(OnClickAvility);
    }

    private void OnClickAvility()
    {
        switch (type)
        {
            case AbilityType.Damage:
                playerStat.SetAttackDamage(1);
                break;
            case AbilityType.Speed:
                playerStat.SetSpeed(0.1f);
                break;
            case AbilityType.ProjectileCount:
                playerStat.SetProjectileNum(1);
                break;
        }
    }
}
