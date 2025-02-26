using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class SetActive : MonoBehaviour
{
    public GameObject panelObject;                   // �г� ������Ʈ
    public Item item;                                // ������ ��ü
    
    InventoryHandler inventoryHandler;

    private void OnEnable()
    {
        inventoryHandler = InventoryManager.Instance.InventoryHandler;
    }

    private void Start()
    {
        if (panelObject != null)
        {
            // �г� ������Ʈ ����
            panelObject.SetActive(false);
        }
    }

    public void TogglePanel(Item item)
    {
        if (panelObject != null)
        {
            bool isActive = !panelObject.activeSelf;    // ���� ���� ����
            panelObject.SetActive(isActive);            // �г� �ݴ� ���·� ����
        }
    }

    public void OnYesClicked()
    {
        if (item != null)
        {
            inventoryHandler.EquipItem(item);           // �������� �Ű������� ����
            Debug.Log("�������� �޾ƿԽ��ϴ�.");
            panelObject.SetActive(false);               // ���� �� �г� �ݱ�
        }
    }

    public void OnNoClicked()
    {
        panelObject.SetActive(false);                    // �г� �ݱ�
    }
}
