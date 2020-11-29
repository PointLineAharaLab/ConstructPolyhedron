using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightHandRayHit : MonoBehaviour
{
    Ray ray;
    public GameObject RightHandAnchor;
    Collider col;
    public GameObject RHGObject;
    public Vector3 RHGPosition;
    public Vector3 RHGHitPosition;
    public float RHGDistance;
    public bool RHGon;
    // Start is called before the first frame update
    void Start()
    {
        ray = new Ray();
        RHGon = false;
        RHGPosition = Vector3.zero;
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
            if (!hitInfo.collider.name.Contains("Ground"))
            {
                Debug.Log(hitInfo.collider.name);
                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
                {
                    //Debug.Log("A");
                    RHGon = true;
                    RHGObject = hitInfo.collider.gameObject;
                    RHGPosition = RHGObject.transform.position;
                    RHGHitPosition = hitInfo.point;
                    RHGDistance = (ray.origin - RHGHitPosition).magnitude;
                }
            }
        }
		if (RHGon)
		{
            if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger) || OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger))
			{
                RHGObject.transform.position = ray.origin + RHGDistance * ray.direction + (RHGPosition - RHGHitPosition);//ヒットしている位置
            }
            else
			{
                RHGon = false;
                RHGPosition = Vector3.zero;
                transform.position = Vector3.down;
            }
        }
        if(!hitYN && !RHGon)// ヒットしていないし、グラブもしていない。
		{
			if (OVRInput.GetDown(OVRInput.Button.One))
			{
                AddVertex(ray.origin + ray.direction);
			}
		}
    }

    public void AddVertex(Vector3 position)
	{
        GameObject prefab = Resources.Load<GameObject>("Prefabs/Vertex");
        GameObject vertexObject = Instantiate(prefab,position, Quaternion.identity);


	}
}
