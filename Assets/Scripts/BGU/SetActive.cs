using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class SetActive : InventoryHandler
{
    public GameObject panelObject;                   // 패널 오브젝트
    public Item item;                                // 아이템 객체

    public void Start()
    {
        if (panelObject != null)
        {
            // 패넬 오브젝트 숨김
            panelObject.SetActive(false);
        }
    }

    public void TogglePanel()
    {
        if (panelObject != null)
        {
            bool isActive = !panelObject.activeSelf;    // 현재 상태 반전
            panelObject.SetActive(isActive);            // 패널 반대 상태로 설정
        }
    }

    public void OnYesClicked()
    {
        if (item != null)
        {
            EquipItem(item);                            // 아이템을 매개변수로 전달
            Debug.Log("아이템을 받아왔습니다.");
            panelObject.SetActive(false);               // 장착 후 패널 닫기
        }
    }

    public void OnNoClicked()
    {
        panelObject.SetActive(false);                    // 패널 닫기
    }
}
