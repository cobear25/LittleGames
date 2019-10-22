using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HocusPocusPlayer : MonoBehaviour
{
    public HocusPocusGameController gameController;

    public float delay = 0.0f;

    float speed = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        StartCoroutine(Move(horizontal, delay));

        if (gameController.isGameOver) {
            Destroy(gameObject);
        }
    }

    IEnumerator Move(float horizontal, float delayTime) {
        yield return new WaitForSeconds(delayTime);
        transform.Translate(Vector2.right * horizontal * speed, Space.World);
        if (horizontal > 0) {
            Quaternion targetRotation = new Quaternion(0, 0, -0.1f, transform.rotation.w);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 100 * Time.deltaTime);
        } else if (horizontal < 0) {
            Quaternion targetRotation = new Quaternion(0, 0, 0.1f, transform.rotation.w);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 100 * Time.deltaTime);
        } else {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.identity, 100 * Time.deltaTime);
        }
    }

    void Hit() {
        GetComponent<SpriteRenderer>().color = Color.red;
        Invoke("EndFlash", 0.2f);
    }

    void EndFlash() {
        GetComponent<SpriteRenderer>().color = Color.white;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Hit();
        gameController.PlayerHit();
    }

    void OnBecameInvisible()
    {
        Hit();
        gameController.PlayerHit();
    }
}
