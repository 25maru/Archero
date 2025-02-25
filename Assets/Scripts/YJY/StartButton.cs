using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    [SerializeField] private GameManager.GameState targetState;
    private Button button; // 버튼 컴포넌트
    [SerializeField] private float TimeLate;

    private void Start()
    {
        if (button == null)
            button = GetComponent<Button>(); // 버튼이 설정되지 않았다면 자동 할당

        if (button != null)
        {
            button.onClick.RemoveAllListeners(); // 기존 이벤트 제거
            button.onClick.AddListener(() => Invoke("InvokeOnClick", TimeLate));
        }
    }

    void InvokeOnClick()
    {
        GameManager.Instance.ChangeState(targetState);
    }
}
