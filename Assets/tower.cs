using UnityEngine;

public class tower : MonoBehaviour
{
    [Header("Stats")]
    public int maxHealth = 100;
    public int currentHealth;

    public float attackRange = 1f;
    public float attackCooldown = 1f;
    public int damage = 10;

    float cooldownTimer;

    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        cooldownTimer -= Time.deltaTime;

        if (cooldownTimer <= 0)
        {
            Attack();
        }
    }

    void Attack()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(
            transform.position,
            attackRange,
            LayerMask.GetMask("Enemy")
        );

        if (enemies.Length > 0)
        {
            // attack first enemy found
            enemies[0].GetComponent<Enemy>().TakeDamage(damage);
            cooldownTimer = attackCooldown;
        }
    }

    public void TakeDamage(int dmg)
    {
        currentHealth -= dmg;

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
