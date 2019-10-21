using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedvsBluePlayer : MonoBehaviour
{
    public KeyCode leftKey;
    public KeyCode rightKey;
    public KeyCode upKey;
    public KeyCode downKey;
    public Material material;

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
 
        if (Input.GetKey(leftKey) && transform.position.x >= -4.5f)
            dir = Vector3.left;
 
        if (Input.GetKey(rightKey) && transform.position.x <= 4.5f)
            dir = Vector3.right;
 
        if (Input.GetKey(upKey) && transform.position.z <= 4.5f)
            dir = Vector3.forward;

        if (Input.GetKey(downKey) && transform.position.z >= -4.5f)
            dir = Vector3.back;
            
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
}

