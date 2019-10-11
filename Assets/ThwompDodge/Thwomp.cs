using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thwomp : MonoBehaviour
{
    public Material angryMaterial;
    public Material happyMaterial;

    bool isMad = false;

    void ChangeFace() {
        isMad = !isMad;
        if (isMad) {
            GetComponent<MeshRenderer>().material = angryMaterial;
        } else {
            GetComponent<MeshRenderer>().material = happyMaterial;
        }
    }

    void Smash() {
        GetComponent<Animator>().Play("smash");
        Invoke("ChangeFace", 1.0f); 
    }

    public void InitiateSmash() {
        ChangeFace();
        Invoke("Smash", 1.0f); 
    }
}
