using UnityEngine;

public class EnemyMelee : MonoBehaviour
{
    public float speed = 2f;
    public float damage = 4f;          // ✅ LOWER DAMAGE
    public float attackRange = 1.5f;
    public float attackCooldown = 2f;  // ✅ SLOWER ATTACK

    private float lastAttackTime;
    private Transform player;

    void Start()
    {
        player = Camera.main.transform;
    }

    void Update()
    {
        if (GameManager.Instance == null) return;
        if (!GameManager.Instance.IsGamePlaying()) return;
        if (player == null) return;

        float distance = Vector3.Distance(transform.position, player.position);

        if (distance > attackRange)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                player.position,
                speed * Time.deltaTime
            );
        }
        else
        {
            TryAttack();
        }
    }

    void TryAttack()
    {
        if (Time.time < lastAttackTime + attackCooldown) return;

        lastAttackTime = Time.time;

        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();

        if (playerHealth != null)
        {
            playerHealth.TakeDamage((int)damage);
        }
    }
}