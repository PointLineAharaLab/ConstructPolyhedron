using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Edge : MonoBehaviour
{
    public GameObject Vertex1, Vertex2;
    Vertex Ver1, Ver2;
    Vector3 scale = new Vector3(0.1f, 1f, 0.1f);
    Quaternion rotation = Quaternion.identity;
    // Start is called before the first frame update

    public float edge_length;
    void Start()
    {
        edge_length = 2f;
        Ver1 = Vertex1.GetComponent<Vertex>();
        Ver2 = Vertex2.GetComponent<Vertex>();
    }

    // Update is called once per frame
    void Update()
    {
        // エッジの場所を決める。両端が、Vertex1, Vertex2になるようにする。

        Vector3 V1 = Vertex1.transform.position;
        Vector3 V2 = Vertex2.transform.position;
        Vector3 center = (V1 + V2) * 0.5f;
        transform.position = center;
        scale.y = (V1 - V2).magnitude * 0.5f;
        transform.localScale = scale;
        rotation = Quaternion.FromToRotation(Vector3.up, V1 - V2);
        transform.rotation = rotation;

        for (int repeat=0; repeat<10; repeat++)
		{
            V1 = Vertex1.transform.position;
            V2 = Vertex2.transform.position;
            Vector3 V12 = V2 - V1;
            float dist = V12.magnitude;
            V12.Normalize();
            float difference = (dist - edge_length) * 0.1f;
            Ver1.setBuffer(difference * V12);
            Ver2.setBuffer(-difference * V12);
        }



    }
}
