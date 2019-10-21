using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RedvsBlueGameController : GameController
{
    public GameObject floorCubePrefab;
    public RedvsBluePlayer redPlayer;
    public RedvsBluePlayer bluePlayer;
    
    public Text timerText;
    public Text redText;
    public Text blueText;
    public Text gameOverText;

    const float timerDuration = 30.0f;
    float timeRemaining = timerDuration;
    bool timerStarted = false;

    List<GameObject> floorTiles = new List<GameObject> { };
    // Start is called before the first frame update
    void Start()
    {
        base.Initialize();
        CreateBoard();
        redPlayer.transform.position = new Vector3(-5, 1, 5);
        bluePlayer.transform.position = new Vector3(5, 1, -5);
        StartTimer();
    }

    void CreateBoard() {
        for (int i = -5; i < 6; i++)
        {
            for (int j = -5; j < 6; j++)
            {
                GameObject tile = Instantiate(floorCubePrefab, new Vector3(i, 0, j), Quaternion.identity);
                floorTiles.Add(tile);
            }
        }
    }

    void StartTimer() {
        timeRemaining = timerDuration;
        timerStarted = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerStarted) {
            timeRemaining -= Time.deltaTime;
            timerText.text = timeRemaining.ToString("0.00");
            if (timeRemaining <= 0) {
                timerStarted = false;
                timerText.text = "0.00";
                CheckScore();
                GameOver();
            }
        }
    }

    void CheckScore() {
        int redCount = 0;
        int blueCount = 0;
        foreach (var tile in floorTiles)
        {
            if (tile.GetComponent<MeshRenderer>().material.color == redPlayer.material.color) {
                redCount++;
            }
            if (tile.GetComponent<MeshRenderer>().material.color == bluePlayer.material.color) {
                blueCount++;
            }
        }
        redText.text = $"{redCount}";
        blueText.text = $"{blueCount}";
        if (redCount > blueCount) {
            gameOverText.text = "RED WINS!";
        } else if (redCount < blueCount) {
            gameOverText.text = "BLUE WINS!";
        } else {
            gameOverText.text = "IT'S A TIE!";
        }
    }
}
