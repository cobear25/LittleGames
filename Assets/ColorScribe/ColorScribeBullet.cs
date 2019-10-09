using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorScribeBullet : MonoBehaviour
{
    public GameObject enemyToHit;

    float speed = 35;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyToHit == null) return;
        transform.position = Vector3.MoveTowards(transform.position, enemyToHit.transform.position, speed * Time.deltaTime);
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.name);
        Destroy(gameObject);
    }
}
