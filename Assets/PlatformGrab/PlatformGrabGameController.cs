using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlatformGrabGameController : MonoBehaviour
{
    public GameObject gameOverPanel;
    public Text scoreText;
    public bool isGameOver = false;

    public bool isGrabbingOne = false;

    int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        gameOverPanel.SetActive(false); 
        UpdateUI();
    }

    public void Score() {
        score++;
        UpdateUI();
    }

    void UpdateUI() {
        scoreText.text = "Score: " + score;
    }

    public void GameOver() {
        isGameOver = true;
        gameOverPanel.SetActive(true);
    }

    public void PlayAgain() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Quit() {
        SceneManager.LoadScene("MenuScene");
    }
}
