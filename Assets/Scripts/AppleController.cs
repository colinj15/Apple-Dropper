using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleController : MonoBehaviour
{
    private ScoreManager scoreManager;
    // Start is called before the first frame update
    public void SetScoreManager(ScoreManager sm)
    {
        scoreManager = sm;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Kill"))
        {
            Destroy(gameObject);
        }
        if (collision.CompareTag("Player"))
        {
            scoreManager.AddScore(1);
            Destroy(gameObject);
        }
    }
}
