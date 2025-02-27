using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsPlayerClose : MonoBehaviour
{
    public GameObject Code;

    private void Start()
    {
        Code.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) // 플레이어 입장 시
        {
            Code.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) // 플레이어 퇴장 시
        {
            Code.SetActive(false);
        }
    }
}
