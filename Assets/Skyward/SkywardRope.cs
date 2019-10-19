using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkywardRope : MonoBehaviour
{
    public Transform playerTransform;
    public GameObject startPiece;
    public GameObject endPiece;

    public GameObject ropePiecePrefab;

    int pieceCount = 100;
    bool velocityRestricted = false;
    // Start is called before the first frame update
    List<GameObject> pieces = new List<GameObject> { };
    List<LineRenderer> lines = new List<LineRenderer> {};
    void Start()
    {
        int lastPiece = 0;
        for (int i = 0; i <= pieceCount; i++)
        {
            // GameObject piece = Instantiate(ropePiecePrefab, new Vector2(transform.position.x + i * 0.1f, transform.position.y), transform.rotation, transform);
            GameObject piece = Instantiate(ropePiecePrefab, new Vector2(transform.position.x, transform.position.y), transform.rotation, transform);
            piece.transform.parent = transform;
            piece.GetComponent<Rigidbody2D>().mass = 1f;//1 - (0.01f * i);
            pieces.Add(piece);
            if (i == 0) {
                startPiece = piece;
                piece.GetComponent<Rigidbody2D>().mass = 3;
            } else {
                HingeJoint2D joint = piece.AddComponent<HingeJoint2D>();
                joint.connectedBody = pieces[lastPiece].GetComponent<Rigidbody2D>();

                DistanceJoint2D distance = piece.AddComponent<DistanceJoint2D>();
                distance.connectedBody = pieces[lastPiece].GetComponent<Rigidbody2D>();
                distance.maxDistanceOnly = true;
                lastPiece++;

                LineRenderer lineRenderer = piece.gameObject.AddComponent<LineRenderer>();
                lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
                lineRenderer.widthMultiplier = 0.1f;
                lineRenderer.positionCount = 2;
                if (i > pieceCount - 10) { 
                    lineRenderer.startColor = Color.green;
                    lineRenderer.endColor = Color.green;
                }
                lines.Add(lineRenderer);
            }
            if (i > pieceCount - 10) {
                piece.AddComponent<RopeEndPiece>();
                piece.GetComponent<Rigidbody2D>().mass = 10;
                piece.GetComponent<SpriteRenderer>().color = Color.green;
            }
            if (i == pieceCount) {
                endPiece = piece;
            }
        }
        Invoke("RestrictVelocity", 0.5f);
    }

    void RestrictVelocity() {
        velocityRestricted = true;
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject piece in pieces)
        {
            if (velocityRestricted && piece.GetComponent<Rigidbody2D>().velocity.magnitude > 10) {
                piece.GetComponent<Rigidbody2D>().velocity = piece.GetComponent<Rigidbody2D>().velocity.normalized * 10;
            } 
        }

        for (int i = 1; i < pieceCount; i++) {
            lines[i].SetPositions(new Vector3[] {pieces[i].transform.position, pieces[i - 1].transform.position});
        }
        // Vector2 relativePos = playerTransform.position - transform.position;
        // if (startPiece.GetComponent<Rigidbody2D>().velocity.magnitude < 100) {
        //     startPiece.GetComponent<Rigidbody2D>().AddForce(100 * relativePos);
        // }
    }
}
