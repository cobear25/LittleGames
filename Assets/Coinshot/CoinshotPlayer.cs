using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinshotPlayer : PlatformPlayer
{
    public CoinshotGamecontroller gamecontroller;
    public GameObject coinPrefab;
    bool facingRight = true;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
        movesInAir = false;
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // cancel space bar jump from superclass
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumping = false;
            if (canJump)
            {
                rb.AddForce(new Vector2(0f, -jumpForce * 100));
            }
            if (facingRight) {
                GameObject newCoin = Instantiate(coinPrefab, new Vector2(transform.position.x + 1, transform.position.y), Quaternion.identity);
                newCoin.GetComponent<Rigidbody2D>().AddForce(new Vector2(100, 600));
                Destroy(newCoin, 10);
            } else {
                GameObject newCoin = Instantiate(coinPrefab, new Vector2(transform.position.x - 1, transform.position.y), Quaternion.identity);
                newCoin.GetComponent<Rigidbody2D>().AddForce(new Vector2(-100, 600));
                Destroy(newCoin, 10);
            }
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            jumping = true;
            if (canJump)
            {
                rb.AddForce(new Vector2(0f, jumpForce * 100));
            }
        }

        GameObject[] coins = GameObject.FindGameObjectsWithTag("bullet");
        foreach (GameObject coin in coins)
        {
            // add line if coin doesn't have one
            if (coin.GetComponent<LineRenderer>() == null) {
                LineRenderer lineRenderer = coin.AddComponent<LineRenderer>();
                lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
                lineRenderer.widthMultiplier = 0.1f;
                lineRenderer.positionCount = 2;
                lineRenderer.startColor = Color.cyan;
                lineRenderer.endColor = Color.cyan;
            }
            coin.GetComponent<LineRenderer>().startColor = Color.cyan;
            coin.GetComponent<LineRenderer>().endColor = Color.cyan;
            coin.GetComponent<LineRenderer>().SetPositions(new Vector3[] { transform.position, coin.transform.position });
        }
        foreach (GameObject coin in coins)
        {
            // handle interacting with lines
            float cursorAngle = Mathf.Atan2(cursorPos.y - transform.position.y, cursorPos.x - transform.position.x);
            float coinAngle = Mathf.Atan2(coin.transform.position.y - transform.position.y, coin.transform.position.x - transform.position.x);
            // highlight lines if mouse is nearby
            if (Mathf.Abs(cursorAngle - coinAngle) < 0.4f) {
                coin.GetComponent<LineRenderer>().startColor = Color.blue;
                coin.GetComponent<LineRenderer>().endColor = Color.blue;
                // when mouse is down apply force
                if (Input.GetKey(KeyCode.Mouse0)) {
                    coin.GetComponent<Rigidbody2D>().AddForce(new Vector2(Mathf.Cos(coinAngle) * 150, Mathf.Sin(coinAngle) * 150));
                    if (Mathf.Abs(coin.GetComponent<Rigidbody2D>().velocity.magnitude) < 0.1f) {
                        rb.velocity += new Vector2(Mathf.Cos(coinAngle) * -2, Mathf.Sin(coinAngle) * -2);
                        // add more force if on ground
                        if (canJump) {
                            rb.velocity += new Vector2(0, Mathf.Sin(coinAngle) * -3);
                        }
                    }
                }
            }
        }
        if (rb.velocity.x > 0) facingRight = true;
        if (rb.velocity.x < 0) facingRight = false;

        GetComponent<SpriteRenderer>().flipX = !facingRight;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "ant") {
            gamecontroller.GameOver();
            Destroy(gameObject);
        } 
    }
}
