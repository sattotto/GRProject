using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rightGrabberColliderTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    void OnTriggerEnter(Collider other) {
        
        if (other.gameObject.tag == "item0")
        {
            Debug.Log("in " + other.gameObject.tag);
            GrabController.itemGrabFlg = true;
        }
        
    }

    void OnTriggerStay(Collider other)
    {
        Debug.Log("Right Hand stay " + other.gameObject.tag);
        if (other.gameObject.tag == "targetObj-1")
        {
            GrabController.objItemGrabFlg = true;
            GrabController.objectName = other.gameObject.name;
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.gameObject.tag == "targetObj-1")
        {
            GrabController.objItemGrabFlg = false;
        }
    }

    // Update is called once per frame
    void Update () {

	}
}
