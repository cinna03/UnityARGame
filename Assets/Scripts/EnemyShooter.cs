using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float shootRange = 6f;
    public float fireRate = 1.5f;

    private float nextFireTime;
    private Transform player;

    void Start()
    {
        player = Camera.main.transform;
    }

    void Update()
    {
        // ✅ Only work when game is running
        if (GameManager.Instance == null) return;
        if (!GameManager.Instance.IsGamePlaying()) return;

        if (player == null) return;

        float distance = Vector3.Distance(transform.position, player.position);

        if (distance > shootRange)
        {
            MoveTowardsPlayer();
        }
        else
        {
            TryShoot();
        }
    }

    void MoveTowardsPlayer()
    {
        transform.position = Vector3.MoveTowards(
            transform.position,
            player.position,
            moveSpeed * Time.deltaTime
        );
    }

    void TryShoot()
    {
        if (Time.time < nextFireTime) return;

        nextFireTime = Time.time + fireRate;

        ShootPlayer();
    }

    void ShootPlayer()
    {
        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();

        if (playerHealth != null)
        {
            playerHealth.TakeDamage(5);
        }

        Debug.Log("Shooter enemy attacked player");
    }
}