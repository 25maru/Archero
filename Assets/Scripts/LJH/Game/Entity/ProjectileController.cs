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
        // ����ü �̵�
        rigid.velocity = dir * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(targetTag)) // ��ǥ���� �浹���� ���
        {
            PlayerStat sourceStat = sourceObject.GetComponent<PlayerStat>();
            PlayerStat targetStat = collision.gameObject.GetComponent<PlayerStat>();

            targetStat.TakeDamage(sourceStat.playerData.AttackDamage);

            DestroyProjectile();
        }
        //// ���� �浹 ���� ���
        else if (collision.gameObject.CompareTag(Wall))
        {
            DestroyProjectile();
        }
    }

    private void DestroyProjectile()
    {
        // ��ƼŬ ���� �߰� ����

            
        Destroy(gameObject);
    }

    public void Init(BaseController source, Vector3 position, Vector3 dir, string targetTag, string Wall)
    {
        // ����ü�� �߻��� ������Ʈ
        sourceObject = source;

        transform.position = position;
        transform.rotation = Quaternion.FromToRotation(Vector3.right, dir.normalized);

        this.dir = dir;

        // ��ǥ���� �±�
        this.targetTag = targetTag;
        this.Wall = Wall;
    }
}
