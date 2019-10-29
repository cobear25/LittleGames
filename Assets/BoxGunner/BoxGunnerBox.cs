using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxGunnerBox : MonoBehaviour
{
    public Vector3 direction;
    bool growing = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (growing) {
        transform.Translate(direction * 30 * Time.deltaTime); 
            transform.localScale *= 1.08f;
        }
    }

    void OnCollisionEnter(Collision col)
    {
        growing = false;
        GetComponent<Rigidbody>().isKinematic = true;
    }
}
