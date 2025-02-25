using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipSlot : MonoBehaviour
{
    public ItemType slotType;           // ������ ������ Ÿ��
    public Image itemImage;             // ������ �̹����� ǥ���� Image ������Ʈ
    public Item equippedItem;           // ���� ������ ������

    //������ ����
    public void Equip(Item item)
    {
        equippedItem = item;
        itemImage.sprite = item.ItemSprite.sprite;          // ������ ������ ����
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
