using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    bool isCoroutine = false;
    float timeDead;

    public static List<EnemyController> enemies = new List<EnemyController>();      // 적 리스트 저장할 변수
    
    protected override void Start()
    {
        base.Start();

        target = PlaySceneManager.Instance.player;
        enemies.Add(this);      // 적이 생성될 때 리스트 추가
    }

    private void Update()
    {
        if (stat.IsDead())
        {
            Gate gate = PlaySceneManager.Instance.gate;

            // 적 사망했는지 확인 후 모든 적 사망 시 게이트 오픈
            enemies.Remove(this);   // 적 사망시 리스트 제거

            if (enemies.Count == 0 && gate != null)      // 모든 적이 사망했고 게이트 연결되어 있을 시
            {
                gate.Open();
            }

            if (!isCoroutine)
            {
                // 사망 모션 구현
                isCoroutine = true;
                anim.SetBool("IsDead", true);
                StartCoroutine(FadeoutAnim());

                // 경험치 구슬 생성
                int rand = Random.Range(1, 5);
                for (int i = 0; i < rand; i++)
                {
                    GameObject newInstance = Instantiate(PlaySceneManager.Instance.expOrb, transform.position, Quaternion.identity);
                    newInstance.GetComponent<ExpOrbController>().Init(stat.GetGold(), stat.GetCurrentExp());
                }
            }

            return;
        }

        lastAttack += Time.deltaTime;
        FindTartget();
    }

    private IEnumerator FadeoutAnim()
    {
        while (true)
        {
            timeDead += Time.deltaTime / 5f;

            Color color = spriteRender.color;
            color.a = Mathf.Lerp(color.a, 0, timeDead);
            spriteRender.color = color;

            if (color.a <= 0)
                break;

            yield return null;
        }

        Destroy(gameObject);
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
