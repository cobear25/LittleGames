using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkywardPlayer : MonoBehaviour
{
    public Text velocityText;
    public FlyAroundGameController gameController;
    public GameObject ropePrefab;

    SkywardRope rope;

    float maxSpeed = 30f;
    float speed = 10f;

    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        speed += vertical * 0.4f;
        if (speed > maxSpeed) speed = maxSpeed;
        if (speed < -maxSpeed) speed = -maxSpeed;
        // transform.Rotate(0, 0, -horizontal * 4, Space.Self);
        // transform.Translate(Vector2.right * speed, Space.Self);


        // strafe right and left with q and e
        if (Input.GetKey(KeyCode.Q)) {
            transform.Translate(Vector2.up * 0.1f, Space.Self);
        }
        if (Input.GetKey(KeyCode.E)) {
            transform.Translate(Vector2.down * 0.1f, Space.Self);
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
            Shoot();
        }
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        // transform.Rotate(0, 0, -horizontal * 4, Space.Self);
        rb.MoveRotation(rb.rotation - horizontal * 4);
        rb.velocity = transform.right * speed;
        velocityText.text = $"Forward Velocity: {speed.ToString("0.00")}";
    }

    List<GameObject> collectables = new List<GameObject>{};
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "collectable" && !collectables.Contains(other.gameObject)) {
            collectables.Add(other.gameObject);
            Destroy(other.gameObject);
            gameController.CollectableCollected();
        }
    }

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        // if (collisionInfo.gameObject.tag == "obstacle") {
        //     gameController.GameOver();
        //     Destroy(gameObject);
        // }
    }

    void Shoot() {
        if (rope != null) {
            Destroy(rope.gameObject);
        } else {
            rope = Instantiate(ropePrefab, transform.position, Quaternion.identity).GetComponent<SkywardRope>();
            rope.playerTransform = transform;
            // rope.startPiece.GetComponent<HingeJoint2D>().connectedBody = GetComponent<Rigidbody2D>();
            // rope.startPiece.GetComponent<FixedJoint2D>().connectedBody = GetComponent<Rigidbody2D>();
            // rope.startPiece.GetComponent<DistanceJoint2D>().connectedBody = GetComponent<Rigidbody2D>();
            Invoke("AttachRope", 0.01f);
        }
    }

    void AttachRope() {
        rope.transform.rotation = transform.rotation;
        HingeJoint2D newRelativeJoint = rope.startPiece.AddComponent<HingeJoint2D>();
        DistanceJoint2D newDistanceJoint2D = rope.startPiece.AddComponent<DistanceJoint2D>();
        newRelativeJoint.autoConfigureConnectedAnchor = false;
        newRelativeJoint.connectedAnchor = Vector2.zero;
        newDistanceJoint2D.maxDistanceOnly = true;
        newRelativeJoint.connectedBody = GetComponent<Rigidbody2D>();
        newDistanceJoint2D.connectedBody = GetComponent<Rigidbody2D>();
        rope.endPiece.GetComponent<Rigidbody2D>().AddForce(transform.right * (150000 + (speed * 10000)));
        Invoke("StopRopeVelocity", 0.2f);
    }

    void StopRopeVelocity() {
        // rope.endPiece.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }
}
