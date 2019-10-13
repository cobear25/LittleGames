using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HopUpFoot : MonoBehaviour
{
    public PlatformPlayer player;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "obstacle") {
            player.Landed();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "obstacle") {
            player.LeftGround();
        }
    }
}
