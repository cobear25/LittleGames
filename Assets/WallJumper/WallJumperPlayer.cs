using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallJumperPlayer : PlatformPlayer
{
    bool movingRight = true;

    bool onLeft = false;
    bool onRight = false;

    public WallJumperGameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        base.Initialize();
    }

    // Update is called once per frame
    public override void Update()
    {
        if (gameController.isGameOver) return;
        float h = Input.GetAxis("Horizontal");
        // float maxSpeed = h * moveSpeed * 100 * Time.deltaTime;
        // rb.velocity = new Vector2(maxSpeed, rb.velocity.y);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumping = true;
            if (canJump)
            {
                if (onRight) {
                    rb.AddForce(new Vector2(-1500, jumpForce * 110));
                } else if (onLeft) {
                    rb.AddForce(new Vector2(1500, jumpForce * 110));
                } else {
                    rb.AddForce(new Vector2(1000, jumpForce * 100));
                }

            }
        }
        if (Input.GetKeyUp(KeyCode.Space)) {
            jumping = false;
        }
        if (jumping && rb.velocity.y > 0.5f)
        {
            rb.AddForce(new Vector2(0, jumpForce * 2));
        }

        gameController.UpdateAltitude((int)transform.position.y);
    }

    public override void Landed(int side) {
        base.Landed(side);
        if (side == 1) onLeft = true;
        if (side == 2) onRight = true;
        rb.gravityScale = 5;
    }

    public override void LeftGround(int side) {
        base.LeftGround(side);
        onLeft = false;
        onRight = false;
        rb.gravityScale = 15;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Circle(Clone)") {
            gameController.GameOver();
            GetComponent<SpriteRenderer>().color = Color.red;
            rb.velocity = Vector2.zero;
            rb.gravityScale = 0;
        } 
    }
}
