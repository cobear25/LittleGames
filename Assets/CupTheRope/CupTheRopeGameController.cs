using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupTheRopeGameController : GameController
{
    int score = 0;
    void Start()
    {
        base.Initialize();
        UpdateUI();
        Invoke("AddPoint", 1);
    }

    void AddPoint() {
        if (isGameOver) return;
        score++;
        UpdateUI();
        Invoke("AddPoint", 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateUI() {
        scoreText.text = $"Score: {score}";
    }
}
