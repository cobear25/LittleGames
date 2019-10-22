using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HopUpFoot : MonoBehaviour
{
    public PlatformPlayer player;
    // 0 is bottom, 1 is left, 2 is right
    public int side = 0;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "obstacle") {
            player.Landed(side);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "obstacle") {
            player.LeftGround(side);
        }
    }
}
