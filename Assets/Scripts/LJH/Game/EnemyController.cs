using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : BaseController
{
    [SerializeField] Transform target;
    [SerializeField] private float followRange = 10f;
    [SerializeField] private float AttackRange = 5f;
    [SerializeField] private Color gizmoColor = new Color(1, 0, 0, 1f);

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

                moveDir = Vector2.zero;
                return;
            }

            moveDir = dir.normalized;
        }
    }

    private void OnDrawGizmosSelected() // �÷��̾� Ž�� ���� ������ ǥ��
    {
        Gizmos.color = gizmoColor;

        // Ž�� ���� �׸���
        Vector3 center = new Vector3(transform.position.x, transform.position.y);
        Vector3 size = new Vector3(followRange, followRange) * 2;

        Gizmos.DrawWireCube(center, size);
        
        // ���� ���� �׸���
        size = new Vector3(AttackRange, AttackRange) * 2;

        Gizmos.DrawWireSphere(center, AttackRange);
    }
}
