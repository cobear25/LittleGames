using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDefenseLane : MonoBehaviour
{
    public int element;
    public List<CardDefenseCard> cards = new List<CardDefenseCard>{};
    public bool destroyed = false;

    public void AddCard(CardDefenseCard card) {
        cards.Add(card);
        card.transform.position = new Vector3(transform.position.x, transform.position.y - 8 - cards.Count * 2, -cards.Count);
    }

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        Destroy(collisionInfo.gameObject);
        if (cards.Count <= 0) {
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
            destroyed = true;
            return;
        }
        CardDefenseCard topCard = cards[cards.Count - 1];
        if (topCard.element == element) {
            // tap card if has hp
            if (topCard.hp > 1) {
                topCard.hp--;
                topCard.transform.Rotate(0, 0, -90);
            } else {
                cards.RemoveAt(cards.Count - 1);
                Destroy(topCard.gameObject);
            }
        } else {
            cards.RemoveAt(cards.Count - 1);
            Destroy(topCard.gameObject);
        }
    }
}
