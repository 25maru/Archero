using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStartButton : MonoBehaviour
{
    [SerializeField] private GameManager.GameState targetState;
    //[SerializeField] private SelectManager.SelectState selectState;
    private Button button; // 버튼 컴포넌트

    private void Start()
    {
        if (button == null)
            button = GetComponent<Button>(); // 버튼이 설정되지 않았다면 자동 할당

        if (button != null)
        {
            button.onClick.RemoveAllListeners(); // 기존 이벤트 제거
            button.onClick.AddListener(() => GameManager.Instance.ChangeState(targetState));
        }
    }
}
