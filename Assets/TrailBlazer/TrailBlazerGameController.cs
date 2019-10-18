using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TrailBlazerGameController : GameController
{
    public float maxX;
    public float maxY;

    int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        base.Initialize();
        UpdateUI();
        Invoke("AddPoint", 1);
    }

    void UpdateUI() {
        scoreText.text = "Score: " + score;
    }

    void AddPoint() {
        score++;
        UpdateUI();
        Invoke("AddPoint", 1);
    }
}
