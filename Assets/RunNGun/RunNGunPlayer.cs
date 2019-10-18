using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunNGunPlayer : PlatformPlayer
{
    public RunNGunGameController gameController;
    public GameObject bulletPrefab;

    bool movingRight = true;
    float bulletSpeed = 1600;

    // Start is called before the first frame update
    void Start()
    {
       base.Initialize(); 
       Shoot();
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

    void Shoot() {
        float dx = bulletSpeed * Time.deltaTime;
        if (!movingRight) {
            dx *= -1;
        }
        var bullet = Instantiate(bulletPrefab);
        bullet.transform.position = transform.position;
        bullet.transform.localScale = new Vector3(0.7f, 0.4f, 0.7f);
        bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(dx, 0);
        Destroy(bullet, 0.7f);
        Invoke("Shoot", 0.2f);
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

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if (collisionInfo.gameObject.tag == "obstacle") {
            gameController.GameOver();
            Destroy(gameObject);
        }
    }
}
