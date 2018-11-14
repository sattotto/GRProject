using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabberTrigerController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "item0")
        {
            Debug.Log("in " + other.gameObject.tag);
            GrabController.itemGrabFlg = true;
        }
        if (other.gameObject.tag == "targetObj-1") {
            GrabController.objItemGrabFlg = true;
        }
    }

    void OnTriggerStay(Collider other)
    {
        Debug.Log("Hand stay " + other.gameObject.tag);
        if (other.gameObject.tag == "targetObj-1")
        {
            GrabController.objectName = other.gameObject.name;
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.gameObject.tag == "targetObj-1")
        {
            GrabController.objItemGrabFlg = false;
        }
		if (other.gameObject.tag == "item0" && (OVRInput.GetDown(OVRInput.RawButton.RHandTrigger) || OVRInput.GetDown(OVRInput.RawButton.LHandTrigger))) {
            GrabController.itemGrabFlg = false;
        }
    }

    // Update is called once per frame
    void Update () {
		if (OVRInput.GetDown(OVRInput.RawButton.RHandTrigger) && OVRInput.GetDown(OVRInput.RawButton.LHandTrigger)) { GrabController.objItemGrabFlg = false; } else {  }
	}
}
