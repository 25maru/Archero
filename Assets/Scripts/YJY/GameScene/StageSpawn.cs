using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSpawn : MonoBehaviour
{
    public List<GameObject> Stages;
    public Transform Enemypool;

    public List<GameObject> RandomStages;
    public string SaveKey;
    int stage;
    GameObject thisStage;
    GameManager gameManager;

    private void Awake()
    {
        gameManager = GameManager.Instance;

        if (PlayerPrefs.HasKey(SaveKey+"Stage"))
        {
            stage = PlayerPrefs.GetInt(SaveKey + "Stage");
        }
        else
        {
            stage = 1;
        }
    }

    private void Start()
    {
        if (Stages[stage - 1] != null)
        {
            thisStage = Stages[stage - 1];
        }
        else
        {
            thisStage = RandomStages[Random.Range(0, RandomStages.Count)];
        }
        Instantiate(thisStage, Enemypool);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (stage % 10 == 0) //10씩일 시
            {
                PlayerPrefs.SetInt(SaveKey, stage); //스테이지 저장

                if (SaveKey == "Tutorial") //10에서 튜토리얼 종료
                {
                    gameManager.ChangeState(GameManager.GameState.MainMenu);
                    return;
                }
                if(stage == 50)
                {
                    gameManager.ChangeState(GameManager.GameState.MainMenu);
                    return;
                }
            }

            PlayerPrefs.SetInt(SaveKey + "Stage", stage+1);

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
