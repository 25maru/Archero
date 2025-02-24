using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Game Data/Player Data")]
public class PlayerData : ScriptableObject
{
    public string Name;
    public int HP;
    public int MaxHP;
    public bool IsDead;

    public int Gold;
    public int Diamond;

    public List<Item> listItem;
    public Item[] equipment;
}
