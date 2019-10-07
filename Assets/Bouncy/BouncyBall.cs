using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncyBall : MonoBehaviour
{
    public float acceleration;
    public float maxBounceSpeed;

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        if (rb.velocity.y > maxBounceSpeed) {
            rb.velocity = new Vector2(rb.velocity.x, maxBounceSpeed - 0.01f);
        }
        transform.Translate(new Vector2(horizontal * acceleration, 0) * Time.deltaTime); 
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "obstacle") {
            GameObject.Find("GameController").GetComponent<BouncyBallGameController>().Hit();
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "obstacle") {
            GameObject.Find("GameController").GetComponent<BouncyBallGameController>().Score();
        }        
    }
}
