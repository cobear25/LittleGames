using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinshotGamecontroller : GameController
{
    public GameObject monsterPrefab;

    int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        base.Initialize();
        UpdateUI();
        AddMonster();
    }

    // Update is called once per frame
    void UpdateUI()
    {
        scoreText.text = $"Enemies Destroyed: {score}"; 
    }

    void AddMonster() {
        Instantiate(monsterPrefab);
        monsterPrefab.transform.position = new Vector2(Random.Range(-80, 80), Random.Range(2, 280));
        Invoke("AddMonster", 1);
    }

    public override void EnemyDestroyed()
    {
        score++;
        UpdateUI();
    }
}
