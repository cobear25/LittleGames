using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperPlayerController : MonoBehaviour
{
    public float speed;
    public bool primary = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime); 
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        if (horizontal > 0 && transform.rotation.z > -0.3f) {
            transform.Rotate(new Vector3(0, 0, -horizontal), Space.Self);
        } else if (horizontal < 0 && transform.rotation.z < 0.3f) {
            transform.Rotate(new Vector3(0, 0, -horizontal), Space.Self);
        }
        transform.Rotate(new Vector3(vertical * 1.5f, 0, 0), Space.Self);
        transform.Rotate(new Vector3(0, -transform.rotation.z, 0), Space.Self);

        // if (transform.rotation.z > 0.3f) {
        //     transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y, 0.3f, transform.rotation.w);
        // } else if (transform.rotation.z < -0.3f) {
        //     transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y, -0.3f, transform.rotation.w);
        // }
    }

    void OnCollisionEnter(Collision collisionInfo)
    {
        GetComponent<MeshRenderer>().enabled = false;
        GetComponentInChildren<TrailRenderer>().enabled = false;
        GameObject.Find("GameController").GetComponent<PaperGameController>().AirplaneCrashed(primary);
        GetComponentInChildren<ParticleSystem>().Play();
        Destroy(gameObject, 0.5f);
    }
}
