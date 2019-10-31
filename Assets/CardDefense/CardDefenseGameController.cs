using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDefenseGameController : GameController
{
    public CardDefenseLane[] lanes;
    public Button[] cardButtons;
    public Sprite waterSprite;
    public Sprite treeSprite;
    public Sprite fireSprite;
    public GameObject cardPrefab;
    public GameObject enemyPrefab;

    GameObject selectedButton;

    float addEnemyInterval = 1.5f;

    int cardsInHand = 0;

    float timeElapsed = 0.0f;
    bool timerStarted = false;
    // Start is called before the first frame update
    void Start()
    {
        base.Initialize();
        AddCards();
        AddEnemy();
    }

    void Update()
    {
        if (!isGameOver) {
            timeElapsed += Time.deltaTime;
            scoreText.text = timeElapsed.ToString("0.00");
        }
    }

    public void CardSelected(IntComponent intComponent) {
        GameObject card = Instantiate(cardPrefab, Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity);
        card.GetComponent<CardDefenseCard>().startPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        card.GetComponent<CardDefenseCard>().SetElement(intComponent.value);
        card.GetComponent<CardDefenseCard>().gameController = this;
        card.GetComponent<CardDefenseCard>().selected = true;
        card.GetComponent<SpriteRenderer>().sprite = SpriteForElement(intComponent.value);

        intComponent.GetComponent<Image>().enabled = false;
        intComponent.GetComponent<Button>().enabled = false;
        selectedButton = intComponent.gameObject;
    }

    void AddCards() {
        foreach (Button button in cardButtons)
        {
            button.enabled = true;
            button.image.enabled = true;
            CardDefenseCard newCard = new CardDefenseCard();
            int randint = Random.Range(0, 3);
            button.GetComponent<IntComponent>().value = randint;
            button.image.sprite = SpriteForElement(randint);
        }
        cardsInHand = 5;
    }

    Sprite SpriteForElement(int element) {
        switch (element)
        {
            case 0:
                return waterSprite;
            case 1:
                return treeSprite;
            default:
                return fireSprite;
        }
    }

    public void ReturnCard() {
        selectedButton.GetComponent<Button>().enabled = true;
        selectedButton.GetComponent<Image>().enabled = true;
    }

    public void CardPlaced() {
        cardsInHand--;
        if (cardsInHand <= 0) {
            AddCards();
        }
    }

    void AddEnemy()
    {
        List<int> availableLanes = new List<int>{};
        for (int i = 0; i < lanes.Length; i++)
        {
            if (!lanes[i].destroyed) {
                availableLanes.Add(i);
            }  
        }
        if (availableLanes.Count == 0) {
            GameOver();
            return;
        }
        int lane = Random.Range(0, availableLanes.Count);
        GameObject enemy = Instantiate(enemyPrefab, new Vector2(lanes[availableLanes[lane]].transform.position.x, 38), Quaternion.identity);
        enemy.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -5);

        if (addEnemyInterval > 0.1f) {
            addEnemyInterval -= 0.01f;
        }
        Invoke("AddEnemy", addEnemyInterval);
    }
}
