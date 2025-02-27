using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public abstract class BaseController : MonoBehaviour
{
    [Header("Projectile Info")]
    [SerializeField] protected ProjectileController projectile;
    [SerializeField] protected float projectileSpacing = 0.2f;

    protected Rigidbody2D rigid;
    protected SpriteRenderer spriteRender;
    protected Animator anim;
    protected BaseStat stat;

    protected Vector2 moveDir = Vector2.zero;
    protected readonly int DirX = Animator.StringToHash("DirX");
    protected readonly int DirY = Animator.StringToHash("DirY");
    protected readonly int IsMove = Animator.StringToHash("IsMove");

    protected float lastAttack = float.MaxValue;
    protected Vector3 ProjectileDir = Vector3.zero;


    protected virtual void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRender = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        stat = GetComponent<BaseStat>();
    }

    protected virtual void FixedUpdate()
    {
        Movement(moveDir);
    }

    protected virtual void Attack()
    {
        // 추후 이펙트 사운드 필요시 추가
    }

    private void Movement(Vector2 direction)
    {
        direction = direction * stat.GetSpeed();
        
        rigid.velocity = direction;

        // 애니메이션 마지막 이동 방향
        if (direction.magnitude > 0)
        {
            anim.SetFloat(DirX, direction.x);
            anim.SetFloat(DirY, direction.y);

            spriteRender.flipX = direction.x < 0;
        }

        anim.SetBool(IsMove, direction.magnitude > 0);
    }
}
