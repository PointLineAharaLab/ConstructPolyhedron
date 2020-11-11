using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightHandRayHit : MonoBehaviour
{
    Ray ray;
    public GameObject RightHandAnchor;
    Collider col;
    // Start is called before the first frame update
    void Start()
    {
        ray = new Ray();

    }

    // Update is called once per frame
    void Update()
    {
        ray.origin = RightHandAnchor.transform.position;
        ray.direction = RightHandAnchor.transform.rotation * Vector3.forward;

        bool hitYN = Physics.Raycast(ray, out RaycastHit hitInfo);

        if (hitYN)
		{
            transform.position = hitInfo.point;
            col = hitInfo.collider;
		}
        else
		{
            transform.position = Vector3.down;
		}
    }
}
