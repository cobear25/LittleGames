using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FiveCoinsGameController : GameController
{
    public GameObject coinPrefab;
    public Text timerText;

    const float timerDuration = 8.0f;
    float timeRemaining = timerDuration;
    bool timerStarted = false;
    int score = 0;
    int coinsRemaining = 5;
    // Start is called before the first frame update
    void Start()
    {
        base.Initialize();
        StartTimer();
        AddCoins();
    }

    void Update()
    {
        if (timerStarted) {
            timeRemaining -= Time.deltaTime;
            timerText.text = timeRemaining.ToString("0.00");
            if (timeRemaining <= 0) {
                timerStarted = false;
                timerText.text = "0.00";
                GameOver();
            }
        }
    }

    void UpdateUI()
    {
        scoreText.text = $"Score: {score}";
    }
    
    void StartTimer() {
        timeRemaining = timerDuration;
        timerStarted = true;
    }

    void AddCoins() {
        for (int i = 1; i < 6; i++)
        {
            var coin = Instantiate(coinPrefab);
            coin.transform.position = new Vector2(Random.Range(-27.0f, 27.0f), Random.Range(0.0f, 15.0f));
            coin.GetComponentInChildren<TextMesh>().text = $"{i}";
        }
    }

    public void CollectableCollected() {
        score++;
        coinsRemaining--;
        UpdateUI();
        if (coinsRemaining <= 0) {
            coinsRemaining = 5;
            AddCoins();
            StartTimer();
        }
    }
}
