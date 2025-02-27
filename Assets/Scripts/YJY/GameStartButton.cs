using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStartButton : MonoBehaviour
{
    [SerializeField] private GameManager.GameState targetState;
    [SerializeField] private SelectManager.SelectState selectState;
    private Button button; // ��ư ������Ʈ
    public TiredManager tiredManager;
    bool isStart = false;

    private void Start()
    {
        if (button == null)
            button = GetComponent<Button>(); // ��ư�� �������� �ʾҴٸ� �ڵ� �Ҵ�

        if (button != null && !isStart)
        {
            isStart = true;
            button.onClick.RemoveAllListeners(); // ���� �̺�Ʈ ����
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
