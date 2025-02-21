using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    public enum GameState
    {
        Title,
        MainMenu,
        Inventory,
        Store,
        Playing,
        Paused,
        GameOver
    }
    public GameState CurrentState { get; private set; }

    private void Start()
    {
        ChangeState(GameState.Title);
    }

    /// <summary>
    /// 게임 상태 변경
    /// </summary>
    /// <param name="newState">상태</param>
    public void ChangeState(GameState newState)
    {
        CurrentState = newState;

        switch (newState)
        {
            case GameState.Title:
                SceneLoader.Instance.LoadScene("TitleScene");
                break;

            case GameState.MainMenu:
                SceneLoader.Instance.LoadScene("MainScene");
                break;

            case GameState.Inventory:
                SceneLoader.Instance.LoadScene("InventoryScene");
                break;

            case GameState.Store:
                // 상점 씬 추가 필요
                break;

            case GameState.Playing:
                SceneLoader.Instance.LoadScene("PlayScene");
                break;

            case GameState.Paused:
                Time.timeScale = 0;
                // 일시정지 UI 필요
                break;

            case GameState.GameOver:
                Debug.Log("게임 오버");
                // 게임오버 UI 필요
                break;
        }
    }
}
