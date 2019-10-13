using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunNGunGameController : GameController
{
    public GameObject enemyPrefab;
    public GameObject collectablePrefab;

    int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        base.Initialize();
        AddEnemy();
        AddCollectable();
    }

    void UpdateUI()
    {
        scoreText.text = $"Score: {score}";
    }

    void AddCollectable() {
        var coll = Instantiate(collectablePrefab);
        coll.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        coll.transform.position = new Vector2(Random.Range(-27.0f, 27.0f), Random.Range(0.0f, 5.0f));
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
            enemy.transform.position = new Vector2(-35, Random.Range(0, 5));
            enemy.GetComponent<Rigidbody2D>().velocity = new Vector2(500 * Time.deltaTime, 0);
        } else {
            enemy.transform.position = new Vector2(35, Random.Range(0, 5));
            enemy.GetComponent<Rigidbody2D>().velocity = new Vector2(-500 * Time.deltaTime, 0);
        }
        Destroy(enemy, 7.0f);
        Invoke("AddEnemy", Random.Range(0.5f, 1.0f));
    }
}
