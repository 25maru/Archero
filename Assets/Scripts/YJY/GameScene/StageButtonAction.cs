using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageButtonAction : MonoBehaviour
{
    public NormalStageController controller;
    public GameObject UpButton;
    public GameObject DownButton;

    [SerializeField] private bool IsThisRed = true;

    private void Start()
    {
        if (IsThisRed) //빨간 버튼일 시
        {
            if (controller.isRed)//빨간 트리거일 시
            {
                DownThisButton();
            }
            else
            {
                UpThisButton();
            }
        }
        else
        {
            if (controller.isRed)//빨간 트리거일 시
            {
                UpThisButton();
            }
            else
            {
                DownThisButton();
            }
        }
    }

    public void ChangeState()
    {
        controller.ChangeisRed();
    }
    public void DownThisButton()
    {
        DownButton.SetActive(true);
        UpButton.SetActive(false); //빨간 버튼을 누른 상태로
    }
    public void UpThisButton()
    {
        DownButton.SetActive(false);
        UpButton.SetActive(true); //빨간 버튼을 누른 상태로
    }
}
