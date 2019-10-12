using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HopUpGameController : GameController
{
    public HopUpPlayer player;
    public GameObject platformPrefab;

    int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        base.Initialize();
        AddPlatforms();
        UpdateUI();
    }
    
    void UpdateUI() {
        scoreText.text = $"Score: {score}";
    }

    float prevPlatX = 0.0f;
    float prevPlatY = 15.0f;
    public void AddPlatforms() {
        // score++;
        for (int i = 0; i < 3; i++)
        {
            Instantiate(platformPrefab);
            float randX = Random.Range(prevPlatX - 15.0f, prevPlatX + 15.0f);
            float randY = Random.Range(prevPlatY + 4.0f, prevPlatY + 6.0f);
            platformPrefab.transform.position = new Vector2(randX, randY);
            prevPlatX = randX;
            prevPlatY = randY;
        }
        Invoke("AddPlatforms", 1);
    }

    public void CollectableCollected() {
        score++;
        UpdateUI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
