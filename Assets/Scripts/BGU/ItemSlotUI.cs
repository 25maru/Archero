using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlotUI : MonoBehaviour
{
    public Image itemImage;             // 아이템 이미지 표시할 Image 컴포넌트
    public Item item;                   // 슬롯에 표시할 아이템

    public void SetItem(Item item)
    {
        this.item = item;
        itemImage.sprite = item.ItemSprite.sprite;      // 아이템 이미지 설정
    }
    
    public void OnItemClicked()
    {
        SetActive setActiveScript = FindObjectOfType<SetActive>();

        if(setActiveScript != null)
        {
            setActiveScript.item = item;                // item 변수에 아이템 할당
            setActiveScript.TogglePanel();              // 패널 활성화
            Debug.Log("장착");
        }
    }
}
