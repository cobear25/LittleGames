using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiveCoinsPlayer : PlatformPlayer
{
    bool movingRight = true;
    public FiveCoinsGameController gameController;
    // Start is called before the first frame update
    void Start()
    {
        base.Initialize();
    }

    // Update is called once per frame
    public override void Update()
    {
        if (gameController.isGameOver) {
            Destroy(gameObject);
        }
        base.Update();   
        if (transform.position.y < -10) {
            gameController.GameOver();
            Destroy(gameObject);
        }
        if (collectables.Count >= 5) {
            collectables.Clear();
        }
        
        if (rb.velocity.x > 0) {
            movingRight = true;
        } else if (rb.velocity.x < 0) {
            movingRight = false;
        }
        GetComponent<SpriteRenderer>().flipX = !movingRight;
    }

    List<GameObject> collectables = new List<GameObject>{};
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "collectable" && !collectables.Contains(other.gameObject)) {
            string coinNumber = other.gameObject.GetComponentInChildren<TextMesh>().text;
            if (collectables.Count == 0 && coinNumber == "1" ||
                collectables.Count == 1 && coinNumber == "2" ||
                collectables.Count == 2 && coinNumber == "3" ||
                collectables.Count == 3 && coinNumber == "4" ||
                collectables.Count == 4 && coinNumber == "5")
            {
                collectables.Add(other.gameObject);
                Destroy(other.gameObject);
                gameController.CollectableCollected();
            }
        }
    }
}
