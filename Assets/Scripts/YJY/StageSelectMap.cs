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
        if (PlayerPosition == null) Debug.Log("포지션이 없습니다.");
        if (PlayerPrefs.HasKey(SaveKey)) //Stage가 정보가 있다면 그 위치로 플레이어 이동
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

        Init(); //플레이어 위치 생성
    }

    void Init()
    {
        Player.transform.position = PlayerPosition[thisStageSave-1].transform.position; //플레이어 위치 변경
        if(thisStageSave == 5) //마지막 스테이지 일 시
        {
            PlayerAni.SetBool("IsClear", true); //모션 변경
        }
    }
}
