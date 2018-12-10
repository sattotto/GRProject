using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour {

	public GameObject VRCharacter;

	[SerializeField]
	private MessageScript msgScript;

	private float duration;

	// Use this for initialization
	void Start () {
		msgScript.SetMessagePanel("this is tutorial");
		duration = 0;
	}
	
	// Update is called once per frame
	void Update () {
		duration += Time.deltaTime;
		nextStage();
	}

	private void nextStage() {
		if(VRCharacter.transform.position.y < -1 || Input.GetKeyDown(KeyCode.Return) || duration > 300) {
			SceneManager.LoadScene("Main");
		}
	}
}
