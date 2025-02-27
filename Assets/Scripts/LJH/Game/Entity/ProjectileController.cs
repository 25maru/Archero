using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    [SerializeField] private float speed;

    private Rigidbody2D rigid;

    private BaseController sourceObject;

    private Vector3 dir;

    private string targetTag;
    private const string wallTag = "Wall";

    private int pierceNum;
    private int reflectionNum;

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
            BaseStat sourceStat = sourceObject.GetComponent<BaseStat>();
            BaseStat targetStat = collision.gameObject.GetComponent<BaseStat>();

            targetStat.TakeDamage((int)sourceStat.GetAttackDamage());

            // 화살 관통 처리
            if (pierceNum <= 0) 
            {
                DestroyProjectile();
            }
            else
            {
                pierceNum--;
            }
        }
        //// 벽과 충돌 했을 경우
        else if (collision.gameObject.CompareTag(wallTag))
        {
            DestroyProjectile();

            //if (reflectionNum <= 0)
            //{
            //    DestroyProjectile();
            //}
            //else
            //{
            //    // 화살의 반사각 구하기
            //    ContactPoint2D[] contacts = new ContactPoint2D[1];
            //    collision.GetContacts(contacts);
            //    Vector3 vecNormal = contacts[0].normal;

            //    dir = Vector3.Reflect(dir.normalized, vecNormal);

            //    reflectionNum--;
            //}
        }
    }

    private void DestroyProjectile()
    {
        // 파티클 생성 추가 예정

            
        Destroy(gameObject);
    }
        
    public void Init(BaseController source, Vector3 position, Vector3 dir, string targetTag)
    {
        // 투사체를 발사한 오브젝트
        sourceObject = source;

        // 투사체 반사, 관통 수
        pierceNum = source.GetComponent<BaseStat>().GetProjectilePierce();
        reflectionNum = source.GetComponent<BaseStat>().GetMaxProjectileReflection();

        // 투사체 위치 각도
        transform.position = position;
        transform.rotation = Quaternion.FromToRotation(Vector3.right, dir.normalized);

        this.dir = dir;

        // 목표물의 태그
        this.targetTag = targetTag;
    }
}
