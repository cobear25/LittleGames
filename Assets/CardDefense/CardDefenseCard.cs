using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDefenseCard : MonoBehaviour
{
    public CardDefenseGameController gameController;

    public int element = 0;
    public int hp = 2;

    public SpriteRenderer spriteRenderer;
    Vector2 grabDif;
    public bool selected = false;
    bool placed = false;
    public Vector2 startPos;

    bool moveToHand = false;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetElement(int e) {
        element = e;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 cardPos = transform.position;
        SpriteRenderer sp = GetComponent<SpriteRenderer>();
        if (selected)
        {
            transform.position = new Vector3(cursorPos.x - grabDif.x, cursorPos.y - grabDif.y, -30);
        }
        if (Input.GetButtonDown("Fire1"))
        {
            if (!placed && spriteRenderer.bounds.Contains(cursorPos))
            {
                selected = true;
                grabDif = cursorPos - cardPos;
            }
        }
        if (Input.GetButtonUp("Fire1"))
        {
            if (selected)
            {
                selected = false;
                foreach (CardDefenseLane lane in gameController.lanes)
                {
                    if (!lane.destroyed && Mathf.Abs(lane.transform.position.x - cursorPos.x) < 5 && cursorPos.y < lane.transform.position.y) {
                        lane.AddCard(this);
                        gameController.CardPlaced();
                        placed = true;
                    }
                }

                if (!placed) {
                    // return to hand
                    moveToHand = true;
                }
            }
        }  
        if (moveToHand) {
            transform.position = Vector2.MoveTowards(transform.position, startPos, 300 * Time.deltaTime);
            if (Vector2.Distance(transform.position, startPos) < 0.5f) {
                Destroy(gameObject);
                gameController.ReturnCard();
            }
        }
    }
}
