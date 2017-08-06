using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDirector : MonoBehaviour {

	private int score = 0;


	void Start () {
		gameObject.GetComponent<Text> ().enabled = false; 
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
