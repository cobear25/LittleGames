using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsaacFly : MonoBehaviour
{
    GameObject player;
    public float speed = 5;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null) {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "bullet") {
            GameObject.Find("GameController").GetComponent<GameController>().EnemyDestroyed();
            Destroy(gameObject);
        }
    }
}
