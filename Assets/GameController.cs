using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject gameOverPanel;
    public Text scoreText;
    public bool isGameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        Initialize();
    }

    public void Initialize() {
        gameOverPanel.SetActive(false);   
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
