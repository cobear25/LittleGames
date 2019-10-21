using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedVsBlueFloorTile : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision col)
    {
        // int a = (int)transform.position.x;
        // int b = Mathf.RoundToInt(col.transform.position.x);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") {
            Material newMaterial = other.transform.parent.gameObject.GetComponent<RedvsBluePlayer>().material;
            GetComponent<MeshRenderer>().material = newMaterial;
        }
    }
}
