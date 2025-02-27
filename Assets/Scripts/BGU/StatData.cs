using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Game Data/Player Data")]
public class StatData : ScriptableObject
{
    [Header("Stat Info")]
    public string Name = "Test";                               // �÷��̾� �̸�
    public int HP;                                             // ü��
    public int MaxHP;                                          // �ִ� ü��
    public bool IsDead = false;                                // �������
    public int level;
    public int exp;
    public int maxExp;

    public int Gold;                                           // ���
    public int Diamond;                                        // ���̾Ƹ��

    [Range(1, 20)][SerializeField] private float speed = 10;      // ĳ���� �ӵ�
    public float Speed
    {
        get { return speed; }
        set { speed = Mathf.Clamp(value, 1, 20); }             // ���� 1~20 ������ ����� �ʵ��� ����
    }

    [Range(1, 5)][SerializeField] private float attackDamage = 3; // ĳ���� ���ݷ�
    public float AttackDamage
    {
        get { return attackDamage; }
        set { attackDamage = Mathf.Clamp(value, 1, 5); }       // ���� 1~5 ������ ����� �ʵ��� ����
    }
    [Range(1, 5)][SerializeField] private float attackSpeed = 3;  // ���� �ӵ�
    public float AttackSpeed
    {
        get { return attackSpeed; }
        set { attackSpeed = Mathf.Clamp(value, 1, 5); }        // ���� 1~5 ������ ����� �ʵ��� ����
    }

    [Header("Projectile Info")]
    public int projectileNum = 1;
    public int projectilePierce = 0;
    public int projectileReflection = 0;
}
