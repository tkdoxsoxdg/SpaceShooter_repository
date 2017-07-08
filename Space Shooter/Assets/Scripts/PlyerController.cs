using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlyerController : MonoBehaviour {

    private Rigidbody rb;
    public float speed;
    public Boundary boundary;
   

    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        rb.position = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.velocity = rb.position * speed;

        rb.position = new Vector3
            (
            Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
            );

    }
    }

