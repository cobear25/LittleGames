using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HopUpPlayer : PlatformPlayer
{
    public HopUpGameController gameController;
    // Start is called before the first frame update
    void Start()
    {
        base.Initialize();
    }

    List<GameObject> collectables = new List<GameObject>{};
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "collectable" && !collectables.Contains(other.gameObject)) {
            collectables.Add(other.gameObject);
            Destroy(other.gameObject);
            gameController.CollectableCollected();
        }
    }

    void OnBecameInvisible()
    {
        gameController.GameOver();
        rb.gravityScale = 0;
    }
}
