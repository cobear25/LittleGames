using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupRopeGround : MonoBehaviour
{
    public CupTheRopeGameController gameController;

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "collectable") {
            gameController.GameOver();
        } 
    }
}
