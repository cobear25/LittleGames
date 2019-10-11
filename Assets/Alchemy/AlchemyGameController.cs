using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AlchemyGameController : MonoBehaviour
{
    [SerializeField]
    GameObject gameOverPanel;
    [SerializeField]
    Text scoreText;
    [SerializeField]
    Text successText;
    [SerializeField]
    Text timerText;
    [SerializeField]
    AlchemyObject fixedObject;
    [SerializeField]
    AlchemyObject changeableObject;

    [HideInInspector]
    public bool isGameOver;
    int score = 0;

    float timeRemaining = 6.0f;
    bool timerStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        gameOverPanel.SetActive(false);
        UpdateUI();
        Invoke("RandomizeFixedObject", 1.0f);
    }

    void Update()
    {
        if (timerStarted) {
            timeRemaining -= Time.deltaTime;
            timerText.text = timeRemaining.ToString("0.00");
            if (timeRemaining <= 0) {
                timerStarted = false;
                GameOver();
            }
        }
    }

    void StartTimer() {
        timeRemaining = 6.0f;
        timerStarted = true;
    }

    void RandomizeFixedObject() {
        StartTimer();
        changeableObject.ResetObject();
        fixedObject.ResetObject();
        for (int i = 0; i < 10; i++)
        {
            int randomAction = Random.Range(0, 6);
            switch (randomAction) {
                case 0:
                    fixedObject.ColorBlue();
                    break;
                case 1:
                    fixedObject.ColorGreen();
                    break;
                case 2:
                    fixedObject.ColorRed();
                    break;
                case 3:
                    fixedObject.Grow();
                    break;
                case 4:
                    fixedObject.Shrink();
                    break;
                case 5:
                    fixedObject.Transform();
                    break;
            }
        }
    }

    void GameOver() {
        isGameOver = true;
        gameOverPanel.SetActive(true);
    }

    void Success() {
        if (isGameOver) return;
        timerStarted = false;
        score++;
        successText.enabled = true;
        UpdateUI();
        Invoke("HideSuccessText", 0.5f);
        Invoke("RandomizeFixedObject", 0.5f);
    }

    void UpdateUI() {
        scoreText.text = $"Score: {score}";
    }

    public void ObjectChanged() {
        if (changeableObject.color == fixedObject.color && 
            changeableObject.size == fixedObject.size &&
            changeableObject.currentSprite == fixedObject.currentSprite) {
                Success();
            } 
    }

    void HideSuccessText() {
        successText.enabled = false; 
    }
    
    public void PlayAgain() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Quit() {
        SceneManager.LoadScene("MenuScene");
    }

}
