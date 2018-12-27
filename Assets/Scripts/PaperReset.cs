using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperReset : MonoBehaviour {

	private Vector3 startPos;

	// Use this for initialization
	void Start () {
		startPos = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (this.transform.position.y < 0 || Input.GetKeyDown(KeyCode.Return)) {
			this.transform.position = startPos;
		}
	}
}
