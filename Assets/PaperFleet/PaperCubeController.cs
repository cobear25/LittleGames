using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperCubeController : MonoBehaviour
{
    public GameObject airplanePrefab;

    bool canGenerate = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0.5f, 0.5f, 0.5f), Space.Self);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "airplane" && canGenerate) {
            GameObject p = Instantiate(airplanePrefab);
            float newX = Random.Range(-2.0f, 2.0f);
            float newY = Random.Range(-2.0f, 2.0f);
            float newZ = Random.Range(-1.0f, 1.0f);
            p.transform.position = new Vector3(other.transform.position.x + newX, other.transform.position.y + newY, other.transform.position.z + newZ);
            p.transform.rotation = other.transform.rotation;
            canGenerate = false;
            Invoke("EnableGenerate", 0.5f);

            GameObject.Find("GameController").GetComponent<PaperGameController>().AirplaneAdded();
        }
    }

    void EnableGenerate() {
        canGenerate = true;
    }
}
