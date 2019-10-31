using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float lookSpeed = 100;
    public Transform player;
    public GameObject cubePrefab;

    public bool shouldShoot = true;

    float verticalRotation = 0;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * lookSpeed * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * lookSpeed * Time.deltaTime;
        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -90, 90);
        player.Rotate(Vector3.up * mouseX);
        transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);

        if (Input.GetKeyDown(KeyCode.Mouse0) && shouldShoot) {
            Shoot();
        }
    }

    void Shoot() {
        GameObject cube = Instantiate(cubePrefab, transform.position + transform.forward, Quaternion.identity);
        BoxGunnerBox box = cube.GetComponent<BoxGunnerBox>();
        box.GetComponent<MeshRenderer>().material.color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), 1);
        box.direction = transform.forward;
    }
}
