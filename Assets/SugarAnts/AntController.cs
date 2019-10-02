using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntController : MonoBehaviour
{
    public float speed;

    private bool isStuck = false;
    // Start is called before the first frame updatej
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject target = GameObject.Find("Candy");
        Vector3 pos = target.transform.position;
        if (Vector3.Distance(pos, transform.position) < 25 && !isStuck) {
            transform.position = Vector3.MoveTowards(transform.position,
                                                    new Vector3(pos.x, transform.position.y, pos.z), speed * Time.deltaTime);

            Vector3 targetDir = new Vector3(pos.x, transform.position.y, pos.z) - transform.position;

            // The step size is equal to speed times frame time.
            float step = 4 * Time.deltaTime;

            Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0f);
            Debug.DrawRay(transform.position, newDir, Color.red);

            // Move our position a step closer to the target.
            transform.rotation = Quaternion.LookRotation(newDir);
        }
    }

    public void Stuck() {
        isStuck = true; 
        GetComponent<Rigidbody>().detectCollisions = false;
    }
}
