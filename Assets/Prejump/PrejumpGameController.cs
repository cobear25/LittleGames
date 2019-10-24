using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrejumpGameController : GameController
{
    public GameObject[] midPlats;
    public GameObject startPlat;
    public GameObject finalPlat;
    public GameObject saw;
    public GameObject[] jumpIndicators;
    public Text gameOverText;

    public bool editMode = true;
    public PrejumpBall ball;
    // Start is called before the first frame update
    void Start()
    {
        base.Initialize(); 
        ShuffleLevel();
    }

    public void ShuffleLevel() {
        if (!editMode) return;
        startPlat.transform.position = new Vector2(startPlat.transform.position.x, Random.Range(-18.0f, 10.0f));
        ball.transform.position = new Vector2(-43, startPlat.transform.position.y + 1);
        finalPlat.transform.position = new Vector2(finalPlat.transform.position.x, Random.Range(-18.0f, 8.0f));
        foreach (GameObject plat in midPlats) {
            plat.transform.position = new Vector2(Random.Range(-24.0f, 24.0f), Random.Range(-18.0f, 8.0f));
        }
        saw.transform.position = new Vector2(Random.Range(-24.0f, 24.0f), Random.Range(-18.0f, 12.0f));
        for (int i = 0; i < jumpIndicators.Length; i++)
        {
            jumpIndicators[i].transform.position = new Vector3(-9 + (i * 3), -20); 
            jumpIndicators[i].GetComponent<JumpIndicator>().gameController = this;
        }
    }

    public void StopGame() {
        editMode = true;
        ball.StopMoving();
        ball.transform.position = new Vector2(-43, startPlat.transform.position.y + 1);
    }

    public void StartGame() {
        editMode = false;
        ball.StartMoving();
    }

    public void WinGame() {
        gameOverText.text = "YOU WIN!"; 
        gameOverPanel.SetActive(true);
    }
}
