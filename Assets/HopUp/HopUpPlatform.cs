using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HopUpPlatform : MonoBehaviour
{
    void Update()
    {
        if (transform.position.y < -30) {
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player") {
            GetComponent<Rigidbody2D>().gravityScale = 0.5f;
        }
    }
}
