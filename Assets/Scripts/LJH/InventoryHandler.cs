using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class InventoryHandler : MonoBehaviour
{
    [SerializeField] InventoryData data;
    public InventoryData Data { get { return data; } }

    // 아이템 장착
    public void EquipItem(Item item)
    {
        switch (item.Type)
        {
            case ItemType.Weapon:
                data.equipment_Weapon = item;
                break;
            case ItemType.Armor:
                data.equipment_Armor = item;
                break;
            case ItemType.Head:
                data.equipment_Head = item;
                break;
            case ItemType.Shoes: 
                data.equipment_Shoes = item;
                break;
            case ItemType.Ring: 
                data.equipment_Ring = item;
                break;
            case ItemType.Necklace: 
                data.equipment_Necklace = item;
                break;
        }
    }

    // 장착 중인 장비의 총 공격력 가져오기
    public float GetEquipAbility_Attack() 
    {
        float total = 0;
        
        if (data.equipment_Weapon)
            total += data.equipment_Weapon.Attack;
        if (data.equipment_Armor)
            total += data.equipment_Armor.Attack;
        if (data.equipment_Head)
            total += data.equipment_Head.Attack;
        if (data.equipment_Shoes)
            total += data.equipment_Shoes.Attack;
        if (data.equipment_Ring)
            total += data.equipment_Ring.Attack;
        if (data.equipment_Necklace)
            total += data.equipment_Necklace.Attack;

        return total;
    }

    // 장착 중인 장비의 총 체력 가져오기
    public float GetEquipAbility_Health() 
    {
        float total = 0;

        if (data.equipment_Weapon)
            total += data.equipment_Weapon.Health;
        if (data.equipment_Armor)
            total += data.equipment_Armor.Health;
        if (data.equipment_Head)
            total += data.equipment_Head.Health;
        if (data.equipment_Shoes)
            total += data.equipment_Shoes.Health;
        if (data.equipment_Ring)
            total += data.equipment_Ring.Health;
        if (data.equipment_Necklace)
            total += data.equipment_Necklace.Health;

        return total;
    }
}