using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwarmGameController : GameController
{
    public GameObject groundPrefab;
    public GameObject sawPrefab;

    int score = 0;

    void Start()
    {
        base.Initialize();   
        UpdateUI();
        Invoke("IncrementScore", 1);
    }

    void Update()
    {
        if (FindObjectsOfType<SwarmPlayer>().Length <= 0) {
            GameOver();
        }
    }

    void UpdateUI() {
        scoreText.text = $"Score: {score}";
    }

    void IncrementScore() {
        if (isGameOver) return;
        score++;
        UpdateUI();
        Invoke("IncrementScore", 1);
    }

    public void AddGround(float yPos) {
        if (isGameOver) return;
        GameObject ground = Instantiate(groundPrefab, new Vector2(56, yPos), Quaternion.identity);
        ground.GetComponent<SwarmGroundController>().gameController = this;
    }

    public void AddSaw() {
        if (isGameOver) return;
        GameObject saw = Instantiate(sawPrefab, new Vector2(56, Random.Range(0.0f, 20.0f)), Quaternion.identity);
        float randomScale = Random.Range(1.0f, 2.0f);
        saw.transform.localScale = new Vector2(randomScale, randomScale);
        saw.GetComponent<SwarmSawController>().gameController = this;
    }
}
