using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketPiece : MonoBehaviour
{
    public RocketLanderGameController gameController;
    bool landed = false;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (landed) return;
        if (Input.GetKey(KeyCode.Space)) {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 10));
            transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = true;
        } else {
            transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
        }   
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (landed) return;
        if (col.gameObject.tag == "ground") {
            landed = true;
            gameController.PieceLanded();
        }
    }
}
