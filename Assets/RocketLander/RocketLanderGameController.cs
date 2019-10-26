using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class RocketLanderGameController : GameController
{
    public GameObject[] pieces;
    public CinemachineVirtualCamera cam;

    public GameObject debris1Prefab;
    public GameObject debris2Prefab;
    public GameObject debris3Prefab;

    int piecesLanded = 0;
    // Start is called before the first frame update
    void Start()
    {
        base.Initialize();
        pieces[0].SetActive(true);
        AddTopdebris();
        AddMiddebris();
        AddBottomdebris();
    }

    void AddTopdebris() {
        GameObject prefab;
        int randInt = Random.Range(0, 3);
        if (randInt == 0) { prefab = debris1Prefab; }
        else if (randInt == 1) { prefab = debris2Prefab; }
        else { prefab = debris3Prefab; }
        GameObject debris = Instantiate(prefab, new Vector2(-50, 40), new Quaternion(0, 0, Random.Range(0.0f, 360.0f), 0));
        debris.GetComponent<Rigidbody2D>().velocity = new Vector2(12, 0);
        debris.GetComponent<Rigidbody2D>().AddTorque(Random.Range(-1.5f, 1.5f));
        Destroy(debris, 10);
        Invoke("AddTopdebris", Random.Range(0.5f, 1.5f));
    }

    void AddMiddebris() {
        GameObject prefab;
        int randInt = Random.Range(0, 3);
        if (randInt == 0) { prefab = debris1Prefab; }
        else if (randInt == 1) { prefab = debris2Prefab; }
        else { prefab = debris3Prefab; }
        GameObject debris = Instantiate(prefab, new Vector2(50, 30), new Quaternion(0, 0, Random.Range(0.0f, 360.0f), 0));
        debris.GetComponent<Rigidbody2D>().velocity = new Vector2(-12, 0);
        debris.GetComponent<Rigidbody2D>().AddTorque(Random.Range(-1.5f, 1.5f));
        Destroy(debris, 10);
        Invoke("AddMiddebris", Random.Range(0.5f, 1.5f));
    }

    void AddBottomdebris() {
        GameObject prefab;
        int randInt = Random.Range(0, 3);
        if (randInt == 0) { prefab = debris1Prefab; }
        else if (randInt == 1) { prefab = debris2Prefab; }
        else { prefab = debris3Prefab; }
        GameObject debris = Instantiate(prefab, new Vector2(-50, 20), new Quaternion(0, 0, Random.Range(0.0f, 360.0f), 0));
        debris.GetComponent<Rigidbody2D>().velocity = new Vector2(12, 0);
        debris.GetComponent<Rigidbody2D>().AddTorque(Random.Range(-1.5f, 1.5f));
        Destroy(debris, 10);
        Invoke("AddBottomdebris", Random.Range(0.5f, 1.5f));
    }

    public void PieceLanded() {
        piecesLanded++;
        if (piecesLanded < pieces.Length) {
            Invoke("SwitchToNextPiece", 1.0f);
        } else {
            GameOver();
        }
    }

    void SwitchToNextPiece() {
        pieces[piecesLanded].transform.position = new Vector2(0, 50);
        pieces[piecesLanded].SetActive(true);
        cam.Follow = pieces[piecesLanded].transform;
    }
}
