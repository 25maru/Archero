using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStartButton : MonoBehaviour
{
    [SerializeField] private GameManager.GameState targetState;
    //[SerializeField] private SelectManager.SelectState selectState;
    private Button button; // ��ư ������Ʈ

    private void Start()
    {
        if (button == null)
            button = GetComponent<Button>(); // ��ư�� �������� �ʾҴٸ� �ڵ� �Ҵ�

        if (button != null)
        {
            button.onClick.RemoveAllListeners(); // ���� �̺�Ʈ ����
            button.onClick.AddListener(() => GameManager.Instance.ChangeState(targetState));
        }
    }
}
