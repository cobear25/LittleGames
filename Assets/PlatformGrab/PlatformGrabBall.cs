using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGrabBall : MonoBehaviour
{
    public PlatformGrabGameController gameController;
    Rigidbody2D rb;
    GameObject lastTouchedPlat;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameController.isGameOver && rb.velocity.x < 12.0f) {
            rb.AddForce(new Vector2(200 * Time.deltaTime, 0));
        }
    }

    void OnCollisionEnter2D(Collision2D  col)
    {
        if (col.gameObject.tag == "obstacle") {
            gameController.GameOver();
            Destroy(gameObject);
        }
        if (col.gameObject != lastTouchedPlat) {
            gameController.Score();
        }
        lastTouchedPlat = col.gameObject; 
    }
}
