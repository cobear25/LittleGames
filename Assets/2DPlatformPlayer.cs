using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformPlayer : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed = 5;
    public float jumpForce = 15;
    public bool jumping = false;
    public bool canJump = true;
    // Start is called before the first frame update
    void Start()
    {
        Initialize();
    }   

    public void Initialize() {
        rb = GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    public virtual void Update()
    {
        float h = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(h * moveSpeed * 100 * Time.deltaTime, rb.velocity.y);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumping = true;
            if (canJump)
            {
                rb.AddForce(new Vector2(0f, jumpForce * 100));
            }
        }
        if (Input.GetKeyUp(KeyCode.Space)) {
            jumping = false;
        }
        if (jumping && rb.velocity.y > 0.5f)
        {
            rb.AddForce(new Vector2(0, jumpForce * 2));
        }
    }

    void LateUpdate()
    {
        if (rb.velocity.y == 0) {
            canJump = true;
        }
    }

    public void Landed() {
        canJump = true;
    }

    public void LeftGround() {
        canJump = false;
    }
}
