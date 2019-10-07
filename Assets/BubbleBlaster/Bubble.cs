using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    int stage = 0;
    float targetScale;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-3.5f, 3.5f), Random.Range(-3.5f, 3.5f)); 
        targetScale = transform.localScale.magnitude;
    }

    // Update is called once per frame
    void Update()
    {
        float maxX = GameObject.Find("GameController").GetComponent<BubbleBlasterGameController>().maxX;
        float maxY = GameObject.Find("GameController").GetComponent<BubbleBlasterGameController>().maxY;
        if (transform.position.x > maxX) {
            transform.position = new Vector2(-maxX, transform.position.y);
        }
        if (transform.position.x < -maxX) {
            transform.position = new Vector2(maxX, transform.position.y);
        }
        if (transform.position.y > maxY) {
            transform.position = new Vector2(transform.position.x, -maxY);
        }
        if (transform.position.y < -maxY) {
            transform.position = new Vector2(transform.position.x, maxY);
        }
        transform.localScale = Vector3.Lerp(transform.localScale, new Vector2(1, 1) * targetScale, Time.deltaTime);
    }

    bool canHit = true;
    void OnTriggerEnter2D(Collider2D other) {
        if (!canHit) { return; }
        if (other.tag == "bullet") {
            canHit = false;
            Invoke("EnableHitting", 0.1f);
            if (stage < 2) {
                stage++;
                targetScale *= 1.7f;
            } else {
                GameObject.Find("GameController").GetComponent<BubbleBlasterGameController>().BubbleDestroyed();
                Destroy(gameObject);
            }
            Destroy(other.gameObject);
        }
    }

    void EnableHitting() {
        canHit = true;
    }
}
