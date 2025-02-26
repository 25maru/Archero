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
        moveDir = Vector2.zero; // 방향 초기화
        Vector3 dir = target.transform.position - transform.position;
        float distance = dir.magnitude;
        
        if (distance <= followRange) // 타겟이 탐색범위보다 안에 있을 경우
        {
            if (distance < AttackRange) // 타겟이 공격범위 안에 있을 경우
            {
                // 공격
                Attack();

                moveDir = Vector2.zero;
                return;
            }

            moveDir = dir.normalized;
        }
    }

    private void OnDrawGizmosSelected() // 플레이어 탐색 범위 기즈모로 표시
    {
        Vector3 center = new Vector3(transform.position.x, transform.position.y);

        // 탐색 범위 그리기
        Gizmos.color = gizmoFollowColor;
        Gizmos.DrawWireSphere(center, followRange);

        // 공격 범위 그리기
        Gizmos.color = gizmoAttackwColor;
        Gizmos.DrawWireSphere(center, AttackRange);
    }
}
