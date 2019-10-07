using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleBlaster : MonoBehaviour
{
    public float acceleration;
    public GameObject bulletPrefab;

    Rigidbody2D rb; 
    bool canShoot = true;
    int life = 3;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float maxX = GameObject.Find("GameController").GetComponent<BubbleBlasterGameController>().maxX;
        float maxY = GameObject.Find("GameController").GetComponent<BubbleBlasterGameController>().maxY;
        if (transform.position.x > maxX) {
            transform.position = new Vector2(-maxX, transform.position.y);
        }
        if (transform.position.x < -maxX) {
            transform.position = new Vector2(maxX, transform.position.y);
        }
        if (transform.position.y > maxY) {
            transform.position = new Vector2(transform.position.x, -maxY);
        }
        if (transform.position.y < -maxY) {
            transform.position = new Vector2(transform.position.x, maxY);
        }

        if (Input.GetKey(KeyCode.Space)) {
            if (canShoot) {
                Shoot();
            }
        }
        if (Input.GetKeyDown(KeyCode.Space)) {
            Shoot();
        }
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        rb.AddForce(transform.right * vertical * acceleration * Time.deltaTime);

        transform.Rotate(0, 0, -horizontal * 3, Space.Self);
    }

    void Shoot() {
        canShoot = false;
        Debug.Log("shoot!");
        GameObject bullet = Instantiate(bulletPrefab);
        bullet.transform.position = transform.position;
        bullet.transform.rotation = transform.rotation;
        bullet.GetComponent<Rigidbody2D>().velocity = transform.right * 10;
        Destroy(bullet, 5);
        Invoke("EnableShooting", 0.15f);
    }

    void EnableShooting() {
        canShoot = true;
    }

    bool invulnerable = false;
    void Hit() {
        invulnerable = true;
        GetComponent<SpriteRenderer>().color = Color.red;
        life--;
        Invoke("FlashWhite", 0.1f);
    }

    void FlashWhite() {
        GetComponent<SpriteRenderer>().color = Color.white;
        invulnerable = false;
        if (life <= 0) {
            GameObject.Find("GameController").GetComponent<BubbleBlasterGameController>().GameOver();
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (invulnerable) { return; }
        if (col.gameObject.tag == "obstacle")  {
            Hit();
        }
    }
}
