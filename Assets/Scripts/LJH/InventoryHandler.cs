using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum ItemType { Weapon, Armor, Head, Shoes, Ring, Necklace, End }

public class InventoryHandler : MonoBehaviour
{
    [SerializeField] InventoryData data;
    public InventoryData Data { get { return data; } }

    private void Start()
    {
        if (data.equipment == null)
        {
            data.equipment = new Item[(int)ItemType.End];
        }
    }

    // ������ ����
    public void EquipItem(Item item)
    {
        data.equipment[(int)item.Type] = item;
    }

    // ���� ���� ����� �� ���ݷ� ��������
    public float GetEquipAvility_Attack() 
    {
        float total = 0;

        for(int i = 0; i < data.equipment.Length; i++)
        {
            total += data.equipment[i] ? data.equipment[i].Attack : 0;
        }

        return total;
    }

    // ���� ���� ����� �� ü�� ��������
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