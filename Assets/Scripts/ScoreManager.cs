using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int score = 0;
    public PlayerSpawner playerSpawner;
    private HighScoreManager highScoreManager;

    void Start()
    {
        highScoreManager = FindObjectOfType<HighScoreManager>();
        scoreText.text = "Score: " + score;
    }

    public void AddScore(int amount)
    {
        score += amount;
        scoreText.text = "Score: " + score;

        if (score > highScoreManager.GetHighScore())
        {
            highScoreManager.SetHighScore(score);
        }
    }

    public void LoseLife(int amount)
    {
        playerSpawner.LoseLife(amount);
    }

    public int GetScore()
    {
        return score;
    }
}