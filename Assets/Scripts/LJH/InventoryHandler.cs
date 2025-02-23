using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum ItemType { Weapon, Armor, gloves, Shoes, End }

public class InventoryHandler : MonoBehaviour
{
    List<Item> listItem;
    Item[] equipment;

    private void Start()
    {
        equipment = new Item[(int)ItemType.End];
    }

    // 인벤토리에 아이템 추가
    public void AddItem(Item item)
    {
        Item newItem = Instantiate(item);

        listItem.Add(newItem);
    }

    // 아이템 장착
    public void EquipItem(Item item)
    {
        equipment[(int)item.Type] = item;
    }

    // 장착 중인 장비의 총 공격력 가져오기
    public float GetEquipAvility_Attack() 
    {
        float total = 0;

        for(int i = 0; i < equipment.Length; i++)
        {
            total += equipment[i] ? equipment[i].Attack : 0;
        }

        return total;
    }

    // 장착 중인 장비의 총 체력 가져오기
    public float GetEquipAvility_Health() 
    {
        float total = 0;

        for (int i = 0; i < equipment.Length; i++)
        {
            total += equipment[i] ? equipment[i].Health : 0;
        }

        return total;
    }
}
