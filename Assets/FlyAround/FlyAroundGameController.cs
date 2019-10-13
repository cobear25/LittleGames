using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FlyAroundGameController : GameController
{
    public float maxX;
    public float maxY;

    public GameObject enemyPrefab;
    public GameObject collectablePrefab;

    int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        base.Initialize();
        UpdateUI();
        AddEnemy();
        AddCollectable();
    }

    void UpdateUI() {
        scoreText.text = "Score: " + score;
    }

    void AddCollectable() {
        var coll = Instantiate(collectablePrefab);
        coll.transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
        coll.transform.position = new Vector2(Random.Range(-maxX + 2, maxX - 2), Random.Range(-maxY + 2, maxY - 2));
    }

    public void CollectableCollected() {
        score++;
        UpdateUI();
        AddCollectable();
    }

    void AddEnemy() {
        var enemy = Instantiate(enemyPrefab);
        int rand = Random.Range(0, 2); 
        if (rand == 0) {
            enemy.transform.position = new Vector2(-35, Random.Range(-maxY, maxY));
            enemy.GetComponent<Rigidbody2D>().velocity = new Vector2(400 * Time.deltaTime, 0);
        } else {
            enemy.transform.position = new Vector2(35, Random.Range(-maxY, maxY));
            enemy.GetComponent<Rigidbody2D>().velocity = new Vector2(-400 * Time.deltaTime, 0);
        }
        Destroy(enemy, 7.0f);
        Invoke("AddEnemy", Random.Range(0.5f, 2.0f));
    }
}
