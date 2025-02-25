using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 임시 아이템 클래스
public class Item : MonoBehaviour
{
    SpriteRenderer itemSprite;
    public SpriteRenderer ItemSprite { get; private set; }

    float attack;
    public float Attack { get; private set; }

    float health;
    public float Health { get; private set; }

    ItemType type;
    public ItemType Type { get; private set; }
}
