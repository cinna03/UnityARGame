using UnityEngine;
using System.Collections.Generic;

public class LeaderboardManager : MonoBehaviour
{
    public static LeaderboardManager Instance;

    private const int maxEntries = 5;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void SaveScore(int score, float time)
    {
        List<LeaderboardEntry> entries = LoadScores();

        entries.Add(new LeaderboardEntry(score, time));

        // Sort: highest score first
        entries.Sort((a, b) => b.score.CompareTo(a.score));

        if (entries.Count > maxEntries)
            entries.RemoveAt(entries.Count - 1);

        // Save back
        for (int i = 0; i < entries.Count; i++)
        {
            PlayerPrefs.SetInt("Score_" + i, entries[i].score);
            PlayerPrefs.SetFloat("Time_" + i, entries[i].time);
        }

        PlayerPrefs.Save();

        Debug.Log("Leaderboard updated ✅");
    }

    public List<LeaderboardEntry> LoadScores()
    {
        List<LeaderboardEntry> entries = new List<LeaderboardEntry>();

        for (int i = 0; i < maxEntries; i++)
        {
            if (PlayerPrefs.HasKey("Score_" + i))
            {
                int score = PlayerPrefs.GetInt("Score_" + i);
                float time = PlayerPrefs.GetFloat("Time_" + i);

                entries.Add(new LeaderboardEntry(score, time));
            }
        }

        return entries;
    }
}

public class LeaderboardEntry
{
    public int score;
    public float time;

    public LeaderboardEntry(int s, float t)
    {
        score = s;
        time = t;
    }
}