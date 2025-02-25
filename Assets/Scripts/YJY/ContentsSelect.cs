using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContentsSelect : MonoBehaviour
{
    [SerializeField] private SelectManager.SelectState targetState;
    private Button button; // ��ư ������Ʈ

    private void Start()
    {
        button = GetComponent<Button>();

        if (button != null)
        {
            button.onClick.RemoveAllListeners(); // ���� �̺�Ʈ ����
            button.onClick.AddListener(() => SelectManager.Instance.ChangeState(targetState));
        }
    }
}
