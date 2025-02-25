using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : BaseController
{
    [SerializeField] GameObject enemyPool;

    float lastAttack = float.MaxValue;
    Vector3 attackDir = Vector3.zero;

    private void Update()
    {
        FindCloseEnemy();

        lastAttack += Time.deltaTime;
        // 멈춰있을 때 공격
        if (moveDir.magnitude <= 0 && attackDelay < lastAttack)
        {
            Attack();
            lastAttack = 0;
        }
    }

    void OnMove(InputValue inputValue)
    {
        moveDir = inputValue.Get<Vector2>();
        moveDir = moveDir.normalized;
    }

    void FindCloseEnemy()
    {
        BaseController[] enemies = enemyPool.GetComponentsInChildren<BaseController>();
        Vector3 closeDir = Vector3.zero;

        foreach (BaseController enemy in enemies)
        {
            // 적이 죽었다면 넘김
            if (enemy.GetComponent<PlayerStat>().playerData.IsDead)
                continue;

            // 플레이어와 적의 사이 거리를 구함
            Vector3 tempDir = (enemy.transform.position - transform.position);

            if (closeDir.magnitude == 0)
            {
                closeDir = tempDir;
            }
            else if (closeDir.magnitude > tempDir.magnitude)
            {
                closeDir = tempDir;
            }
        }

        // 가까운 적의 방향 정규화
        attackDir = closeDir.normalized;
    }

    protected override void Attack()
    {
        if (attackDir == Vector3.zero)
            return;

        base.Attack();

        // 노말 벡터 구하기
        Vector3 vecNormal = new Vector3(-attackDir.y, attackDir.x, 0); 

        for (int i = 0; i < projectileNum; i++)
        {
            ProjectileController newProjectile = Instantiate(projectile, transform.position, Quaternion.identity);

            // 투사체 간격 오프셋
            float offset = (i - (projectileNum - 1) / 2) * projectileSpacing;

            // 투사체 생성 위치
            Vector3 createPos = transform.position + (vecNormal * offset);

            // 투사체 방향
            //Vector3 dir = attackDir + (vecNormalAttack * offset);
            //dir = dir.normalized;

            newProjectile.Init(this, createPos, attackDir, "Enemy");
        }
    }
}
