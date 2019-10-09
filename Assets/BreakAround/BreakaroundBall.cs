using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakaroundBall : MonoBehaviour
{
    public BreakaroundGameController gameController;

    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(16, 0);    
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnBecameInvisible()
    {
        gameController.GameOver();
    }
}
