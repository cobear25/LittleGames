using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GraveyardGameController : GameController
{
    public GameObject tombstonePrefab;
    public GameObject ghostPrefab;
    public Transform pillar;
    public Text livesText;
    // Start is called before the first frame update
    void Start()
    {
        base.Initialize(); 
        AddTombstones();
        AddGhosts();
        float randX = Random.Range(-200.0f, 200.0f);
        float randZ = Random.Range(-200.0f, 200.0f);
        pillar.position = new Vector3(randX, pillar.position.y, randZ);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) {
            Cursor.lockState = CursorLockMode.None;
            Quit();
        }

        if (Input.GetKeyDown(KeyCode.R)) {
            PlayAgain();
        }
    }

    void AddTombstones() {
        for (int i = -20; i < 20; i++)
        {
            for (int j = -20; j < 20; j++) {
                float randX = i * 10;
                float randZ = j * 10;
                Instantiate(tombstonePrefab, new Vector3(randX, 4, randZ), Quaternion.Euler(0, Random.Range(0.0f, 360.0f), 0));
            }
        }
    }

    void AddGhosts() {
        for (int i = 0; i < 100; i++)
        {
            float randX = Random.Range(-200.0f, 200.0f);
            float randZ = Random.Range(-200.0f, 200.0f);
            Instantiate(ghostPrefab, new Vector3(randX, 3, randZ), Quaternion.identity);
        } 
    }
}
