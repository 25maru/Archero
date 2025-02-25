using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    [SerializeField] private GameManager.GameState targetState;
    private Button button; // ��ư ������Ʈ
    [SerializeField] private float TimeLate;

    private void Start()
    {
        if (button == null)
            button = GetComponent<Button>(); // ��ư�� �������� �ʾҴٸ� �ڵ� �Ҵ�

        if (button != null)
        {
            button.onClick.RemoveAllListeners(); // ���� �̺�Ʈ ����
            button.onClick.AddListener(() => Invoke("InvokeOnClick", TimeLate));
        }
    }

    void InvokeOnClick()
    {
        GameManager.Instance.ChangeState(targetState);
    }
}
