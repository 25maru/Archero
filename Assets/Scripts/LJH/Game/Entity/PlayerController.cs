using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : BaseController
{
    [SerializeField] GameObject enemyPool;
    [SerializeField] float offsetAttackDis = 1f; // 발사 방향 앞쪽으로 옮기는 오프셋

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
        // 멈춰있을 때 공격
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
            // 적이 죽었다면 넘김
            if (enemy.GetComponent<BaseStat>().IsDead())
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
        ProjectileDir = closeDir.normalized;
    }

    protected override void Attack()
    {
        if (ProjectileDir == Vector3.zero)
            return;

        base.Attack();

        // 노말 벡터 구하기
        Vector3 vecNormal = new Vector3(-ProjectileDir.y, ProjectileDir.x, 0); 

        for (int i = 0; i < stat.GetProjectileNum(); i++)
        {
            GameObject newProjectile = Instantiate(projectile, transform.position, Quaternion.identity);


            // 투사체 간격 오프셋
            float Spacing = (i - (stat.GetProjectileNum() - 1) / 2) * projectileSpacing;

            // 투사체 생성 위치
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
