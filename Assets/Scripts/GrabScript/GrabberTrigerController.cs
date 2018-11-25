using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabberTrigerController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "item0") {
            GrabController.itemGrabFlg = true;
        }
        if (other.gameObject.tag == "targetObj-1") {
            GrabController.objItemGrabFlg = true;
        }
    }

    void OnTriggerStay(Collider other) {
        if (other.gameObject.tag == "targetObj-1") {
            GrabController.objectName = other.gameObject.name;
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.gameObject.tag == "item0" && !(OVRInput.Get(OVRInput.RawAxis1D.RHandTrigger) > 0.7 || OVRInput.Get(OVRInput.RawAxis1D.LHandTrigger) > 0.7)) {
            GrabController.itemGrabFlg = false;
        }
		if (other.gameObject.tag == "targetObj-1") {
            GrabController.objItemGrabFlg = false;
        }
    }

    // Update is called once per frame
    void Update () {
		if (OVRInput.GetDown(OVRInput.RawButton.RHandTrigger) && OVRInput.GetDown(OVRInput.RawButton.LHandTrigger)) { GrabController.objItemGrabFlg = false; } else {  }
    }
}
