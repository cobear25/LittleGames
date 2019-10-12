using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HopUpCameraController : MonoBehaviour
{
    public Transform player;
    // Update is called once per frame
    void Update()
    {
        // if (player.position.y >= transform.position.y) {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.position.x, player.position.y, transform.position.z), 20 * Time.deltaTime);
        // } else 
        // { 
        //     transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.position.x, transform.position.y, transform.position.z), 10 * Time.deltaTime);
        // }
    }
}
