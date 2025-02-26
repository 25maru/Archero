using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipSlot : MonoBehaviour
{
    [SerializeField] InventoryData invenData;
    public ItemType slotType;           // ������ ������ Ÿ��
    public Image itemImage;             // ������ �̹����� ǥ���� Image ������Ʈ
    public Item equippedItem;           // ���� ������ ������

    private void Start()
    {
        //if (invenData.equipment[(int)slotType])
        //{
        //    invenData.equipment[(int)slotType].GetSprite();
        //    itemImage.sprite = invenData.equipment[(int)slotType].SpriteItem;
        //}
    }

    //������ ����
    public void Equip(Item item)
    {
        equippedItem = item;
        itemImage.enabled = true;                           // �̹��� ǥ��
    }

    // ������ ���� ����
    public void Unequip()
    {
        equippedItem = null;
        itemImage.sprite = null;                              // �̹��� ����
        itemImage.enabled = false;                            // �̹��� ����
    }
}