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
    [SerializeField] float offsetAttackDis = 1f; // �߻� ���� �������� �ű�� ������

    PlayerController target;
    public Gate gate;           // gate ������Ʈ ����

    public static List<EnemyController> enemies = new List<EnemyController>();      // �� ����Ʈ ������ ����
    
    protected override void Start()
    {
        base.Start();

        target = PlaySceneManager.Instance.player;
        enemies.Add(this);      // ���� ������ �� ����Ʈ �߰�
    }

    private void Update()
    {
        lastAttack += Time.deltaTime;

        FindTartget();

        // �� ����ߴ��� Ȯ�� �� ��� �� ��� �� ����Ʈ ����
        if (stat.IsDead())
        {
            enemies.Remove(this);   // �� ����� ����Ʈ ����

            if(enemies.Count == 0 && gate != null)      // ��� ���� ����߰� ����Ʈ ����Ǿ� ���� ��
            {
                gate.Open();
            }
        }
    }

    private void FindTartget()
    {
        if (target.GetComponent<BaseStat>().IsDead())
            return;

        moveDir = Vector2.zero; // ���� �ʱ�ȭ
        Vector3 dir = target.transform.position - transform.position;
        float distance = dir.magnitude;
        
        if (distance <= followRange) // Ÿ���� Ž���������� �ȿ� ���� ���
        {
            if (distance < AttackRange) // Ÿ���� ���ݹ��� �ȿ� ���� ���
            {
                // ����
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
            // ����ü �̵� ����
            ProjectileDir = (target.transform.position - transform.position).normalized;

            GameObject newProjectile = Instantiate(projectile, transform.position, Quaternion.identity);

            // ����ü ���� ��ġ
            Vector3 createPos = transform.position + (ProjectileDir * offsetAttackDis);

            newProjectile.GetComponent<ProjectileController>().Init(this, createPos, ProjectileDir, "Player");
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
