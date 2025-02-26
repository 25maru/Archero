using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class SetActive : MonoBehaviour
{
    Item item;                                // 아이템 객체
    
    InventoryHandler inventoryHandler;

    Button btnYes;
    Button btnNo;

    private void Awake()
    {
        btnYes = GetComponentsInChildren<Button>()[0];
        btnNo = GetComponentsInChildren<Button>()[1];

        btnYes.onClick.AddListener(OnYesClicked);
        btnNo.onClick.AddListener(OnNoClicked);

        inventoryHandler = InventoryManager.Instance.InventoryHandler;
    }
   
    public void TogglePanel(GameObject item)
    {
        this.item = item.GetComponent<Item>();
        gameObject.SetActive(true);     // 패널 반대 상태로 설정
    }

    public void OnYesClicked()
    {
        Item temp = InventoryManager.Instance.InventoryHandler.Data.listItem[item.itemIdx];

        inventoryHandler.EquipItem(temp);                                   // 아이템을 매개변수로 전달
        InventoryManager.Instance.InventoryUI.UpdateEquipSlot(item.Type, item.GetItemSprite());   // 장착 UI 업데이트

        gameObject.SetActive(false);                                        // 장착 후 패널 닫기
        item = null;
    }

    public void OnNoClicked()
    {
        gameObject.SetActive(false);                    // 패널 닫기
        item = null;
    }
}
