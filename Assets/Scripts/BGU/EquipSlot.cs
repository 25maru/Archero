using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipSlot : MonoBehaviour
{
    [SerializeField] InventoryData invenData;
    public ItemType slotType;           // 슬롯의 아이템 타입
    public Image itemImage;             // 아이템 이미지를 표시할 Image 컴포넌트
    public Item equippedItem;           // 현재 장착된 아이템

    private void Start()
    {
        //if (invenData.equipment[(int)slotType])
        //{
        //    invenData.equipment[(int)slotType].GetSprite();
        //    itemImage.sprite = invenData.equipment[(int)slotType].SpriteItem;
        //}
    }

    //아이템 장착
    public void Equip(Item item)
    {
        equippedItem = item;
        itemImage.enabled = true;                           // 이미지 표시
    }

    // 아이템 장착 해제
    public void Unequip()
    {
        equippedItem = null;
        itemImage.sprite = null;                              // 이미지 제거
        itemImage.enabled = false;                            // 이미지 숨김
    }
}