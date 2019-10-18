using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoombopGamecontroller : GameController
{
    public GameObject enemyPrefab;

    int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        base.Initialize();
        AddEnemy();
    }

    void UpdateUI()
    {
        scoreText.text = $"Score: {score}";
    }

    public void EnemyBopped() {
        score++;
        UpdateUI();
    }

    void AddEnemy() {
        var enemy = Instantiate(enemyPrefab);
        int rand = Random.Range(0, 2); 
        if (rand == 0) {
            enemy.transform.position = new Vector2(-25, Random.Range(0, 1));
            enemy.GetComponent<Rigidbody2D>().velocity = new Vector2(300 * Time.deltaTime, 0);
        } else {
            enemy.transform.position = new Vector2(25, Random.Range(0, 1));
            enemy.GetComponent<Rigidbody2D>().velocity = new Vector2(-300 * Time.deltaTime, 0);
        }
        Destroy(enemy, 8.0f);
        Invoke("AddEnemy", Random.Range(0.5f, 1.0f));
    }
}
