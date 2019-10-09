using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BreakaroundGameController : MonoBehaviour
{
    [SerializeField]
    GameObject gameOverPanel;
    [SerializeField]
    Text scoreText;
    [SerializeField]
    GameObject brickPrefab;
    public float circleRadius;

    [HideInInspector]
    public bool isGameOver;
    int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        gameOverPanel.SetActive(false);
        UpdateUI();
        AddBrick();
    }

    public void GameOver() {
        isGameOver = true;
        gameOverPanel.SetActive(true);
    }

    public void BrickHit() {
        score++;
        UpdateUI();
    }

    void UpdateUI() {
        scoreText.text = $"Score: {score}";
    }

    void AddBrick() {
        GameObject brick = Instantiate(brickPrefab);
        brickPrefab.transform.position = Random.insideUnitCircle * circleRadius;
        brick.GetComponent<BreakaroundBrick>().gameController = this;
        if (!isGameOver) {
            Invoke("AddBrick", 1.0f);
        }
    }
    
    public void PlayAgain() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Quit() {
        SceneManager.LoadScene("MenuScene");
    }

}
