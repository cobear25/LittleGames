using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeEndPiece : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "obstacle") {
            RelativeJoint2D newRelativeJoint = gameObject.AddComponent<RelativeJoint2D>();
            DistanceJoint2D newDistanceJoint2D = gameObject.AddComponent<DistanceJoint2D>();
            newDistanceJoint2D.maxDistanceOnly = true;
            newRelativeJoint.connectedBody = col.rigidbody;
            newDistanceJoint2D.connectedBody = col.rigidbody;
            col.rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
        } 
    }
}
