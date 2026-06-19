using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [Header("Panels")]
    public GameObject startMenuPanel;
    public GameObject inGameUIPanel;
    public GameObject endGamePanel;
    public GameObject leaderboardPanel;

    [Header("In-Game UI")]
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText;

    [Header("End Game UI")]
    public TextMeshProUGUI finalScoreText;
    public TextMeshProUGUI enemiesKilledText;
    public TextMeshProUGUI timeSurvivedText;

    void Awake()
    {
        // Singleton setup
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // =========================
    // PANEL CONTROL
    // =========================

    public void ShowStartMenu()
    {
        startMenuPanel.SetActive(true);
        inGameUIPanel.SetActive(false);
        endGamePanel.SetActive(false);
        leaderboardPanel.SetActive(false);
    }

    public void ShowInGameUI()
    {
        startMenuPanel.SetActive(false);
        inGameUIPanel.SetActive(true);
        endGamePanel.SetActive(false);
        leaderboardPanel.SetActive(false);
    }

    public void ShowEndGame()
    {
        startMenuPanel.SetActive(false);
        inGameUIPanel.SetActive(false);
        endGamePanel.SetActive(true);
        leaderboardPanel.SetActive(false);
    }

    public void ShowLeaderboard()
    {
        startMenuPanel.SetActive(false);
        inGameUIPanel.SetActive(false);
        endGamePanel.SetActive(false);
        leaderboardPanel.SetActive(true);
    }

    // =========================
    // UI UPDATES
    // =========================

    public void UpdateHealth(int value)
    {
        healthText.text = "Health: " + value;
    }

    public void UpdateScore(int value)
    {
        scoreText.text = "Score: " + value;
    }

    public void UpdateTimer(float value)
    {
        timerText.text = "Time: " + Mathf.CeilToInt(value);
    }

    public void UpdateEndGameSummary(int score, int enemies, float time)
    {
        finalScoreText.text = "Score: " + score;
        enemiesKilledText.text = "Enemies: " + enemies;
        timeSurvivedText.text = "Time: " + Mathf.CeilToInt(time);
    }
}