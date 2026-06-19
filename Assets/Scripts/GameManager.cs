using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public enum GameState
    {
        StartMenu,
        Playing,
        GameOver
    }

    [Header("Game State")]
    public GameState currentState;

    [Header("Timer")]
    public float gameDuration = 60f;
    private float currentTime;

    [Header("Player References")]
    public PlayerHealth playerHealth;
    public PlayerStats playerStats;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        if (playerHealth == null)
        {
            playerHealth = FindObjectOfType<PlayerHealth>();
        }

        if (playerStats == null)
        {
            playerStats = FindObjectOfType<PlayerStats>();
        }

        ShowStartMenu();
    }

    void Update()
    {
        if (currentState != GameState.Playing) return;

        currentTime -= Time.deltaTime;

        if (UIManager.Instance != null)
        {
            UIManager.Instance.UpdateTimer(currentTime);
        }

        if (currentTime <= 0)
        {
            GameOver();
        }
    }

    public bool IsGamePlaying()
    {
        return currentState == GameState.Playing;
    }

    public void ShowStartMenu()
    {
        currentState = GameState.StartMenu;

        if (UIManager.Instance != null)
        {
            UIManager.Instance.ShowStartMenu();
        }
    }

    public void StartGame()
    {
        currentState = GameState.Playing;
        currentTime = gameDuration;

        ResetPlayerData();

        if (UIManager.Instance != null)
        {
            UIManager.Instance.ShowInGameUI();
            UIManager.Instance.UpdateTimer(currentTime);
        }

        Debug.Log("Game started.");
    }

    public void GameOver()
    {
        if (currentState == GameState.GameOver) return;

        currentState = GameState.GameOver;

        int finalScore = playerStats != null ? playerStats.score : 0;
        int enemiesKilled = playerStats != null ? playerStats.enemiesKilled : 0;
        float timeSurvived = gameDuration - currentTime;

        if (UIManager.Instance != null)
        {
            UIManager.Instance.UpdateEndGameSummary(finalScore, enemiesKilled, timeSurvived);
            UIManager.Instance.ShowEndGame();
        }

        Debug.Log("Game over.");
    }

    public void RestartGame()
    {
        StartGame();
    }

    public void ReturnToMainMenu()
    {
        currentState = GameState.StartMenu;

        if (UIManager.Instance != null)
        {
            UIManager.Instance.ShowStartMenu();
        }

        Debug.Log("Returned to main menu.");
    }

    void ResetPlayerData()
    {
        if (playerStats != null)
        {
            playerStats.ResetStats();
        }

        if (playerHealth != null)
        {
            playerHealth.ResetHealth();
        }
    }
}