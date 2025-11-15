using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreManager : MonoBehaviour
{
    private int highScore = 0;
    private static HighScoreManager _instance;
    void Awake()
    {
       if (_instance != null && _instance != this)
        {
            Destroy(gameObject);            
            return;
        }
        _instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetHighScore()
    {
        return highScore;
    }

    public void SetHighScore(int newHighScore)
    {
        highScore = newHighScore;
    }
}
