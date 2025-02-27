using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelectMap : MonoBehaviour
{
    [SerializeField] private string SaveKey;
    public List<GameObject> PlayerPosition;
    public GameObject Player;
    public Animator PlayerAni;
    int thisStageSave = 0;

    private void Start()
    {
        if (PlayerPosition == null) Debug.Log("�������� �����ϴ�.");
        if (PlayerPrefs.HasKey(SaveKey)) //Stage�� ������ �ִٸ� �� ��ġ�� �÷��̾� �̵�
        {
            if(SaveKey == "Tutorial")
            {
                thisStageSave = PlayerPrefs.GetInt(SaveKey) / 2;
            }
            else
            {
                thisStageSave = PlayerPrefs.GetInt(SaveKey) / 10;
            }
        }
        else
        {
            thisStageSave = 1;
        }

        Init(); //�÷��̾� ��ġ ����
    }

    void Init()
    {
        Player.transform.position = PlayerPosition[thisStageSave-1].transform.position; //�÷��̾� ��ġ ����
        if(thisStageSave == 5) //������ �������� �� ��
        {
            PlayerAni.SetBool("IsClear", true); //��� ����
        }
    }
}
