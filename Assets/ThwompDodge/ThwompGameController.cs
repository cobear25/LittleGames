using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ThwompGameController : MonoBehaviour
{
    public GameObject gameOverPanel;
    public Text scoreText;
    public Thwomp[] thwomps;

    public GameObject collectablePrefab;

    bool isGameOver = false;
    int score = 0;

    void Start()
    {
        gameOverPanel.SetActive(false);
        UpdateUI();
        AddCollectable();
        Invoke("StartThwomp", 1.0f);
    }

    void UpdateUI() {
        scoreText.text = $"Score: {score}";
    }

    void AddCollectable() {
        GameObject collectable = Instantiate(collectablePrefab);
        float randomX = Mathf.Round(Random.Range(-2, 3));
        collectable.transform.position = new Vector3(randomX, 0.75f, 0);
    }

    void StartThwomp() {
        thwomps[Random.Range(0, thwomps.Length)].InitiateSmash();
        Invoke("StartThwomp", 1.6f);
    }

    public void CollectableCollected() {
        score++;
        UpdateUI();
        AddCollectable();
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
