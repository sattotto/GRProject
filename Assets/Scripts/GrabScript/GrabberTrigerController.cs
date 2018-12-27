using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabberTrigerController : MonoBehaviour {

    private GrabController myGrabController;

	// Use this for initialization
	void Start () {
		myGrabController = GameObject.Find("GameManager").GetComponent<GrabController>();
	}

    void OnTriggerEnter(Collider other) {
        Debug.Log(other.gameObject.name);
        myGrabController.objectName = "";
        if (other.gameObject.tag == "item0") {
            if (OVRInput.Get(OVRInput.RawAxis1D.RHandTrigger) > 0.5) {
                myGrabController.rightHandObject = other.gameObject;
            }
            if (OVRInput.Get(OVRInput.RawAxis1D.LHandTrigger) > 0.5) {
                myGrabController.leftHandObject = other.gameObject;
            }
        }
        if (other.gameObject.tag == "targetObj-1") {
            myGrabController.objectName = other.gameObject.name;
        }

    }

    void OnTriggerStay(Collider other) {
        if (other.gameObject.tag != "Untagged" || other.gameObject.tag != "Player") {
            if (OVRInput.Get(OVRInput.RawAxis1D.RHandTrigger) > 0.2 && myGrabController.rightHandObject == null) {
                myGrabController.rightHandObject = other.gameObject;
            }
            if (OVRInput.Get(OVRInput.RawAxis1D.LHandTrigger) > 0.2 && myGrabController.leftHandObject == null) {
                myGrabController.leftHandObject = other.gameObject;
            }
        }
    }

    void OnTriggerExit(Collider other) {
		if (other.gameObject.tag == "targetObj-1") {
            myGrabController.objectName = "";
        }
    }
}
