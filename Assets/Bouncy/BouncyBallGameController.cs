using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BouncyBallGameController : MonoBehaviour
{
    public GameObject gameOverPanel;
    public Text scoreText;

    public GameObject groundPrefab;
    public GameObject spikePrefab;

    public Vector2 topSpikePosition;
    public Vector2 bottomSpikePosition;

    int points = 0;

    float timeElapsed = 0;
    float addGroundInterval = 2;

    float spikeTimeElapsed = 0;
    float newSpikeInterval = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        gameOverPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;
        // addPointElapsed += Time.deltaTime;
        if (timeElapsed > addGroundInterval) {
            timeElapsed = 0;
            AddGround();
        }

        spikeTimeElapsed += Time.deltaTime;
        if (spikeTimeElapsed > newSpikeInterval) {
            spikeTimeElapsed = 0;
            newSpikeInterval = Random.Range(0.5f, 2.0f);
            AddSpike();
        }
    }

    void UpdateUI() {
        scoreText.text = "Score: " + points;
    }

    public void Hit() {
        gameOverPanel.SetActive(true);
    }

    public void Score() {
        points++;
        UpdateUI();
    }

    public void PlayAgain() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Quit() {
        SceneManager.LoadScene("MenuScene");
    }

    public void AddGround() {
        GameObject newGround = Instantiate(groundPrefab);
        newGround.transform.position = new Vector2(98.6f, -5.4f);
        GameObject newGround2 = Instantiate(groundPrefab);
        newGround2.transform.position = new Vector2(98.6f, 13.5f);
    }

    void AddSpike() {
        GameObject newSpike = Instantiate(spikePrefab);
        if (Random.Range(0, 2) == 1) {
            newSpike.transform.position = topSpikePosition;
            newSpike.GetComponent<SpriteRenderer>().flipY = true;
        } else {
            newSpike.transform.position = bottomSpikePosition;
        }
    }
}
