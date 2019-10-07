using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncyGround : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-0.2f, 0, 0, Space.World); 
    }

    void OnBecameInvisible()
    {
        // GameObject.Find("GameController").GetComponent<BouncyBallGameController>().AddGround();
    }
}
