using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 50;
    private int currentHealth;

    public int scoreValue = 10;

    void OnEnable()
    {
        currentHealth = maxHealth;
        Debug.Log("Enemy spawned with HP: " + currentHealth);
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        Debug.Log("Enemy took damage: " + amount + " | HP left: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Enemy died ✅");

        if (GameManager.Instance != null)
        {
            GameManager.Instance.RegisterEnemyKill(scoreValue);
        }

        gameObject.SetActive(false);
    }
}