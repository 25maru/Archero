using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Shop Data", menuName = "Game Data/Shop Data")]
public class ShopData : ScriptableObject
{
    public List<GameObject> items;
}