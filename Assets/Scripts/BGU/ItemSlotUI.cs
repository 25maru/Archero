using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlotUI : MonoBehaviour
{
    public Image itemImage;             // ������ �̹��� ǥ���� Image ������Ʈ
    public Item item;                   // ���Կ� ǥ���� ������

    public void SetItem(Item item)
    {
        this.item = item;
        itemImage.sprite = item.ItemSprite.sprite;      // ������ �̹��� ����
    }
    
    public void OnItemClicked()
    {
        SetActive setActiveScript = FindObjectOfType<SetActive>();

        if(setActiveScript != null)
        {
            setActiveScript.item = item;                // item ������ ������ �Ҵ�
            setActiveScript.TogglePanel();              // �г� Ȱ��ȭ
            Debug.Log("����");
        }
    }
}
