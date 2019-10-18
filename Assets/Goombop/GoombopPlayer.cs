using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoombopPlayer : PlatformPlayer
{
    public GoombopGamecontroller gameController;

    bool movingRight = true;
    float bulletSpeed = 1600;
    bool canHop = true;

    // Start is called before the first frame update
    void Start()
    {
       base.Initialize(); 
    }

    public override void Update()
    {
        base.Update();
        if (rb.velocity.x > 0) {
            movingRight = true;
        } else if (rb.velocity.x < 0) {
            movingRight = false;
        }
        if (transform.position.y < -10) {
            gameController.GameOver();
            Destroy(gameObject);
        }
    }

    List<GameObject> boppedEnemies = new List<GameObject>{};
    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        Debug.Log(collisionInfo.gameObject.tag);
        if (collisionInfo.gameObject.tag == "obstacle" && !boppedEnemies.Contains(collisionInfo.gameObject) && canHop) {
            boppedEnemies.Add(collisionInfo.gameObject);
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(new Vector2(0, 1600));
            collisionInfo.gameObject.GetComponentInChildren<Animator>().Play("GoombaSquish");
            Destroy(collisionInfo.gameObject, 0.6f);
            gameController.EnemyBopped();
            canHop = false;
            Invoke("EnableHop", 0.5f);
        } else if (collisionInfo.gameObject.tag != "obstacle") {
            Destroy(gameObject);
            gameController.GameOver();
        }
    }

    void EnableHop() {
        canHop = true;
    }
}
