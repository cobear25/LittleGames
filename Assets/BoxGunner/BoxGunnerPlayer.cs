using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoxGunnerPlayer : MonoBehaviour
{
    public float speed = 10;
    public float jumpForce = 10;

    bool grounded = true;

    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        rb.MovePosition(transform.position + move * speed * Time.deltaTime);

        if (grounded && Input.GetKeyDown(KeyCode.Space)) {
            GetComponent<Rigidbody>().AddForce(new Vector3(0, jumpForce, 0));
        }

        if (Input.GetKeyDown(KeyCode.Q)) {
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene("MenuScene");
        }

        if (Input.GetKeyDown(KeyCode.R)) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ground") {
            grounded = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "ground") {
            grounded = false;
        }
    }
}
