using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Game Data/Player Data")]
public class PlayerData : ScriptableObject
{
    public string Name = "Test";                               // �÷��̾� �̸�
    public int HP;                                             // ü��
    public int MaxHP;                                          // �ִ� ü��
    public bool IsDead = false;                                // �������

    public int Gold;                                           // ���
    public int Diamond;                                        // ���̾Ƹ��

    [Range(1, 20)][SerializeField] public int speed = 10;      // ĳ���� �ӵ�
    public int Speed
    {
        get { return speed; }
        set { speed = Mathf.Clamp(value, 1, 20); }             // ���� 1~20 ������ ����� �ʵ��� ����
    }

    [Range(1, 5)][SerializeField] public int attackDamage = 3; // ĳ���� ���ݷ�
    public int AttackDamage
    {
        get { return attackDamage; }
        set { attackDamage = Mathf.Clamp(value, 1, 5); }       // ���� 1~5 ������ ����� �ʵ��� ����
    }
    [Range(1, 5)][SerializeField] public int attackSpeed = 3;  // ���� �ӵ�
    public int AttackSpeed
    {
        get { return attackSpeed; }
        set { attackSpeed = Mathf.Clamp(value, 1, 5); }        // ���� 1~5 ������ ����� �ʵ��� ����
    }
}
