using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyAroundPlayer : MonoBehaviour
{
    public FlyAroundGameController gameController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float maxX = GameObject.Find("GameController").GetComponent<FlyAroundGameController>().maxX;
        float maxY = GameObject.Find("GameController").GetComponent<FlyAroundGameController>().maxY;
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
