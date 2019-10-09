using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakaroundBrick : MonoBehaviour
{
    public BreakaroundGameController gameController;
    float rotation;
    bool isHit = false;
    // Start is called before the first frame update
    void Start()
    {
       rotation = Random.Range(-2.0f, 2.0f); 
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, rotation, Space.Self);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player") {
            Break();
        } 
    }

    void Break() {
        if (isHit) return;
        isHit = true;
        gameController.BrickHit();
        Destroy(gameObject, 0.05f);
    }
}
