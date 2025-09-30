using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeController : MonoBehaviour
{
    public float speed;
    private float baseSpeed;
    private float direction;
    private Rigidbody2D rb;
    private int tens = 0; // How many tens of points the player has

    // Apple spawning stuff
    public GameObject apple;   
    public float minWait;     
    public float maxWait;
    private float baseMinWait;
    private float baseMaxWait;
    public Vector2 spawnOffset;
    public ScoreManager scoreManager;

    // Start is called before the first frame update
    void Start()
    {
        baseSpeed = speed;
        baseMinWait = minWait;
        baseMaxWait = maxWait;

        rb = GetComponent<Rigidbody2D>();
        direction = UnityEngine.Random.Range(-1f, 1f);
        if (direction < 0)
        {
            direction = -1f;
        }
        else
        {
            direction = 1f;
        }
        rb.velocity = new Vector2(direction * speed, 0); 
        
        StartCoroutine(SpawnLoop());
    }

    IEnumerator SpawnLoop()
        {
            while (true)
            {
                // Pick a random time and wait
                float waitTime = UnityEngine.Random.Range(minWait, maxWait);
                yield return new WaitForSeconds(waitTime);

            // Spawn prefab
            if (apple != null)
            {
                Vector3 spawnPos = transform.position + (Vector3)spawnOffset;
                spawnPos.z = -1f;
                AppleController newApple = Instantiate(apple, spawnPos, Quaternion.identity).GetComponent<AppleController>();
                newApple.SetScoreManager(scoreManager);
                }
            }
        }

    // Update is called once per frame
    void Update()
    {
        int score = scoreManager.GetScore();
        if (score / 10 > tens)
        {
            tens = score / 10;
            Debug.Log("Tens increased to " + tens);
        }
        speed = baseSpeed * (1f + tens);
        minWait = baseMinWait * (float)Math.Pow(0.9, tens);
        maxWait = baseMaxWait * (float)Math.Pow(0.9, tens);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall"))
        {
            direction = -direction;
            rb.velocity = new Vector2(direction * speed, 0);
        }
    }
}
