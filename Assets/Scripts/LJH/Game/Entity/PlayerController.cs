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
        // �������� �� ����
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
            // ���� �׾��ٸ� �ѱ�
            if (enemy.GetComponent<PlayerStat>().playerData.IsDead)
                continue;

            // �÷��̾�� ���� ���� �Ÿ��� ����
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

        // ����� ���� ���� ����ȭ
        attackDir = closeDir.normalized;
    }

    protected override void Attack()
    {
        if (attackDir == Vector3.zero)
            return;

        base.Attack();

        // �븻 ���� ���ϱ�
        Vector3 vecNormal = new Vector3(-attackDir.y, attackDir.x, 0); 

        for (int i = 0; i < projectileNum; i++)
        {
            ProjectileController newProjectile = Instantiate(projectile, transform.position, Quaternion.identity);

            // ����ü ���� ������
            float offset = (i - (projectileNum - 1) / 2) * projectileSpacing;

            // ����ü ���� ��ġ
            Vector3 createPos = transform.position + (vecNormal * offset);

            // ����ü ����
            //Vector3 dir = attackDir + (vecNormalAttack * offset);
            //dir = dir.normalized;

            newProjectile.Init(this, createPos, attackDir, "Enemy");
        }
    }
}
