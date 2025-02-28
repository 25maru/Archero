using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSpawn : MonoBehaviour
{
    public List<GameObject> Stages;
    public Transform Enemypool;

    public List<GameObject> RandomStages;
    public string SaveKey;

    public TextMeshProUGUI Floor;

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

        Floor.text = "Floor : " + stage.ToString("00");
    }

    private void Start()
    {
        int now = stage % 10;
        if (now == 0) { now = 10; }

        if (Stages[now - 1] != null)
        {
            thisStage = Stages[now - 1];
        }
        else
        {
            thisStage = RandomStages[Random.Range(0, RandomStages.Count)];
        }
        Instantiate(thisStage, Enemypool);

        if (stage == 1) // ù Ʃ�丮�� �� �÷��̾� ������ �ʱ�ȭ
        {
            PlayerStat stat = PlaySceneManager.Instance.player.GetComponent<PlayerStat>(); // �÷��̾� �������� �޾ƿ���
            stat.InitGameData(); // ���� ������ �ʱ�ȭ
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (stage % 10 == 0) //10���� ��
            {
                PlayerPrefs.SetInt(SaveKey, stage); //�������� ����
                PlayerStat stat = PlaySceneManager.Instance.player.GetComponent<PlayerStat>(); // �÷��̾� �������� �޾ƿ���

                if (SaveKey == "Tutorial") //10���� Ʃ�丮�� ����
                {
                    gameManager.ChangeState(GameManager.GameState.MainMenu);

                    stat.InitGameData(); // ���� ������ �ʱ�ȭ
                    return;
                }
                if(stage == 50)
                {
                    gameManager.ChangeState(GameManager.GameState.MainMenu);

                    stat.InitGameData(); // ���� ������ �ʱ�ȭ
                    return;
                }
            }

            PlayerPrefs.SetInt(SaveKey + "Stage", stage+1);

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
