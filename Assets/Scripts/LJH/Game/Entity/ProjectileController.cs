using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    [SerializeField] private float speed;

    private Rigidbody2D rigid;

    private BaseController sourceObject;
    private string targetTag;
    private string Wall;
    private Vector3 dir;

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        // 투사체 이동
        rigid.velocity = dir * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(targetTag)) // 목표물과 충돌했을 경우
        {
            PlayerStat sourceStat = sourceObject.GetComponent<PlayerStat>();
            PlayerStat targetStat = collision.gameObject.GetComponent<PlayerStat>();

            targetStat.TakeDamage(sourceStat.playerData.AttackDamage);

            DestroyProjectile();
        }
        //// 벽과 충돌 했을 경우
        else if (collision.gameObject.CompareTag(Wall))
        {
            DestroyProjectile();
        }
    }

    private void DestroyProjectile()
    {
        // 파티클 생성 추가 예정

            
        Destroy(gameObject);
    }

    public void Init(BaseController source, Vector3 position, Vector3 dir, string targetTag, string Wall)
    {
        // 투사체를 발사한 오브젝트
        sourceObject = source;

        transform.position = position;
        transform.rotation = Quaternion.FromToRotation(Vector3.right, dir.normalized);

        this.dir = dir;

        // 목표물의 태그
        this.targetTag = targetTag;
        this.Wall = Wall;
    }
}
