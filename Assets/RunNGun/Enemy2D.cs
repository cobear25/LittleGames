using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2D : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "bullet") {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
