using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallJumperGameController : GameController
{
    public GameObject obstaclePrefab;
    int altitude = 0;
    // Start is called before the first frame update
    void Start()
    {
        base.Initialize();    
        AddObstacles();
        UpdateUI();
    }

    void UpdateUI() {
        scoreText.text = $"Altitude: {altitude}";
    }

    void AddObstacles() {
        for (int i = 0; i < 30; i++)
        {
            float xPos = 7.0f;
            if (i % 2 == 0) {
                xPos = -7.0f;
            }
            Instantiate(obstaclePrefab, new Vector2(xPos, Random.Range(1, 43) * 7), Quaternion.identity);
        }
    }

    public void UpdateAltitude(int alt) {
        altitude = alt;
        UpdateUI();
    }
}
