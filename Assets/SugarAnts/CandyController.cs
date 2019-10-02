using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyController : MonoBehaviour
{
    public SugarAntsGameController gameController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float planeY = transform.position.y;

        Plane plane = new Plane(Vector3.up, Vector3.up * planeY); // ground plane

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        float distance; // the distance from the ray origin to the ray intersection of the plane
        if (Input.GetMouseButton(0)) {
            if (plane.Raycast(ray, out distance))
            {
                Vector3 cursorPoint = ray.GetPoint(distance);
                // if (cursorPoint.x < gameController.maxX - 0.5f &&
                //     cursorPoint.x > -gameController.maxX + 0.5f &&
                //     cursorPoint.z < gameController.maxZ - 0.5f &&
                //     cursorPoint.z > -gameController.maxZ + 0.5f)
                // {

                    transform.position = Vector3.MoveTowards(transform.position, ray.GetPoint(distance), 40 * Time.deltaTime); // distance along the ray
                // }
            }
        }
    }
}
