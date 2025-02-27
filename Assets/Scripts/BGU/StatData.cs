using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Game Data/Player Data")]
public class StatData : ScriptableObject
{
    [Header("Stat Info")]
    public string Name = "Test";                               // 플레이어 이름
    public int HP;                                             // 체력
    public int MaxHP;                                          // 최대 체력
    public bool IsDead = false;                                // 사망조건
    public int level;
    public int exp;
    public int maxExp;

    public int Gold;                                           // 골드
    public int Diamond;                                        // 다이아몬드

    [Range(1, 20)][SerializeField] private float speed = 10;      // 캐릭터 속도
    public float Speed
    {
        get { return speed; }
        set { speed = Mathf.Clamp(value, 1, 20); }             // 값이 1~20 범위를 벗어나지 않도록 제한
    }

    [Range(1, 5)][SerializeField] private float attackDamage = 3; // 캐릭터 공격력
    public float AttackDamage
    {
        get { return attackDamage; }
        set { attackDamage = Mathf.Clamp(value, 1, 5); }       // 값이 1~5 범위를 벗어나지 않도록 제한
    }
    [Range(1, 5)][SerializeField] private float attackSpeed = 3;  // 공격 속도
    public float AttackSpeed
    {
        get { return attackSpeed; }
        set { attackSpeed = Mathf.Clamp(value, 1, 5); }        // 값이 1~5 범위를 벗어나지 않도록 제한
    }

    [Header("Projectile Info")]
    public int projectileNum = 1;
    public int projectilePierce = 0;
    public int projectileReflection = 0;
}
