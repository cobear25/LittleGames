using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SugarAntsGameController : MonoBehaviour
{
    public GameObject antPrefab;
    public GameObject stickyPaperPrefab;
    public float maxX;
    public float maxZ;
    public float yPos;

    public int minAntCount;
    public int maxAntCount;

    public Text scoreText;
    private int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < Random.Range(minAntCount, maxAntCount); i++) {
            GameObject ant = Instantiate(antPrefab);
            ant.transform.position = new Vector3(Random.Range(-maxX, maxX), yPos, Random.Range(-maxZ, maxZ));
        } 

        for (int i = 0; i < Random.Range(3, 6); i++) {
            Vector3 newPos = new Vector3(Random.Range(-maxX, maxX), 2.5f, Random.Range(-maxZ, maxZ));
            float randomRotation = Random.Range(-90.0f, 90.0f);
            Quaternion newAngle = new Quaternion(0, randomRotation, 0, transform.rotation.w);
            GameObject stickyPaper = Instantiate(stickyPaperPrefab, newPos, newAngle);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AntCaptured() {
        score++;
        scoreText.text = "Ants Captured: " + score;
    }

    public void PlayAgain() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Quit() {
        SceneManager.LoadScene("MenuScene");
    }
}
