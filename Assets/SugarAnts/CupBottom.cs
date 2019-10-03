using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupBottom : MonoBehaviour
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
            Debug.Log("col tag: " + col.gameObject.tag);
            Debug.Log("other tag: " + col.collider.gameObject.tag);
            GameObject.Find("SugarAntGameController").GetComponent<SugarAntsGameController>().AntCaptured();
            col.gameObject.GetComponent<AntController>().InCup();
        }
    }
}
