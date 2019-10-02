using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPaper : MonoBehaviour
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
        if (col.gameObject.tag == "ant") {
            col.gameObject.GetComponent<AntController>().Stuck();
            FixedJoint joint = gameObject.AddComponent<FixedJoint>();
            // sets joint position to point of contact
            joint.anchor = col.contacts[0].point;
            // conects the joint to the other object
            joint.connectedBody = col.contacts[0].otherCollider.transform.GetComponentInParent<Rigidbody>();
            // Stops objects from continuing to collide and creating more joints
            joint.enableCollision = false;
        } 
    }
}
