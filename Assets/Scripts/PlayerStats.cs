using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int score = 0;
    public int enemiesKilled = 0;

    public void ResetStats()
    {
        score = 0;
        enemiesKilled = 0;

        if (UIManager.Instance != null)
        {
            UIManager.Instance.UpdateScore(score);
        }
    }

    public void AddScore(int amount)
    {
        score += amount;

        if (UIManager.Instance != null)
        {
            UIManager.Instance.UpdateScore(score);
        }
    }

    public void EnemyKilled()
    {
        enemiesKilled++;
    }
}