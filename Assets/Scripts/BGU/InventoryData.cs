    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    [CreateAssetMenu(fileName = "InventoryHandler", menuName = "Game Data/Inventory Data")]
    public class InventoryData : ScriptableObject
    {
        public List<Item> listItem;
        public Item[] equipment;
    }