using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TyppoEnemy : MonoBehaviour
{
    public float speed;

    bool isDead = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position,
                            new Vector2(transform.position.x, -100), 
                            speed * Time.deltaTime);
    }

    public void Explode() {
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<CircleCollider2D>().enabled = false;
        GetComponentInChildren<ParticleSystem>().Play();
        Destroy(gameObject, 0.5f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (isDead) { return; }
        if (other.gameObject.name == "wall") {
            isDead = true;
            Explode();
            GameObject.Find("GameController").GetComponent<TyppoGameController>().WallHit();
        } 
    }
}
