using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewObject : MonoBehaviour {

	private int now;
	private int starttime;
	private bool flg = false;

	void OnTriggerEnter(Collider other) {
		starttime = (int)Time.time;
		flg = false;
	}

	void OnTriggerStay(Collider other) {
		now = (int)Time.time;
		if (!flg && (now-starttime) > 3 && other.gameObject.tag != "hand") {
			flg = true;
			GameManager.writeText(NarrativeController.viewObjectNarrative(GrabController.grabingObjectName));
		}
	}
}
