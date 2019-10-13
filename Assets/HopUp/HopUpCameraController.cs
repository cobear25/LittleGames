using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HopUpCameraController : MonoBehaviour
{
    public Transform player;
    void FixedUpdate()
    {
        Vector3 newPos = new Vector3(player.position.x, player.position.y, transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, newPos, 15 * Time.deltaTime);
    }
}
