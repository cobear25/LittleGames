using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxedInGameController : GameController
{
    public GameObject boxPrefab;
    public GameObject collectablePrefab;

    int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        base.Initialize();
        PopulateBoard();
        AddCollectable();
        UpdateUI();
    }

    void PopulateBoard() {
        for (int i = -3; i <= 3; i++)
        {
            for (int j = -3; j <= 3; j++)
            {
                GameObject box = Instantiate(boxPrefab, new Vector2(i * 10, j * 10), Quaternion.identity);
                if (Mathf.Abs(i) == 3 || Mathf.Abs(j) == 3) {
                    box.GetComponent<BoxedInBox>().isSolid = true;
                    box.GetComponent<BoxedInBox>().canToggle = false;
                } else {
                    box.GetComponent<BoxedInBox>().isSolid = false;
                }
                box.GetComponent<BoxedInBox>().gameController = this;
            }
        }
    }

    void UpdateUI() {
        scoreText.text = $"Score: {score}";
    }

    public void CollectableCollected() {
        score++;
        UpdateUI();
        AddCollectable();
    }

    void AddCollectable()
    {
        GameObject collectable = Instantiate(collectablePrefab);
        collectable.transform.localScale = new Vector2(3f, 3f);
        collectablePrefab.transform.position = new Vector2(Random.Range(-2, 3) * 10, Random.Range(-2, 3) * 10);
    }
}
