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

    // �κ��丮�� ������ �߰�
    public void AddItem(Item item)
    {
        Item newItem = Instantiate(item);

        listItem.Add(newItem);
    }

    // ������ ����
    public void EquipItem(Item item)
    {
        equipment[(int)item.Type] = item;
    }

    // ���� ���� ����� �� ���ݷ� ��������
    public float GetEquipAvility_Attack() 
    {
        float total = 0;

        for(int i = 0; i < equipment.Length; i++)
        {
            total += equipment[i] ? equipment[i].Attack : 0;
        }

        return total;
    }

    // ���� ���� ����� �� ü�� ��������
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
