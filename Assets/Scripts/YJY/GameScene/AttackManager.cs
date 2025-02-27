using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackManager : MonoBehaviour
{
    [SerializeField] private float DestroyTime = 1.0f;
    [SerializeField] private int AttackDamage = 10;

    private void Start()
    {
        Invoke("DestroyThisAttack",DestroyTime);
    }

    void DestroyThisAttack()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            BaseStat targetStat = collision.gameObject.GetComponent<BaseStat>();

            targetStat.TakeDamage(AttackDamage);
        }
    }
}
