using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : BaseController
{
    [SerializeField] Transform target;

    [Header("Range Info")]
    [SerializeField] private float followRange = 10f;
    [SerializeField] private float AttackRange = 5f;
    [SerializeField] private Color gizmoFollowColor = new Color(1, 0, 0, 1f);
    [SerializeField] private Color gizmoAttackwColor = new Color(0, 0, 1, 1f);

    private void Update()
    {
        FindTartget();
    }

    private void FindTartget()
    {
        moveDir = Vector2.zero; // ���� �ʱ�ȭ
        Vector3 dir = target.transform.position - transform.position;
        float distance = dir.magnitude;
        
        if (distance <= followRange) // Ÿ���� Ž���������� �ȿ� ���� ���
        {
            if (distance < AttackRange) // Ÿ���� ���ݹ��� �ȿ� ���� ���
            {
                // ����
                Attack();

                moveDir = Vector2.zero;
                return;
            }

            moveDir = dir.normalized;
        }
    }

    private void OnDrawGizmosSelected() // �÷��̾� Ž�� ���� ������ ǥ��
    {
        Vector3 center = new Vector3(transform.position.x, transform.position.y);

        // Ž�� ���� �׸���
        Gizmos.color = gizmoFollowColor;
        Gizmos.DrawWireSphere(center, followRange);

        // ���� ���� �׸���
        Gizmos.color = gizmoAttackwColor;
        Gizmos.DrawWireSphere(center, AttackRange);
    }
}
