using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThwompPlayer : MonoBehaviour
{
    public ThwompGameController gameController;

    float tumblingDuration = 0.3f;
    bool isTumbling = false;
 
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
    }

    void Update()
    {
        var dir = Vector3.zero;
 
        if ((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) && transform.position.x >= -1.5f)
            dir = Vector3.left;
 
        if ((Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) && transform.position.x <= 1.5f)
            dir = Vector3.right;
 
        if (dir != Vector3.zero && !isTumbling)
        {
            StartCoroutine(Tumble(dir));
        }
    }

    IEnumerator Tumble(Vector3 direction)
    {
        isTumbling = true;
 
        var rotAxis = Vector3.Cross(Vector3.up, direction);
        var pivot = (transform.position + Vector3.down * 0.5f) + direction * 0.5f;
 
        var startRotation = transform.rotation;
        var endRotation = Quaternion.AngleAxis(90.0f, rotAxis) * startRotation;
 
        var startPosition = transform.position;
        var endPosition = transform.position + direction;
 
        float rotSpeed = 90.0f / tumblingDuration;
        float t = 0.0f;
 
        while (t < tumblingDuration)
        {
            t += Time.deltaTime;
            if( t < tumblingDuration)
            {
                transform.RotateAround(pivot, rotAxis, rotSpeed * Time.deltaTime);
                yield return null;
            }
            else
            {
                transform.rotation = endRotation;
                transform.position = endPosition;
            }
        }
 
        isTumbling = false;
    }
    
    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.gameObject.tag == "obstacle") {
            gameObject.AddComponent<MeshExplosion>();
            StartCoroutine(gameObject.GetComponent<MeshExplosion>().SplitMesh(true));
            Invoke("Die", 0.5f);
        }
    }

    void Die() {
        gameController.GameOver();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "collectable") {
            gameController.CollectableCollected();
            Destroy(other.gameObject);
        }
    }
}

