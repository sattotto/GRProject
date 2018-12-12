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
        if (other.gameObject.tag == "item0") {
            if (OVRInput.Get(OVRInput.RawAxis1D.RHandTrigger) > 0.7) {
                myGrabController.rightHandObject = other.gameObject;
            }
            if (OVRInput.Get(OVRInput.RawAxis1D.LHandTrigger) > 0.7) {
                myGrabController.leftHandObject = other.gameObject;
            }
        }
        if (other.gameObject.tag == "targetObj-1") {
            myGrabController.objectName = other.gameObject.name;
        }
    }

    void OnTriggerStay(Collider other) {
        // 冗長？？？
        // if (other.gameObject.tag == "targetObj-1") {
        //     myGrabController.objectName = other.gameObject.name;
        // }

        // if (OVRInput.Get(OVRInput.RawAxis1D.RHandTrigger) > 0.7 || OVRInput.Get(OVRInput.RawAxis1D.LHandTrigger) > 0.7) {
        //     Debug.Log("hoge");
        //     GrabController.grabingObjectName = other.gameObject.name;
        //     GrabController.grabingObjectFlg = true;
        // }
    }

    void OnTriggerExit(Collider other) {
		if (other.gameObject.tag == "targetObj-1") {
            myGrabController.objectName = "";
        }
    }
}
