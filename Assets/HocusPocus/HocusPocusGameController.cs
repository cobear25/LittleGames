using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HocusPocusGameController : GameController
{
    public GameObject treePrefab;
    public GameObject pumpkinPrefab;

    List<GameObject> obstacles = new List<GameObject>{};

    int score = 0;
    int lives = 3;

    void Start()
    {
        base.Initialize(); 
        AddObstacle();
        UpdateUI();
        Invoke("AddPoint", 1);
    }

    // Update is called once per frame
    void Update()
    {
        List<GameObject> toDeleteList = new List<GameObject> { };
        foreach (GameObject obstacle in obstacles)
        {
            obstacle.transform.Translate(0, -1.5f, 0, Space.World);
            // Add obstacle to delete list once it's past so we aren't holding on to hundreds of objects
            if (obstacle.transform.position.y < -100)
            {
                toDeleteList.Add(obstacle);
            }
        }
        foreach (GameObject obstacle in toDeleteList) {
            obstacles.Remove(obstacle);
            Destroy(obstacle);
        }
    }

    void UpdateUI() {
        scoreText.text = $"Score: {score}";
    }

    void AddPoint() {
        score++;
        UpdateUI();
        Invoke("AddPoint", 1);
    }

    void AddObstacle() {
        if (isGameOver) return;
        float randomX = Random.Range(-70.0f, 70.0f);
        if (Random.Range(0, 2) == 0) {
            GameObject tree = Instantiate(treePrefab, new Vector2(randomX, 60), Quaternion.identity);
            obstacles.Add(tree);
        } else {
            GameObject pumpkin = Instantiate(pumpkinPrefab, new Vector2(randomX, 60), Quaternion.identity);
            obstacles.Add(pumpkin);
        }
        Invoke("AddObstacle", Random.Range(0.5f, 1.5f));
    }

    public void PlayerHit() {
        lives--;
        if (lives <= 0) {
            GameOver();
        }
    }
}
