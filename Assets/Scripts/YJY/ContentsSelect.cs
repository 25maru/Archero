using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContentsSelect : MonoBehaviour
{
    [SerializeField] private SelectManager.SelectState targetState;
    private Button button; // 버튼 컴포넌트

    private void Start()
    {
        button = GetComponent<Button>();

        if (button != null)
        {
            button.onClick.RemoveAllListeners(); // 기존 이벤트 제거
            button.onClick.AddListener(() => SelectManager.Instance.ChangeState(targetState));
        }
    }
}
