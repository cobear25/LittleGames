using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwarmGroundController : MonoBehaviour
{
    public SwarmGameController gameController;

    void Update()
    {
        transform.Translate(-0.6f, 0, 0, Space.World);
        if (transform.position.x < -80) {
            Destroy(gameObject, 0.5f);
        }
    }

    void OnBecameInvisible()
    {
        gameController.AddGround(transform.position.y); 
    }
}
