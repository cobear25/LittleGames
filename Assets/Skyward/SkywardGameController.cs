using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkywardGameController : GameController
{
    public GameObject debris1Prefab;
    public GameObject debris2Prefab;
    // Start is called before the first frame update
    void Start()
    {
        base.Initialize();
        for (int i = 0; i < 300; i++)
        {
            GameObject deb;
            if (Random.Range(0, 2) == 0) {
                deb = Instantiate(debris1Prefab);
            } else {
                deb = Instantiate(debris2Prefab);
            }
            float randScale = Random.Range(0.2f, 0.7f);
            float randRot = Random.Range(0.0f, 360.0f);
            Vector2 randPos = new Vector2(Random.Range(-150f, 150f), Random.Range(-150f, 150f));
            deb.transform.localScale = new Vector2(randScale, randScale);
            deb.transform.position = randPos;
            deb.transform.rotation = new Quaternion(0, 0, randRot, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
