using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject playerPrefab;
    public float padding;
    private int lives = 3;
    private GameObject[] playerInstances = new GameObject[3];

    // Start is called before the first frame update
    void Start()
    {
        Vector3 spawnPosition = new Vector3(0f, -3.5f, 0f);
        playerInstances[0] = Instantiate(playerPrefab, spawnPosition + new Vector3(-padding, 0f, 0f), Quaternion.identity);
        playerInstances[1] = Instantiate(playerPrefab, spawnPosition + new Vector3(padding, 0f, 0f), Quaternion.identity);
        playerInstances[2] = Instantiate(playerPrefab, spawnPosition, Quaternion.identity);

        playerInstances[0].GetComponent<BoxController>().SetPadding(-padding);
        playerInstances[1].GetComponent<BoxController>().SetPadding(padding);
        playerInstances[2].GetComponent<BoxController>().SetPadding(0f);
    }

    public void LoseLife(int amount)
    {
        Destroy(playerInstances[3 - lives]);
        lives -= amount;
        if (lives <= 0)
        {
            // Game Over Logic Here
            UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver");
        }
    }

}
