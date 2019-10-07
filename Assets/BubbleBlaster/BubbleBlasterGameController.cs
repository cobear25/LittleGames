using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BubbleBlasterGameController : MonoBehaviour
{
    public GameObject gameOverPanel;
    public Text scoreText;

    public float maxX;
    public float maxY;

    public GameObject bubblePrefab;

    int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        gameOverPanel.SetActive(false);
        UpdateUI();
    }

    void UpdateUI() {
        scoreText.text = "Score: " + score;
    }

    void AddBubble() {
        GameObject bubble = Instantiate(bubblePrefab);
        bubble.transform.position = new Vector2(Random.Range(-maxX, maxX), Random.Range(-maxY, maxY));
    }

    public void BubbleDestroyed() {
        score++;
        AddBubble();
        UpdateUI();
    }

    public void GameOver() {
        gameOverPanel.SetActive(true);
    }
    
    public void PlayAgain() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Quit() {
        SceneManager.LoadScene("MenuScene");
    }
}
