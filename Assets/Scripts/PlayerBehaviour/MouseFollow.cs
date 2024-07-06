using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFollow : MonoBehaviour
{

    Camera cam;
    Collider planeCollider;
    RaycastHit hit;
    Ray ray;

    void Start()
    {
        cam = GameObject.Find("FollowCamera").GetComponent<Camera>();
        planeCollider = GameObject.Find("Ground").GetComponent<Collider>();
    }

    void FixedUpdate()
    {
        //Ray going from the camera through the mouse cursor
        ray = cam.ScreenPointToRay(Input.mousePosition);

        //Checks if the ray has intersected the plane
        //Updates the position of the game object this script is attached to, to match the point of intersection
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider == planeCollider)
            {
                //When the right mouse button is held down
                if (Input.GetMouseButton(1))
                {
                    transform.position = Vector3.MoveTowards(transform.position, hit.point, Time.deltaTime * 5);
                }
                
                transform.LookAt(new Vector3(hit.point.x, transform.position.y, hit.point.z));
            }
        }
    }
}
