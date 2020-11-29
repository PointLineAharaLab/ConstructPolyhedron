using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vertex : MonoBehaviour
{
    public Color color;

    float scale = 0.25f; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setBuffer(Vector3 v)
	{
        Vector3 position = transform.position;
        position += v;
        transform.position = position;
	}
}
