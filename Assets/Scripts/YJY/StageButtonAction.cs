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
        if (IsThisRed) //���� ��ư�� ��
        {
            if (controller.isRed)//���� Ʈ������ ��
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
            if (controller.isRed)//���� Ʈ������ ��
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
        UpButton.SetActive(false); //���� ��ư�� ���� ���·�
    }
    public void UpThisButton()
    {
        DownButton.SetActive(false);
        UpButton.SetActive(true); //���� ��ư�� ���� ���·�
    }
}
