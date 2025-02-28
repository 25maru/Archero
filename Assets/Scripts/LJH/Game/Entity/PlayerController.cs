using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : BaseController
{
    [SerializeField] GameObject enemyPool;
    [SerializeField] float offsetAttackDis = 1f; // �߻� ���� �������� �ű�� ������

    [Header("UI Info")]
    [SerializeField] HealthUI uiHealth;
    [SerializeField] ExpUI uiExp;
    [SerializeField] LevelUpUI uiLevelUp;

    bool firstLoad = false;

    protected override void Start()
    {
        base.Start();
    }

    private void Update()
    {
        if (!firstLoad)
        {
            ChangeHealthUI();
            ChangeExpUI();

            firstLoad = true;
        }

        FindCloseEnemy();

        lastAttack += Time.deltaTime;
        // �������� �� ����
        if (moveDir.magnitude <= 0 && stat.GetAttackSpeed() < lastAttack)
        {
            Attack();
            lastAttack = 0f;
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
            if (enemy.GetComponent<BaseStat>().IsDead())
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
        ProjectileDir = closeDir.normalized;
    }

    protected override void Attack()
    {
        if (ProjectileDir == Vector3.zero)
            return;

        base.Attack();

        // �븻 ���� ���ϱ�
        Vector3 vecNormal = new Vector3(-ProjectileDir.y, ProjectileDir.x, 0); 

        for (int i = 0; i < stat.GetProjectileNum(); i++)
        {
            GameObject newProjectile = Instantiate(projectile, transform.position, Quaternion.identity);


            // ����ü ���� ������
            float Spacing = (i - (stat.GetProjectileNum() - 1) / 2) * projectileSpacing;

            // ����ü ���� ��ġ
            Vector3 createPos = transform.position + (vecNormal * Spacing) + (ProjectileDir * offsetAttackDis);

            newProjectile.GetComponent<ProjectileController>().Init(this, createPos, ProjectileDir, "Enemy");
        }
    }

    public void ChangeHealthUI()
    {
        uiHealth.UpdateHealth(stat.GetCurrentHealth(), stat.GetMaxHealth());
    }

    public void ShowLevelUpUI()
    {
        uiLevelUp.Show();
    }

    public void ChangeExpUI()
    {
        PlayerStat playerStat = (PlayerStat)stat;
        uiExp.UpdatExp(playerStat.GetCurrentExp(), playerStat.GetMaxExp(), playerStat.GetLevel());
    }
}
