using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakaroundPaddle : MonoBehaviour
{
    private float angle = 0.0f;
    float radius = 16.0f;
    float paddleSpeed = 4.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        angle -= (horizontal * Time.deltaTime * paddleSpeed);
        transform.position = new Vector2(Mathf.Cos(angle) * radius, Mathf.Sin(angle) * radius);
        transform.eulerAngles = new Vector3(0, 0, angle);
    }

    void LateUpdate()
    {
        transform.eulerAngles = new Vector3(0, 0, Mathf.Rad2Deg * angle);
    }
}
