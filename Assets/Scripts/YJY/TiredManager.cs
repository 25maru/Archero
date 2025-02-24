using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.UI;

public class TiredManager : MonoBehaviour
{
    int PlayTired;
    public List<RawImage> Tired;
    public Texture FullTired, EmptyTired;

    private void Start()
    {
        if (PlayerPrefs.HasKey("Tired"))  //�Ƿε� ������ ���ִٸ�
        {
            PlayTired = PlayerPrefs.GetInt("Tired");
        }
        else  //ó�� �ϴ� ���̶��
        {
            PlayTired = 4;
        }
        UpdateTired();
    }

    public void MinusTired()
    {
        PlayTired--;
        UpdateTired();
    }
    public void PlusTired()
    {
        PlayTired++;
        UpdateTired();
    }
    void UpdateTired()
    {
        //PlayerPrefs.SetInt("Tired", PlayTired);
        for (int i = 0; i < PlayTired; i++)
        {
            Tired[i].texture = FullTired;
        }
        for(int i = PlayTired; i < Tired.Count; i++)
        {
            Tired[i].texture = EmptyTired;
        }
    }
}
