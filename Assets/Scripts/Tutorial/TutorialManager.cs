using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour {

	public GameObject VRCharacter;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		nextStage();
	}

	private void nextStage() {
		if(VRCharacter.transform.position.y < -1) {
			SceneManager.LoadScene("Main");
		}
	}
}
