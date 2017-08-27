using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroller : MonoBehaviour {
    public float scrollspeed;
    public float tileSizeZ;

    public Vector3 startPosition;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float newPosition = Mathf.Repeat(Time.time * scrollspeed, tileSizeZ);
        transform.position = startPosition + Vector3.forward * newPosition;
	}
}
