using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : BaseController
{
    [Header("Range Info")]
    [SerializeField] private float followRange = 10f;
    [SerializeField] private float AttackRange = 5f;
    [SerializeField] private Color gizmoFollowColor = new Color(1, 0, 0, 1f);
    [SerializeField] private Color gizmoAttackwColor = new Color(0, 0, 1, 1f);
    [SerializeField] float offsetAttackDis = 1f; // 발사 방향 앞쪽으로 옮기는 오프셋

    PlayerController target;

    protected override void Start()
    {
        base.Start();

        target = FindAnyObjectByType<PlayerController>();
    }

    private void Update()
    {
        lastAttack += Time.deltaTime;

        FindTartget();
    }

    private void FindTartget()
    {
        if (target.GetComponent<BaseStat>().IsDead())
            return;

        moveDir = Vector2.zero; // 방향 초기화
        Vector3 dir = target.transform.position - transform.position;
        float distance = dir.magnitude;
        
        if (distance <= followRange) // 타겟이 탐색범위보다 안에 있을 경우
        {
            if (distance < AttackRange) // 타겟이 공격범위 안에 있을 경우
            {
                // 공격
                if (stat.GetAttackSpeed() < lastAttack)
                {
                    Attack();
                    lastAttack = 0f;
                }

                moveDir = Vector2.zero;
                return;
            }

            moveDir = dir.normalized;
        }
    }

    protected override void Attack()
    {
        base.Attack();

        {
            // 투사체 이동 방향
            ProjectileDir = (target.transform.position - transform.position).normalized;

            GameObject newProjectile = Instantiate(projectile, transform.position, Quaternion.identity);

            // 투사체 생성 위치
            Vector3 createPos = transform.position + (ProjectileDir * offsetAttackDis);

            newProjectile.GetComponent<ProjectileController>().Init(this, createPos, ProjectileDir, "Player");
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
