using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class InventoryHandler : MonoBehaviour
{
    [SerializeField] InventoryData data;
    public InventoryData Data { get { return data; } }

    // ������ ����
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

    // ���� ���� ����� �� ���ݷ� ��������
    public float GetEquipAvility_Attack() 
    {
        float total = 0;

        //for(int i = 0; i < data.equipment.Length; i++)
        //{
        //    total += data.equipment[i] ? data.equipment[i].Attack : 0;
        //}
        total += data.equipment_Weapon.Attack;
        total += data.equipment_Head.Attack;
        total += data.equipment_Armor.Attack;
        total += data.equipment_Shoes.Attack;
        total += data.equipment_Ring.Attack;
        total += data.equipment_Necklace.Attack;

        return total;
    }

    // ���� ���� ����� �� ü�� ��������
    public float GetEquipAvility_Health() 
    {
        float total = 0;

        total += data.equipment_Weapon.Health;
        total += data.equipment_Head.Health;
        total += data.equipment_Armor.Health;
        total += data.equipment_Shoes.Health;
        total += data.equipment_Ring.Health;
        total += data.equipment_Necklace.Health;

        return total;
    }
}