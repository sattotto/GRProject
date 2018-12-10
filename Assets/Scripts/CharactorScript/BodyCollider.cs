using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyCollider : MonoBehaviour {

	private TextWriter myTextWriter;

	void Start() {
		myTextWriter = new TextWriter();
		
	}
	void OnTriggerEnter(Collider other) {
		if (GrabController.grabingObjectFlg && (other.gameObject.tag == "grabObj" || other.gameObject.tag == "drink" || other.gameObject.tag == "eat")) {
			myTextWriter.writeText(GameObject.Find("GameManager").GetComponent<NarrativeController>().getObjectNarrative(GrabController.grabingObjectName));
			Destroy(other.gameObject);
			int count = PlayerPrefs.GetInt(GrabController.grabingObjectName+"_get",0);
			PlayerPrefs.SetInt(GrabController.grabingObjectName+"_get",count);
			GrabController.grabingObjectFlg = false;
            GrabController.grabingObjectName = "";
			
		}
	}
}
