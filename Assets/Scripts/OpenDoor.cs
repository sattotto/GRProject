using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour {

	private bool isNear;
	private Animator animator;
	// Use this for initialization
	void Start () {
		isNear = false;
		animator = GameObject.Find("doorObject/Door").GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButton("Jump") && isNear) {
			animator.SetBool ("isNear", !animator.GetBool ("isNear"));
		}
	}
 
	void OnTriggerEnter(Collider col) {
		if(col.tag == "Player") {
			isNear = true;
		}
	}
 
	void OnTriggerExit(Collider col) {
		animator.SetBool ("isNear", false);
	}
}
