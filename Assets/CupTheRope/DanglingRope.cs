using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanglingRope : MonoBehaviour
{
    public GameObject ropePiecePrefab;
    public Rigidbody2D ropeBase;

    bool movingRight = true;

    List<GameObject> pieces = new List<GameObject> { };
    void Start()
    {
        int lastPiece = 0;
        for (int i = 0; i <= 20; i++)
        {
            GameObject piece = Instantiate(ropePiecePrefab, new Vector2(ropeBase.transform.position.x, ropeBase.transform.position.y - (i * 0.40f)), transform.rotation, transform);
            piece.transform.parent = transform;
            pieces.Add(piece);
            if (i == 0) {
                FixedJoint2D joint = piece.AddComponent<FixedJoint2D>();
                joint.connectedBody = ropeBase;
            } else {
                HingeJoint2D joint = piece.AddComponent<HingeJoint2D>();
                joint.connectedBody = pieces[lastPiece].GetComponent<Rigidbody2D>();
                JointAngleLimits2D limits = joint.limits;
                limits.min = 0;
                limits.max = 90;
                joint.limits = limits;
                joint.useLimits = true;

                DistanceJoint2D distance = piece.AddComponent<DistanceJoint2D>();
                distance.connectedBody = pieces[lastPiece].GetComponent<Rigidbody2D>();
                distance.maxDistanceOnly = true;
                lastPiece++;

                // LineRenderer lineRenderer = piece.gameObject.AddComponent<LineRenderer>();
                // lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
                // lineRenderer.widthMultiplier = 0.1f;
                // lineRenderer.positionCount = 2;
            }
        }
        AddPiece();
        ropeBase.GetComponent<Rigidbody2D>().velocity = new Vector2(2, 0);
        Invoke("SwitchDirection", 15);
    }

    void SwitchDirection() {
        ropeBase.GetComponent<Rigidbody2D>().velocity = new Vector2(-ropeBase.GetComponent<Rigidbody2D>().velocity.x, 0);
        Invoke("SwitchDirection", 15);
    }

    void Update()
    {
        // if (movingRight && ropeBase.transform.position.x < 10) {
        //     ropeBase.AddForce(new Vector2(4, 0));
        // }
        // if (ropeBase.transform.position.x < 10) {
        //     ropeBase.GetComponent<Rigidbody2D>().AddForce(new Vector2(1.0f, 0));
        // } else {
        //     ropeBase.GetComponent<Rigidbody2D>().AddForce(new Vector2(-1.0f, 0));
        // }
        if (Input.GetMouseButton(0)) {
            Vector2 cursorPos = transform.InverseTransformPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            // Debug.Log(cursorPos);
            foreach (GameObject piece in pieces)
            {
                Vector2 piecePos = transform.InverseTransformPoint(piece.transform.position);
                if (Vector2.Distance(cursorPos, piecePos) < 0.2f) {
                    Debug.Log(Vector2.Distance(cursorPos, piecePos));
                    Destroy(piece.GetComponent<HingeJoint2D>());
                    Destroy(piece.GetComponent<DistanceJoint2D>());
                }
            }
        }
    }

    void AddPiece() {
        // add new piece
        GameObject prevPiece = pieces[0];
        GameObject newPiece = Instantiate(ropePiecePrefab, new Vector2(ropeBase.transform.position.x, ropeBase.transform.position.y), transform.rotation, transform);
        newPiece.transform.parent = transform;
        pieces.Insert(0, newPiece);

        // disconnect previous base piece
        Destroy(prevPiece.GetComponent<FixedJoint2D>());
        
        ropeBase.transform.Translate(0, 0.5f, 0);
        Invoke("AttachToNewPiece", 0.1f);

    }

    void AttachToNewPiece() {
        GameObject prevPiece = pieces[1];
        GameObject newPiece = pieces[0];
        HingeJoint2D joint = prevPiece.AddComponent<HingeJoint2D>();
        joint.connectedBody = newPiece.GetComponent<Rigidbody2D>();
        JointAngleLimits2D limits = joint.limits;
        limits.min = 0;
        limits.max = 90;
        joint.limits = limits;
        joint.useLimits = true;

        DistanceJoint2D distance = prevPiece.AddComponent<DistanceJoint2D>();
        distance.connectedBody = newPiece.GetComponent<Rigidbody2D>();
        distance.maxDistanceOnly = true;

        FixedJoint2D fixedJoint = newPiece.AddComponent<FixedJoint2D>();
        fixedJoint.connectedBody = ropeBase;

        ropeBase.transform.Translate(0, -0.5f, 0);

        Invoke("AddPiece", 0.1f);
    }
}
