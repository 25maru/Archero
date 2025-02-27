using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStartButton : MonoBehaviour
{
    [SerializeField] private GameManager.GameState targetState;
    [SerializeField] private SelectManager.SelectState selectState;
    private Button button; // 버튼 컴포넌트
    public TiredManager tiredManager;
    bool isStart = false;

    private void Start()
    {
        if (button == null)
            button = GetComponent<Button>(); // 버튼이 설정되지 않았다면 자동 할당

        if (button != null && !isStart)
        {
            isStart = true;
            button.onClick.RemoveAllListeners(); // 기존 이벤트 제거
            button.onClick.AddListener(() => tiredManager.MinusTired());
            button.onClick.AddListener(() => Invoke("InvokeStartGame",1f));
        }
    }

    void InvokeStartGame()
    {
        PlayerPrefs.DeleteAll();

        GameManager.Instance.ChangeState(targetState);
        if (SelectManager.Instance.state == SelectManager.SelectState.Normal)
        {
            SceneLoader.Instance.LoadScene("PlayScene");
        }
        else if (SelectManager.Instance.state == SelectManager.SelectState.Tutorial)
        {
            SceneLoader.Instance.LoadScene("TutorialScene");
        }
    }
}
