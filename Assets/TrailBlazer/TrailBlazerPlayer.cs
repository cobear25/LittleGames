using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailBlazerPlayer : MonoBehaviour
{
    public TrailBlazerGameController gameController;
    public GameObject firePrefab;
    // Start is called before the first frame update
    void Start()
    {
        AddFire();
    }

    // Update is called once per frame
    void Update()
    {
        float maxX = gameController.maxX;
        float maxY = gameController.maxY;
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

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        transform.Rotate(0, 0, -horizontal * 4, Space.Self);
        transform.Translate(Vector2.right * 0.2f, Space.Self);
    }

    void AddFire() {
        var fire = Instantiate(firePrefab);
        fire.transform.position = transform.position;
        fire.transform.rotation = transform.rotation;
        Invoke("AddFire", 0.03f);
    }

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if (collisionInfo.gameObject.tag == "obstacle") {
            gameController.GameOver();
            Destroy(gameObject);
        }
    }
}
