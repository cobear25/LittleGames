using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ColorScribeGameController : MonoBehaviour
{
    public InputField inputField;
    public GameObject gameOverPanel;
    public Text scoreText;
    public GameObject enemyPrefab;

    bool isGameOver = false;
    int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        gameOverPanel.SetActive(false);
        inputField.ActivateInputField();
        UpdateUI();
        AddEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        inputField.ActivateInputField();
    }

    void UpdateUI() {
        scoreText.text = $"Score: {score}";
    }

    void AddEnemy() {
        if (isGameOver) return;
        GameObject enemy = Instantiate(enemyPrefab);
        enemy.transform.position = new Vector3(Random.Range(-45.0f, 45.0f), 1, 80);
        enemy.GetComponent<ColorScribeEnemy>().gameController = this;
        Invoke("AddEnemy", Random.Range(0.7f, 2.0f));
    }

    public void TextEntered(Text text) {
        if (isGameOver) return;
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("obstacle")) {
            obj.GetComponent<ColorScribeEnemy>().ColorTyped(text.text);
        }
        inputField.text = "";
    }

    public void EnemyDestroyed() {
        score++;
        UpdateUI();
    }

    public void GameOver() {
        isGameOver = true;
        GetComponentInChildren<ParticleSystem>().Play();
        gameOverPanel.SetActive(true);
    }

    public void PlayAgain() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Quit() {
        SceneManager.LoadScene("MenuScene");
    }
}
