using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreText : MonoBehaviour
{
    public TMPro.TextMeshProUGUI highScoreText;
    private HighScoreManager highScoreManager;
    void Start()
    {
        highScoreManager = FindObjectOfType<HighScoreManager>();
        highScoreText.text = "High Score:\n" + highScoreManager.GetHighScore().ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
