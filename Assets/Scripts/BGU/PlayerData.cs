using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Game Data/Player Data")]
public class PlayerData : ScriptableObject
{
    public string Name = "Test";                               // 플레이어 이름
    public int HP;                                             // 체력
    public int MaxHP;                                          // 최대 체력
    public bool IsDead = false;                                // 사망조건

    public int Gold;                                           // 골드
    public int Diamond;                                        // 다이아몬드

    [Range(1, 20)][SerializeField] public int speed = 10;      // 캐릭터 속도
    public int Speed
    {
        get { return speed; }
        set { speed = Mathf.Clamp(value, 1, 20); }             // 값이 1~20 범위를 벗어나지 않도록 제한
    }

    [Range(1, 5)][SerializeField] public int attackDamage = 3; // 캐릭터 공격력
    public int AttackDamage
    {
        get { return attackDamage; }
        set { attackDamage = Mathf.Clamp(value, 1, 5); }       // 값이 1~5 범위를 벗어나지 않도록 제한
    }
    [Range(1, 5)][SerializeField] public int attackSpeed = 3;  // 공격 속도
    public int AttackSpeed
    {
        get { return attackSpeed; }
        set { attackSpeed = Mathf.Clamp(value, 1, 5); }        // 값이 1~5 범위를 벗어나지 않도록 제한
    }
}
