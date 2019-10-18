using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsaacPlayer : PlatformPlayer
{
    bool movingRight = true;
    public IsaacGameController gameController;
    public GameObject tearPrefab;
    public Transform eyeTransform;
    // Start is called before the first frame update
    void Start()
    {
        base.Initialize();
        ShootTear();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();   
        if (gameController.isGameOver) {
            Destroy(gameObject);
        }
        if (transform.position.y < -10) {
            gameController.GameOver();
            Destroy(gameObject);
        }
        
        if (rb.velocity.x > 0) {
            movingRight = true;
        } else if (rb.velocity.x < 0) {
            movingRight = false;
        }
        if (movingRight) {
            transform.localScale = new Vector2(2, transform.localScale.y);
        } else {
            transform.localScale = new Vector2(-2, transform.localScale.y);
        }
    }

    void ShootTear()
    {
        GameObject tear = Instantiate(tearPrefab);
        tear.transform.position = eyeTransform.position;
        float baseXForce = movingRight ? 1500 : -1500;
        tear.GetComponent<Rigidbody2D>().AddForce(new Vector2(rb.velocity.x * 80 + baseXForce, 1800 + (transform.position.y * 10)));
        tear.GetComponent<IsaacTear>().player = this;

        Invoke("ShootTear", 0.5f);
    }

    public void HitEnemy() {
        gameController.EnemyDestroyed();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "ant") {
            gameController.GameOver();
            Destroy(gameObject);
        } 
    }
}
