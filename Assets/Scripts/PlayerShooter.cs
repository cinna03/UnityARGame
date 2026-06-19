using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    [Header("Shooting Setup")]
    public Transform firePoint;
    public float fireRate = 0.3f;

    private float nextFireTime;

    void Update()
    {
        // Editor testing: left mouse click
        if (Input.GetMouseButton(0))
        {
            TryShoot();
        }
    }

    public void ShootButtonPressed()
    {
        // Mobile UI button will call this later
        TryShoot();
    }

    void TryShoot()
    {
        if (GameManager.Instance == null) return;
        if (!GameManager.Instance.IsGamePlaying()) return;

        if (Time.time < nextFireTime) return;

        Shoot();
        nextFireTime = Time.time + fireRate;
    }

    void Shoot()
    {
        if (ObjectPool.Instance == null)
        {
            Debug.LogWarning("ObjectPool missing in scene.");
            return;
        }

        if (firePoint == null)
        {
            Debug.LogWarning("FirePoint not assigned on PlayerShooter.");
            return;
        }

        ObjectPool.Instance.SpawnFromPool(
            "Bullet",
            firePoint.position,
            firePoint.rotation
        );

        Debug.DrawRay(firePoint.position, firePoint.forward * 5f, Color.red, 1f);

        Debug.Log("Player shot bullet.");
    }
}