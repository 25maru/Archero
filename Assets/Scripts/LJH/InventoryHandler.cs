using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum ItemType { Weapon, Armor, gloves, Shoes, End }

public class InventoryHandler : MonoBehaviour
{
    [SerializeField] InventoryData data;

    private void Start()
    {
        data.equipment = new Item[(int)ItemType.End];
    }

    // 인벤토리에 아이템 추가
    public void AddItem(Item item)
    {
        Item newItem = Instantiate(item);

        data.listItem.Add(newItem);
    }

    // 아이템 장착
    public void EquipItem(Item item)
    {
        data.equipment[(int)item.Type] = item;
    }

    // 장착 중인 장비의 총 공격력 가져오기
    public float GetEquipAvility_Attack() 
    {
        float total = 0;

        for(int i = 0; i < data.equipment.Length; i++)
        {
            total += data.equipment[i] ? data.equipment[i].Attack : 0;
        }

        return total;
    }

    // 장착 중인 장비의 총 체력 가져오기
    public float GetEquipAvility_Health() 
    {
        float total = 0;

        for (int i = 0; i < data.equipment.Length; i++)
        {
            total += data.equipment[i] ? data.equipment[i].Health : 0;
        }

        return total;
    }
}

[CreateAssetMenu(fileName = "InventoryHandler", menuName = "Game Data/Inventory Data")]
public class InventoryData : ScriptableObject
{
    public List<Item> listItem;
    public Item[] equipment;
}
