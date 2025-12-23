using UnityEngine;

public class directionalAttack : MonoBehaviour
{
    [Header("Attack Settings")]
    public float attackRange = 1f;
    public float attackCooldown = 1f;
    public LayerMask enemyLayer;

    private float lastAttackTime;
    private Transform target;
    private SpriteRenderer sr;
    private Animator anim;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        FindTarget();

        if (target == null)
        {
            Idle();
            return;
        }

        FaceTarget();

        if (Time.time >= lastAttackTime + attackCooldown)
        {
            Attack();
            lastAttackTime = Time.time;
        }
    }

    void FindTarget()
    {
        Collider2D enemy = Physics2D.OverlapCircle(
            transform.position,
            attackRange,
            enemyLayer
        );

        target = enemy ? enemy.transform : null;
    }

    void FaceTarget()
    {
        if (target.position.x < transform.position.x)
            sr.flipX = true;
        else
            sr.flipX = false;
    }

    void Attack()
    {
        anim.SetBool("isAttack", true);
        // damage logic here
    }

    void Idle()
    {
        anim.SetBool("isAttack", false);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}