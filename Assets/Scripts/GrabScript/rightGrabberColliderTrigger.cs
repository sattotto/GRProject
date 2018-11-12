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
        if (other.gameObject.tag == "targetObj-1")
        {
            Debug.Log("stay " + other.gameObject.tag);
            GrabController.objItemGrabFlg = true;
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.gameObject.tag == "item0")
        {
            GrabController.itemGrabFlg = false;
        }
        if (other.gameObject.tag == "targetObj-1")
        {
            GrabController.objItemGrabFlg = false;
        }
    }

    // Update is called once per frame
    void Update () {

	}
}
