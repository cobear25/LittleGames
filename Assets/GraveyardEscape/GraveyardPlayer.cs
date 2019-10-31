using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraveyardPlayer : MonoBehaviour
{
    public GraveyardGameController gameController;

    public float speed = 10;
    Rigidbody rb;

    int life = 3;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (gameController.isGameOver) return;
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        rb.MovePosition(transform.position + move * speed * Time.deltaTime);
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (gameController.isGameOver) return;
        if (other.tag == "obstacle") {
            life--;
            gameController.livesText.text = $"Lives: {life}";
            if (life <= 0) {
                Cursor.lockState = CursorLockMode.None;
                gameController.GameOver();
            }
        }
        if (other.tag == "collectable") {
            gameController.PlayAgain();
        }
    }
}
