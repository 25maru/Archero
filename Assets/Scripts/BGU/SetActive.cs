using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class SetActive : MonoBehaviour
{
    [SerializeField] private AudioClip equipClip;

    Item item;                                // ������ ��ü
    
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
        gameObject.SetActive(true);     // �г� �ݴ� ���·� ����
    }

    public void OnYesClicked()
    {
        if (equipClip != null)
            AudioSource.PlayClipAtPoint(equipClip, Vector3.zero);

        Item temp = InventoryManager.Instance.InventoryHandler.Data.listItem[item.itemIdx];

        inventoryHandler.EquipItem(temp); // �������� �Ű������� ����
        InventoryManager.Instance.InventoryUI.UpdateEquipSlot(item.Type, item.GetItemSprite()); // ���� UI ������Ʈ
        InventoryManager.Instance.InventoryUI.UpdateUIFromPlayerStat(); // �÷��̾� ���� UI ������Ʈ

        gameObject.SetActive(false); // ���� �� �г� �ݱ�
        item = null;
    }

    public void OnNoClicked()
    {
        gameObject.SetActive(false);                    // �г� �ݱ�
        item = null;
    }
}
