using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private ParticleSystem impactParticleSystem;

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
        CreatePaticle(transform.position);
            
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

    public void CreatePaticle(Vector3 position)
    {
        // 지정된 위치에 파티클 생성
        ParticleSystem particleInstance = Instantiate(impactParticleSystem, position, Quaternion.identity);

        // 파티클 갯수 설정
        ParticleSystem.EmissionModule em = particleInstance.emission;
        em.SetBurst(0, new ParticleSystem.Burst(0, Mathf.Ceil(12.5f)));

        // 파티클 속도 설정
        ParticleSystem.MainModule mainModule = particleInstance.main;
        mainModule.startSpeedMultiplier = 10f;

        particleInstance.Play();
    }
}
