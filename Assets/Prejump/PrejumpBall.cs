using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrejumpBall : MonoBehaviour
{
    Rigidbody2D rb;
    public PrejumpGameController gameController;

    bool shouldMove = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void StartMoving() {
        shouldMove = true;
    }

    public void StopMoving() {
        shouldMove = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (shouldMove) {
            rb.velocity = new Vector2(15, rb.velocity.y);
        } else {
            rb.velocity = Vector2.zero;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "obstacle") {
            gameController.StopGame();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "collectable") {
            rb.AddForce(new Vector2(0, 1400));
            if (rb.velocity.y < 0) {
                rb.AddForce(new Vector2(0, -43 * rb.velocity.y));
            }
        }

        if (other.tag == "Finish") {
            gameController.WinGame();
        }
    }
}
