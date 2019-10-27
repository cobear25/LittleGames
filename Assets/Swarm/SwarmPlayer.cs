using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwarmPlayer : MonoBehaviour
{
    Rigidbody2D rb;
    bool jumping = false;
    float jumpForce = 25;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            StartCoroutine(Jump(Random.Range(0.0f, 0.15f)));
        }
        if (jumping && rb.velocity.y > 0.5f)
        {
            rb.AddForce(new Vector2(0, jumpForce * 2));
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            jumping = false;
        }
    }

    IEnumerator Jump(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        rb.AddForce(new Vector2(0, jumpForce * 100));
        jumping = true;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "obstacle") {
            Destroy(gameObject);
        }
    }

}
