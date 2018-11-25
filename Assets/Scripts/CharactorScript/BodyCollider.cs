using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyCollider : MonoBehaviour {

	void OnTriggerStay(Collider other) {
		if ((OVRInput.Get(OVRInput.RawAxis1D.RHandTrigger) < 0.4 || OVRInput.Get(OVRInput.RawAxis1D.LHandTrigger) < 0.4) && GrabController.grabingObjectFlg &&
		 (other.gameObject.tag == "grabObj" || other.gameObject.tag == "drink" || other.gameObject.tag == "eat")) {
			Debug.Log(NarrativeController.getObjectNarrative(GrabController.grabingObjectName));
			GameManager.writeText(NarrativeController.getObjectNarrative(GrabController.grabingObjectName));
			Destroy(other.gameObject);
			GrabController.grabingObjectFlg = false;
            GrabController.grabingObjectName = "";
		}
	}
}
