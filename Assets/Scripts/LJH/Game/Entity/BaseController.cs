using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public abstract class BaseController : MonoBehaviour
{
    [Header("Projectile Info")]
    [SerializeField] protected ProjectileController projectile;
    [SerializeField] protected int projectileNum = 1;
    [SerializeField] protected float projectileSpacing = 5f;
    [SerializeField] protected float attackDelay = 1.5f;

    protected Rigidbody2D rigid;
    protected SpriteRenderer spriteRender;
    protected Animator anim;
    protected PlayerStat stat;

    protected Vector2 moveDir = Vector2.zero;
    protected readonly int DirX = Animator.StringToHash("DirX");
    protected readonly int DirY = Animator.StringToHash("DirY");
    protected readonly int IsMove = Animator.StringToHash("IsMove");

    protected virtual void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRender = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        stat = GetComponent<PlayerStat>();
    }

    protected virtual void FixedUpdate()
    {
        Movement(moveDir);
    }

    protected virtual void Attack()
    {
        // ���� ����Ʈ ���� �ʿ�� �߰�
    }

    private void Movement(Vector2 direction)
    {
        direction = direction * stat.playerData.Speed;
        
        rigid.velocity = direction;

        // �ִϸ��̼� ������ �̵� ����
        if (direction.magnitude > 0)
        {
            anim.SetFloat(DirX, direction.x);
            anim.SetFloat(DirY, direction.y);

            spriteRender.flipX = direction.x < 0;
        }

        anim.SetBool(IsMove, direction.magnitude > 0);
    }
}
