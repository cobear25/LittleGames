using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TyppoGameController : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Text pointsText;
    public GameObject gameOverPanel;
    public bool gameOver = false;
    public Image heart1;
    public Image heart2;
    public Image heart3;
    public Sprite emptyHeart;

    int life = 3;
    int points = 0;

    List<float> xPositions = new List<float>{};
    // Start is called before the first frame update
    void Start()
    {
        gameOverPanel.SetActive(false);
        foreach (TyppoKey tk in GameObject.FindObjectsOfType<TyppoKey>()) {
            xPositions.Add(tk.transform.position.x);
        }

        AddEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver) { return; }
        foreach (TyppoKey tk in GameObject.FindObjectsOfType<TyppoKey>()) {
            if (Input.GetKeyDown(tk.keyCode)) {
                tk.Flash();
            }
        }
    }

    void AddEnemy() {
        if (gameOver) { return; }
        float xPos = xPositions[Random.Range(0, xPositions.Count)];
        TyppoEnemy enemy = Instantiate(enemyPrefab).GetComponent<TyppoEnemy>();
        enemy.transform.position = new Vector2(xPos, 10);
        enemy.speed = Random.Range(5.0f, 6.0f);
        Invoke("AddEnemy", Random.Range(0.5f, 0.6f));
    }

    public void EnemyDestroyed() {
        points++;
        UpdateUI();
    }

    public void WallHit() {
        life--;
        UpdateUI();
        if (life <= 0) {
            gameOver = true;
            gameOverPanel.SetActive(true);
            foreach (TyppoEnemy enemy in GameObject.FindObjectsOfType<TyppoEnemy>())
            {
                enemy.Explode();
            }
        }
    }

    void UpdateUI() {
        pointsText.text = "Enemies Destroyed: " + points;
        if (life < 3) {
            heart3.sprite = emptyHeart;
        }
        if (life < 2) {
            heart2.sprite = emptyHeart;
        }
        if (life < 1) {
            heart1.sprite = emptyHeart;
        }
    }

    public void PlayAgain() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Quit() {
        SceneManager.LoadScene("MenuScene");
    }
}
