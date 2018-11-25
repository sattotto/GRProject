using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyCollider : MonoBehaviour {

	void OnTriggerEnter(Collider other) {
		if (GrabController.grabingObjectFlg && (other.gameObject.tag == "grabObj" || other.gameObject.tag == "drink" || other.gameObject.tag == "eat")) {
			Debug.Log(NarrativeController.getObjectNarrative(GrabController.grabingObjectName));
			GameManager.writeText(NarrativeController.getObjectNarrative(GrabController.grabingObjectName));
			Destroy(other.gameObject);
			GameManager.setMyDictionary(GrabController.grabingObjectName);
			GrabController.grabingObjectFlg = false;
            GrabController.grabingObjectName = "";
			
		}
	}
}
