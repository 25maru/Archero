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
        // ����ü �̵�
        rigid.velocity = dir * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(targetTag)) // ��ǥ���� �浹���� ���
        {
            BaseStat sourceStat = sourceObject.GetComponent<BaseStat>();
            BaseStat targetStat = collision.gameObject.GetComponent<BaseStat>();

            targetStat.TakeDamage((int)sourceStat.GetAttackDamage());

            // ȭ�� ���� ó��
            if (pierceNum <= 0) 
            {
                DestroyProjectile();
            }
            else
            {
                pierceNum--;
            }
        }
        //// ���� �浹 ���� ���
        else if (collision.gameObject.CompareTag(wallTag))
        {
            DestroyProjectile();

            //if (reflectionNum <= 0)
            //{
            //    DestroyProjectile();
            //}
            //else
            //{
            //    // ȭ���� �ݻ簢 ���ϱ�
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
        // ��ƼŬ ���� �߰� ����

            
        Destroy(gameObject);
    }
        
    public void Init(BaseController source, Vector3 position, Vector3 dir, string targetTag)
    {
        // ����ü�� �߻��� ������Ʈ
        sourceObject = source;

        // ����ü �ݻ�, ���� ��
        pierceNum = source.GetComponent<BaseStat>().GetProjectilePierce();
        reflectionNum = source.GetComponent<BaseStat>().GetMaxProjectileReflection();

        // ����ü ��ġ ����
        transform.position = position;
        transform.rotation = Quaternion.FromToRotation(Vector3.right, dir.normalized);

        this.dir = dir;

        // ��ǥ���� �±�
        this.targetTag = targetTag;
    }
}
