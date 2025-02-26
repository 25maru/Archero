    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    [CreateAssetMenu(fileName = "InventoryHandler", menuName = "Game Data/Inventory Data")]
    public class InventoryData : ScriptableObject
    {
        public List<Item> listItem;
        public Item equipment_Weapon;
        public Item equipment_Armor;
        public Item equipment_Head;
        public Item equipment_Shoes;
        public Item equipment_Ring;
        public Item equipment_Necklace;
}