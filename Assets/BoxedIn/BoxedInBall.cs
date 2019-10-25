using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxedInBall : MonoBehaviour
{
    public bool isBad = false;
    public BoxedInGameController gameController;
    public float speed;

    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (isBad) {
            rb.velocity = new Vector2(-speed, -speed);
        } else {
            rb.velocity = new Vector2(speed, speed);
        }
    }

    void Update()
    {
        rb.velocity = rb.velocity.normalized * speed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (isBad) return;
        if (other.tag == "collectable") {
            gameController.CollectableCollected();
            Destroy(other.gameObject);
        }   
    }

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if (isBad) return;
        if (collisionInfo.gameObject.tag == "obstacle") {
            gameController.GameOver();
            Destroy(gameObject);
        }
    }
}
