using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TyppoKey : MonoBehaviour
{
    public KeyCode keyCode;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Flash() {
        GetComponent<SpriteRenderer>().color = Color.red;
        Invoke("FlashBack", 0.1f);

        foreach(TyppoEnemy enemy in GameObject.FindObjectsOfType<TyppoEnemy>()) {
            Vector3 enemyPoint = new Vector3(enemy.transform.position.x, enemy.transform.position.y, transform.position.z);
            if (GetComponent<SpriteRenderer>().bounds.Contains(enemyPoint)) {
                enemy.Explode();
                GameObject.Find("GameController").GetComponent<TyppoGameController>().EnemyDestroyed();
            }
        }
    }

    void FlashBack() {
        GetComponent<SpriteRenderer>().color = Color.white;
    }
}
