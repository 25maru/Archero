using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class SetActive : MonoBehaviour
{
    public GameObject panelObject;                   // �г� ������Ʈ

    public void Start()
    {
        if(panelObject != null)
        {
            // �г� ������Ʈ ����
            panelObject.SetActive(false);
        }
    }

    public void TogglePanel()
    {
        if (panelObject != null)
        {
            bool isActive = !panelObject.activeSelf;    // ���� ���� ����
            panelObject.SetActive(isActive);            // �г� �ݴ� ���·� ����
        }
    }

    public void OnYesClicked()
    {
        Debug.Log("YES ��ư Ŭ��");
    }

    public void OnNoClicked()
    {
        panelObject.SetActive(false);                    // �г� �ݱ�
    }
}
