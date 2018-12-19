using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyCollider : MonoBehaviour {

	private GrabController myGrabController;

	void Start() {
		myGrabController = GameObject.Find("GameManager").GetComponent<GrabController>();
	}
	void OnTriggerEnter(Collider other) {
		if (myGrabController.rightHandObjectGrabing() && myGrabController.rightHandObject == other.gameObject) {
			myGrabController.myTextWriter.writeText(GameObject.Find("GameManager").GetComponent<NarrativeController>().getObjectNarrative(other.gameObject.name));
			int count = PlayerPrefs.GetInt("get",0) + 1;
			PlayerPrefs.SetInt("get",count);
			GameObject.Find("GameManager").GetComponent<GameManager>().gameEnd("get");
			myGrabController.rightHandObject = null;
			Destroy(other.gameObject); // myGrabController.rightHandObject
		}
		if (myGrabController.leftHandObjectGrabing() && myGrabController.leftHandObject == other.gameObject) { 
			myGrabController.myTextWriter.writeText(GameObject.Find("GameManager").GetComponent<NarrativeController>().getObjectNarrative(other.gameObject.name));
			int count = PlayerPrefs.GetInt("get",0) + 1;
			PlayerPrefs.SetInt("get",count);
			GameObject.Find("GameManager").GetComponent<GameManager>().gameEnd("get");
			myGrabController.leftHandObject = null;
			Destroy(other.gameObject); // myGrabController.leftHandObject ??
		}
	}
}
