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

    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        rb.position = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.velocity = new Vector3(moveHorizontal, 0.0f, moveVertical) * speed;

        rb.rotation = Quaternion.Euler(new Vector3(moveHorizontal, 0.0f, moveVertical));
  
        }




    }

