using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IsaacGameController : GameController
{
    public GameObject flyPrefab;

    int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        base.Initialize();
        AddFly();
    }

    void UpdateUI()
    {
        scoreText.text = $"Score: {score}";
    }

    public void EnemyDestroyed() {
        score++;
        UpdateUI();
    }

    void AddFly() {
        if (isGameOver) return;
        GameObject fly = Instantiate(flyPrefab);
        fly.transform.position = new Vector2(Random.Range(-80.0f, 80.0f), Random.Range(25.0f, 35.0f));
        fly.GetComponent<IsaacFly>().speed = Random.Range(3.0f, 8.0f);
        Invoke("AddFly", 1.5f);
    }
}
