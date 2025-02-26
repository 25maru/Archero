using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "Game Data/Item Data")]
public class ItemData : ScriptableObject
{
    [SerializeField] List<GameObject> itemDatabase;
}
