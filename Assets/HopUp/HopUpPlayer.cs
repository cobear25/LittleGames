using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HopUpPlayer : MonoBehaviour
{
    public HopUpGameController gameController;
    Rigidbody2D rb;
    public float moveSpeed = 100;
    public float jumpForce = 5;
    bool jumping = false;
    public bool canJump = true;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(h * moveSpeed * 100 * Time.deltaTime, rb.velocity.y);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumping = true;
            if (canJump)
            {
                rb.AddForce(new Vector2(0f, jumpForce * 100));
            }
        }
        if (Input.GetKeyUp(KeyCode.Space)) {
            jumping = false;
        }
        if (jumping && rb.velocity.y > 0.5f)
        {
            rb.AddForce(new Vector2(0, jumpForce * 2));
        }
    }

    public void Landed() {
        canJump = true;
    }

    public void LeftGround() {
        canJump = false;
    }
    List<GameObject> collectables = new List<GameObject>{};
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "collectable" && !collectables.Contains(other.gameObject)) {
            collectables.Add(other.gameObject);
            Destroy(other.gameObject);
            gameController.CollectableCollected();
        }
    }

    void OnBecameInvisible()
    {
        gameController.GameOver();
        rb.gravityScale = 0;
    }
}
